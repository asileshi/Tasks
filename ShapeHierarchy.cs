using System;

namespace ShapeHierarchy
{
    abstract public class Shape
    {
        private string name;

        public Shape(string name)
        {
            this.name = name;
        }

        abstract public double CalculateArea();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    public class Circle : Shape
    {
        public double Radius;

        public Circle(double radius) : base("Circle")
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : Shape
    {
        public double Width;
        public double Height;

        public Rectangle(double width, double height) : base("Rectangle")
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Triangle : Shape
    {
        public double Base;
        public double Height;

        public Triangle(double @base, double height) : base("Triangle")
        {
            Base = @base;
            Height = height;
        }

        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }

    class Program
    {
        public static void PrintShapeArea(Shape shape)
        {
            Console.WriteLine($"Shape is: {shape.Name}");
            Console.WriteLine($"Area is: {shape.CalculateArea()}");
        }

        public static void Main()
        {
            Circle circle = new Circle(3.2);
            Rectangle rectangle = new Rectangle(3, 4);
            Triangle triangle = new Triangle(2, 4);

            PrintShapeArea(circle);
            PrintShapeArea(rectangle);
            PrintShapeArea(triangle);
        }
    }
}
