using System;
using System.Globalization;
namespace Test
{
    public abstract class Shape : IComparable<Shape>
    {
        public abstract string Name { get; set; }
        public abstract double Area();
        public int CompareTo(Shape? s)
        {
            if (s == null) return 1;
            if (this.Area() > s.Area()) return 1;
            else if (this.Area() < s.Area()) return -1;
            else return 0;
        }
    }
    public class Rectangle : Shape, ICloneable, IComparable<Rectangle>
    {
        public override string Name { get; set; } = "Rectangle";
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double w, double h)
        {
            Width = w;
            Height = h;
        }
        public object Clone()
        {
            return new Rectangle(Width, Height);
        }
        public override double Area()
        {
            return Width * Height;
        }
        public int CompareTo(Rectangle? r)
        {
            if (r is null) return 1;
            if (this.Area() > r.Area()) return 1;
            else if (this.Area() < r.Area()) return -1;
            else return 0;
        }
        public override string ToString()
        {
            return Name + ":" + Width + ":" + Height + ":" + Area();
        }
    }
    public class Triagle : Shape, ICloneable, IComparable<Triagle>
    {
        public override string Name { get; set; } = "Triagle";
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }   
        public Triagle(double a = 0, double b = 0, double c = 0)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public object Clone()
        {
            return new Triagle(a, b, c);
        }
        public override double Area()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public int CompareTo(Triagle? t)
        {
            if (t is null) return 1;
            if (this.Area() > t.Area()) return 1;
            else if (this.Area() < t.Area()) return -1;
            else return 0;
        }
        public override string ToString()
        {
            return Name + ":" + a + ":" + b + ":" + c + ":" + Area();
        }
    }
    public class Circle : Shape, ICloneable, IComparable<Circle>
    {
        public override string Name { get; set; } = "Circle";
        public double r { get; set; }
        public Circle(double r = 0)
        {
            this.r = r;
        }
        public object Clone()
        {
            return new Circle(r);
        }
        public override double Area()
        {
            return Math.PI * r * r;
        }
        public int CompareTo(Circle? c)
        {
            if (c is null) return 1;
            if (this.Area() > c.Area()) return 1;
            else if (this.Area() < c.Area()) return -1;
            else return 0;
        }
        public override string ToString()
        {
            return Name + ":" + r + ":" + Area();
        }
    }
    public class Square : Rectangle, ICloneable, IComparable<Square>
    {
        public override string Name { get; set; } = "Square";
        public Square(double w = 0) : base(w, w) { }
        public new Square Clone()
        {
            return new Square(Width);
        }
        public override double Area()
        {
            return Width * Width;
        }
        public int CompareTo(Square? s)
        {
            if (s is null) return 1;
            if (this.Area() > s.Area()) return 1;
            else if (this.Area() < s.Area()) return -1;
            else return 0;
        }
        public override string ToString()
        {
            return Name + ":" + Width + ":" + Area();
        }
    }
    public class Program
    {
        public static void Main()
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Rectangle(4, 5));
            shapes.Add(new Rectangle(10, 2.5));
            shapes.Add(new Triagle(3, 4, 5));
            shapes.Add(new Circle(10));
            shapes.Add(new Square(5));
            Square s = new Square(9);
            Square ss = s.Clone();
            shapes.Add(ss);
            Console.WriteLine("Mang truoc khi sort:");
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }
            shapes.Sort();
            Console.WriteLine("Mang sau khi sort");
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }
        }
    }
}