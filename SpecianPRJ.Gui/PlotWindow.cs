using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SpecianPRJ.Interfaces;

namespace SpecianPRJ.Gui
{
    public partial class PlotWindow : Form
    {
        public PlotWindow()
        {
            InitializeComponent();
        }

        public IDistribution Distribution { get; set; }

        public int Minimum { get; set; } = 50;
        public int Maximum { get; set; } = 60;

        private void PlotWindow_Load(object sender, EventArgs e)
        {

        }

        private FunctionSeries getFunction()
        {
            FunctionSeries fs = new FunctionSeries();
            double step = (Maximum - Minimum) / 100D;
            for (double x = Minimum; x <= Maximum; x+= step)
            {
                DataPoint dp = new DataPoint(x, Distribution.CumulativeDistributionFunction((double)x));
                fs.Points.Add(dp);
            }

            return fs;
        }

        private void PlotWindow_Shown(object sender, EventArgs e)
        {
            PlotView pv = new PlotView();
            pv.BackColor = Color.White;
            pv.Dock = DockStyle.Fill;
            this.Controls.Add(pv);

            LinearAxis XAxis = new LinearAxis() { Position = OxyPlot.Axes.AxisPosition.Bottom, Minimum = this.Minimum,  Maximum = this.Maximum };
            LinearAxis YAxis = new LinearAxis();

            PlotModel pm = new PlotModel();
            pm.Axes.Add(XAxis);
            pm.Axes.Add(YAxis);

            pv.Model = pm;
            pv.Model.Series.Add(getFunction());
        }
    }
}
