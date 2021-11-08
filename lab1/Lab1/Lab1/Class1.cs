using System;

namespace Lab1
{
    public class Trapezia
    {
        /// <summary>
        /// Основания трапеции
        /// <param name="a"> Левая граница основания </param>
        /// <param name="b"> Правая граница основания </param>
        /// <summary>

        private double a, b;

        /// <summary>
        /// Контсруктор класса Trapezia
        /// <summary>
        public Trapezia(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        /// <summary>
        /// Проверка на корректность ввода a и b
        /// <summary>
        public bool Correct()
        {
            if ((a > 1 && b > a) || (b <= Math.Log(a)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Подсчет значения интеграла 
        /// <summary>
        private double FindIntegral()
        {
            double len = 0;
            double dx = (b - a) / 1000;
            double X = a;
            double Xy = a + dx;
            while (Xy < b)
            {
                len += Math.Sqrt(Math.Pow(Xy - X, 2) + Math.Pow(Math.Log(Xy) - Math.Log(X), 2));
                X += dx;
                Xy += dx;
            }
            return len;

        }
        /// <summary>
        /// Подсчет длины сторон трапеции
        /// <summary>
        public double[] FindSidesLen()
        {
            double[] sides = new double[4];
            sides[0] = b - a;
            sides[1] = Math.Abs(Math.Cos(b));
            sides[2] = FindIntegral();
            sides[3] = Math.Abs(Math.Cos(a));
            return sides;
        }
        /// <summary>
        /// Нахождение площади трапеции
        /// <summary>
        public double FindSquare()
        {
            return (Math.Log(b) - Math.Log(a));
        }
        /// <summary>
        /// Нахождение периметра трапеции
        /// <summary>
        public double FindPerim()
        {
            double per = 0;
            foreach (double side in this.FindSidesLen())
            {
                per = per + side;
            }
            return per;
        }
        /// <summary>
        /// Проверка точек на принадлежность
        /// <summary>
        public bool CheckPoint(double X, double Y)
        {
            if (X > b || X < a)
            {
                return false;
            }
            else if(Y < 0 || Y > Math.Log(X))
            {
                return false;
            }
            else return true;
        }
    }

}
