using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PieChartTestFW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DrawPieChartLoop(10);
        }

        private void DrawPieChartLoop(int loopCount)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int j = 0; j < loopCount; j++)
            {
                using (var graphics = this.CreateGraphics())
                {
                    graphics.Clear(Color.White);
                    for (int i = 0; i < 200; i++)
                    {
                        DrawPieChartOnForm(graphics, new Point(10 + i, 10), new Size(150, 150));
                    }
                }
            }

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            renderResults.Text = elapsedTime;
        }
        public void DrawPieChartOnForm(Graphics myPieGraphic, Point myPieLocation, Size myPieSize)
        {
            //Take Total Five Values & Draw Chart Of These Values.
            int[] myPiePercent = { 10, 20, 25, 5, 40 };

            //Take Colors To Display Pie In That Colors Of Taken Five Values.
            Color[] myPieColors = { Color.Red, Color.Black, Color.Blue, Color.Green, Color.Maroon };

            //Call Function Which Will Draw Pie of Values.
            DrawPieChart(myPiePercent, myPieColors, myPieGraphic, myPieLocation, myPieSize);
        }


        // Draws a pie chart.
        public void DrawPieChart(int[] myPiePerecents, Color[] myPieColors, Graphics myPieGraphic, Point
      myPieLocation, Size myPieSize)
        {
            //Check if sections add up to 100.
            int sum = 0;
            foreach (int percent_loopVariable in myPiePerecents)
            {
                sum += percent_loopVariable;
            }

            if (sum != 100)
            {
                MessageBox.Show("Sum Do Not Add Up To 100.");
            }

            //Check Here Number Of Values & Colors Are Same Or Not.They Must Be Same.
            if (myPiePerecents.Length != myPieColors.Length)
            {
                MessageBox.Show("There Must Be The Same Number Of Percents And Colors.");
            }

            int PiePercentTotal = 0;
            for (int PiePercents = 0; PiePercents < myPiePerecents.Length; PiePercents++)
            {
                using (SolidBrush brush = new SolidBrush(myPieColors[PiePercents]))
                {

                    //Here it Will Convert Each Value Into 360, So Total Into 360 & Then It Will Draw A Full Pie Chart.
                    myPieGraphic.FillPie(brush, new Rectangle(myPieLocation, myPieSize), Convert.ToSingle(PiePercentTotal * 360 / 100), Convert.ToSingle(myPiePerecents[PiePercents] * 360 / 100));
                }

                PiePercentTotal += myPiePerecents[PiePercents];
            }
            return;
        }
    }
}
