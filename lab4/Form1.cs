using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinearAlgebra;

namespace lab4
{
        public partial class Form1 : Form
        {
            private string _filename;
            public Form1()
            {
                InitializeComponent();
            }

            private void button_loading_Click(object sender, EventArgs e)
            {
                // Create
                BuisnessLogic B = new BuisnessLogic();
                B.Path = _filename;
                bool filepath = true;
                try
                {
                    B.ReadFile(B.Path);
                    B.FileParser(B.Path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    filepath = false;
                }
                if (filepath)
                {
                    // Clean
                    chart1.Series[0].Points.Clear();
                    chart2.Series[0].Points.Clear();
                    chart3.Series[0].Points.Clear();
                    chart4.Series[0].Points.Clear();
                    chart5.Series[0].Points.Clear();
                    MathVector[] vectorsSetosa = new MathVector[B.Kol("setosa")];
                    vectorsSetosa = B.ReadArr("setosa", B.Kol("setosa"));
                    MathVector vmiddleSetosa = B.Middle(vectorsSetosa);
                    MathVector[] vectorsVersicolor = new MathVector[B.Kol("versicolor")];
                    vectorsSetosa = B.ReadArr("versicolor", B.Kol("versicolor"));
                    MathVector vmiddleVersicolor = B.Middle(vectorsSetosa);
                    MathVector[] vectorsVirginica = new MathVector[B.Kol("virginica")];
                    vectorsSetosa = B.ReadArr("virginica", B.Kol("virginica"));
                    MathVector vmiddleVirginica = B.Middle(vectorsSetosa);
                    // Specifications
                    Chart[] charts = new Chart[4];
                    charts[0] = chart1;
                    charts[1] = chart2;
                    charts[2] = chart3;
                    charts[3] = chart4;
                    for (int i = 0; i < 4; i++)
                    {
                        charts[i].Series[0].Points.AddXY("setosa", Math.Round(vmiddleSetosa[i], 2));
                        charts[i].Series[0].Points.AddXY("versicolor", Math.Round(vmiddleVersicolor[i], 2));
                        charts[i].Series[0].Points.AddXY("virginica", Math.Round(vmiddleVirginica[i], 2));
                        charts[i].Series[0].IsValueShownAsLabel = true;
                    }
                    //Distance
                    chart5.Series[0].Points.AddXY("setosa-versicolor", Math.Round(vmiddleSetosa.CalcDistance(vmiddleVersicolor), 2));
                    chart5.Series[0].Points.AddXY("setosa-virginica", Math.Round(vmiddleSetosa.CalcDistance(vmiddleVirginica), 2));
                    chart5.Series[0].Points.AddXY("virginica-versicolor", Math.Round(vmiddleVersicolor.CalcDistance(vmiddleVirginica), 2));
                    chart5.Series[0].IsValueShownAsLabel = true;
                }
            }

            private void button1_Click(object sender, EventArgs e)
            {
                openFileDialog1.ShowDialog();
                BuisnessLogic B = new BuisnessLogic();
                _filename = openFileDialog1.FileName;
                MessageBox.Show("Файл загружен, идет проверка файла");
                try
                {
                    B.FileParser(_filename);
                }
                catch (Exception ex)
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
