using System;
using CSharp10lab;


namespace CSharp10lab
{

    public class InvalidDepartmentException : System.Exception
    {
        public InvalidDepartmentException()
        : base() { }
        public InvalidDepartmentException(string message)
        : base(message) { }
        public InvalidDepartmentException
        (string message, System.Exception inner)
        : base(message, inner) { }

    }
    public class Matrix : IComparable
    {
        public int[,] InnerMatrix;
        public int RowAndLineCount;
        public Matrix()
        {
            Random random = new Random();
            RowAndLineCount = random.Next(2, 5);
            InnerMatrix = new int[RowAndLineCount, RowAndLineCount];
            for (int rowIndex = 0; rowIndex < RowAndLineCount; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < RowAndLineCount; ++columnIndex)
                {
                    InnerMatrix[rowIndex, columnIndex] = random.Next(0, 100);
                }
            }
        }
        public Matrix( int rowCount)
        {
            Random random = new Random();
            RowAndLineCount = rowCount;
            InnerMatrix = new int[RowAndLineCount, RowAndLineCount];
            for (int rowIndex = 0; rowIndex < RowAndLineCount; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < RowAndLineCount; ++columnIndex)
                {
                    InnerMatrix[rowIndex, columnIndex] = random.Next(0, 100);
                }
            }
        }
        public object Clone()
        {
            Matrix clonedRowCount = new Matrix();
            clonedRowCount.RowAndLineCount = this.RowAndLineCount;
            for (int rowIndex = 0; rowIndex < this.RowAndLineCount; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < RowAndLineCount; ++columnIndex)
                {
                    clonedRowCount.InnerMatrix[rowIndex, columnIndex] = this.InnerMatrix[rowIndex, columnIndex];
                }
            }
            return clonedRowCount;
        }
        public static Matrix operator +(Matrix first, Matrix second)
        {
            Matrix resultMatrix = (Matrix)first.Clone();
            try
            {
                for (int rowIndex = 0; rowIndex < first.RowAndLineCount; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < first.RowAndLineCount; ++columnIndex)
                    {
                        resultMatrix.InnerMatrix[rowIndex, columnIndex] = first.InnerMatrix[rowIndex, columnIndex] + second.InnerMatrix[rowIndex, columnIndex];
                    }
                }
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            resultMatrix.ShowMatrix(resultMatrix);
            return resultMatrix;
        }

        public static Matrix operator -(Matrix first, Matrix second)
        {
            Matrix resultMatrix = (Matrix)first.Clone();
            for (int rowIndex = 0; rowIndex < first.RowAndLineCount; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < first.RowAndLineCount; ++columnIndex)
                {
                    resultMatrix.InnerMatrix[rowIndex, columnIndex] = first.InnerMatrix[rowIndex, columnIndex] - second.InnerMatrix[rowIndex, columnIndex];
                }
            }
            resultMatrix.ShowMatrix(resultMatrix);
            return resultMatrix;
        }

        public static Matrix operator *(Matrix first, Matrix second)
        {
            Matrix resultMatrix = (Matrix)first.Clone();
            for (int rowIndex = 0; rowIndex < first.RowAndLineCount; ++rowIndex)
            {
                Console.Write("\n");
                for (int columnIndex = 0; columnIndex < first.RowAndLineCount; ++columnIndex)
                {
                    for (int innerIndex = 0; innerIndex < first.RowAndLineCount; ++innerIndex)
                    {
                        resultMatrix.InnerMatrix[rowIndex, columnIndex] += first.InnerMatrix[rowIndex, innerIndex] * second.InnerMatrix[innerIndex, columnIndex];
                    }
                    Console.Write(resultMatrix.InnerMatrix[rowIndex, columnIndex] + " ");
                    resultMatrix.InnerMatrix[rowIndex, columnIndex] = 0;
                }
            }
            return resultMatrix;
        }

        public static Matrix operator +(Matrix inputMatrix)
        {
            Matrix resultMatrix = (Matrix)inputMatrix.Clone();
            try
            {
                for (int rowIndex = 0; rowIndex < inputMatrix.RowAndLineCount; ++rowIndex)
                {
                    Console.Write("\n");
                    for (int columnIndex = 0; columnIndex < inputMatrix.RowAndLineCount; ++columnIndex)
                    {
                        Console.Write(inputMatrix.InnerMatrix[columnIndex, rowIndex] + " ");
                    }
                }
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return resultMatrix;
        }
        public void ShowMatrix(Matrix first)
        {
            for (int rowIndex = 0; rowIndex < first.RowAndLineCount; ++rowIndex)
            {
                Console.Write("\n");
                for (int columnIndex = 0; columnIndex < first.RowAndLineCount; ++columnIndex)
                {
                    Console.Write(InnerMatrix[rowIndex, columnIndex].ToString() + " ");
                }
            }
            Console.Write("\n");
        }
        public static int operator !(Matrix inputMatrix)
        {
            int determinant = 0;
            switch (inputMatrix.RowAndLineCount)
            {
                case 2:
                    determinant = inputMatrix.InnerMatrix[0, 0] * inputMatrix.InnerMatrix[1, 1] - inputMatrix.InnerMatrix[0, 1] * inputMatrix.InnerMatrix[1, 0];
                    break;
                case 3:
                    determinant = (inputMatrix.InnerMatrix[0, 0] * inputMatrix.InnerMatrix[1, 1] * inputMatrix.InnerMatrix[2, 2] +
                                  inputMatrix.InnerMatrix[0, 2] * inputMatrix.InnerMatrix[1, 0] * inputMatrix.InnerMatrix[2, 1] +
                                  inputMatrix.InnerMatrix[0, 1] * inputMatrix.InnerMatrix[1, 2] * inputMatrix.InnerMatrix[2, 0]) -
                                  (inputMatrix.InnerMatrix[0, 2] * inputMatrix.InnerMatrix[1, 1] * inputMatrix.InnerMatrix[2, 0] +
                                  inputMatrix.InnerMatrix[0, 1] * inputMatrix.InnerMatrix[1, 0] * inputMatrix.InnerMatrix[2, 2] +
                                  inputMatrix.InnerMatrix[0, 0] * inputMatrix.InnerMatrix[1, 2] * inputMatrix.InnerMatrix[2, 1]);
                    break;
                default:
                    Console.WriteLine("Can not find determinant");
                    break;
            }
            return determinant;
        }

        public static bool operator ==(Matrix first, Matrix second)
        {
            byte check = 0;
            for (int rowIndex = 0; rowIndex < first.RowAndLineCount; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < first.RowAndLineCount; ++columnIndex)
                {
                    if (first.InnerMatrix[rowIndex, columnIndex] != second.InnerMatrix[rowIndex, columnIndex])
                    {
                        ++check;
                    };
                }
            }
            if (check == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Matrix first, Matrix second)
        {
            int result = 0;
            for (int rowIndex = 0; rowIndex < first.RowAndLineCount; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < first.RowAndLineCount; ++columnIndex)
                {
                    result = result + first.InnerMatrix[rowIndex, columnIndex] * first.InnerMatrix[rowIndex, columnIndex] - second.InnerMatrix[rowIndex, columnIndex] * second.InnerMatrix[rowIndex, columnIndex];
                }
            }
            return result > 0;
        }

        public static bool operator <(Matrix first, Matrix second)
        {
            int result = 0;
            for (int rowIndex = 0; rowIndex < first.RowAndLineCount; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < first.RowAndLineCount; ++columnIndex)
                {
                    result = result + first.InnerMatrix[rowIndex, columnIndex] * first.InnerMatrix[rowIndex, columnIndex] - second.InnerMatrix[rowIndex, columnIndex] * second.InnerMatrix[rowIndex, columnIndex];
                }
            }
            return result < 0;
        }
        public static bool operator !=(Matrix first, Matrix second)
        {
            byte check = 0;
            for (int rowIndex = 0; rowIndex < first.RowAndLineCount; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < first.RowAndLineCount; ++columnIndex)
                {
                    if (first.InnerMatrix[rowIndex, columnIndex] != second.InnerMatrix[rowIndex, columnIndex])
                    {
                        ++check;
                    };
                }
            }
            if (check != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >=(Matrix first, Matrix second)
        {
            return !(first < second);
        }
        public static bool operator <=(Matrix first, Matrix second)
        {
            return !(first > second);
        }
        public override bool Equals(object myObject)
        {
            bool result = false;
            if (myObject is Matrix)
            {
                var parameter = myObject as Matrix;
                if (parameter.RowAndLineCount == this.RowAndLineCount)
                {
                    result = true;
                }
            }
            return result;
        }
        public override int GetHashCode()
        {
            return (int)this.RowAndLineCount;
        }
        public static implicit operator int[,](Matrix inputMatrix)
        {
            return inputMatrix.InnerMatrix;
        }
        public static explicit operator int(Matrix inputMatrix)
        {
            return inputMatrix.RowAndLineCount;
        }
        public static bool operator true(Matrix inputMatrix)
        {
            return inputMatrix.RowAndLineCount != 1;
        }
        public static bool operator false(Matrix inputMatrix)
        {
            return inputMatrix.RowAndLineCount == 1;
        }
        int IComparable.CompareTo(object myObject)
        {
            if (myObject is Matrix)
            {
                var parameter = myObject as Matrix;
                if (parameter.RowAndLineCount > this.RowAndLineCount)
                {
                    Console.WriteLine("1 case");
                    return -1;
                }
                if (parameter.RowAndLineCount == this.RowAndLineCount)
                {
                    Console.WriteLine("2 case");
                    return 0;
                }
                if (parameter.RowAndLineCount < this.RowAndLineCount)
                {
                    Console.WriteLine("3 case");
                    return 1;
                }
            }
            Console.WriteLine("4 case");
            return -1;
        }

        public int ChangeOrShowRowAndLineCount {
            get { return RowAndLineCount; }
            set { RowAndLineCount = value; }
        }
    }


    internal class Program
    {

        static void Main(string[] args)
        {
            char select = ' ';
            Matrix myMatrix = new Matrix();
            Matrix myCloneMatrix = (Matrix)myMatrix.Clone();
            myMatrix.ShowMatrix(myMatrix);
            myCloneMatrix.ShowMatrix(myCloneMatrix);
            Console.WriteLine("Select your operation: s = summ, d = difference, c = compare, m = multiplication, " +
                              "r = reverse InnerMatrix, f = determinant.");
            select = Convert.ToChar(Console.ReadLine());
            switch (select)
            {
                case 's':
                    Console.WriteLine((myMatrix + myCloneMatrix).ToString() + "\n");
                    break;
                case 'd':
                    Console.WriteLine((myMatrix - myCloneMatrix).ToString() + "\n");
                    break;
                case 'm':
                    Console.WriteLine((myMatrix * myCloneMatrix).ToString() + "\n");
                    break;
                case 'r':
                    Console.WriteLine((+myCloneMatrix).ToString() + "\n");
                    break;
                case 'f':
                    Console.WriteLine((!myCloneMatrix).ToString() + "\n");
                    break;
                case 'c':
                    Console.WriteLine((myMatrix == myCloneMatrix).ToString() + "\n");
                    break;
                default:
                    Console.WriteLine("Wrong operation type");
                    break;
            }

            Console.ReadKey();
        }

    }

}