using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProgTech
{
    public partial class CurrencySelectionForm : Form
    {
        public CurrencySelectionForm()
        {
            InitializeComponent();
        }

        public bool ShowUSD { get { return usdCheckBox.Checked; } }
        public bool ShowEUR { get { return eurCheckBox.Checked; } }
        public bool ShowDM { get { return dmCheckBox.Checked; } }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ShowUSD || ShowEUR || ShowDM)
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Select at least one currency type");
        }
    }
}
