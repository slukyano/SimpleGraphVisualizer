namespace ProgTech
{
    partial class CurrencySelectionForm
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
            this.usdCheckBox = new System.Windows.Forms.CheckBox();
            this.eurCheckBox = new System.Windows.Forms.CheckBox();
            this.dmCheckBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usdCheckBox
            // 
            this.usdCheckBox.AutoSize = true;
            this.usdCheckBox.Checked = true;
            this.usdCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.usdCheckBox.Location = new System.Drawing.Point(12, 12);
            this.usdCheckBox.Name = "usdCheckBox";
            this.usdCheckBox.Size = new System.Drawing.Size(49, 17);
            this.usdCheckBox.TabIndex = 0;
            this.usdCheckBox.Text = "USD";
            this.usdCheckBox.UseVisualStyleBackColor = true;
            // 
            // eurCheckBox
            // 
            this.eurCheckBox.AutoSize = true;
            this.eurCheckBox.Checked = true;
            this.eurCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.eurCheckBox.Location = new System.Drawing.Point(12, 36);
            this.eurCheckBox.Name = "eurCheckBox";
            this.eurCheckBox.Size = new System.Drawing.Size(49, 17);
            this.eurCheckBox.TabIndex = 1;
            this.eurCheckBox.Text = "EUR";
            this.eurCheckBox.UseVisualStyleBackColor = true;
            // 
            // dmCheckBox
            // 
            this.dmCheckBox.AutoSize = true;
            this.dmCheckBox.Checked = true;
            this.dmCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dmCheckBox.Location = new System.Drawing.Point(12, 60);
            this.dmCheckBox.Name = "dmCheckBox";
            this.dmCheckBox.Size = new System.Drawing.Size(43, 17);
            this.dmCheckBox.TabIndex = 2;
            this.dmCheckBox.Text = "DM";
            this.dmCheckBox.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 99);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(102, 99);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // CurrencySelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 134);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.dmCheckBox);
            this.Controls.Add(this.eurCheckBox);
            this.Controls.Add(this.usdCheckBox);
            this.Name = "CurrencySelectionForm";
            this.Text = "Select currency";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox usdCheckBox;
        private System.Windows.Forms.CheckBox eurCheckBox;
        private System.Windows.Forms.CheckBox dmCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;

    }
}