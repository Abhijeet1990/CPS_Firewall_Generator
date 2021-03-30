using AB_Research_Common.CyberNetworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TamuControlCenter.Client.Classes;

namespace FirewallGenerator
{
    public partial class MainForm : Form
    {
        public OpenFileDialog ofd = new OpenFileDialog();

        public List<UtilityControlCenter> ucs = new List<UtilityControlCenter>();
        public List<Substation> subs = new List<Substation>();
        public List<BalancingAuthority> bas = new List<BalancingAuthority>();
        public IDictionary<string, FirewallConfig> firewallStorer = new Dictionary<string, FirewallConfig>();
        public static IPAddress selectedNetwork;
        public static IPAddress selectedSubnetMask;
        public MainForm()
        {
            InitializeComponent();

            configuratorTC.Visible = false;

            var configs = ConfigUtility.GetCyberConfig();

            // Collect the topology and populate the tree view
            TopologyGeneration.CreateCompleteCyberNetwork(configs);
            //TopologyGeneration.CreateCyberNetwork();
            var nodes = TopologyGeneration.nodes;

            foreach (var node in nodes)
            {
                var classType = node.GetType().ToString().Split('.')[2];
                switch (classType)
                {
                    case "UtilityControlCenter":
                        var util = (UtilityControlCenter)node;
                        ucs.Add(util);
                        break;

                    case "Substation":
                        var sub = (Substation)node;
                        subs.Add(sub);
                        break;
                }
            }

            foreach (var util in ucs)
            {
                TreeNode utilNode = new TreeNode(util.label);
                utilNode.Tag = new UtilityControlCenter
                {
                    label = util.label,
                    networkLan = util.networkLan,
                    subnetMask = util.subnetMask
                };
                var substations = util.substations;
                foreach (var sub in substations)
                {
                    var actualsub = TopologyGeneration.substationList.Single(a => a.label == sub);
                    var subName = actualsub.label.Split('.')[actualsub.label.Split('.').Count() - 1];
                    TreeNode subNode = new TreeNode(subName);
                    subNode.Tag = new Substation
                    {
                        label = subName,
                        networkLan = actualsub.networkLan,
                        OTSubnetMask = actualsub.OTSubnetMask
                    };
                    utilNode.Nodes.Add(subNode);
                }
                firewallAccessTreeView.Nodes[0].Nodes.Add(utilNode);
            }

        }

        private void firewallAccessTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            configuratorTC.Visible = true;
            if (e.Node.Level == 1) configuratorTC.SelectedTab = utilTypePage;
            else if (e.Node.Level == 2) configuratorTC.SelectedTab = subTypePage;
            else configuratorTC.SelectedTab = baTypePage;

            var nodeTag = e.Node.Tag;

            if (nodeTag is Substation)
            {
                var subTag = (Substation)e.Node.Tag;
                selectedNetwork = subTag.networkLan;
                selectedSubnetMask = subTag.OTSubnetMask;

            }
            else if (nodeTag is UtilityControlCenter)
            {
                var utilTag = (UtilityControlCenter)e.Node.Tag;
                selectedNetwork = utilTag.networkLan;
                selectedSubnetMask = utilTag.subnetMask;
            }
            else
            {
                selectedNetwork = IPAddress.Parse("127.0.0.0");
            }

            //var nodeTag = (Substation)e.Node.Tag.GetType();
            configuratorTC.SelectedTab.Text = e.Node.Text;

            

            //first clear the controls before populating them with configured ones
            subAclGB.Controls.Clear();
            utilAclGB.Controls.Clear();
            subObjectGroupGB.Controls.Clear();
            utilObjectGroupGB.Controls.Clear();
            subInterfaceGB.Controls.Clear();
            utilInterfaceGB.Controls.Clear();

            if (nodeTag is UtilityControlCenter)
            {
                var utilTag = (UtilityControlCenter)nodeTag;
                utilNodeLabel.Text = utilTag.label;

                // populate the utility firewall configurator based on stored config
                var utilkey = utilNodeLabel.Text;
                if (firewallStorer.ContainsKey(utilkey))
                {
                    populateUtilFirewallConfig(firewallStorer[utilkey]);
                }
            }
            else if (nodeTag is Substation)
            {
                var subTag = (Substation)nodeTag;
                subNodeLabel.Text = subTag.label;

                // populate the substation firewall configurator based on stored config
                var subkey = subNodeLabel.Text;
                if (firewallStorer.ContainsKey(subkey))
                {
                    populateSubFirewallConfig(firewallStorer[subkey]);
                }
            }
        }

