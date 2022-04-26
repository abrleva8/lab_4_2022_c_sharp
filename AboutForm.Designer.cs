namespace lab_4 {
    partial class AboutForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.checkBoxShowAgain = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkBoxShowAgain
            // 
            this.checkBoxShowAgain.AutoSize = true;
            this.checkBoxShowAgain.Location = new System.Drawing.Point(128, 155);
            this.checkBoxShowAgain.Name = "checkBoxShowAgain";
            this.checkBoxShowAgain.Size = new System.Drawing.Size(108, 17);
            this.checkBoxShowAgain.TabIndex = 0;
            this.checkBoxShowAgain.Text = "Don\'t show again";
            this.checkBoxShowAgain.UseVisualStyleBackColor = true;
            this.checkBoxShowAgain.CheckedChanged += new System.EventHandler(this.checkBoxShowAgain_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 44);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(191, 84);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "The first variation of the fourth task.\r\n\r\nDatabase of the bank accounts.\r\n\r\nLevo" +
    "n Abramyan, group 404, 2022.";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 219);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBoxShowAgain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AboutForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxShowAgain;
        private System.Windows.Forms.TextBox textBox1;
    }
}