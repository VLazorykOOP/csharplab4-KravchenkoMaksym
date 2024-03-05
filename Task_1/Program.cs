using System;

namespace Task_1
{
    class ATriangle
    {
        // Поля
        protected int a;
        protected int b;
        private readonly string color; // колір трикутника

        // Конструктор
        public ATriangle(int sideA, int sideB, string triangleColor)
        {
            a = sideA;
            b = sideB;
            color = triangleColor;
        }

        // Індексатор
        public object this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return color;
                    default: throw new ArgumentException("Невірний індекс");
                }
            }
            set
            {
                switch (i)
                {
                    case 0: a = (int)value; break;
                    case 1: b = (int)value; break;
                    default: throw new ArgumentException("Невірний індекс");
                }
            }
        }

        // Перевантаження операцій
        public static ATriangle operator ++(ATriangle t)
        {
            t.a++;
            t.b++;
            return t;
        }

        public static ATriangle operator --(ATriangle t)
        {
            t.a--;
            t.b--;
            return t;
        }

        public static ATriangle operator +(ATriangle t, int scalar)
        {
            t.a += scalar;
            t.b += scalar;
            return t;
        }

        public static bool operator true(ATriangle t)
        {
            return t.a > 0 && t.b > 0 && t.a + t.b > t.GetHypotenuse();
        }

        public static bool operator false(ATriangle t)
        {
            return !(t.a > 0 && t.b > 0 && t.a + t.b > t.GetHypotenuse());
        }

        // Перетворення типів
        public static explicit operator string(ATriangle t)
        {
            return $"a = {t.a}, b = {t.b}, color = {t.color}";
        }

        public static explicit operator ATriangle(string s)
        {
            var parts = s.Split(',');
            return new ATriangle(int.Parse(parts[0].Split('=')[1]), int.Parse(parts[1].Split('=')[1]), parts[2].Split('=')[1]);
        }

        // Методи
        public void PrintSides()
        {
            Console.WriteLine($"Сторони трикутника: a = {a}, b = {b}, гiпотенуза = {GetHypotenuse()}");
        }

        public double CalculatePerimeter()
        {
            return a + b + GetHypotenuse();
        }

        public double CalculateArea()
        {
            return 0.5 * a * b;
        }

        public bool IsIsosceles()
        {
            return a == b || a == GetHypotenuse() || b == GetHypotenuse();
        }

        // Властивості
        public int SideA
        {
            get { return a; }
            set { a = value; }
        }

        public int SideB
        {
            get { return b; }
            set { b = value; }
        }

        public string Color
        {
            get { return color; }
        }

        // Приватний метод для розрахунку гіпотенузи
        private double GetHypotenuse()
        {
            return Math.Sqrt(a * a + b * b);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введiть сторону a:");
            int sideA = int.Parse(Console.ReadLine());

            Console.WriteLine("Введiть сторону b:");
            int sideB = int.Parse(Console.ReadLine());

            Console.WriteLine("Введiть колiр трикутника:");
            string triangleColor = Console.ReadLine();

            // Створення екземпляра класу ATriangle за допомогою конструктора
            ATriangle triangle = new ATriangle(sideA, sideB, triangleColor);

            Console.WriteLine("Iнформацiя про трикутник:");

            // Використання індексатора для отримання значень полів
            Console.WriteLine($"За допомогою індексатора: a = {triangle[0]}, b = {triangle[1]}, колір = {triangle[2]}");

            // Використання перевантажених операцій ++ та --
            triangle++;
            Console.WriteLine($"Збільшені значення a та b: a = {triangle.SideA}, b = {triangle.SideB}");

            // Використання перевантажених операцій +
            triangle = triangle + 5;
            Console.WriteLine($"Додано скаляр до a та b: a = {triangle.SideA}, b = {triangle.SideB}");

            // Використання перевантажених операторів true і false
            if (triangle)
                Console.WriteLine("Трикутник існує.");
            else
                Console.WriteLine("Такий трикутник не існує.");

            // Використання перетворення типу ATriangle в string
            string triangleString = (string)triangle;
            Console.WriteLine($"Перетворення в рядок: {triangleString}");

            // Використання перетворення string в ATriangle
            ATriangle newTriangle = (ATriangle)triangleString;
            Console.WriteLine($"Повернення з рядка: a = {newTriangle.SideA}, b = {newTriangle.SideB}, колір = {newTriangle.Color}");

        }
    }
}
