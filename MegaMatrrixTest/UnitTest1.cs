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
            Matrix clonedMatrix = (Matrix)inputMatrix.Clone();
            Assert.AreEqual(inputMatrix, clonedMatrix);            
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
            Matrix expectedResultMatrix = (inputMatrix + inputMatrix);
            int getnumber = expectedResultMatrix.InnerMatrix[0, 0];
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
            Matrix expectedResultMatrix = (inputMatrix - inputMatrix);
            int getnumber = expectedResultMatrix.InnerMatrix[0, 0];
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
        public void TestEqualityOfMatrices()
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

            bool expectedResult = firstMatrix == secondMatrix;

            Assert.IsTrue(expectedResult);
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

            bool expectedResult = firstMatrix != secondMatrix;

            Assert.IsTrue(expectedResult);
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

            
            bool expectedResult = firstMatrix > secondMatrix;

            
            Assert.IsTrue(expectedResult);
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

            
            bool expectedResult = firstMatrix < secondMatrix;

            
            Assert.IsTrue(expectedResult);
        }
        [TestMethod]
        public void TestOfGreaterThanOrEqualMatrices()
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

            
            bool expectedResult = firstMatrix >= secondMatrix;

            
            Assert.IsTrue(expectedResult);
        }

        [TestMethod]
        public void TestOfLessThanOrEqualMatrices()
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

            
            bool expectedResult = firstMatrix <= secondMatrix;

            
            Assert.IsTrue(expectedResult);
        }

        [TestMethod]
        public void TestOfGetHashCode()
        {
            
            Matrix inputMatrix = new Matrix(2);

            
            int hashCode = inputMatrix.GetHashCode();

            
            Assert.AreEqual(2, hashCode);
        }

        [TestMethod]
        public void TestOfImplicitOperator()
        {
            
            Matrix inputMatrix = new Matrix(2);
            inputMatrix.InnerMatrix[0, 0] = 1;
            inputMatrix.InnerMatrix[0, 1] = 2;
            inputMatrix.InnerMatrix[1, 0] = 3;
            inputMatrix.InnerMatrix[1, 1] = 4;

            
            int[,] expectedResultArray = (int[,])inputMatrix;

            
            Assert.AreEqual(1, expectedResultArray[0, 0]);
            Assert.AreEqual(2, expectedResultArray[0, 1]);
            Assert.AreEqual(3, expectedResultArray[1, 0]);
            Assert.AreEqual(4, expectedResultArray[1, 1]);
        }

        [TestMethod]
        public void TestOfExplicitOperatorConvertsToRowAndLineCount()
        {
            
            Matrix inputMatrix = new Matrix(2);

            
            int expectedRowAndLineCount = (int)inputMatrix;

            
            Assert.AreEqual(2, expectedRowAndLineCount);
        }

        [TestMethod]
        public void TestOfCompareToReturns1IfCurrentMatrixIsSmaller()
        {
            
            Matrix firstInputMatrix = new Matrix(1);
            Matrix secondInputMatrix = new Matrix(2);

            
            int expectedResult = ((IComparable)firstInputMatrix).CompareTo(secondInputMatrix);

            
            Assert.AreEqual(-1, expectedResult);
        }

        [TestMethod]
        public void TestOfCompareToReturns0IfMatricesAreEqual()
        {
            Matrix firstInputMatrix = new Matrix(2);
            Matrix secondInputMatrix = new Matrix(2);

            int expectedResult = ((IComparable)firstInputMatrix).CompareTo(secondInputMatrix);

            Assert.AreEqual(0, expectedResult);
        }

        [TestMethod]
        public void TestOfCompareToReturnsMinus1IfCurrentMatrixIsLarger()
        {
            Matrix firstInputMatrix = new Matrix(2);
            Matrix secondInputMatrix = new Matrix(1);


            int expectedResult = ((IComparable)firstInputMatrix).CompareTo(secondInputMatrix);


            Assert.AreEqual(1, expectedResult);
        }

        [TestMethod]
        public void TestOfChangeOrShowRowAndLineCountGetsAndSetRowAndLineCount()
        {

            Matrix inputMatrix = new Matrix(2);

            inputMatrix.ChangeOrShowRowAndLineCount = 3;
            int expectedRowAndLineCount = inputMatrix.ChangeOrShowRowAndLineCount;

            Assert.AreEqual(3, expectedRowAndLineCount);
        }
    }
}
