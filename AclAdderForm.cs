using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirewallGenerator
{
    public partial class AclAdderForm : Form
    {
        public int aclno;
        public string accessGroup;
        //public bool permitDeny;
        public string permitDeny;
        public string protocol;
        public List<string> ogList;

        public AclAdderForm(List<string> _ogList, int _aclno)
        {
            InitializeComponent();
            ogList = new List<string>();
            objectGroupLB.DataSource = _ogList;
            aclNoTB.Text = _aclno.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aclno = Convert.ToInt32(aclNoTB.Text);
            accessGroup = accessGroupCB.SelectedItem.ToString();
            //permitDeny = (permitDenyCB.SelectedItem.ToString() == "permit") ? true : false;
            permitDeny = permitDenyCB.SelectedItem.ToString();
            protocol = protocolsCB.SelectedItem.ToString();
            ogList = objectGroupLB.SelectedItems.Cast<string>().ToList();
            this.Close();
        }
    }
}
