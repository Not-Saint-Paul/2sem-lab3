using System;
using System.Text;

namespace Lab03
{
    public class DifferentMatrixSizesException : Exception
    {
        public DifferentMatrixSizesException()
        {
        }

        public DifferentMatrixSizesException(string message)
            : base(message)
        {
        }

        public DifferentMatrixSizesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class SquareMatrix : IComparable, ICloneable
    {
        private int size { get; set; }
        private double[,] matrix;
        public SquareMatrix(int size)
        {
            this.size = size;
            matrix = new double[this.size, this.size];
            RandomMatrix();
        }

        public void RandomMatrix()
        {
            Random RandomNumber = new Random();
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    matrix[rowIndex, columnIndex] = RandomNumber.Next(-10, 10);
                }
            }
        }
        public void CustomMatrix()
        {
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    matrix[rowIndex, columnIndex] = double.Parse(Console.ReadLine());
                }
            }
        }
        public void DiagonalMatrix()
        {
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    if (rowIndex == columnIndex)
                    {
                        matrix[rowIndex, columnIndex] = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        matrix[rowIndex, columnIndex] = 0;
                    }
                }
            }
        }
        public void IdentityMatrix()
        {
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    if (rowIndex == columnIndex)
                    {
                        matrix[rowIndex, columnIndex] = 1;
                    }
                    else
                    {
                        matrix[rowIndex, columnIndex] = 0;
                    }
                }
            }
        }
        public void NullMatrix()
        {
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    matrix[rowIndex, columnIndex] = 0;
                }
            }
        }

        public override bool Equals(object other)
        {
            if (other is SquareMatrix)
            {
                var comparedMatrix = other as SquareMatrix;
                if (size != comparedMatrix.size)
                {
                    return false;
                }
                for (int rowIndex = 0; rowIndex < size; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                    {
                        if (matrix[rowIndex, columnIndex] != comparedMatrix.matrix[rowIndex, columnIndex])
                        {
                            return false;
                        }
                    }
                }
                return true;

            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(object other)
        {
            if (other is SquareMatrix)
            {
                SquareMatrix comparedMatrix = other as SquareMatrix;
                double thisMatrixWeight, comparedMatrixWeight;
                thisMatrixWeight = 0;
                comparedMatrixWeight = 0;
                for (int rowIndex = 0; rowIndex < size; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                    {
                        thisMatrixWeight += matrix[rowIndex, columnIndex];
                    }
                }
                for (int rowIndex = 0; rowIndex < comparedMatrix.size; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < comparedMatrix.size; ++columnIndex)
                    {
                        comparedMatrixWeight += comparedMatrix.matrix[rowIndex, columnIndex];
                    }
                }
                if (thisMatrixWeight == comparedMatrixWeight)
                {
                    return 0;
                }
                else if (thisMatrixWeight < comparedMatrixWeight)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            return -1;
        }

        public static SquareMatrix operator +(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix.size != secondMatrix.size)
            {
                throw new DifferentMatrixSizesException("Матрицы не соразмерны");
            }

            int size = firstMatrix.size;
            SquareMatrix resultMatrix = new SquareMatrix(size);
            resultMatrix.NullMatrix();

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    resultMatrix.matrix[rowIndex, columnIndex] = firstMatrix.matrix[rowIndex, columnIndex] + secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static SquareMatrix operator -(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix.size != secondMatrix.size)
            {
                throw new DifferentMatrixSizesException("Матрицы не соразмерны");
            }

            int size = firstMatrix.size;
            SquareMatrix resultMatrix = new SquareMatrix(size);
            resultMatrix.NullMatrix();

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    resultMatrix.matrix[rowIndex, columnIndex] = firstMatrix.matrix[rowIndex, columnIndex] - secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static SquareMatrix operator *(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix.size != secondMatrix.size)
            {
                throw new DifferentMatrixSizesException("Матрицы не соразмерны");
            }

            int size = firstMatrix.size;
            SquareMatrix resultMatrix = new SquareMatrix(size);
            resultMatrix.NullMatrix();

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    resultMatrix.matrix[rowIndex, columnIndex] = firstMatrix.matrix[rowIndex, columnIndex] * secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static bool operator <(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight < secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight > secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator <=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight <= secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight >= secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight == secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight != secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator true(SquareMatrix squareMatrix)
        {
            if (squareMatrix.size != 0)
            {
                return true;
            }
            return false;
        }

        public static bool operator false(SquareMatrix squareMatrix)
        {
            if (squareMatrix.size != 0)
            {
                return false;
            }
            return true;
        }

        public SquareMatrix GetSubMatrix(int columnFromMatrix, SquareMatrix mainMatrix)
        {
            SquareMatrix subMatrix = new SquareMatrix(mainMatrix.size - 1);
            for (int rowIndex = 0; rowIndex < subMatrix.size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < columnFromMatrix; ++columnIndex)
                {
                    subMatrix.matrix[rowIndex, columnIndex] = mainMatrix.matrix[rowIndex + 1, columnIndex + 1];
                }
            }
            return subMatrix;
        }


        public double Determinate(SquareMatrix squareMatrix)
        {
            double theRealDeterminant = 0;

            if (squareMatrix.size == 1)
            {
                theRealDeterminant = squareMatrix.matrix[0, 0];
            }
            else if (squareMatrix.size == 2)
            {
                theRealDeterminant = squareMatrix.matrix[0, 0] * squareMatrix.matrix[1, 1] - squareMatrix.matrix[0, 1] * squareMatrix.matrix[1, 0];
            }
            else
            {
                for (int columnIndex = 0; columnIndex < squareMatrix.size; ++columnIndex)
                {
                    double minor = Convert.ToInt32(Math.Pow(-1, columnIndex));
                    double ColumnNumber = minor * squareMatrix.matrix[0, columnIndex];
                    SquareMatrix SubMatrix = GetSubMatrix(columnIndex, squareMatrix);

                    theRealDeterminant += ColumnNumber * Determinate(SubMatrix);
                }
            }
            return theRealDeterminant;
        }

        public override string ToString()
        {
            StringBuilder matrixStringBuilder = new StringBuilder();
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    matrixStringBuilder.AppendFormat("{0, 4} ", matrix[rowIndex, columnIndex]);
                }
                matrixStringBuilder.Append('\n');
            }
            return matrixStringBuilder.ToString();
        }

        public object Clone()
        {
            SquareMatrix clonedMatrix = new SquareMatrix(size);
            clonedMatrix.matrix = matrix;
            return clonedMatrix;
        }

        public SquareMatrix ReverseMatrix()
        {
            double theRealDeterminant = Determinate(this);
            SquareMatrix reversedMatrix = Clone() as SquareMatrix;
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    reversedMatrix.matrix[rowIndex, columnIndex] = matrix[rowIndex, columnIndex] * theRealDeterminant;
                }
            }
            return reversedMatrix;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SquareMatrix squareMatrix1 = new SquareMatrix(3);
            Console.WriteLine(squareMatrix1);
            SquareMatrix squareMatrix2 = new SquareMatrix(3);

            Console.WriteLine(squareMatrix1 + squareMatrix2);
            Console.WriteLine(squareMatrix1 * squareMatrix2);
            Console.WriteLine(squareMatrix1 < squareMatrix2);

            Console.WriteLine(squareMatrix1.Equals(squareMatrix2));
            Console.WriteLine(squareMatrix1.CompareTo(squareMatrix2));
            Console.WriteLine(squareMatrix2.GetHashCode());
            Console.WriteLine(squareMatrix1.Determinate(squareMatrix1));
            Console.WriteLine(squareMatrix1.ReverseMatrix());

            SquareMatrix squareMatrix3 = new SquareMatrix(6);
            try
            {
                Console.WriteLine(squareMatrix2 + squareMatrix3);
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message);
            }
            Console.ReadLine();

        }
    }
}