        private void populateUtilFirewallConfig(FirewallConfig fg)
        {
            // populate interfaces
            var interfaces = fg.interfaces;
            foreach (var inter in interfaces)
            {
                Label[] lb = new Label[3];
                lb[0] = new Label();
                lb[0].Text = inter.interfaceName;
                lb[0].Location = new Point(utilInterfaceGB.Location.X + 5, 20 * interfaces.IndexOf(inter) + 15);
                lb[1] = new Label();
                lb[1].Text = inter.ipAddress;
                lb[1].Location = new Point(utilInterfaceGB.Location.X + 150, 20 * interfaces.IndexOf(inter) + 15);
                lb[2] = new Label();
                lb[2].Text = inter.subnetMask;
                lb[2].Location = new Point(utilInterfaceGB.Location.X + 300, 20 * interfaces.IndexOf(inter) + 15);
                utilInterfaceGB.Controls.AddRange(lb);
            }

            // populate object groups
            var objectGrps = fg.objectGroups;
            foreach (var objectGrp in objectGrps)
            {
                Label[] lb = new Label[3];
                lb[0] = new Label();
                lb[0].Text = objectGrp.objectName;
                lb[0].Location = new Point(utilObjectGroupGB.Location.X + 5, 20 * objectGrps.IndexOf(objectGrp) + 15);
                lb[1] = new Label();
                lb[1].Text = objectGrp.objectType;
                lb[1].Location = new Point(utilObjectGroupGB.Location.X + 150, 20 * objectGrps.IndexOf(objectGrp) + 15);

                lb[2] = new Label();
                List<string> storeObjects = new List<string>();
                if (objectGrp.objectType =="network")
                {
                    foreach (var item in objectGrp.networkObjects)
                    {
                        var hostString = "";
                        hostString += (item.type +"#" +item.ipAddress +"#"+ item.subnetAddress+"#");
                        storeObjects.Add(hostString);
                    }
                    lb[2].Text = string.Join(",", storeObjects.ToArray());
                }
                else
                {
                    foreach (var item in objectGrp.portObjects)
                    {
                        var hostString = "";
                        hostString += (item.portCount.ToString() + "#" + item.portNumber+ "#");
                        storeObjects.Add(hostString);
                    }
                    lb[2].Text = string.Join(",", storeObjects.ToArray());
                }               
                lb[2].Location = new Point(utilObjectGroupGB.Location.X + 300, 20 * objectGrps.IndexOf(objectGrp) + 15);
                utilObjectGroupGB.Controls.AddRange(lb);
            }

            // populate ACLS
            var acls = fg.acls;
            foreach (var acl in acls)
            {
                Label[] lb = new Label[4];
                lb[0] = new Label();
                lb[0].Text = acl.accessGroup;
                lb[0].Location = new Point(utilAclGB.Location.X + 5, 20 * acls.IndexOf(acl) + 15);
                lb[1] = new Label();
                lb[1].Text = acl.permit;
                lb[1].Location = new Point(utilAclGB.Location.X + 150, 20 * acls.IndexOf(acl) + 15);
                lb[2] = new Label();
                lb[2].Text = acl.protocol;
                lb[2].Location = new Point(utilAclGB.Location.X + 250, 20 * acls.IndexOf(acl) + 15);
                lb[3] = new Label();
                lb[3].Text = string.Join(",", acl.objectGroups.ToArray());
                lb[3].Location = new Point(utilAclGB.Location.X + 350, 20 * acls.IndexOf(acl) + 15);

                utilAclGB.Controls.AddRange(lb);
            }
        }

