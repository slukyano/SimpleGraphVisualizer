using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProgTech
{
    public partial class AboutForm : Form
    {
        private static AboutForm _form;

        private AboutForm()
        {
            InitializeComponent();
        }

        public static void ShowAbout()
        {
            if (_form == null)
            {
                _form = new AboutForm();
                _form.FormClosed += _form_FormClosed;
                _form.Show();
            }
        }

        static void _form_FormClosed(object sender, FormClosedEventArgs e)
        {
            _form.FormClosed -= _form_FormClosed;
            _form = null;
        }
    }
}
