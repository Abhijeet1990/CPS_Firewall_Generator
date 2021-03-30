namespace FirewallGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("CIR Balancing Authority");
            this.firewallAccessTreeView = new System.Windows.Forms.TreeView();
            this.configuratorTC = new System.Windows.Forms.TabControl();
            this.utilTypePage = new System.Windows.Forms.TabPage();
            this.saveUtilConfigBtn = new System.Windows.Forms.Button();
            this.utilAclGB = new System.Windows.Forms.GroupBox();
            this.utilAclBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.utilObjectGroupGB = new System.Windows.Forms.GroupBox();
            this.utilObjectGroupBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.utilNodeLabel = new System.Windows.Forms.Label();
            this.utilInterfaceGB = new System.Windows.Forms.GroupBox();
            this.utilAddInterfaceBtn = new System.Windows.Forms.Button();
            this.utilFirewallBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.subTypePage = new System.Windows.Forms.TabPage();
            this.saveSubConfigBtn = new System.Windows.Forms.Button();
            this.subAclGB = new System.Windows.Forms.GroupBox();
            this.subAclBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.subObjectGroupGB = new System.Windows.Forms.GroupBox();
            this.subObjectGroupBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.subNodeLabel = new System.Windows.Forms.Label();
            this.subFirewallBtn = new System.Windows.Forms.Button();
            this.subInterfaceGB = new System.Windows.Forms.GroupBox();
            this.subAddInterfaceBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.baTypePage = new System.Windows.Forms.TabPage();
            this.ConfiguratorPanel = new System.Windows.Forms.Panel();
            this.srcButton = new System.Windows.Forms.Button();
            this.srcPathTB = new System.Windows.Forms.TextBox();
            this.configuratorTC.SuspendLayout();
            this.utilTypePage.SuspendLayout();
            this.subTypePage.SuspendLayout();
            this.ConfiguratorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // firewallAccessTreeView
            // 
            this.firewallAccessTreeView.Location = new System.Drawing.Point(3, 27);
            this.firewallAccessTreeView.Name = "firewallAccessTreeView";
            treeNode1.Name = "rootNode";
            treeNode1.Text = "CIR Balancing Authority";
            this.firewallAccessTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.firewallAccessTreeView.Size = new System.Drawing.Size(225, 457);
            this.firewallAccessTreeView.TabIndex = 0;
            this.firewallAccessTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.firewallAccessTreeView_NodeMouseClick);
            // 
            // configuratorTC
            // 
            this.configuratorTC.Controls.Add(this.utilTypePage);
            this.configuratorTC.Controls.Add(this.subTypePage);
            this.configuratorTC.Controls.Add(this.baTypePage);
            this.configuratorTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configuratorTC.Location = new System.Drawing.Point(0, 3);
            this.configuratorTC.Name = "configuratorTC";
            this.configuratorTC.SelectedIndex = 0;
            this.configuratorTC.Size = new System.Drawing.Size(544, 476);
            this.configuratorTC.TabIndex = 1;
            // 
            // utilTypePage
            // 
            this.utilTypePage.BackColor = System.Drawing.Color.PaleTurquoise;
            this.utilTypePage.Controls.Add(this.saveUtilConfigBtn);
            this.utilTypePage.Controls.Add(this.utilAclGB);
            this.utilTypePage.Controls.Add(this.utilAclBtn);
            this.utilTypePage.Controls.Add(this.label4);
            this.utilTypePage.Controls.Add(this.utilObjectGroupGB);
            this.utilTypePage.Controls.Add(this.utilObjectGroupBtn);
            this.utilTypePage.Controls.Add(this.label3);
            this.utilTypePage.Controls.Add(this.utilNodeLabel);
            this.utilTypePage.Controls.Add(this.utilInterfaceGB);
            this.utilTypePage.Controls.Add(this.utilAddInterfaceBtn);
            this.utilTypePage.Controls.Add(this.utilFirewallBtn);
            this.utilTypePage.Controls.Add(this.label1);
            this.utilTypePage.Location = new System.Drawing.Point(4, 24);
            this.utilTypePage.Name = "utilTypePage";
            this.utilTypePage.Padding = new System.Windows.Forms.Padding(3);
            this.utilTypePage.Size = new System.Drawing.Size(536, 448);
            this.utilTypePage.TabIndex = 0;
            this.utilTypePage.Text = "Utility";
            // 
            // saveUtilConfigBtn
            // 
            this.saveUtilConfigBtn.BackColor = System.Drawing.Color.Ivory;
            this.saveUtilConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveUtilConfigBtn.Location = new System.Drawing.Point(432, 413);
            this.saveUtilConfigBtn.Name = "saveUtilConfigBtn";
            this.saveUtilConfigBtn.Size = new System.Drawing.Size(98, 31);
            this.saveUtilConfigBtn.TabIndex = 11;
            this.saveUtilConfigBtn.Text = "Save Config";
            this.saveUtilConfigBtn.UseVisualStyleBackColor = false;
            this.saveUtilConfigBtn.Click += new System.EventHandler(this.saveUtilConfigBtn_Click);
            // 
            // utilAclGB
            // 
            this.utilAclGB.AutoSize = true;
            this.utilAclGB.BackColor = System.Drawing.Color.LightCyan;
            this.utilAclGB.Location = new System.Drawing.Point(9, 317);
            this.utilAclGB.Name = "utilAclGB";
            this.utilAclGB.Size = new System.Drawing.Size(6, 19);
            this.utilAclGB.TabIndex = 10;
            this.utilAclGB.TabStop = false;
            this.utilAclGB.Text = "Access Control Lists";
            // 
            // utilAclBtn
            // 
            this.utilAclBtn.BackColor = System.Drawing.Color.Ivory;
            this.utilAclBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilAclBtn.Location = new System.Drawing.Point(204, 295);
            this.utilAclBtn.Name = "utilAclBtn";
            this.utilAclBtn.Size = new System.Drawing.Size(109, 27);
            this.utilAclBtn.TabIndex = 9;
            this.utilAclBtn.Text = "Add ACLs";
            this.utilAclBtn.UseVisualStyleBackColor = false;
            this.utilAclBtn.Click += new System.EventHandler(this.utilAclBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Configures Access Controls";
            // 
            // utilObjectGroupGB
            // 
            this.utilObjectGroupGB.AutoSize = true;
            this.utilObjectGroupGB.BackColor = System.Drawing.Color.LightCyan;
            this.utilObjectGroupGB.Location = new System.Drawing.Point(9, 174);
            this.utilObjectGroupGB.Name = "utilObjectGroupGB";
            this.utilObjectGroupGB.Size = new System.Drawing.Size(6, 19);
            this.utilObjectGroupGB.TabIndex = 7;
            this.utilObjectGroupGB.TabStop = false;
            this.utilObjectGroupGB.Text = "Object Groups";
            // 
            // utilObjectGroupBtn
            // 
            this.utilObjectGroupBtn.BackColor = System.Drawing.Color.Ivory;
            this.utilObjectGroupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilObjectGroupBtn.Location = new System.Drawing.Point(204, 150);
            this.utilObjectGroupBtn.Name = "utilObjectGroupBtn";
            this.utilObjectGroupBtn.Size = new System.Drawing.Size(140, 30);
            this.utilObjectGroupBtn.TabIndex = 6;
            this.utilObjectGroupBtn.Text = "Add Object Groups";
            this.utilObjectGroupBtn.UseVisualStyleBackColor = false;
            this.utilObjectGroupBtn.Click += new System.EventHandler(this.utilObjectGroupBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Configures Object Groups";
            // 
            // utilNodeLabel
            // 
            this.utilNodeLabel.AutoSize = true;
            this.utilNodeLabel.Location = new System.Drawing.Point(55, 4);
            this.utilNodeLabel.Name = "utilNodeLabel";
            this.utilNodeLabel.Size = new System.Drawing.Size(47, 15);
            this.utilNodeLabel.TabIndex = 4;
            this.utilNodeLabel.Text = "label3";
            // 
            // utilInterfaceGB
            // 
            this.utilInterfaceGB.AutoSize = true;
            this.utilInterfaceGB.BackColor = System.Drawing.Color.LightCyan;
            this.utilInterfaceGB.Location = new System.Drawing.Point(9, 49);
            this.utilInterfaceGB.Name = "utilInterfaceGB";
            this.utilInterfaceGB.Size = new System.Drawing.Size(6, 19);
            this.utilInterfaceGB.TabIndex = 3;
            this.utilInterfaceGB.TabStop = false;
            this.utilInterfaceGB.Text = "Interfaces";
            // 
            // utilAddInterfaceBtn
            // 
            this.utilAddInterfaceBtn.BackColor = System.Drawing.Color.Ivory;
            this.utilAddInterfaceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilAddInterfaceBtn.Location = new System.Drawing.Point(204, 32);
            this.utilAddInterfaceBtn.Name = "utilAddInterfaceBtn";
            this.utilAddInterfaceBtn.Size = new System.Drawing.Size(109, 26);
            this.utilAddInterfaceBtn.TabIndex = 2;
            this.utilAddInterfaceBtn.Text = "Add Interface";
            this.utilAddInterfaceBtn.UseVisualStyleBackColor = false;
            this.utilAddInterfaceBtn.Click += new System.EventHandler(this.utilAddInterfaceBtn_Click);
            // 
            // utilFirewallBtn
            // 
            this.utilFirewallBtn.BackColor = System.Drawing.Color.Ivory;
            this.utilFirewallBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilFirewallBtn.Location = new System.Drawing.Point(288, 413);
            this.utilFirewallBtn.Name = "utilFirewallBtn";
            this.utilFirewallBtn.Size = new System.Drawing.Size(138, 31);
            this.utilFirewallBtn.TabIndex = 1;
            this.utilFirewallBtn.Text = "Generate Firewall";
            this.utilFirewallBtn.UseVisualStyleBackColor = false;
            this.utilFirewallBtn.Click += new System.EventHandler(this.utilFirewallBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configures Interfaces";
            // 
            // subTypePage
            // 
            this.subTypePage.BackColor = System.Drawing.Color.Tan;
            this.subTypePage.Controls.Add(this.saveSubConfigBtn);
            this.subTypePage.Controls.Add(this.subAclGB);
            this.subTypePage.Controls.Add(this.subAclBtn);
            this.subTypePage.Controls.Add(this.label5);
            this.subTypePage.Controls.Add(this.subObjectGroupGB);
            this.subTypePage.Controls.Add(this.subObjectGroupBtn);
            this.subTypePage.Controls.Add(this.label6);
            this.subTypePage.Controls.Add(this.subNodeLabel);
            this.subTypePage.Controls.Add(this.subFirewallBtn);
            this.subTypePage.Controls.Add(this.subInterfaceGB);
            this.subTypePage.Controls.Add(this.subAddInterfaceBtn);
            this.subTypePage.Controls.Add(this.label2);
            this.subTypePage.Location = new System.Drawing.Point(4, 24);
            this.subTypePage.Name = "subTypePage";
            this.subTypePage.Padding = new System.Windows.Forms.Padding(3);
            this.subTypePage.Size = new System.Drawing.Size(536, 448);
            this.subTypePage.TabIndex = 1;
            this.subTypePage.Text = "Substation";
            // 
            // saveSubConfigBtn
            // 
            this.saveSubConfigBtn.BackColor = System.Drawing.Color.OldLace;
            this.saveSubConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSubConfigBtn.Location = new System.Drawing.Point(439, 415);
            this.saveSubConfigBtn.Name = "saveSubConfigBtn";
            this.saveSubConfigBtn.Size = new System.Drawing.Size(91, 29);
            this.saveSubConfigBtn.TabIndex = 17;
            this.saveSubConfigBtn.Text = "Save Config";
            this.saveSubConfigBtn.UseVisualStyleBackColor = false;
            this.saveSubConfigBtn.Click += new System.EventHandler(this.saveSubConfigBtn_Click);
            // 
            // subAclGB
            // 
            this.subAclGB.AutoSize = true;
            this.subAclGB.BackColor = System.Drawing.Color.SeaShell;
            this.subAclGB.Location = new System.Drawing.Point(9, 333);
            this.subAclGB.Name = "subAclGB";
            this.subAclGB.Size = new System.Drawing.Size(6, 19);
            this.subAclGB.TabIndex = 16;
            this.subAclGB.TabStop = false;
            this.subAclGB.Text = "Interfaces";
            // 
            // subAclBtn
            // 
            this.subAclBtn.BackColor = System.Drawing.Color.OldLace;
            this.subAclBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subAclBtn.Location = new System.Drawing.Point(197, 295);
            this.subAclBtn.Name = "subAclBtn";
            this.subAclBtn.Size = new System.Drawing.Size(109, 32);
            this.subAclBtn.TabIndex = 15;
            this.subAclBtn.Text = "Add ACLs";
            this.subAclBtn.UseVisualStyleBackColor = false;
            this.subAclBtn.Click += new System.EventHandler(this.subAclBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Configures Access Controls";
            // 
            // subObjectGroupGB
            // 
            this.subObjectGroupGB.AutoSize = true;
            this.subObjectGroupGB.BackColor = System.Drawing.Color.SeaShell;
            this.subObjectGroupGB.Location = new System.Drawing.Point(9, 211);
            this.subObjectGroupGB.Name = "subObjectGroupGB";
            this.subObjectGroupGB.Size = new System.Drawing.Size(6, 19);
            this.subObjectGroupGB.TabIndex = 13;
            this.subObjectGroupGB.TabStop = false;
            this.subObjectGroupGB.Text = "Interfaces";
            // 
            // subObjectGroupBtn
            // 
            this.subObjectGroupBtn.BackColor = System.Drawing.Color.OldLace;
            this.subObjectGroupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subObjectGroupBtn.Location = new System.Drawing.Point(197, 168);
            this.subObjectGroupBtn.Name = "subObjectGroupBtn";
            this.subObjectGroupBtn.Size = new System.Drawing.Size(139, 33);
            this.subObjectGroupBtn.TabIndex = 12;
            this.subObjectGroupBtn.Text = "Add Object Groups";
            this.subObjectGroupBtn.UseVisualStyleBackColor = false;
            this.subObjectGroupBtn.Click += new System.EventHandler(this.subObjectGroupBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Configures Object Groups";
            // 
            // subNodeLabel
            // 
            this.subNodeLabel.AutoSize = true;
            this.subNodeLabel.Location = new System.Drawing.Point(58, 3);
            this.subNodeLabel.Name = "subNodeLabel";
            this.subNodeLabel.Size = new System.Drawing.Size(47, 15);
            this.subNodeLabel.TabIndex = 6;
            this.subNodeLabel.Text = "label3";
            // 
            // subFirewallBtn
            // 
            this.subFirewallBtn.BackColor = System.Drawing.Color.OldLace;
            this.subFirewallBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subFirewallBtn.Location = new System.Drawing.Point(299, 415);
            this.subFirewallBtn.Name = "subFirewallBtn";
            this.subFirewallBtn.Size = new System.Drawing.Size(134, 29);
            this.subFirewallBtn.TabIndex = 5;
            this.subFirewallBtn.Text = "Generate Firewall";
            this.subFirewallBtn.UseVisualStyleBackColor = false;
            this.subFirewallBtn.Click += new System.EventHandler(this.subFirewallBtn_Click);
            // 
            // subInterfaceGB
            // 
            this.subInterfaceGB.AutoSize = true;
            this.subInterfaceGB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.subInterfaceGB.BackColor = System.Drawing.Color.SeaShell;
            this.subInterfaceGB.Location = new System.Drawing.Point(9, 70);
            this.subInterfaceGB.Name = "subInterfaceGB";
            this.subInterfaceGB.Size = new System.Drawing.Size(6, 5);
            this.subInterfaceGB.TabIndex = 4;
            this.subInterfaceGB.TabStop = false;
            this.subInterfaceGB.Text = "Interfaces";
            // 
            // subAddInterfaceBtn
            // 
            this.subAddInterfaceBtn.BackColor = System.Drawing.Color.OldLace;
            this.subAddInterfaceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subAddInterfaceBtn.Location = new System.Drawing.Point(197, 35);
            this.subAddInterfaceBtn.Name = "subAddInterfaceBtn";
            this.subAddInterfaceBtn.Size = new System.Drawing.Size(109, 29);
            this.subAddInterfaceBtn.TabIndex = 3;
            this.subAddInterfaceBtn.Text = "Add Interface";
            this.subAddInterfaceBtn.UseVisualStyleBackColor = false;
            this.subAddInterfaceBtn.Click += new System.EventHandler(this.subAddInterfaceBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Configures Interfaces";
            // 
            // baTypePage
            // 
            this.baTypePage.Location = new System.Drawing.Point(4, 24);
            this.baTypePage.Name = "baTypePage";
            this.baTypePage.Padding = new System.Windows.Forms.Padding(3);
            this.baTypePage.Size = new System.Drawing.Size(536, 448);
            this.baTypePage.TabIndex = 2;
            this.baTypePage.Text = "Balancing Authority";
            this.baTypePage.UseVisualStyleBackColor = true;
            // 
            // ConfiguratorPanel
            // 
            this.ConfiguratorPanel.Controls.Add(this.configuratorTC);
            this.ConfiguratorPanel.Location = new System.Drawing.Point(234, 2);
            this.ConfiguratorPanel.Name = "ConfiguratorPanel";
            this.ConfiguratorPanel.Size = new System.Drawing.Size(546, 482);
            this.ConfiguratorPanel.TabIndex = 2;
            // 
            // srcButton
            // 
            this.srcButton.Location = new System.Drawing.Point(153, 2);
            this.srcButton.Name = "srcButton";
            this.srcButton.Size = new System.Drawing.Size(75, 23);
            this.srcButton.TabIndex = 3;
            this.srcButton.Text = "Source";
            this.srcButton.UseVisualStyleBackColor = true;
            this.srcButton.Click += new System.EventHandler(this.srcButton_Click);
            // 
            // srcPathTB
            // 
            this.srcPathTB.Location = new System.Drawing.Point(3, 4);
            this.srcPathTB.Name = "srcPathTB";
            this.srcPathTB.Size = new System.Drawing.Size(150, 20);
            this.srcPathTB.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(781, 487);
            this.Controls.Add(this.srcPathTB);
            this.Controls.Add(this.srcButton);
            this.Controls.Add(this.firewallAccessTreeView);
            this.Controls.Add(this.ConfiguratorPanel);
            this.Name = "MainForm";
            this.Text = "Firewall Configurator";
            this.configuratorTC.ResumeLayout(false);
            this.utilTypePage.ResumeLayout(false);
            this.utilTypePage.PerformLayout();
            this.subTypePage.ResumeLayout(false);
            this.subTypePage.PerformLayout();
            this.ConfiguratorPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView firewallAccessTreeView;
        private System.Windows.Forms.TabControl configuratorTC;
        private System.Windows.Forms.TabPage utilTypePage;
        private System.Windows.Forms.Button utilFirewallBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox utilInterfaceGB;
        private System.Windows.Forms.Button utilAddInterfaceBtn;
        private System.Windows.Forms.TabPage baTypePage;
        private System.Windows.Forms.Label utilNodeLabel;
        private System.Windows.Forms.GroupBox utilObjectGroupGB;
        private System.Windows.Forms.Button utilObjectGroupBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox utilAclGB;
        private System.Windows.Forms.Button utilAclBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage subTypePage;
        private System.Windows.Forms.GroupBox subAclGB;
        private System.Windows.Forms.Button subAclBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox subObjectGroupGB;
        private System.Windows.Forms.Button subObjectGroupBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label subNodeLabel;
        private System.Windows.Forms.Button subFirewallBtn;
        private System.Windows.Forms.GroupBox subInterfaceGB;
        private System.Windows.Forms.Button subAddInterfaceBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel ConfiguratorPanel;
        private System.Windows.Forms.Button saveUtilConfigBtn;
        private System.Windows.Forms.Button saveSubConfigBtn;
        private System.Windows.Forms.Button srcButton;
        private System.Windows.Forms.TextBox srcPathTB;
    }
}