        private void populateSubFirewallConfig(FirewallConfig fg)
        {
            // populate interfaces
            var interfaces = fg.interfaces;
            foreach (var inter in interfaces)
            {
                Label[] lb = new Label[3];
                lb[0] = new Label();
                lb[0].Text = inter.interfaceName;
                lb[0].Location = new Point(subInterfaceGB.Location.X + 5, 20 * interfaces.IndexOf(inter) + 15);
                lb[1] = new Label();
                lb[1].Text = inter.ipAddress;
                lb[1].Location = new Point(subInterfaceGB.Location.X + 150, 20 * interfaces.IndexOf(inter) + 15);
                lb[2] = new Label();
                lb[2].Text = inter.subnetMask;
                lb[2].Location = new Point(subInterfaceGB.Location.X + 300, 20 * interfaces.IndexOf(inter) + 15);
                subInterfaceGB.Controls.AddRange(lb);
            }

            // populate object groups
            var objectGrps = fg.objectGroups;
            foreach (var objectGrp in objectGrps)
            {
                Label[] lb = new Label[3];
                lb[0] = new Label();
                lb[0].Text = objectGrp.objectName;
                lb[0].Location = new Point(subObjectGroupGB.Location.X + 5, 20 * objectGrps.IndexOf(objectGrp) + 15);
                lb[1] = new Label();
                lb[1].Text = objectGrp.objectType;
                lb[1].Location = new Point(subObjectGroupGB.Location.X + 150, 20 * objectGrps.IndexOf(objectGrp) + 15);

                lb[2] = new Label();
                List<string> storeObjects = new List<string>();
                if (objectGrp.objectType == "network")
                {
                    foreach (var item in objectGrp.networkObjects)
                    {
                        var hostString = "";
                        hostString += (item.type + "#" + item.ipAddress + "#" + item.subnetAddress + "#");
                        storeObjects.Add(hostString);
                    }
                    lb[2].Text = string.Join(",", storeObjects.ToArray());
                }
                else
                {
                    foreach (var item in objectGrp.portObjects)
                    {
                        var hostString = "";
                        hostString += (item.portCount.ToString() + "#" + item.portNumber + "#");
                        storeObjects.Add(hostString);
                    }
                    lb[2].Text = string.Join(",", storeObjects.ToArray());
                }
                lb[2].Location = new Point(subObjectGroupGB.Location.X + 300, 20 * objectGrps.IndexOf(objectGrp) + 15);
                subObjectGroupGB.Controls.AddRange(lb);
            }

            // populate ACLS
            var acls = fg.acls;
            foreach (var acl in acls)
            {
                Label[] lb = new Label[4];
                lb[0] = new Label();
                lb[0].Text = acl.accessGroup;
                lb[0].Location = new Point(subAclGB.Location.X + 5, 20 * acls.IndexOf(acl) + 15);
                lb[1] = new Label();
                lb[1].Text = acl.permit;
                lb[1].Location = new Point(subAclGB.Location.X + 150, 20 * acls.IndexOf(acl) + 15);
                lb[2] = new Label();
                lb[2].Text = acl.protocol;
                lb[2].Location = new Point(subAclGB.Location.X + 250, 20 * acls.IndexOf(acl) + 15);
                lb[3] = new Label();
                lb[3].Text = string.Join(",", acl.objectGroups.ToArray());
                lb[3].Location = new Point(subAclGB.Location.X + 350, 20 * acls.IndexOf(acl) + 15);

                subAclGB.Controls.AddRange(lb);
            }
        }

        private void utilAddInterfaceBtn_Click(object sender, EventArgs e)
        {
            // get the controls count in the group box
            int intAdded = utilInterfaceGB.Controls.Count;
            InterfaceAdderForm f = new InterfaceAdderForm(Convert.ToInt32(intAdded/3)+1 , selectedNetwork.ToString(),selectedSubnetMask.ToString());
            f.ShowDialog();

            Label[] lb = new Label[3];
            lb[0] = new Label();
            lb[0].Text = f.interfaceName;
            lb[0].Location = new Point(utilInterfaceGB.Location.X + 5, 20*(f.interfaceNumber-1) + 15);
            lb[1] = new Label();
            lb[1].Text = f.interfaceIp;
            lb[1].Location = new Point(utilInterfaceGB.Location.X + 150, 20*(f.interfaceNumber-1) + 15);
            lb[2] = new Label();
            lb[2].Text = f.interfaceSubnet;
            lb[2].Location = new Point(utilInterfaceGB.Location.X + 300, 20*(f.interfaceNumber-1) + 15);

            utilInterfaceGB.Controls.AddRange(lb);

        }

