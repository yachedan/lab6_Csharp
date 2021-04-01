using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            VectorDecimal vector = new(3);
            vector.SetVector();
            vector.DecimalArray[1] = 8080;
            vector.GetVector();
            VectorDecimal vector2 = new();
            Console.WriteLine("\n"+vector.GetVectorCount());
            
        }

        
    }
}
