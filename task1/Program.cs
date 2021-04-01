using System;
using System.Linq;
namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            School school = new(5);
            //school.SetTeachers();
            Random random = new();
            DateTime start = new(1950,1,1);
            DateTime end = new(2002,1,1);
            int range = (end-start).Days;
            for (int i = 0; i < 5; i++)
            {

                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                school.PIB_Teacher[i] = new string(Enumerable.Repeat(chars, random.Next(3,15))
                  .Select(s => s[random.Next(s.Length)]).ToArray()); ;
                school.Classes[i] = random.Next(1,10);
                school.DateBirth[i] = start.AddDays(random.Next(range));
                school.Subjects[i] = new string[random.Next(1,5)];
                for (int j = 0; j < school.Subjects[i].Length; j++)
                {
                    school.Subjects[i][j] = new string(Enumerable.Repeat(chars, random.Next(3, 15))
                  .Select(s => s[random.Next(s.Length)]).ToArray()); ;
                }
            }
            Console.WriteLine(school[0,1]);
            school[0,1] = 200;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Classes: " + school[0,i] + " Date: " + school[1,i]);
            }
            school++;
            Console.WriteLine("\nOpearator++");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Classes: " + school[0, i] + " Date: " + school[1, i]);
            }
            Console.WriteLine("\nOperator !");
            Console.WriteLine(!school);
            Console.WriteLine("\nOperator +");
            school += 2;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Classes: " + school[0, i] + " Date: " + school[1, i]);
            }
            Console.WriteLine(school.ToString());
        }
    }
}
