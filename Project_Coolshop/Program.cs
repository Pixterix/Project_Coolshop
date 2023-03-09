using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Coolshop
{
    public class Person
    {
        int Index;
        string Surname;
        string Name;
        string Date;

        public Person(int NewIndex, string NewSurname, string NewName, string NewDate)
        {
            Index = NewIndex;
            Surname = NewSurname;
            Name = NewName;
            Date = NewDate;
        }

        public String Info()
        {
            return Index.ToString() + "," + Surname + "," + Name + "," + Date;
        }

        public String InfoByNum(int N)
        {
            switch (N)
            {
                case 0:
                    return  Index.ToString();
                case 1:
                    return Surname;
                case 2:
                    return Name;
                case 3:
                    return Date;
                default:
                    return "Error";
            }
        }
    }
    class Program
    {
        static void Main(string[] argss)
        {
            String[] args = new String[4];
            args[1] = "file.csv";
            args[2] = "1";
            args[3] = "Gialli";
            List<Person> People = ReadFile(args[1]);
            foreach (Person P in People)
            {
                if (P.InfoByNum(int.Parse(args[2])) == args[3])
                {
                    Console.WriteLine(P.Info());
                }
            }
            Console.ReadLine();
        }

        static List<Person> ReadFile(String FileName)
        {
            List<Person> People = new List<Person>();
            String Line;
            try
            {
                StreamReader File = new StreamReader(FileName);
                Line = File.ReadLine();
                while (Line != null)
                {
                    String[] Info = Line.Split(',');
                    Person NewPerson = new Person(int.Parse(Info[0]), Info[1], Info[2], Info[3]);
                    People.Add(NewPerson);
                    Line = File.ReadLine();
                }
                File.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Execption: " + e.Message);
                Console.ReadLine();
            }
            return People;
        }
    }
}
