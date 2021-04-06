using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            VectorDecimal vector = new(3);
            vector.SetVector();
            vector.DecimalArray[1] = 80;
            vector.GetVector();
            VectorDecimal vector2 = new(3);
            vector2[0] = 10;
            vector2[1] = 20;
            vector2[2] = 30;
            Console.WriteLine("Vector count:");
            Console.WriteLine("\n"+vector.GetVectorCount());
            vector++;
            Console.WriteLine("Vector ++:");
            vector.GetVector();
            vector--;
            Console.WriteLine("\nVector --:");
            vector.GetVector();
            Console.WriteLine("\nVector bool:");
            if(vector)
                Console.WriteLine("true");
            Console.WriteLine("\nVector +:");
            Console.WriteLine((vector+vector2).ToString());
            Console.WriteLine("\nVector *:");
            Console.WriteLine((vector * 2).ToString());
            Console.WriteLine("\nVector >= :");
            Console.WriteLine(vector>vector2);
        }

        
    }
}