        private void subAddInterfaceBtn_Click(object sender, EventArgs e)
        {
            int intAdded = subInterfaceGB.Controls.Count;
            InterfaceAdderForm f = new InterfaceAdderForm(Convert.ToInt32(intAdded / 3) + 1,selectedNetwork.ToString(),selectedSubnetMask.ToString());
            //InterfaceAdderForm f = new InterfaceAdderForm();
            f.ShowDialog();

            Label[] lb = new Label[3];
            lb[0] = new Label();
            lb[0].Text = f.interfaceName;
            lb[0].Location = new Point(subInterfaceGB.Location.X + 5, 20 * (f.interfaceNumber - 1) + 15);
            lb[1] = new Label();
            lb[1].Text = f.interfaceIp;
            lb[1].Location = new Point(subInterfaceGB.Location.X + 150, 20 * (f.interfaceNumber - 1) + 15);
            lb[2] = new Label();
            lb[2].Text = f.interfaceSubnet;
            lb[2].Location = new Point(subInterfaceGB.Location.X + 300, 20 * (f.interfaceNumber - 1) + 15);

            subInterfaceGB.Controls.AddRange(lb);

        }

        private void utilObjectGroupBtn_Click(object sender, EventArgs e)
        {
            int intAdded = utilObjectGroupGB.Controls.Count;
            ObjectGroupAdderForm f = new ObjectGroupAdderForm(Convert.ToInt32(intAdded / 3) + 1);
            //ObjectGroupAdderForm f = new ObjectGroupAdderForm();
            f.ShowDialog();

            Label[] lb = new Label[3];
            lb[0] = new Label();
            lb[0].Text = f.ogName;
            //var x = utilObjectGroupGB.Location.X + 5;
            //var y = utilObjectGroupGB.Location.Y + 20 * (f.ogNumber - 1);
            lb[0].Location = new Point(utilObjectGroupGB.Location.X + 5, 20 * (f.ogNumber - 1) + 15);
            lb[1] = new Label();
            lb[1].Text = f.ogType;
            lb[1].Location = new Point(utilObjectGroupGB.Location.X + 150,20 * (f.ogNumber - 1) + 15);
            lb[2] = new Label();
            lb[2].Text = string.Join(",", f.ogList.ToArray());
            lb[2].Location = new Point(utilObjectGroupGB.Location.X + 300, 20 * (f.ogNumber - 1) + 15);
            //var xc = lb[0].Location.X;
            //var yc = lb[0].Location.Y;
            utilObjectGroupGB.Controls.AddRange(lb);
        }

        private void utilAclBtn_Click(object sender, EventArgs e)
        {
            List<string> ogList = new List<string>();
            foreach (Control ctrl in utilObjectGroupGB.Controls)
            {
                if (utilObjectGroupGB.Controls.IndexOf(ctrl)%3 == 0)
                {
                    ogList.AddRange(ctrl.Text.Split(','));
                }
            }

            int intAdded = utilAclGB.Controls.Count;
            AclAdderForm f = new AclAdderForm(ogList, Convert.ToInt32(intAdded / 4) + 1);
            f.ShowDialog();

            Label[] lb = new Label[4];
            lb[0] = new Label();
            lb[0].Text = f.accessGroup;
            lb[0].Location = new Point(utilAclGB.Location.X + 5, 20 * (f.aclno - 1) + 15);
            lb[1] = new Label();
            lb[1].Text = f.permitDeny.ToString();
            lb[1].Location = new Point(utilAclGB.Location.X + 150, 20 * (f.aclno - 1) + 15);
            lb[2] = new Label();
            lb[2].Text = f.protocol.ToString();
            lb[2].Location = new Point(utilAclGB.Location.X + 250, 20 * (f.aclno - 1) + 15);
            lb[3] = new Label();
            lb[3].Text = string.Join(",", f.ogList.ToArray());
            lb[3].Location = new Point(utilAclGB.Location.X + 350, 20 * (f.aclno - 1) + 15);

            utilAclGB.Controls.AddRange(lb);
        }

        private void subObjectGroupBtn_Click(object sender, EventArgs e)
        {
            int intAdded = subObjectGroupGB.Controls.Count;
            ObjectGroupAdderForm f = new ObjectGroupAdderForm(Convert.ToInt32(intAdded / 3) + 1);
            f.ShowDialog();

            Label[] lb = new Label[3];
            lb[0] = new Label();
            lb[0].Text = f.ogName;
            lb[0].Location = new Point(subObjectGroupGB.Location.X + 5, 20 * (f.ogNumber - 1)+15);
            lb[1] = new Label();
            lb[1].Text = f.ogType;
            lb[1].Location = new Point(subObjectGroupGB.Location.X + 150, 20 * (f.ogNumber - 1) + 15);
            lb[2] = new Label();
            lb[2].Text = string.Join(",", f.ogList.ToArray());
            lb[2].Location = new Point(subObjectGroupGB.Location.X + 300,20 * (f.ogNumber - 1) + 15);

            subObjectGroupGB.Controls.AddRange(lb);
        }

