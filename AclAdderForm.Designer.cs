namespace FirewallGenerator
{
    partial class AclAdderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.accessGroupCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.protocolsCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.permitDenyCB = new System.Windows.Forms.ComboBox();
            this.objectGroupLB = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.aclNoTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Access Group";
            // 
            // accessGroupCB
            // 
            this.accessGroupCB.FormattingEnabled = true;
            this.accessGroupCB.Items.AddRange(new object[] {
            "from_inside",
            "from_outside"});
            this.accessGroupCB.Location = new System.Drawing.Point(121, 52);
            this.accessGroupCB.Name = "accessGroupCB";
            this.accessGroupCB.Size = new System.Drawing.Size(121, 21);
            this.accessGroupCB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Protocols";
            // 
            // protocolsCB
            // 
            this.protocolsCB.FormattingEnabled = true;
            this.protocolsCB.Items.AddRange(new object[] {
            "FTP",
            "DNP3",
            "HTTP",
            "MODBUS",
            "ICCP",
            "SQL"});
            this.protocolsCB.Location = new System.Drawing.Point(121, 127);
            this.protocolsCB.Name = "protocolsCB";
            this.protocolsCB.Size = new System.Drawing.Size(121, 21);
            this.protocolsCB.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Permit/Deny";
            // 
            // permitDenyCB
            // 
            this.permitDenyCB.FormattingEnabled = true;
            this.permitDenyCB.Items.AddRange(new object[] {
            "permit",
            "deny"});
            this.permitDenyCB.Location = new System.Drawing.Point(121, 88);
            this.permitDenyCB.Name = "permitDenyCB";
            this.permitDenyCB.Size = new System.Drawing.Size(121, 21);
            this.permitDenyCB.TabIndex = 5;
            // 
            // objectGroupLB
            // 
            this.objectGroupLB.FormattingEnabled = true;
            this.objectGroupLB.Location = new System.Drawing.Point(121, 166);
            this.objectGroupLB.Name = "objectGroupLB";
            this.objectGroupLB.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.objectGroupLB.Size = new System.Drawing.Size(120, 43);
            this.objectGroupLB.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Object Groups";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "ACL Number";
            // 
            // aclNoTB
            // 
            this.aclNoTB.Location = new System.Drawing.Point(193, 19);
            this.aclNoTB.Name = "aclNoTB";
            this.aclNoTB.Size = new System.Drawing.Size(49, 20);
            this.aclNoTB.TabIndex = 10;
            // 
            // AclAdderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 251);
            this.Controls.Add(this.aclNoTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.objectGroupLB);
            this.Controls.Add(this.permitDenyCB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.protocolsCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.accessGroupCB);
            this.Controls.Add(this.label1);
            this.Name = "AclAdderForm";
            this.Text = "AclAdderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox accessGroupCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox protocolsCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox permitDenyCB;
        private System.Windows.Forms.ListBox objectGroupLB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox aclNoTB;
    }
}