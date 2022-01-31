using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LinearAlgebra;
using llab4.Presentation;
using llab4.View;
namespace llab4
{
    public partial class Form1 : Form, IIris
    {
        public string Path { get; set; }
        public MathVector VMiddleSetosa { get; set; }
        public MathVector VMiddleVersicolor { get; set; }
        public MathVector VMiddleVirginica { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button_loading_Click(object sender, EventArgs e)
        {
            IrisPresentation presentation = new IrisPresentation(this);
            bool filepath = true;
            try
            {
                presentation.FileParser();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                filepath = false;
            }
            if (filepath)
            {
                Chart[] charts = new Chart[5];
                charts[0] = chart1;
                charts[1] = chart2;
                charts[2] = chart3;
                charts[3] = chart4;
                charts[4] = chart5;
                for(int i=0;i<5;i++)
                    charts[i].Series[0].Points.Clear();
                presentation.CalculateMiddle();
                for (int i = 0; i < 4; i++)
                {
                    charts[i].Series[0].Points.AddXY("setosa", Math.Round(VMiddleSetosa[i], 2));
                    charts[i].Series[0].Points.AddXY("versicolor", Math.Round(VMiddleVersicolor[i], 2));
                    charts[i].Series[0].Points.AddXY("virginica", Math.Round(VMiddleVirginica[i], 2));
                    charts[i].Series[0].IsValueShownAsLabel = true;
                }
                chart5.Series[0].Points.AddXY("setosa-versicolor", Math.Round(VMiddleSetosa.CalcDistance(VMiddleVersicolor), 2));
                chart5.Series[0].Points.AddXY("setosa-virginica", Math.Round(VMiddleSetosa.CalcDistance(VMiddleVirginica), 2));
                chart5.Series[0].Points.AddXY("virginica-versicolor", Math.Round(VMiddleVirginica.CalcDistance(VMiddleVersicolor), 2));
                chart5.Series[0].IsValueShownAsLabel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Path = openFileDialog1.FileName;
            IrisPresentation presentation = new IrisPresentation(this);
            MessageBox.Show("Файл загружен идет проверка");
            try
            {
                presentation.FileParser();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Проверка завершена");
            }
        }
    }
}
