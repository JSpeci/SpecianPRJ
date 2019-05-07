﻿using SpecianPRJ.Scheme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecianPRJ.Gui
{
    public partial class MainForm : Form
    {
        private RBDDiagram diagram;
        private SchemeDrawHelper drawHelper;
        private PlotWindow plotWindow;

        public MainForm()
        {
            InitializeComponent();
            diagram = new RBDDiagram();
            drawHelper = new SchemeDrawHelper();
        }
                
        //add block clicked
        private void button2_Click(object sender, EventArgs e)
        {
            Blocks.Block block = new Blocks.Block();
            block.Name = textBox4.Text;

            diagram.SchemeHolder.Blocks.Add(block);

            updateTextFormOfDiagram();
        }

        //add paralel item button clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //correction of upDown numeric
            if ((int)this.numericUpDown1.Value < 0 || (int)this.numericUpDown1.Value >= diagram.SchemeHolder.Blocks.Count)
            {
                this.numericUpDown1.Value = diagram.SchemeHolder.Blocks.Count - 1;
            }

            var block = diagram.SchemeHolder.Blocks.ElementAt((int)this.numericUpDown1.Value);

            if(double.TryParse(this.textBox2.Text, out var lambda))
            {
                Distributions.ExponencialDistribution exp = new Distributions.ExponencialDistribution(lambda);
                Blocks.Item item = new Blocks.Item(textBox1.Text, exp);
                block.AddITem(item);
            }

            updateTextFormOfDiagram();
        }

        //compute button
        private void button3_Click(object sender, EventArgs e)
        {
            if(double.TryParse(this.textBox5.Text, out var time))
            {
                diagram.CalculateItself(time);
            }
        }

        //show plot button 
        private void button4_Click(object sender, EventArgs e)
        {
            plotWindow = new PlotWindow();
            plotWindow.Distribution = diagram.SchemeHolder.Blocks.First().ParalelItems.First().Distribution;
            plotWindow.Minimum = 0;
            plotWindow.Maximum = 60;
            plotWindow.Show();
        }

        //index of Item to plot
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        //show text output
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void updateTextFormOfDiagram()
        {
            this.label7.Text = diagram.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
