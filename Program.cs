using System;
using System.Collections.Generic;

namespace DelegatesFilterExample
{
    class Program
    {
        public delegate bool FilterDelegate(Person p);
        static void Main(string[] args)
        {
            Person p1 = new Person() { Name = "John", Age = 41 };
            Person p2 = new Person() { Name = "Jane", Age = 69 };
            Person p3 = new Person() { Name = "Jake", Age = 12 };
            Person p4 = new Person() { Name = "Jessie", Age = 25 };

            List<Person> people = new List<Person>() { p1, p2, p3, p4 };

            DisplayPeople("Child:", people, IsChild);
            DisplayPeople("Adult:", people, IsAdult);
            DisplayPeople("Senior:", people, IsSenior);
        }

        static void DisplayPeople(string title, List<Person> people, FilterDelegate filter)
        {
            Console.WriteLine(title);
            foreach (var item in people)
            {
                if (filter(item))
                {
                    Console.WriteLine(format: "{0}, {1} years old", item.Name, item.Age);
                }
            }
        }

        static bool IsChild(Person p)
        {
            return p.Age < 18;
        }
        static bool IsAdult(Person p)
        {
            return p.Age >= 18;
        }
        static bool IsSenior(Person p)
        {
            return p.Age > 65;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
