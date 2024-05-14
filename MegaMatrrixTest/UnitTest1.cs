using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CSharp10lab;
using System.Security.Cryptography;

namespace MegaMatrrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEqualityOfClone()
        {
            Matrix inputMatrix = new Matrix(2);
            inputMatrix.InnerMatrix[0, 0] = 1;
            inputMatrix.InnerMatrix[0, 1] = 2;
            inputMatrix.InnerMatrix[1, 0] = 3;
            inputMatrix.InnerMatrix[1, 1] = 4;
            Matrix ClonedMatrix = (Matrix)inputMatrix.Clone();
            Assert.AreEqual(inputMatrix, ClonedMatrix);            
        }
        [TestMethod]
        public void TestAddOperation() 
        {
            Matrix inputMatrix = new Matrix(2);
            inputMatrix.InnerMatrix[0, 0] = 1;
            inputMatrix.InnerMatrix[0, 1] = 2;
            inputMatrix.InnerMatrix[1, 0] = 3;
            inputMatrix.InnerMatrix[1, 1] = 4;
            int correctValue = inputMatrix.InnerMatrix[0, 0];
            Matrix resultMatrix = (inputMatrix + inputMatrix);
            int getnumber = resultMatrix.InnerMatrix[0, 0];
            Assert.AreEqual(getnumber, correctValue * 2);
        }
        [TestMethod]
        public void TestMinusOperation()
        {
            Matrix inputMatrix = new Matrix(2);
            inputMatrix.InnerMatrix[0, 0] = 1;
            inputMatrix.InnerMatrix[0, 1] = 2;
            inputMatrix.InnerMatrix[1, 0] = 3;
            inputMatrix.InnerMatrix[1, 1] = 4;
            int correctValue = 0;
            Matrix resultMatrix = (inputMatrix - inputMatrix);
            int getnumber = resultMatrix.InnerMatrix[0, 0];
            Assert.AreEqual(getnumber, correctValue);
        }
        [TestMethod]
        public void TestMultiplicationOperation()
        {
            
            Matrix firstMatrix = new Matrix(2);
            firstMatrix.InnerMatrix[0, 0] = 1;
            firstMatrix.InnerMatrix[0, 1] = 2;
            firstMatrix.InnerMatrix[1, 0] = 3;
            firstMatrix.InnerMatrix[1, 1] = 4;

            Matrix secondMatrix = new Matrix(2);
            secondMatrix.InnerMatrix[0, 0] = 5;
            secondMatrix.InnerMatrix[0, 1] = 6;
            secondMatrix.InnerMatrix[1, 0] = 7;
            secondMatrix.InnerMatrix[1, 1] = 8;

            Matrix expectedResultMatrix = new Matrix(2);
            expectedResultMatrix.InnerMatrix[0, 0] = 19;
            expectedResultMatrix.InnerMatrix[0, 1] = 22;
            expectedResultMatrix.InnerMatrix[1, 0] = 43;
            expectedResultMatrix.InnerMatrix[1, 1] = 50;

            
            Matrix actualResultMatrix = firstMatrix * secondMatrix;

            
            Assert.IsTrue(actualResultMatrix.Equals(expectedResultMatrix));
        }
        [TestMethod]
        public void TestReverseOperation()
        {
            Matrix inputMatrix = new Matrix(2);
            inputMatrix.InnerMatrix[0, 0] = 1;
            inputMatrix.InnerMatrix[0, 1] = 2;
            inputMatrix.InnerMatrix[1, 0] = 3;
            inputMatrix.InnerMatrix[1, 1] = 4;

            Matrix reversedMatrix = new Matrix(2);
            inputMatrix.InnerMatrix[0, 0] = 1;
            inputMatrix.InnerMatrix[0, 1] = 3;
            inputMatrix.InnerMatrix[1, 0] = 2;
            inputMatrix.InnerMatrix[1, 1] = 4;

            Matrix actualReversedMatrix = +inputMatrix;
            Assert.IsTrue(actualReversedMatrix.Equals(reversedMatrix));
        }

        [TestMethod]
        public void TestShowOperation()
        {
            Matrix inputMatrix = new Matrix(2);
            inputMatrix.InnerMatrix[0, 0] = 1;
            inputMatrix.InnerMatrix[0, 1] = 2;
            inputMatrix.InnerMatrix[1, 0] = 3;
            inputMatrix.InnerMatrix[1, 1] = 4;

            inputMatrix.ShowMatrix(inputMatrix);
        }
        [TestMethod]
        public void TestDeterminantOperation()
        {
            Matrix inputMatrix = new Matrix(2);
            inputMatrix.InnerMatrix[0, 0] = 1;
            inputMatrix.InnerMatrix[0, 1] = 2;
            inputMatrix.InnerMatrix[1, 0] = 3;
            inputMatrix.InnerMatrix[1, 1] = 4;
            int correctValue = -2;
            int determinant = !inputMatrix;

            Assert.AreEqual(determinant, correctValue);
        }
        [TestMethod]
        public void TestEqualityOflMatrices()
        {
            Matrix firstMatrix = new Matrix(2);
            firstMatrix.InnerMatrix[0, 0] = 1;
            firstMatrix.InnerMatrix[0, 1] = 2;
            firstMatrix.InnerMatrix[1, 0] = 3;
            firstMatrix.InnerMatrix[1, 1] = 4;

            Matrix secondMatrix = new Matrix(2);
            secondMatrix.InnerMatrix[0, 0] = 1;
            secondMatrix.InnerMatrix[0, 1] = 2;
            secondMatrix.InnerMatrix[1, 0] = 3;
            secondMatrix.InnerMatrix[1, 1] = 4;

            bool result = firstMatrix == secondMatrix;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestInequalityOfDifferentMatrices()
        {
            Matrix firstMatrix = new Matrix(2);
            firstMatrix.InnerMatrix[0, 0] = 1;
            firstMatrix.InnerMatrix[0, 1] = 2;
            firstMatrix.InnerMatrix[1, 0] = 3;
            firstMatrix.InnerMatrix[1, 1] = 4;

            Matrix secondMatrix = new Matrix(2);
            secondMatrix.InnerMatrix[0, 0] = 1;
            secondMatrix.InnerMatrix[0, 1] = 2;
            secondMatrix.InnerMatrix[1, 0] = 3;
            secondMatrix.InnerMatrix[1, 1] = 5;

            bool result = firstMatrix != secondMatrix;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestOfGreaterThanFirstMatrix()
        {
            
            Matrix firstMatrix = new Matrix(2);
            firstMatrix.InnerMatrix[0, 0] = 2;
            firstMatrix.InnerMatrix[0, 1] = 3;
            firstMatrix.InnerMatrix[1, 0] = 4;
            firstMatrix.InnerMatrix[1, 1] = 5;

            Matrix secondMatrix = new Matrix(2);
            secondMatrix.InnerMatrix[0, 0] = 1;
            secondMatrix.InnerMatrix[0, 1] = 2;
            secondMatrix.InnerMatrix[1, 0] = 3;
            secondMatrix.InnerMatrix[1, 1] = 4;

            
            bool result = firstMatrix > secondMatrix;

            
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestOfLessThanFirstMatrix()
        {
            
            Matrix firstMatrix = new Matrix(2);
            firstMatrix.InnerMatrix[0, 0] = 1;
            firstMatrix.InnerMatrix[0, 1] = 2;
            firstMatrix.InnerMatrix[1, 0] = 3;
            firstMatrix.InnerMatrix[1, 1] = 4;

            Matrix secondMatrix = new Matrix(2);
            secondMatrix.InnerMatrix[0, 0] = 2;
            secondMatrix.InnerMatrix[0, 1] = 3;
            secondMatrix.InnerMatrix[1, 0] = 4;
            secondMatrix.InnerMatrix[1, 1] = 5;

            
            bool result = firstMatrix < secondMatrix;

            
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestOfGreaterThanOrEqualMatricesEqual()
        {
            
            Matrix firstMatrix = new Matrix(2);
            firstMatrix.InnerMatrix[0, 0] = 1;
            firstMatrix.InnerMatrix[0, 1] = 2;
            firstMatrix.InnerMatrix[1, 0] = 3;
            firstMatrix.InnerMatrix[1, 1] = 4;

            Matrix secondMatrix = new Matrix(2);
            secondMatrix.InnerMatrix[0, 0] = 1;
            secondMatrix.InnerMatrix[0, 1] = 2;
            secondMatrix.InnerMatrix[1, 0] = 3;
            secondMatrix.InnerMatrix[1, 1] = 4;

            
            bool result = firstMatrix >= secondMatrix;

            
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestOfLessThanOrEqualMatricesEqual()
        {
            
            Matrix firstMatrix = new Matrix(2);
            firstMatrix.InnerMatrix[0, 0] = 1;
            firstMatrix.InnerMatrix[0, 1] = 2;
            firstMatrix.InnerMatrix[1, 0] = 3;
            firstMatrix.InnerMatrix[1, 1] = 4;

            Matrix secondMatrix = new Matrix(2);
            secondMatrix.InnerMatrix[0, 0] = 1;
            secondMatrix.InnerMatrix[0, 1] = 2;
            secondMatrix.InnerMatrix[1, 0] = 3;
            secondMatrix.InnerMatrix[1, 1] = 4;

            
            bool result = firstMatrix <= secondMatrix;

            
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestOfGetHashCode()
        {
            
            Matrix matrix = new Matrix(2);

            
            int hashCode = matrix.GetHashCode();

            
            Assert.AreEqual(2, hashCode);
        }
        [TestMethod]
        public void TestOfImplicitOperator()
        {
            
            Matrix matrix = new Matrix(2);
            matrix.InnerMatrix[0, 0] = 1;
            matrix.InnerMatrix[0, 1] = 2;
            matrix.InnerMatrix[1, 0] = 3;
            matrix.InnerMatrix[1, 1] = 4;

            
            int[,] jaggedArray = (int[,])matrix;

            
            Assert.AreEqual(1, jaggedArray[0, 0]);
            Assert.AreEqual(2, jaggedArray[0, 1]);
            Assert.AreEqual(3, jaggedArray[1, 0]);
            Assert.AreEqual(4, jaggedArray[1, 1]);
        }
        [TestMethod]
        public void TestOfExplicitOperatorConvertsToRowAndLineCount()
        {
            
            Matrix matrix = new Matrix(2);

            
            int rowAndLineCount = (int)matrix;

            
            Assert.AreEqual(2, rowAndLineCount);
        }

        

        [TestMethod]
        public void TestOfCompareToReturns1IfCurrentMatrixIsSmaller()
        {
            
            Matrix matrix1 = new Matrix(1);
            Matrix matrix2 = new Matrix(2);

            
            int result = ((IComparable)matrix1).CompareTo(matrix2);

            
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestOfCompareToReturns0IfMatricesAreEqual()
        {
            // Arrange
            Matrix matrix1 = new Matrix(2);
            Matrix matrix2 = new Matrix(2);

            // Act
            int result = ((IComparable)matrix1).CompareTo(matrix2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestOfCompareToReturnsMinus1IfCurrentMatrixIsLarger()
        {
            // Arrange
            Matrix matrix1 = new Matrix(2);
            Matrix matrix2 = new Matrix(1);

            // Act
            int result = ((IComparable)matrix1).CompareTo(matrix2);

            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void TestOfChangeOrShowRowAndLineCountGetsAndSetRowAndLineCount()
        {
            // Arrange
            Matrix matrix = new Matrix(2);

            // Act
            matrix.ChangeOrShowRowAndLineCount = 3;
            int rowAndLineCount = matrix.ChangeOrShowRowAndLineCount;

            // Assert
            Assert.AreEqual(3, rowAndLineCount);
        }
    }
}
