using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace Homework20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, put the path of assembly");
            FileInfo f = new FileInfo(Console.ReadLine());

            Assembly assembly = Assembly.LoadFrom(f.FullName);
            Type type = assembly.GetType();
            Console.WriteLine(type);

            Console.WriteLine("Realized interfaces:");
            foreach (Type i in type.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }

            Console.WriteLine("Methods:");
            foreach (MethodInfo method in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                string modificator = "";
                if (method.IsPublic)
                    modificator += "public";
                else if (method.IsPrivate)
                    modificator += "private";
                else if (method.IsAssembly)
                    modificator += "internal";
                else if (method.IsFamily)
                    modificator += "protected";
                else if (method.IsConstructor)
                    modificator += "constructor";
                else if (method.IsAbstract)
                    modificator += "abstract";
                Console.WriteLine($"{modificator}{method.ReturnType.Name} {method.Name} ()");
            }
        }
    }
}