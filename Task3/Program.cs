using System;
using System.Reflection;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {            
            Assembly assembly = null;
            assembly = Assembly.LoadFrom("Task2");

            Type[] types = assembly.GetTypes();

            Type T = null;
            foreach (var item in types)
            {
                if (item.Name == "Temperature")
                    T = item;
            }

            ConstructorInfo tCtor = T.GetConstructor(Type.EmptyTypes);
            var t = tCtor.Invoke(new object[] { });

            Console.WriteLine(t.ToString()); 

            MethodInfo tMethodConvert = T.GetMethod("ConvertToFahrenheit");

            tMethodConvert.Invoke(t, new object[] { });
            Console.WriteLine(t.ToString());
        }
    }
}