        private void subAclBtn_Click(object sender, EventArgs e)
        {
            List<string> ogList = new List<string>();
            foreach (Control ctrl in subObjectGroupGB.Controls)
            {
                if (subObjectGroupGB.Controls.IndexOf(ctrl) % 3 == 0)
                {
                    ogList.AddRange(ctrl.Text.Split(','));
                }
            }

            int intAdded = subAclGB.Controls.Count;
            AclAdderForm f = new AclAdderForm(ogList, Convert.ToInt32(intAdded / 4) + 1);
            f.ShowDialog();

            Label[] lb = new Label[4];
            lb[0] = new Label();
            lb[0].Text = f.accessGroup;
            lb[0].Location = new Point(subAclGB.Location.X + 5, 20 * (f.aclno - 1) + 15);
            lb[1] = new Label();
            lb[1].Text = f.permitDeny.ToString();
            lb[1].Location = new Point(subAclGB.Location.X + 150, 20 * (f.aclno - 1) + 15);
            lb[2] = new Label();
            lb[2].Text = f.protocol.ToString();
            lb[2].Location = new Point(subAclGB.Location.X + 250, 20 * (f.aclno - 1) + 15);
            lb[3] = new Label();
            lb[3].Text = string.Join(",", f.ogList.ToArray());
            lb[3].Location = new Point(subAclGB.Location.X + 350, 20 * (f.aclno - 1) + 15);

            subAclGB.Controls.AddRange(lb);
        }

        // Every time we click on save it would basically save the config in memory which can be retrieved
        // if the same component is re-clicked
        private void utilFirewallBtn_Click(object sender, EventArgs e)
        {
            FirewallConfig fg = new FirewallConfig();
            fg.label = configuratorTC.SelectedTab.Text;

            // Adding all the interfaces
            List<Interface> interfaces = new List<Interface>();
            for (int i = 0; i < utilInterfaceGB.Controls.Count/3; i++)
            {
                var inter = new Interface();
                inter.interfaceName = utilInterfaceGB.Controls[3*i].Text;
                inter.ipAddress = utilInterfaceGB.Controls[3 * i+1].Text;
                inter.subnetMask = utilInterfaceGB.Controls[3 * i+2].Text;
                interfaces.Add(inter);
            }
            fg.interfaces = interfaces;

            // Adding all the object groups
            List<ObjectGroup> ogs = new List<ObjectGroup>();

            for (int i = 0; i < utilObjectGroupGB.Controls.Count/3; i++)
            {
                var og = new ObjectGroup();
                og.objectName = utilObjectGroupGB.Controls[3*i].Text;
                og.objectType = utilObjectGroupGB.Controls[3*i + 1].Text.ToLower();
                if (og.objectType == "network")
                {
                    List<NetworkObject> networkObjects = new List<NetworkObject>();
                    var noComponents = utilObjectGroupGB.Controls[3*i + 2].Text.Split(',').ToList();
                    foreach (var noComponent in noComponents)
                    {
                        var nobject = new NetworkObject();
                        var items = noComponent.Split('#');
                        nobject.type = items[0];
                        nobject.ipAddress = items[1];
                        nobject.subnetAddress = items[2];
                        networkObjects.Add(nobject);
                    }
                    og.networkObjects = networkObjects;

                }
                else
                {
                    List<PortObject> portObjects = new List<PortObject>();
                    var portComponents = utilObjectGroupGB.Controls[3*i + 2].Text.Split(',').ToList();
                    foreach (var portComponent in portComponents)
                    {
                        var pobject = new PortObject();
                        var items = portComponent.Split('#');
                        pobject.portCount = Convert.ToInt32(items[0]);
                        pobject.portNumber = items[1];
                        portObjects.Add(pobject);
                    }
                    og.portObjects = portObjects;
                }
                ogs.Add(og);
            }
            fg.objectGroups = ogs;

            // Adding all the ACLS
            List<AccessControl> acls = new List<AccessControl>();           
            for (int i = 0; i < utilAclGB.Controls.Count/4; i++)
            {
                var acl = new AccessControl();
                acl.accessGroup = utilAclGB.Controls[4 * i].Text;
                acl.permit = utilAclGB.Controls[4 * i + 1].Text;
                acl.protocol = utilAclGB.Controls[4 * i + 2].Text;
                acl.objectGroups = utilAclGB.Controls[4 * i + 3].Text.Split(',').ToList();
                acls.Add(acl);
            }
            fg.acls = acls;

            firewallStorer.Add(new KeyValuePair<string, FirewallConfig>(fg.label,fg));
        }

