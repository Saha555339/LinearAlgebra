using System;
using System.Collections.Generic;
using System.Text;
using LinearAlgebra;
namespace llab4.View
{
    internal interface IIris
    {
        string Path { get; set; }
        MathVector VMiddleSetosa { get; set; }
        MathVector VMiddleVersicolor { get; set; }
        MathVector VMiddleVirginica { get; set; }
    }
}
