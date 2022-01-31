using System;
using System.Collections.Generic;
using System.Text;
using llab4.Model;
using llab4.View;

namespace llab4.Presentation
{
    internal class IrisPresentation
    {
        Iris iris = new Iris();
        private IIris irisView;
        public IrisPresentation(IIris view)
        {
            irisView = view;
        }
        public void ConnectBetweenModelAndView()
        {
            ParseFile File = new ParseFile(irisView.Path);
            File.ReadFile();
            File.ReadArr();
            iris.VSetosa = File.VectorSetosa;
            iris.VVersicolor = File.VectorVersicolor;
            iris.VVirginica = File.VectorVirginica;
            
        }
        public void FileParser()
        {
            if (irisView.Path == null)
                throw new Exception("Путь файла не загружен");
            else
            {
                ParseFile File = new ParseFile(irisView.Path);
                File.FileParser();
            }
        }
        public void CalculateMiddle()
        {
            ConnectBetweenModelAndView();
            irisView.VMiddleSetosa = iris.CalculatingMiddleSetosa();
            irisView.VMiddleVersicolor = iris.CalculatingMiddleVersicolor();
            irisView.VMiddleVirginica = iris.CalculatingMiddleVirginica();
        }
    }
}
