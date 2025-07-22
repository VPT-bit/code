using System;
namespace bai4._1
{
    public abstract class Shape : IComparable<Shape>
    {
        public abstract string? Name { get; set; }
        public abstract double Area();
        public int CompareTo(Shape? other)
        {
            if (other == null) return 1;
            if (this.Area() < other.Area()) return 1;
            else if (this.Area() > other.Area()) return -1;
            else return 0;
        }
    }

    public class Rectangle : Shape, IComparable<Rectangle>
    {
        private double _width = 0;
        private double _height = 0;
        public double Width
        {
            get => _width; 
            set
            {
                if (value < 0)
                    throw new ArgumentException("Width cannot be negative");
                _width = value;
            }
        }
        public double Height
        {
            get => _height;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Height cannot be negative");
                _height = value;
            }
        }
        public override string? Name { get; set; } = "Rectangle";
        public Rectangle(double w = 0, double h = 0) 
        {
            Width = w;
            Height = h;
        }
        public override double Area()
        {
            return Width * Height;
        }
        public int CompareTo(Rectangle? other)
        {
            if (other == null) return 1;
            if (this.Area() < other.Area()) return 1;
            else if (this.Area() > other.Area()) return -1;
            else return 0;
        }
    }

    public class Circle : Shape, IComparable<Circle>
    {
        private double _radius = 0;
        public double Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Radius cannot be negative");
                _radius = value;
            }
        }
        public override string? Name { get; set; } = "Circle";
        public Circle(double r = 0)
        {
            Radius = r;
        }
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
        public int CompareTo(Circle? other)
        {
            if (other == null) return 1;
            if (this.Area() < other.Area()) return 1;
            else if (this.Area() > other.Area()) return -1;
            else return 0;
        }
    }

    public class Triagle : Shape, IComparable<Triagle>
    {
        private double _a = 0;
        private double _b = 0;
        private double _c = 0;
        public double A
        {
            get => _a;
            set
            {
                if (value < 0)
                    throw new ArgumentException("A cannot be negative");
                _a = value;
            }
        }
        public double B
        {
            get => _b;
            set
            {
                if (value < 0)
                    throw new ArgumentException("B cannot be negative");
                _b = value;
            }
        }
        public double C
        {
            get => _c;
            set
            {
                if (value < 0)
                    throw new ArgumentException("C cannot be negative");
                _c = value;
            }
        }
        public override string? Name { get; set; } = "Triangle";
        public Triagle(double a = 0, double b = 0, double c = 0)
        {
            A = a;
            B = b;
            C = c;
        }
        public override double Area()
        {
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
        public int CompareTo(Triagle? other)
        {
            if (other == null) return 1;
            if (this.Area() < other.Area()) return 1;
            else if (this.Area() > other.Area()) return -1;
            else return 0;
        }
    }

    public class Square : Rectangle, IComparable<Square>
    {
        public double Side
        {
            get => Width;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Side cannot be negative");
                Width = value;
                Height = value;
            }
        }
        public override string? Name { get; set; } = "Square";
        public Square(double s = 0) : base(s, s)
        {
            Side = s;
        }
        public override double Area()
        {
            return Side * Side;
        }
        public int CompareTo(Square? other)
        {
            if (other == null) return 1;
            if (this.Area() < other.Area()) return 1;
            else if (this.Area() > other.Area()) return -1;
            else return 0;
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<Shape> shapes = new List<Shape>
            {
                new Rectangle(3, 4),
                new Circle(5),
                new Triagle(3, 4, 5),
                new Square(2)
            };
            Console.WriteLine("Danh sach cac hinh: ");
            foreach (var shape in shapes)
            {
                Console.WriteLine("{0}: {1}", shape.Name, shape.Area());
            }
            shapes.Sort();
            Console.WriteLine("Danh sach cac hinh sau khi sap xep: ");
            foreach (var shape in shapes)
            {
                Console.WriteLine("{0}: {1}", shape.Name, shape.Area());
            }
        }
    }
}