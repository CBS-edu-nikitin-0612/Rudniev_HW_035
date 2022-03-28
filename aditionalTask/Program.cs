using System;
using System.Reflection;

namespace aditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = null;
            assembly = Assembly.LoadFrom("Task2");

            Console.WriteLine("Info of assembly: ");
            Console.WriteLine("Full name: " + assembly.FullName);
            Console.WriteLine("Location: " + assembly.Location);

            Console.WriteLine(new string('-', 60));

            Type[] types = assembly.GetTypes();
            Console.WriteLine("Info of types: ");
            foreach (var item in types)
            {
                Console.WriteLine("Full name: " + item.FullName);
                Console.WriteLine("Base type: " + item.BaseType);
                Console.WriteLine("It is class: " + item.IsClass);
                Console.WriteLine("It is enum: " + item.IsEnum);
                Console.WriteLine(new string('*', 40));
            }
        }
    }
}
