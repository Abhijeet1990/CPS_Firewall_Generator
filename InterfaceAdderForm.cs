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
    public partial class InterfaceAdderForm : Form
    {
        public int interfaceNumber;
        public string interfaceName;
        public string interfaceIp;
        public string interfaceSubnet;
        public InterfaceAdderForm(int _intNumber, string _ipaddress, string _subnet)
        {
            InitializeComponent();
            interfaceNumber = _intNumber;
            intNoTB.Text = interfaceNumber.ToString();
            ipTB.Text = _ipaddress;
            subnetTB.Text = _subnet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //intNoTB.Text = interfaceNumber.ToString();
            interfaceNumber = Convert.ToInt32(intNoTB.Text);
            interfaceName = nameTB.Text;
            interfaceIp = ipTB.Text;
            interfaceSubnet = subnetTB.Text;
            this.Close();
        }
    }
}
