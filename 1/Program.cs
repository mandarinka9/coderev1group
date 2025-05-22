using System;
using System.Linq;

namespace _1labasharpcoderev {
    public class Program {
        public static void Main() {
            Console.WriteLine("Введите текст для главного класса:");
            string inputText = Console.ReadLine();
            FirstClass textBase = new FirstClass(inputText);

            Console.WriteLine("\nТестирование базового класса:");
            Console.WriteLine(textBase.ToString());
            Console.WriteLine(textBase.FirstAndLast());

            FirstClass copyBase = new FirstClass(textBase);
            Console.WriteLine("Копия базового класса:");
            Console.WriteLine(copyBase.ToString());

            Console.WriteLine("\nВведите текст для дочернего класса:");
            string secondText = Console.ReadLine();
            SecondClass secondClassInstance = new SecondClass(secondText);

            Console.WriteLine("\nТестирование дочернего класса:");
            Console.WriteLine(secondClassInstance.ToString());
            Console.WriteLine($"Длина строки: {secondClassInstance.Length}");
            Console.WriteLine($"Строка в верхнем регистре: {secondClassInstance.Vverh()}");
            Console.WriteLine($"Количество гласных: {secondClassInstance.CountGlas()}");

            Console.WriteLine("\nТестирование пустой строки:");
            FirstClass emptyBase = new FirstClass("");
            Console.WriteLine(emptyBase.ToString());
            Console.WriteLine(emptyBase.FirstAndLast());

            Console.ReadKey();
        }
    }
}
