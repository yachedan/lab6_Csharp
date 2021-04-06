using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixDecimal matrix = new(3,4);
            matrix.SetMatrix();
            matrix.GetMatrix();
            Console.WriteLine(matrix++.ToString());
        }
    }
}
