using SpecianPRJ.Scheme;
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
        private SchemeCalculator calculator;

        private PlotWindow plotWindow;

        public MainForm()
        {
            InitializeComponent();
            diagram = new RBDDiagram();
            drawHelper = new SchemeDrawHelper();
            calculator = new SchemeCalculator();
            DrawRectangle();
            //InitDemoScheme();
        }

        private void InitDemoScheme()
        {
            diagram = new RBDDiagram();
            drawHelper = new SchemeDrawHelper();
            calculator = new SchemeCalculator();
            diagram.setUpTestScheme();
            updateTextFormOfDiagram();
        }

        private void DrawRectangle()
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(270, 20, 700, 500));
            myBrush.Dispose();
            formGraphics.Dispose();
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

            if (double.TryParse(this.textBox2.Text, out var lambda))
            {
                Distributions.ExponencialDistribution exp = new Distributions.ExponencialDistribution(lambda);
                Blocks.Item item = new Blocks.Item(textBox1.Text, exp);
                item.NumberId = diagram.ItemCounter++;
                block.AddITem(item);
            }

            updateTextFormOfDiagram();
        }

        //compute button
        private void button3_Click(object sender, EventArgs e)
        {
            if (double.TryParse(this.textBox5.Text, out var time))
            {
                MessageBox.Show("Pravděpodobnost bezporuchového provozu zadaného systému v čase " + time.ToString() + " hodin je " + (diagram.CalculateItself(time)*100).ToString() + " % ");
            }
        }

        //show plot button 
        private void button4_Click(object sender, EventArgs e)
        {
            plotWindow = new PlotWindow();

            var selectedItem = diagram.SchemeHolder.Blocks
                .SelectMany(i => i.ParalelItems)
                .OrderByDescending(i => i.NumberId)
                .Where(i => i.NumberId == numericUpDown2.Value)
                .FirstOrDefault();

            if (selectedItem != null)
            {
                plotWindow.Distribution = selectedItem.Distribution;
                plotWindow.Minimum = 0;

                var maximum = (int) selectedItem.Distribution.QuantileFunction(0.97D);

                plotWindow.Maximum = maximum;
                plotWindow.Show();
            }
        }

        //index of Item to plot
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        //show text output
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(diagram.ToString());
        }

        private void updateTextFormOfDiagram()
        {
            DrawRectangle();
            var drawScheme = drawHelper.DrawImageByScheme(diagram.SchemeHolder, 200, 80);

            foreach (var rect in drawScheme.Rectangles)
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
                System.Drawing.Graphics formGraphics;
                formGraphics = this.CreateGraphics();
                formGraphics.DrawRectangle(myPen, new Rectangle(rect.x, rect.y, rect.sizeX, rect.sizeY));
                myPen.Dispose();
                formGraphics.Dispose();
            }

            foreach (var line in drawScheme.Lines)
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
                System.Drawing.Graphics formGraphics;
                formGraphics = this.CreateGraphics();
                formGraphics.DrawLine(myPen, line.x1, line.y1, line.x2, line.y2);
                myPen.Dispose();
                formGraphics.Dispose();
            }

            foreach (var text in drawScheme.Texts)
            {
                System.Drawing.Graphics formGraphics = this.CreateGraphics();
                string drawString = text.text;
                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 13);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                formGraphics.DrawString(drawString, drawFont, drawBrush, text.x, text.y, drawFormat);
                drawFont.Dispose();
                drawBrush.Dispose();
                formGraphics.Dispose();
            }
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
