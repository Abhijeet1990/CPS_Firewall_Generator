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
    public partial class ObjectGroupAdderForm : Form
    {
        public int ogNumber;
        public string ogName;
        public string ogType;
        public List<string> ogList;
        public DataGridView networkDgv;
        public DataGridView portDgv;
        public ObjectGroupAdderForm(int _ogNumber)
        {
            InitializeComponent();
            ogList = new List<string>();
            ogNoTB.Text = _ogNumber.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                networkDgv = new DataGridView();
                networkDgv.ColumnCount = 3;
                networkDgv.Columns[0].Name = "Host/Network Type";
                networkDgv.Columns[1].Name = "IP Address";
                networkDgv.Columns[2].Name = "Subnet Mask";
                dgvPanel.Controls.Clear();
                dgvPanel.Controls.Add(networkDgv);
            }
            else
            {
                portDgv = new DataGridView();
                portDgv.ColumnCount = 2;
                portDgv.Columns[0].Name = "Port Count";
                portDgv.Columns[1].Name = "Port Number";
                dgvPanel.Controls.Clear();
                dgvPanel.Controls.Add(portDgv);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ogNumber = Convert.ToInt32(ogNoTB.Text);
            ogName = ogNameTB.Text;
            ogType = comboBox1.SelectedItem.ToString();
            var controls = dgvPanel.Controls;

            if(controls[0].GetType() == typeof(DataGridView))
            {
                DataGridView dgv = (DataGridView)controls[0];
                for (int i = 0; i < dgv.Rows.Count-1; i++)
                {
                    var oneObject = "";
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        oneObject += dgv.Rows[i].Cells[j].Value.ToString()+"#";
                    }
                    ogList.Add(oneObject);
                }
            }

            this.Close();

        }
    }
}
