using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    //Полиморфизм.
    //для того чтобы обязать классы-наследники переопределить методы
    //и пользоваться полями базового класса, необходимо создать контракт.
    //для этого в базовом классе объявляется абстрактный метод, в котором
    //не указывается реализация, она будет определяться в наследниках
    //класс должен быть абстрактным, но не все методы обязаны быть абстрактными
    public abstract class Shape
    {
        //в конкретном примере экземпляр Shape нельзя создать
        public Shape()
        {
            Console.WriteLine("Shape created");
        }
        public abstract void Draw();
        public abstract double Area();
        public abstract double Perimeter();
    }

    public class Triangle : Shape, IBaseCollection
    {
        private readonly double a, b, c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            Console.WriteLine("Triangle created");

        }
        public override double Area()
        {
            return Calculator.TriangleSquare(a, b, c);
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Triangle");
        }

        public override double Perimeter()
        {
            return a + b + c;
        }

        void IBaseCollection.Add(object obj)
        {
            throw new NotImplementedException();
        }

        void IBaseCollection.Remove(object obj)
        {
            throw new NotImplementedException();
        }
    }

    public class Rectangle : Shape
    {
        private readonly double width;
        private readonly double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
            Console.WriteLine("Rectangle created");
        }        

        public override double Area()
        {
            return width * height;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public override double Perimeter()
        {
            return 2 * (width + height);
        }
    }
}
