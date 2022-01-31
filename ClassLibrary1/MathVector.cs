using System;
using System.Collections;

namespace LinearAlgebra
{
	/// <summary>
	/// Математический ветор.
	/// </summary>
	public class MathVector : IMathVector
	{
		/// <summary>
		/// кол-во координат
		/// </summary>
		private int _dimensions;
		/// <summary>
		/// массив координат
		/// </summary>
		private double[] _arr;
		/// <summary>
		/// Конструктор класса.
		/// </summary>
		/// <exception cref="Exception">
		/// Incorrect dimension
		/// </exception>
		/// <param name="kol">кол-во координат</param>
		public MathVector(int kol)
		{
			if (kol <= 0)
				throw new Exception("Incorrect demnsions");
			_dimensions = kol;
			_arr = new double[_dimensions];
		}
		/// <summary>
		/// Перегрузка оператора + для вектора и числа
		/// </summary>
		/// <param name="z">Вектор</param>
		/// <param name="x">Число</param>
		/// <returns></returns>
		public static MathVector operator +(MathVector z, double x)
		{
			return (MathVector)z.SumNumber(x);
		}
		/// <summary>
		/// Перегрузка опрератора + для двух векторов
		/// </summary>
		/// <param name="z">Вектор</param>
		/// <param name="z2">Другой вектор</param>
		/// <returns></returns>
		public static MathVector operator +(MathVector z, MathVector z2)
		{
				return (MathVector)z.Sum(z2);
		}
		/// <summary>
		/// Перегрузка оператора *
		/// </summary>
		/// <param name="z">Вектор</param>
		/// <param name="x">Число</param>
		/// <returns></returns>
		public static MathVector operator *(MathVector z, double x)
		{
			return (MathVector)z.MultiplyNumber(x);
		}
		/// <summary>
		/// Перегрузка оператора *
		/// </summary>
		/// <param name="z">Вектор</param>
		/// <param name="z2">Другой вектор</param>
		/// <returns></returns>
		public static MathVector operator *(MathVector z, MathVector z2)
		{
				return (MathVector)z.Multiply(z2);
		}
		/// <summary>
		/// Перегрузка оператора / для вектора и числа, + исключения
		/// </summary>
		/// <exception cref="Exception">
		/// Деление на ноль
		/// </exception>
		/// <param name="z">Вектор</param>
		/// <param name="x">Число</param>
		/// <returns></returns>
		public static MathVector operator /(MathVector z, double x)
		{
			if (x == 0)
				throw new Exception("Деление на ноль");
			for (int i = 0; i < z.Dimensions; i++)
				z[i] = z[i] / x;
			return z;
		}
		/// <summary>
		/// Перегрузка оператора / для двух векторов
		/// </summary>
		/// <exception cref="Exception">
		/// Размерности векторов не равны
		/// Деление на ноль
		/// </exception>
		/// <param name="z">Вектор</param>
		/// <param name="z2">Другой вектор</param>
		/// <returns></returns>
		public static MathVector operator /(MathVector z, MathVector z2)
		{
			if (z.Dimensions != z2.Dimensions)
				throw new Exception("Размерности векторов не равны");
			else
			{
				for (int i = 0; i < z.Dimensions; i++)
				{
					if (z2[i] == 0)
						throw new Exception("Деление на ноль");
					z[i] = z[i] / z2[i];
				}
				return z;
			}
		}
		/// <summary>
		/// Перегрузка оператора - для вектора и числа
		/// </summary>
		/// <param name="z">Вектор</param>
		/// <param name="x">Число</param>
		/// <returns></returns>
		public static MathVector operator -(MathVector z, double x)
		{
			for (int i = 0; i < z.Dimensions; i++)
				z[i] = z[i] - x;
			return z;
		}
		/// <summary>
		/// Перегрузка оператора - для двух векторов
		/// </summary>
		/// <exception cref="Exception">
		/// Размерности векторов не равны
		/// </exception>
		/// <param name="z">Вектор</param>
		/// <param name="z2">Другой вектор</param>
		/// <returns></returns>
		public static MathVector operator -(MathVector z, MathVector z2)
		{
			if (z.Dimensions != z2.Dimensions)
				throw new Exception("Размерности векторов не равны");
			else
			{
				for (int i = 0; i < z.Dimensions; i++)
					z[i] = z[i] - z2[i];
				return z;
			}
		}
		/// <summary>
		/// Перегрузка оператора % как скалярное произведение
		/// </summary>
		/// <param name="z">Вектор</param>
		/// <param name="z2">Другой вектор</param>
		/// <returns></returns>
		public static double operator %(MathVector z, MathVector z2)
		{
			if (z.Dimensions != z2.Dimensions)
				throw new Exception("Размерности векторов не равны");
			else
				return z.ScalarMultiply(z2);
		}
		public int Dimensions
		{
			get { return _dimensions; }
		}
		public double this[int i]
		{
			get 
			{
				try
				{ return _arr[i]; }
				catch
				{ throw new Exception("Некорректное обращение к координате"); }
			}
			set 
			{
				try { _arr[i] = value; }
				catch { throw new Exception("Некорректное обращение к координате"); }
			}
		}
		/// <summary>
		/// переменная, которая хранит длину(модуль) вектора
		/// </summary>
		private double _length;
		public double Length
		{
			get
			{
				double length = 0;
				for (int i = 0; i < _dimensions; i++)
					length += Math.Pow(_arr[i], 2);
				_length = Math.Sqrt(length);
				return _length;
			}
		}
		public IMathVector SumNumber(double number)
		{
			MathVector z = new MathVector(_dimensions);
			for(int i=0;i<_dimensions;i++)
				z[i] = this[i] + number;
			return z;
		}
		public IMathVector Sum(IMathVector vector)
		{
			MathVector z = new MathVector(_dimensions);
			if (this.Dimensions != vector.Dimensions)
				throw new Exception("Размерности векторов не равны");
			for (int i = 0; i < _dimensions; i++)
				z[i] = this[i] + vector[i];
			return z;
		}
		public IMathVector MultiplyNumber(double number)
		{
			MathVector z = new MathVector(_dimensions);
			for(int i=0;i<_dimensions;i++)
				z[i] = this[i] * number;
			return z;
		}
		public IMathVector Multiply(IMathVector vector)
		{
			MathVector z = new MathVector(_dimensions);
			if (this.Dimensions != vector.Dimensions)
				throw new Exception("Размерности векторов не равны");
			for (int i=0;i<_dimensions;i++)
				z[i] = this[i] * vector[i];
			return z;
		}
		public double ScalarMultiply(IMathVector vector)
        {
			if (this.Dimensions != vector.Dimensions)
				throw new Exception("Размерности векторов не равны");
			double scal = 0;
			for (int i = 0; i < _dimensions; i++)
				scal += this[i] * vector[i];
			return scal;
        }
		public double CalcDistance(IMathVector vector)
        {
			double distance = 0;
			if (this.Dimensions != vector.Dimensions)
				throw new Exception("Размерности векторов не равны");
			for (int i=0;i<_dimensions;i++)
				distance += Math.Pow(this[i] - vector[i], 2);
			return Math.Sqrt(distance);
        }

        public IEnumerator GetEnumerator()
        {
			return _arr.GetEnumerator();
        }
    }
}
