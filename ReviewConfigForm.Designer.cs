namespace FirewallGenerator
{
    partial class ReviewConfigForm
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
            this.firewallContentLB = new System.Windows.Forms.ListBox();
            this.validateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firewallContentLB
            // 
            this.firewallContentLB.FormattingEnabled = true;
            this.firewallContentLB.HorizontalScrollbar = true;
            this.firewallContentLB.Location = new System.Drawing.Point(2, 2);
            this.firewallContentLB.Name = "firewallContentLB";
            this.firewallContentLB.ScrollAlwaysVisible = true;
            this.firewallContentLB.Size = new System.Drawing.Size(466, 420);
            this.firewallContentLB.TabIndex = 0;
            // 
            // validateButton
            // 
            this.validateButton.Location = new System.Drawing.Point(328, 428);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(75, 23);
            this.validateButton.TabIndex = 1;
            this.validateButton.Text = "Validate";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.validateButton_Click);
            // 
            // ReviewConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 450);
            this.Controls.Add(this.validateButton);
            this.Controls.Add(this.firewallContentLB);
            this.Name = "ReviewConfigForm";
            this.Text = "Review Firewall Configuration";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox firewallContentLB;
        private System.Windows.Forms.Button validateButton;
    }
}