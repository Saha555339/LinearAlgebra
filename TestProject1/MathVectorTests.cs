using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra;
namespace TestProject1
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void TestMethodCreateMathVector()
        {
            // Arrange&Act
            MathVector vector = new MathVector(3);
            vector[0] = 2;vector[1] = -5;vector[2] = -2.5;
            double x = 2; double y = -5; double z = -2.5;
            // Assert
            Assert.AreEqual(x, vector[0]);
            Assert.AreEqual(y, vector[1]);
            Assert.AreEqual(z, vector[2]);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethodCreateMathVectorException()
        {
                MathVector vector = new MathVector(-20);
        }
        [TestMethod]
        public void TestMethodSumNumber()
        {
            // Arrange
            MathVector V1 = new MathVector(2);
            double number = -10;
            MathVector Rezult = new MathVector(2);
            V1[0] = 1; V1[1] = 8;
            Rezult[0] = -9; Rezult[1] = -2;
            // Act
            V1 = (V1+number);
            // Assert
            Assert.AreEqual(Rezult[0], V1[0]);
            Assert.AreEqual(Rezult[1], V1[1]);
        }
        [TestMethod]
        public void TestMethodSum()
        {
            // Arrange
            MathVector V1 = new MathVector(2);
            MathVector V2 = new MathVector(2);
            MathVector Rezult = new MathVector(2);
            V1[0] = 1; V1[1] = 2;
            V2[0] = -3; V2[1] = 0;
            Rezult[0] = -2; Rezult[1] = 2;
            // Act
            V1=(V1+V2);
            // Assert
            Assert.AreEqual(Rezult[0], V1[0]);
            Assert.AreEqual(Rezult[1], V1[1]);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethodSumException()
        {
            MathVector vect1 = new MathVector(2);
            MathVector vect2 = new MathVector(3);
                vect1 = vect1 + vect2;           
        }
        [TestMethod]
        public void TestMethodMultiplyNumber()
        {
            // Arrange
            MathVector V1 = new MathVector(2);
            double number = 10;
            MathVector Rezult = new MathVector(2);
            V1[0] = 1; V1[1] = 2;
            Rezult[0] = 10; Rezult[1] = 20;
            // Act
            V1 = (V1 * number);
            // Assert
            Assert.AreEqual(Rezult[0], V1[0]);
            Assert.AreEqual(Rezult[1], V1[1]);
        }
        [TestMethod]
        public void TestMethodMultiply()
        {
            // Arrange
            MathVector V1 = new MathVector(2);
            MathVector V2 = new MathVector(2);
            MathVector Rezult = new MathVector(2);
            V1[0] = 1; V1[1] = 2;
            V2[0] = -3; V2[1] = 0;
            Rezult[0] = -3; Rezult[1] = 0;
            // Act
            V1 = (V1*V2);
            // Assert
            Assert.AreEqual(Rezult[0], V1[0]);
            Assert.AreEqual(Rezult[1], V1[1]);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethodMultiplyException()
        {
            MathVector vect1 = new MathVector(2);
            MathVector vect2 = new MathVector(3);
                vect1 = vect1 * vect2;
        }
        [TestMethod]
        public void TestMethodDimensions()
        {
            // Arrange
            MathVector V = new MathVector(3);
            int dimensions;
            int rezult = 3;
            // Act
            dimensions=V.Dimensions;
            // Assert
            Assert.AreEqual(rezult, dimensions);
        }
        [TestMethod]
        public void TestMethodThis()
        {
            // Arrange
            MathVector V = new MathVector(1);
            V[0] = 25;
            double coordinate;
            double rezult = 25;
            // Act
            coordinate = V[0];
            // Assert
            Assert.AreEqual(rezult, coordinate);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethodThisExceptions()
        {
            MathVector V = new MathVector(2);
            double coordinate;
                coordinate = V[-1];
        }
        [TestMethod]
        public void TestMethodLength()
        {
            // Arrange
            MathVector V = new MathVector(2);
            V[0] = 0; V[1] = 1;
            double length=0;
            double rezult =1;
            // Act
            length = V.Length;
            // Assert
            Assert.AreEqual(rezult, length);
        }
        [TestMethod]
        public void TestMethodScalarMultiply()
        {
            // Arrange
            MathVector V1 = new MathVector(2);
            MathVector V2 = new MathVector(2);
            double scalar_multiply = 0;
            V1[0] = 1; V1[1] = 8;
            V2[0] = -9; V2[1] = -2;
            double rezult = -25;
            // Act
            scalar_multiply =(V1 % V2);
            // Assert
            Assert.AreEqual(rezult, scalar_multiply);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethodScalarMultiplyException()
        {
            MathVector v1 = new MathVector(3);
            MathVector v2 = new MathVector(2);
            double scalar_multiply = 0;
                scalar_multiply = v1.ScalarMultiply(v2);
        }
        [TestMethod]
        public void TestMethodDistance()
        {
            // Arrange
            MathVector V1 = new MathVector(2);
            MathVector V2 = new MathVector(2);
            V1[0] = 1; V1[1] = 2;
            V2[0] = -2; V2[1] = -2;
            double distance = 0;
            double rezult = 5;
            // Act
            distance = V1.CalcDistance(V2);
            // Assert
            Assert.AreEqual(rezult, distance);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethodDistanceException()
        {
            MathVector v1 = new MathVector(1);
            MathVector v2 = new MathVector(3);
            double distance = 0;
                distance = v1.CalcDistance(v2);
        }
        [TestMethod]
        public void TestMethodMinusNumber()
        {
            // Arrange
            MathVector v = new MathVector(2);
            v[0] = 5; v[1] = -5;
            double number = 10;
            MathVector rezult = new MathVector(2);
            rezult[0] = -5; rezult[1] = -15;
            // Act
            v = v - number;
            // Assert
            Assert.AreEqual(rezult[0], v[0]);
            Assert.AreEqual(rezult[1], v[1]);

        }
        [TestMethod]
        public void TestMethodMinus()
        {
            // Arrange
            MathVector V1 = new MathVector(2);
            MathVector V2 = new MathVector(2);
            V1[0] = 10; V1[1] = 22;
            V2[0] = 5; V2[1] = 20;
            MathVector rezult = new MathVector(2);
            rezult[0] = 5; rezult[1] = 2;
            // Act
            V1 = V1 - V2;
            // Assert
            Assert.AreEqual(rezult[0], V1[0]);
            Assert.AreEqual(rezult[1], V1[1]);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethodMinusExeption()
        {
            MathVector v1 = new MathVector(2);
            MathVector v2 = new MathVector(1);
            v1 = v1 - v2;
        }
        [TestMethod]
        public void TestMethodDivisionNumber()
        {
            // Arrange
            MathVector V1 = new MathVector(2);
            V1[0] = 10; V1[1] = 22;
            double number = 4;
            MathVector rezult = new MathVector(2);
            rezult[0] = 2.5; rezult[1] = 5.5;
            // Act
            V1 = V1 / number;
            // Assert
            Assert.AreEqual(rezult[0], V1[0]);
            Assert.AreEqual(rezult[1], V1[1]);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethodDivisionNumberException()
        {
            MathVector v = new MathVector(2);
            v[0] = 5;
            v[1] = -5;
            double number = 0;
            v = v / number;
        }
        [TestMethod]
        public void TestMethodDivision()
        {
            // Arrange
            MathVector V1 = new MathVector(2);
            MathVector V2 = new MathVector(2);
            V1[0] = 10; V1[1] = 22;
            V2[0] = 5; V2[1] = 20;
            MathVector rezult = new MathVector(2);
            rezult[0] = 2; rezult[1] = 1.1;
            // Act
            V1 = V1 / V2;
            // Assert
            Assert.AreEqual(rezult[0], V1[0]);
            Assert.AreEqual(rezult[1], V1[1]);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethodDivisionErrorDimensions()
        {
            MathVector v1 = new MathVector(2);
            v1[0] = 1; v1[1] = 2;
            MathVector v2 = new MathVector(3);
            v2[0] = 3; v2[1] = 3; v2[2] = 4;
                v1 = v1 / v2;
        }
       [TestMethod]
       [ExpectedException(typeof(System.Exception))]
       public void TestMethodDivisionZeroException()
       {
           MathVector v1 = new MathVector(2);
           v1[0] = 1; v1[1] = 2;
           MathVector v2 = new MathVector(2);
           v2[0] = 2; v2[1] = 0;
            v1 = v1 / v2;
       }
    }
}
