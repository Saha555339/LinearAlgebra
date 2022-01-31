using System;
using System.Collections.Generic;
using System.Text;
using LinearAlgebra;
namespace llab4.Model
{
    internal class Iris
    {
        private const int _k = 4;
        public List<MathVector> VSetosa { get; set; }
        public List<MathVector> VVersicolor { get; set; }
        public List<MathVector> VVirginica { get; set; }

        /// <summary>
        /// Метод считает средние значения для каждого из вида ирисов
        /// </summary>
        /// <param name="_vectorSetosa">Вектор Setosa</param>
        /// <param name="_vectorVersicolor">Вектор Versicolor</param>
        /// <param name="_vectorVirginica">Вектор virginica</param>
        public MathVector CalculatingMiddleSetosa()
        {
            MathVector _vectorMiddleSetosa = new MathVector(_k);
            for (int j = 0; j < 4; j++)
            {
                double sum = 0;
                for (int i = 0; i < VSetosa.Count; i++)
                    sum += VSetosa[i][j];
                _vectorMiddleSetosa[j] = sum / VSetosa.Count;
            }
            return _vectorMiddleSetosa;
        }
        public MathVector CalculatingMiddleVirginica()
        {
            MathVector _vectorMiddleVirginica = new MathVector(_k);
            for (int j = 0; j < 4; j++)
            {
                double sum = 0;
                for (int i = 0; i < VVirginica.Count; i++)
                    sum += VVirginica[i][j];
                _vectorMiddleVirginica[j] = sum / VVirginica.Count;
            }
            return _vectorMiddleVirginica;
        }
        public MathVector CalculatingMiddleVersicolor()
        {
            MathVector _vectorMiddleVersicolor = new MathVector(_k);
            for (int j = 0; j < 4; j++)
            {
                double sum = 0;
                for (int i = 0; i < VVersicolor.Count; i++)
                    sum += VVersicolor[i][j];
                _vectorMiddleVersicolor[j] = sum / VVersicolor.Count;
            }
            return _vectorMiddleVersicolor;
        }
    }
}
