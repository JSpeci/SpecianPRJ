using SpecianPRJ.Interfaces;
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
            calculator = new SchemeCalculator(diagram.SchemeHolder);
            DrawRectangle();
            //InitDemoScheme();
        }

        private void InitDemoScheme()
        {
            diagram = new RBDDiagram();
            drawHelper = new SchemeDrawHelper();
            calculator = new SchemeCalculator(diagram.SchemeHolder);
            diagram.setUpTestScheme();
            UpdateDrawedDiagram();
        }

        private void DrawRectangle()
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            System.Drawing.SolidBrush myBrush2 = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            int sizeX = (diagram.SchemeHolder.Blocks.Count * 150) - (diagram.SchemeHolder.Blocks.Count * 15);
            if (sizeX > 1200)
            {
                sizeX = 1200;

            }
            if (sizeX < 200)
            {
                sizeX = 200;
            }
            int maxOfItems = 1;
            int sizeY = 600;
            if (diagram.SchemeHolder.Blocks.Select(i => i.ParalelItems.Count).ToList().Count != 0)
            {
                maxOfItems = diagram.SchemeHolder.Blocks.Select(i => i.ParalelItems.Count).ToList().Max();
            }
            sizeY = 60 + maxOfItems * 80;
            formGraphics.FillRectangle(myBrush2, new Rectangle(270, 20, 1500, 1000));
            formGraphics.FillRectangle(myBrush, new Rectangle(270, 20, sizeX, sizeY));
            myBrush.Dispose();
            myBrush2.Dispose();
            formGraphics.Dispose();
        }

        //add block clicked
        private void button2_Click(object sender, EventArgs e)
        {
            Blocks.Block block = new Blocks.Block();
            block.Name = textBox4.Text;

            if (diagram.SchemeHolder.Blocks.Count < 10)
            {
                diagram.SchemeHolder.Blocks.Add(block);

                if (double.TryParse(this.textBox2.Text, out var lambda))
                {
                    Distributions.ExponencialDistribution exp = new Distributions.ExponencialDistribution(lambda);
                    Blocks.Item item = new Blocks.Item(textBox1.Text, exp);
                    item.NumberId = diagram.ItemCounter++;
                    block.AddITem(item);
                }

                textBox4.Text = "Block" + (diagram.SchemeHolder.Blocks.Count + 01).ToString();
                RefreshComboBoxesItems();
                UpdateDrawedDiagram();
            }

        }

        //add paralel item button clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //correction of upDown numeric
            var block = diagram.SchemeHolder.Blocks.Where(i => i.Name == (string)comboBox3.SelectedItem).SingleOrDefault();

            if (block == null)
            {
                return;
            }

            if (block.ParalelItems.Count < 10)
            {
                if (double.TryParse(this.textBox2.Text, out var lambda))
                {
                    Distributions.ExponencialDistribution exp = new Distributions.ExponencialDistribution(lambda);
                    Blocks.Item item = new Blocks.Item(textBox1.Text, exp);
                    item.NumberId = diagram.ItemCounter++;
                    block.AddITem(item);
                }
                RefreshComboBoxesItems();
                UpdateDrawedDiagram();

            }
        }

        //compute button
        private void button3_Click(object sender, EventArgs e)
        {
            if (double.TryParse(this.textBox5.Text, out var time))
            {
                MessageBox.Show("Pravděpodobnost bezporuchového provozu zadaného systému v čase " + time.ToString() + " hodin je " + (diagram.CalculateItself(time) * 100).ToString() + " % ");
            }
        }

        //show plot for Block
        private void button6_Click(object sender, EventArgs e)
        {
            plotWindow = new PlotWindow();

            var selectedBlock = diagram.SchemeHolder.Blocks
                .Where(i => i.Name == (string)comboBox2.SelectedItem)
                .FirstOrDefault();

            if(selectedBlock == null)
            {
                return;
            }

            this.showPlotWindowByDistribution(selectedBlock.Distribution);
        }

        //show plot for Item button 
        private void button4_Click(object sender, EventArgs e)
        {
            plotWindow = new PlotWindow();

            var selectedItem = diagram.SchemeHolder.Blocks
                .SelectMany(i => i.ParalelItems)
                .OrderByDescending(i => i.NumberId)
                .Where(i => (i.NumberId.ToString() + ": " + i.Name) == (string)comboBox1.SelectedItem)
                .FirstOrDefault();

            if(selectedItem == null)
            {
                return;
            }

            this.showPlotWindowByDistribution(selectedItem.Distribution);
        }

        //show plot for  all scheme
        private void button7_Click(object sender, EventArgs e)
        {
            plotWindow = new PlotWindow();
            this.showPlotWindowByDistribution(calculator);
        }

        private void showPlotWindowByDistribution(IDistributionWithCumulativeDF selectedBlock)
        {
            if (selectedBlock != null)
            {
                plotWindow.Distribution = selectedBlock;
                plotWindow.Minimum = 0;
                double maximum = (int)selectedBlock.QuantileFunction(0.995D);

                if (maximum < 1D)
                {
                    maximum = 1D;
                }

                plotWindow.Maximum = (int)maximum;
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

        private void UpdateDrawedDiagram()
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
                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", text.size);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                formGraphics.DrawString(drawString, drawFont, drawBrush, text.x, text.y, drawFormat);
                drawFont.Dispose();
                drawBrush.Dispose();
                formGraphics.Dispose();
            }
        }

        private void RefreshComboBoxesItems()
        {
            foreach (var b in diagram.SchemeHolder.Blocks)
            {
                foreach (var i in b.ParalelItems)
                {
                    if (!comboBox1.Items.Contains(i.NumberId.ToString() + ": " + i.Name))
                    {
                        comboBox1.Items.Insert(comboBox1.Items.Count, i.NumberId.ToString() + ": " + i.Name);
                    }
                }
            }

            foreach (var b in diagram.SchemeHolder.Blocks)
            {
                if (!comboBox2.Items.Contains(b.Name))
                {
                    comboBox2.Items.Insert(comboBox2.Items.Count, b.Name);
                }

                if (!comboBox3.Items.Contains(b.Name))
                {
                    comboBox3.Items.Insert(comboBox3.Items.Count, b.Name);
                }
            }

            if (comboBox1.SelectedItem == null && comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            if (comboBox2.SelectedItem == null && comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
            if (comboBox3.SelectedItem == null && comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
            }

            this.button1.Enabled = diagram.SchemeHolder.Blocks.Count > 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.button1.Enabled = false;
        }

        //delete selected ITEM
        private void button9_Click(object sender, EventArgs e)
        {
            var selectedItem = diagram.SchemeHolder.Blocks
                .SelectMany(i => i.ParalelItems)
                .OrderByDescending(i => i.NumberId)
                .Where(i => (i.NumberId.ToString() + ": " + i.Name) == (string)comboBox1.SelectedItem)
                .FirstOrDefault();

            if (selectedItem == null)
            {
                return;
            }

            var block = diagram.SchemeHolder.Blocks.Where(i => i.ParalelItems.Any(j => j.NumberId == selectedItem.NumberId)).FirstOrDefault();

            block.ParalelItems.Remove(selectedItem);

            if(block.ParalelItems.Count == 0)
            {
                diagram.SchemeHolder.Blocks.Remove(block);
            }

            comboBox1.Items.Remove(selectedItem.NumberId.ToString() + ": " + selectedItem.Name);
            UpdateDrawedDiagram();
        }

        //delete selected BLOCK
        private void button8_Click(object sender, EventArgs e)
        {
            var selectedBlock = diagram.SchemeHolder.Blocks
                .Where(i => i.Name == (string)comboBox2.SelectedItem)
                .FirstOrDefault();

            if (selectedBlock == null)
            {
                return;
            }

            diagram.SchemeHolder.Blocks.Remove(selectedBlock);
            comboBox2.Items.Remove(selectedBlock.Name);
            comboBox3.Items.Remove(selectedBlock.Name);
            UpdateDrawedDiagram();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        // selected Item to show plot
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
