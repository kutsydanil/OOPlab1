using System;
using Lab1;

namespace ConsoleApp1
{
    class Program
    {
        static Trapezia newTrapecia()
        {
            Trapezia trapezia;
            double a, b;
            Console.WriteLine("Ввод значений переменной a и b");
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите значение a(координату основания): ");
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите значение b(координату основания): ");
                    b = Convert.ToDouble(Console.ReadLine());
                    trapezia = new Trapezia(a, b);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода значения(неверный формат)!");
                }
            }
            return trapezia;
        }
        static void Main(string[] args)
        {
            Trapezia trapezia = newTrapecia();
            if (trapezia.Correct())
            {
                bool flag = true;
                while (flag)
                {
                    int N;
                    Console.WriteLine("     Меню: ");
                    Console.WriteLine("     1 - Подсчет значений сторон трапеции");
                    Console.WriteLine("     2 - Подсчет периметра трапеции");
                    Console.WriteLine("     3 - Подсчет площади трапеции");
                    Console.WriteLine("     4 - Проверка принадлежности точки");
                    Console.WriteLine("     5 - Создание новой трапеции");
                    Console.WriteLine("     Выход");

                    Console.WriteLine("Введите пункт меню: ");
                    N = Convert.ToInt32(Console.ReadLine());
                    switch (N)
                    {
                        case 1:
                            int i = 1;
                            Console.WriteLine("Длинны сторон трапеции: ");
                            foreach (double side in trapezia.FindSidesLen())
                            {
                                Console.WriteLine("№" + Convert.ToString(i) + " = " + Convert.ToString(side));
                                i = i + 1;
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Периметр равен: " + trapezia.FindPerim());
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Площадь равна: " + trapezia.FindSquare());
                            break;
                        case 4:
                            double X, Y;
                            Console.WriteLine("Ввод значений для проверки на принадлежность трапеции");
                            Console.WriteLine("Введите значение X: ");
                            X = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите значение Y:");
                            Y = Convert.ToDouble(Console.ReadLine());
                            if (trapezia.CheckPoint(X, Y))
                            {
                                Console.WriteLine("Точки принадлежат трапеции");
                            }
                            else Console.WriteLine("Точки не лежат в трапеции");
                            break;
                        case 5:
                            Console.WriteLine("Создание новой трапеции");
                            trapezia = newTrapecia();
                            break;
                        case 6:
                            Console.WriteLine("Завершение работы");
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Нет такого пункта меню");
                            break;
                            
                    }
                }
            }
            else Console.WriteLine("Ввод некорректных данных");
        }
    }
}