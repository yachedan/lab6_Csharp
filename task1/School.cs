using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace task1
{
    public class School
    {
        private string[] _pibTeacher;
        private string[][] _subjects;
        private int[] _classes;
        private DateTime[] _dateBirth;

        public string[] PIB_Teacher
        {
            get { return _pibTeacher; }
            set
            {
                foreach (string elem in value)
                    if (Regex.Match(elem, "^[A-Za-z ]+$").Success)
                        _pibTeacher = value;
                    else
                        throw new ArgumentException("Wrong input");
            }
        }

        public string[][] Subjects
        {
            get { return _subjects; }
            set { _subjects = value; }
        }
        public int[] Classes { get { return _classes; } set { _classes = value; } }
        public DateTime[] DateBirth
        {
            get { return _dateBirth; }
            set { _dateBirth = value; }
        }
        public int Retiree
        {
            get
            {
                int count = 0;
                foreach (DateTime date in DateBirth)
                    if ((DateTime.Now.Year - date.Year) >= 60)
                        count++;
                return count;
            }
        }   
        public object this[int i, int j]
        {
            get
            {if(i == 0)
                return _classes[j];
            else if(i == 1)
                return _dateBirth[j];
            else
                throw new ArgumentException("Wrong index!");
            }
            set
            {if(i == 0)
                _classes[j] =Convert.ToInt32(value);
            else if(i == 1)
                _dateBirth[j] = Convert.ToDateTime(value);
            else
                    throw new ArgumentException("Wrong index!");
            }
        }
        public School()
        {

        }
        public School(string[] pib_Teacher, string[][] subjects, int[] classes, DateTime[] dateBirth)
        {
            _pibTeacher = pib_Teacher;
            _subjects = subjects;
            _classes = classes;
            _dateBirth = dateBirth;
        }
        public School(int number)
        {
            this._pibTeacher = new string[number];
            this._subjects = new string[number][];
            this._classes = new int[number];
            this._dateBirth = new DateTime[number];
        }
        public void SetTeachers()
        {
            Console.WriteLine("Input number of teachers: ");
            int number = Convert.ToInt32(Console.ReadLine());
            _pibTeacher = new string[number];
            _subjects = new string[number][];
            _classes = new int[number];
            _dateBirth = new DateTime[number];
            for (int i = 0; i < number; i++)
            {

                Console.Write("\nEnter name: ");
                string test = Console.ReadLine();
                while (!Regex.Match(test, "^[A-Za-z ]+$").Success)
                {
                    Console.WriteLine("Wrong name! Try again: ");
                    test = Console.ReadLine();
                }
                _pibTeacher[i] = test;
                Console.Write("Enter number of subjects: ");
                test = Console.ReadLine();
                while (!Regex.Match(test, "[1-9]{1}").Success)
                {
                    Console.WriteLine("Wrong number! Try again: ");
                    test = Console.ReadLine();
                }
                int subNumber = Convert.ToInt32(test);
                _subjects[i] = new string[subNumber];
                for (int j = 0; j < subNumber; j++)
                {
                    Console.Write("Subject " + j + ": ");
                    _subjects[i][j] = Console.ReadLine();
                }
                Console.Write("Enter number of classes: ");
                test = Console.ReadLine();
                while (!Regex.Match(test, "[1-9]").Success)
                {
                    Console.WriteLine("Wrong number! Try again: ");
                    test = Console.ReadLine();
                }
                _classes[i] = Convert.ToInt32(test);
                Console.Write("Enter date of birth: ");
                DateTime tempDate;
                while (!DateTime.TryParse(Console.ReadLine(), out tempDate))
                {
                    Console.WriteLine("Wrong date! Try again: ");
                }
                _dateBirth[i] = tempDate;
            }
        }
        public void GetTeachers()
        {
            for (int i = 0; i < _pibTeacher.Length; i++)
            {

                Console.Write("\nName: " + _pibTeacher[i] + "\n" + "Subjects: ");
                Console.Write("[");
                for (int j = 0; j < _subjects[i].Length; j++)
                {
                    Console.Write(_subjects[i][j] + ", ");
                }
                Console.Write("]");
                Console.WriteLine("\n" + "Classes: " + _classes[i] + "\n" + "Date Of Birth:" + _dateBirth[i]);
            }
        }
        public int Overwork()
        {
            int count = 0;
            for (int i = 0; i < _pibTeacher.Length; i++)
                if (_classes[i] > 4)
                    count++;
            return count;
        }
        
        public static School operator ++(School school) 
        {
            for (int i = 0; i < school._classes.Length; i++)
            {
                school._classes[i] +=1;
                school._dateBirth[i] = school._dateBirth[i].AddDays(1);
            }
            return school;
        }
        public static School operator --(School school)
        {
            for (int i = 0; i < school._classes.Length; i++)
            {
                school._classes[i] -= 1;
                school._dateBirth[i] = school._dateBirth[i].AddDays(-1);
            }
            return school;
        }

        public static Boolean operator !(School school)
        {
             if(school._classes.Length >= 3)
                return true;
            else
                return false;
        }
        public static School operator +(School school, int integer)
        {
            for (int i = 0; i < school._classes.Length; i++)
                school._classes[i] += integer;
            return school;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < _pibTeacher.Length; i++)
            {

                result += "\nName: " + _pibTeacher[i] + "\n" + "Subjects: ";
                result += "[";
                for (int j = 0; j < _subjects[i].Length; j++)
                {
                    result += _subjects[i][j] + ", ";
                }
                result += "]";
                result += "\n" + "Classes: " + _classes[i] + "\n" + "Date Of Birth:" + _dateBirth[i] +"\n";
            }
            return result;
        }

    }
}
