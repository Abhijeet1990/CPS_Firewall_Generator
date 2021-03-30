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

namespace FirewallGenerator
{
    public partial class ReviewConfigForm : Form
    {
        public FirewallConfig firewallConfig = new FirewallConfig();
        public ReviewConfigForm(FirewallConfig _firewallConfig)
        {
            InitializeComponent();
            firewallConfig = _firewallConfig;
            generateFirewallConfigText(firewallConfig);
           
        }

        private void generateFirewallConfigText(FirewallConfig fc)
        {
            // prepare the firewall config text in the list box
            StringBuilder firewallBuilder = new StringBuilder();

            firewallContentLB.Items.Add("hostname " + fc.label); firewallBuilder.AppendLine("\n");
            firewallContentLB.Items.Add("names"); firewallBuilder.AppendLine("\n");
            firewallContentLB.Items.Add("\n");

             // create the interfaces
            foreach (var ifc in fc.interfaces)
            {
                firewallContentLB.Items.Add("interface GigabitEthernet1/" + (fc.interfaces.IndexOf(ifc) + 1).ToString()); firewallBuilder.Append("\n");
                firewallContentLB.Items.Add("nameif " + ifc.interfaceName); firewallBuilder.Append("\n");
                firewallContentLB.Items.Add("security-level 100"); firewallBuilder.Append("\n");
                firewallContentLB.Items.Add("ip address " + ifc.ipAddress + " " + ifc.subnetMask); firewallBuilder.Append("\n");
                firewallContentLB.Items.Add("\n");
            }
            firewallContentLB.Items.Add("\n");

            // create the object-groups
            foreach (var og in fc.objectGroups)
            {
                if (og.networkObjects!=null)
                {
                    foreach (var no in og.networkObjects)
                    {
                        firewallContentLB.Items.Add("object-group network " + og.objectName); firewallBuilder.Append("\n");
                        firewallContentLB.Items.Add(" network-object " + no.type + " " + no.ipAddress); firewallBuilder.Append("\n");
                    }
                   
                }
                if(og.portObjects!=null)
                {
                    firewallContentLB.Items.Add("object-group service " + og.objectName); firewallBuilder.Append("\n");
                    foreach (var po in og.portObjects)
                    {
                        firewallContentLB.Items.Add(" port-object eq " + po.portNumber); firewallBuilder.Append("\n");
                    }
                }
            }
            firewallContentLB.Items.Add("\n");

            // create access control list
            List<string> AccessGroups = new List<string>();
            foreach (var acl in fc.acls)
            {
                var aclString = "access-list " + acl.accessGroup + " extended " + acl.permit + " "+acl.protocol+" ";
                if (!AccessGroups.Contains(acl.accessGroup))
                    AccessGroups.Add(acl.accessGroup);

                foreach (var og in acl.objectGroups)
                {
                    aclString += "object-group " + og + " ";
                }
                firewallContentLB.Items.Add(aclString); firewallBuilder.Append("\n");
            }
            firewallContentLB.Items.Add("\n");

            // add the access group
            foreach (var ag in AccessGroups)
            {
                if (ag.Contains("inside"))
                { firewallContentLB.Items.Add("access-group " + ag + " in interface inside"); firewallBuilder.Append("\n"); }
                else
                { firewallContentLB.Items.Add("access-group " + ag + " in interface outside"); firewallBuilder.Append("\n"); }
            }
            firewallContentLB.Items.Add("\n");

            firewallContentLB.Items.Add("telnet timeout 5"); firewallBuilder.Append("\n");
            firewallContentLB.Items.Add("ssh timeout 5"); firewallBuilder.Append("\n");
            firewallContentLB.Items.Add("\n");

            //string firewallConfig = firewallBuilder.ToString();
            //firewallContentLB.Text = firewallConfig;
            //for (int i = 0; i < firewallBuilder.Length; i++)
            //{
            //    firewallContentLB.Items.Add(firewallBuilder[i].ToString());
            //}

            
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            // write a component validation function
            string feedback = "";
            foreach (var inf in firewallConfig.interfaces)
            {
                IPAddress ipAddress;
                if (string.IsNullOrEmpty(inf.interfaceName)) feedback += " Need to have a Interface name\n";
                if (string.IsNullOrEmpty(inf.ipAddress)) feedback += " Need to have a ip address\n";
                if (string.IsNullOrEmpty(inf.subnetMask)) feedback += " Need to have a subnet mask\n";
                if (!IPAddress.TryParse(inf.ipAddress, out ipAddress )) feedback+= inf.ipAddress+" Not a Valid IP Address\n";
                if (!IPAddress.TryParse(inf.subnetMask, out ipAddress)) feedback += inf.subnetMask + " Not a Valid Subnet Mask\n";
                
                
            }

            foreach (var og in firewallConfig.objectGroups)
            {
                if (string.IsNullOrEmpty(og.objectName)) feedback += " Need to have an object group name\n";
                if (string.IsNullOrEmpty(og.objectType)) feedback += " Define the object type\n";
                if (og.objectType.ToLower() == "port")
                { if (og.portObjects.Count() == 0) feedback += " Assign atleast one port object\n"; }
                if (og.objectType.ToLower() == "network")
                { if (og.networkObjects.Count() == 0) feedback += " Assign atleast one network object\n"; }
                
            }

            foreach (var acl in firewallConfig.acls)
            {
                if (string.IsNullOrEmpty(acl.accessGroup)) feedback += " Assign an access group\n";
                if (acl.objectGroups.Count() == 0) feedback += " Assign atleast one object group to the ACL\n";
                if (string.IsNullOrEmpty(acl.protocol)) feedback += " Define the protocol or service for the ACL\n";
                if (string.IsNullOrEmpty(acl.permit)) feedback += " Define the permission for the ACL\n";
            }

            if (!string.IsNullOrEmpty(feedback)) MessageBox.Show(feedback);
        }
    }
}
