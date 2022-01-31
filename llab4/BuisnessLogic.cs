using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LinearAlgebra;
using System.Globalization;
namespace llab4
{
    class Load_Parse
    {
        private string _path;
        private const int _k = 4;
        private string[] _arr;
        private List<MathVector> _vectorSetosa = new List<MathVector>();
        public List<MathVector> VectorSetosa
        {
            get { return _vectorSetosa; }
        }
        private List<MathVector> _vectorVersicolor = new List<MathVector>();
        public List<MathVector> VectorVersicolor
        {
            get { return _vectorVersicolor; }
        }
        private List<MathVector> _vectorVirginica = new List<MathVector>();
        public List<MathVector> VectorVirginica
        {
            get { return _vectorVirginica; }
        }
        IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
        public Load_Parse(string path)
        {
            _path = path;
        }
        public void ReadFile()
        {
            System.IO.FileInfo file = new FileInfo(_path);
            _arr = File.ReadAllLines(_path);
            if (_arr[0] == "")
                throw new Exception("Файл пуст");
        }
        public void ReadArr()
        {
            int ks = 0;
            int kvr = 0;
            int kva = 0;
            for(int i=1;i<_arr.Length;i++)
            {
                string[] charact = _arr[i].Split(',');
                if (charact[_k] == "setosa")
                {
                    _vectorSetosa.Add(new MathVector(_k));
                    for (int j = 0; j < _k; j++)
                        _vectorSetosa[ks][j] = double.Parse(charact[j], formatter);
                    ks++;
                } 
                else if(charact[_k]=="versicolor")
                {
                    _vectorVersicolor.Add(new MathVector(_k));
                    for (int j = 0; j < _k; j++)
                        _vectorVersicolor[kvr][j] = double.Parse(charact[j], formatter);
                    kvr++;
                }
                else if(charact[_k]=="virginica")
                {
                    _vectorVirginica.Add(new MathVector(_k));
                    for (int j = 0; j < _k; j++)
                        _vectorVirginica[kva][j] = double.Parse(charact[j], formatter);
                    kva++;
                }
            }
        }
        public void FileParser()
        {
            System.IO.FileInfo file = new System.IO.FileInfo(_path);
            if (!(_path.EndsWith(".csv")))
                throw new Exception("Некорректный тип файла");
            else
            {
                if (file.Length > 1024 * 1024)
                    throw new Exception("Некорректный размер файла");
                else
                {
                    string[] Arr = File.ReadAllLines(_path);
                    if (Arr[0] == "")
                        throw new Exception("Файл пуст");
                    else
                    {
                        for (int i = 0; i < Arr.Length; i++)
                            if (Arr[i].EndsWith(";"))
                                throw new Exception("Некорректное содержание файла");
                        string[] charact = Arr[0].Split(',');
                        if (charact[0] != "sepal_length" || charact[1] != "sepal_width" || charact[2] != "petal_length" || charact[3] != "petal_width" || charact[4] != "species")
                            throw new Exception("Некорректный тип характеристик");
                        for (int i = 1; i < Arr.Length; i++)
                        {
                            string[] koordinate = Arr[i].Split(",");
                            for (int j = 0; j < _k; j++)
                            {
                                try
                                {
                                    double x = double.Parse(koordinate[j], formatter);
                                }
                                catch (Exception)
                                {
                                    throw new Exception("Некорректный тип координаты в строке: " + Convert.ToString(i + 1) + " в столбце: " + Convert.ToString(j + 1));
                                }
                                if (koordinate[_k] != "setosa" && koordinate[_k] != "versicolor" && koordinate[_k] != "virginica")
                                    throw new Exception("Неверный тип вектора в строке: " + Convert.ToString(i + 1));
                            }
                        }
                    }
                }
            }

        }
    }

    class Calculating_Median
    {
        private const int _k = 4;
        private MathVector _vectorMiddleSetosa = new MathVector(_k);
        public MathVector VectorMiddleSetosa
        {
            get { return _vectorMiddleSetosa; }
        }
        private MathVector _vectorMiddleVersicolor = new MathVector(_k);
        public MathVector VectorMiddleVersicolor
        {
            get { return _vectorMiddleVersicolor; }
        }
        private MathVector _vectorMiddleVirginica = new MathVector(_k);
        public MathVector VectorMiddleVirginica
        {
            get { return _vectorMiddleVirginica; }
        }
        /// <summary>
        /// Метод считает средние значения для каждого из вида ирисов
        /// </summary>
        /// <param name="_vectorSetosa">Вектор Setosa</param>
        /// <param name="_vectorVersicolor">Вектор Versicolor</param>
        /// <param name="_vectorVirginica">Вектор virginica</param>
        public void Middle(List<MathVector> _vectorSetosa, List<MathVector> _vectorVersicolor, List<MathVector> _vectorVirginica)
        {
            for (int j = 0; j < 4; j++)
            {
                double sum = 0;
                for (int i = 0; i < _vectorSetosa.Count; i++)
                    sum += _vectorSetosa[i][j];
                _vectorMiddleSetosa[j] = sum / _vectorSetosa.Count;
            }
            for (int j = 0; j < 4; j++)
            {
                double sum = 0;
                for (int i = 0; i < _vectorVersicolor.Count; i++)
                    sum += _vectorVersicolor[i][j];
                _vectorMiddleVersicolor[j] = sum / _vectorVersicolor.Count;
            }
            for (int j = 0; j < 4; j++)
            {
                double sum = 0;
                for (int i = 0; i < _vectorVirginica.Count; i++)
                    sum += _vectorVirginica[i][j];
                _vectorMiddleVirginica[j] = sum / _vectorVirginica.Count;
            }
        }
    }
}
