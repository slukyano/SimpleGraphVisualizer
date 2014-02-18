using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProgTech
{
    public partial class Form1 : Form
    {
        private static readonly Pen UsdPen = new Pen(Color.Green, 2);
        private static readonly Pen EurPen = new Pen(Color.Blue, 2);
        private static readonly Pen DmPen = new Pen(Color.Brown, 2);

        private RateList _rates;
        private bool _showUSD, _showEUR, _showDM;

        private GraphCanvas _canvas;

        public Form1()
        {
            InitializeComponent();

            _monthLabel.Text = "";

            _canvas = new GraphCanvas();
            _canvas.Location = new Point(15, 45);
            _canvas.Size = new Size(this.ClientSize.Width - 30, this.ClientSize.Height - 60);
            Controls.Add(_canvas);

            this.Resize += Form1_Resize;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            _canvas.Size = new Size(this.ClientSize.Width - 30, this.ClientSize.Height - 45);
            _canvas.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm.ShowAbout();
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _rates = RateList.ReadFromFile("TestRates.txt");

            CurrencySelectionForm dialog = new CurrencySelectionForm();
            DialogResult result = dialog.ShowDialog();

            switch (result)
            {
                case DialogResult.OK:
                    _showUSD = dialog.ShowUSD;
                    _showEUR = dialog.ShowEUR;
                    _showDM = dialog.ShowDM;

                    drawToolStripMenuItem.Enabled = true;
                    break;

                case DialogResult.Cancel:
                    _showUSD = _showEUR = _showDM = false;

                    drawToolStripMenuItem.Enabled = false;
                    _monthLabel.Text = "";
                    break;
            } 
        }

        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _canvas.RemoveAllLines();
            
            if (!_showUSD && !_showEUR && !_showDM)
                return;
            
            _monthLabel.Text = _rates.Month;

            if (_showUSD)
                _canvas.AddLine(PointsFromRates(_rates.GetRates(Currency.USD)), 30, UsdPen, "USD");
            if (_showEUR)
                _canvas.AddLine(PointsFromRates(_rates.GetRates(Currency.EUR)), 30, EurPen, "EUR");
            if (_showDM)
                _canvas.AddLine(PointsFromRates(_rates.GetRates(Currency.DM)), 30, DmPen, "DM");

            _canvas.Refresh();
        }

        private List<GraphPoint> PointsFromRates(IEnumerable<ForexRate> rates)
        {
            List<GraphPoint> points = new List<GraphPoint>();
            foreach (ForexRate rate in rates)
                points.Add(new GraphPoint(rate.Day, rate.Rate));

            return points;
        }
    }
}
