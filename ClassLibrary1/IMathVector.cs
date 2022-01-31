using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra
{
	/// <summary>
	/// Интерфейс математического вектора.
	/// </summary>
	public interface IMathVector : IEnumerable
	{
		/// <summary>
		/// Размерность вектора.
		/// </summary>
		int Dimensions { get; }
		/// <summary>
		/// Индексатор. Нумерация с нуля.
		/// </summary>
		/// <exception cref="Exception">
		/// Некорректное обращение к координате
		/// </exception>
		/// <param name="i">номер элемента</param>
		/// <returns>Элемент вектора</returns>
		double this[int i] { get; set; }
		/// <summary>
		/// Длина(модуль) вектора
		/// </summary>
		double Length { get; }
		/// <summary>
		/// Покомпонентное сложение с числом.
		/// </summary>
		/// <param name="number">число</param>
		/// <returns>Вектор</returns>
		IMathVector SumNumber(double number);
		/// <summary>
		/// Покомпонентное умножение на число.
		/// </summary>
		/// <param name="number">число</param>
		/// <returns>Вектор</returns>
		IMathVector MultiplyNumber(double number);
		/// <summary>
		/// Покомпонентное сложение с другим вектором
		/// </summary>
		/// <exception cref="Exception">
		/// Размерности векторов не равны
		/// </exception>
		/// <param name="vector">другой вектор</param>
		/// <returns>Вектор</returns>
		IMathVector Sum(IMathVector vector);
		/// <summary>
		/// Покомпонентное умножение с другим вектором
		/// </summary>
		/// <exception cref="Exception">
		/// Размерности векторов не равны
		/// </exception>
		/// <param name="vector">другой вектор</param>
		/// <returns>Вектор</returns>
		IMathVector Multiply(IMathVector vector);
		/// <summary>
		/// Скалярное умножение
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Число</returns>
		double ScalarMultiply(IMathVector vector);
		/// <summary>
		/// Вычисление Эвклидого расстояния до другого вектора.
		/// </summary>
		/// <exception cref="Exception">
		/// Размерности векторов не равны
		/// </exception>
		/// <param name="vector">другой вектор</param>
		/// <returns>Евклидово расстояние</returns>
		double CalcDistance(IMathVector vector);
	}
}