        private void subFirewallBtn_Click(object sender, EventArgs e)
        {
            FirewallConfig fg = new FirewallConfig();
            fg.label = configuratorTC.SelectedTab.Text;

            // Adding all the interfaces
            List<Interface> interfaces = new List<Interface>();
            for (int i = 0; i < subInterfaceGB.Controls.Count / 3; i++)
            {
                var inter = new Interface();
                inter.interfaceName = subInterfaceGB.Controls[3 * i].Text;
                inter.ipAddress = subInterfaceGB.Controls[3 * i + 1].Text;
                inter.subnetMask = subInterfaceGB.Controls[3 * i + 2].Text;
                interfaces.Add(inter);
            }
            fg.interfaces = interfaces;

            // Adding all the object groups
            List<ObjectGroup> ogs = new List<ObjectGroup>();

            for (int i = 0; i < subObjectGroupGB.Controls.Count / 3; i++)
            {
                var og = new ObjectGroup();
                og.objectName = subObjectGroupGB.Controls[3 * i].Text;
                og.objectType = subObjectGroupGB.Controls[3 * i + 1].Text.ToLower();
                if (og.objectType == "network")
                {
                    List<NetworkObject> networkObjects = new List<NetworkObject>();
                    var noComponents = subObjectGroupGB.Controls[3 * i + 2].Text.Split(',').ToList();
                    foreach (var noComponent in noComponents)
                    {
                        var nobject = new NetworkObject();
                        var items = noComponent.Split('#');
                        nobject.type = items[0];
                        nobject.ipAddress = items[1];
                        nobject.subnetAddress = items[2];
                        networkObjects.Add(nobject);
                    }
                    og.networkObjects = networkObjects;

                }
                else
                {
                    List<PortObject> portObjects = new List<PortObject>();
                    var portComponents = subObjectGroupGB.Controls[3 * i + 2].Text.Split(',').ToList();
                    foreach (var portComponent in portComponents)
                    {
                        var pobject = new PortObject();
                        var items = portComponent.Split('#');
                        pobject.portCount = Convert.ToInt32(items[0]);
                        pobject.portNumber = items[1];
                        portObjects.Add(pobject);
                    }
                    og.portObjects = portObjects;
                }
                ogs.Add(og);
            }
            fg.objectGroups = ogs;

            // Adding all the ACLS
            List<AccessControl> acls = new List<AccessControl>();
            for (int i = 0; i < subAclGB.Controls.Count / 4; i++)
            {
                var acl = new AccessControl();
                acl.accessGroup = subAclGB.Controls[4 * i].Text;
                acl.permit = subAclGB.Controls[4 * i + 1].Text;
                acl.protocol = subAclGB.Controls[4 * i + 2].Text;
                acl.objectGroups = subAclGB.Controls[4 * i + 3].Text.Split(',').ToList();
                acls.Add(acl);
            }
            fg.acls = acls;

            firewallStorer.Add(new KeyValuePair<string, FirewallConfig>(fg.label, fg));
        }

        private void saveUtilConfigBtn_Click(object sender, EventArgs e)
        {
            ReviewConfigForm rcf = new ReviewConfigForm(firewallStorer[utilNodeLabel.Text]);
            rcf.ShowDialog();
        }

        private void saveSubConfigBtn_Click(object sender, EventArgs e)
        {
            ReviewConfigForm rcf = new ReviewConfigForm(firewallStorer[subNodeLabel.Text]);
            rcf.ShowDialog();
        }

        private void srcButton_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                srcPathTB.Text = ofd.FileName;
                TopologyGeneration.configPath = srcPathTB.Text.TrimEnd('\\').Remove(srcPathTB.Text.LastIndexOf('\\') + 1);
            }
        }
    }
}
