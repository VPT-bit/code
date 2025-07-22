using System;
namespace BTStack
{
    class Stack
    {
        private List<int>? _stack;
        private int top = 0;
        private int max = 0;
        public List<int>? stack
        {
            get { return _stack; }
            set { _stack = value; }
        }
        public int Max { 
            get { return max; } 
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Size cannot be negative");
                }
                max = value;
            } 
        }
        public int Top
        {
            get { return top; }
            set { top = value; }
        }
       public Stack(int m = 0)
        {
            Max = m;
            Top = -1;
            stack = new List<int>(Max);
        }
       public void Push(int data)
        {
            if (Top == Max - 1)
            {
                Console.WriteLine("Stack Overflow");
            }
            else
            {
                Top++;
                stack.Add(data);
            }
        }

        public void Pop()
        {
            if (Top == -1)
            {
                Console.WriteLine("Stack Underflow");
            }
            else
            {
                stack.RemoveAt(Top);
                Top--;
            }
        }
        public int Peek()
        {
            return Top == -1 ? -1 : stack[Top];
        }
        public bool IsEmpty()
        {
            return Top == -1;
        }
        public virtual void Print() {}
    }

    class PrimeStack : Stack {
        public PrimeStack(int m = 0) : base(m) { }
        public override void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                while (stack.Count() != 0)
                {
                    if (stack.Count() == 1)
                    {
                        Console.Write(this.Peek());
                    }
                    else
                    {
                        Console.Write(this.Peek() + " * ");
                    }
                    this.Pop();
                }
                Console.WriteLine("");
            }
        }
    }
    class HexaStack : Stack
    {
        public HexaStack(int m = 0) : base(m) { }
        public override void Print()
        {
            if (IsEmpty()) Console.WriteLine("Stack is empty");
            else
            {
                while (stack.Count() != 0)
                {
                    if (10 <= this.Peek() && this.Peek() <= 15)
                    {
                        switch (this.Peek())
                        {
                            case 10:
                                Console.Write("A");
                                break;
                            case 11:
                                Console.Write("B");
                                break;
                            case 12:
                                Console.Write("C");
                                break;
                            case 13:
                                Console.Write("D");
                                break;
                            case 14:
                                Console.Write("E");
                                break;
                            case 15:
                                Console.Write("F");
                                break;
                        }
                    }
                    else
                    {
                        Console.Write(this.Peek());
                    }
                    this.Pop();
                }
                Console.WriteLine("");
            }
        }
    }
    class Program
    {
        public static void Main()
        {
            // prime
            Console.Write("Nhap so nguyen duong n: ");
            PrimeStack s1 = new PrimeStack(100);
            int n;
            if (int.TryParse(Console.ReadLine(), out n) == false)
            {
                Console.WriteLine("Nhap sai dinh dang");
                return;
            }
            if (n < 0)
            {
                Console.WriteLine("Nhap so nguyen duong");
                return;
            }
            int nClone = n;
            for (int i = 2; i<=Math.Sqrt(nClone); i++)
            {
                while (nClone % i == 0)
                {
                    s1.Push(i);
                    nClone /= i;
                }
            }
            if (nClone > 1)
            {
                s1.Push(nClone);
            }
            Console.Write("Tich cac so nguyen to: ");
            s1.Print();
            // hexa
            HexaStack s2 = new HexaStack(100);
            nClone = n;
            while (nClone != 0)
            {
                s2.Push(nClone % 16);
                nClone /= 16;
            }
            Console.Write("Chuyen thanh hexa: ");
            s2.Print();
        }
    }
}