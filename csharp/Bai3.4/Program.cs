using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3_4
{
  class Printer
  {
    private string nhaSX;
    public string NhaSX { get; set; }
    private double giaBan;
    public double GiaBan { get; set; }

    //Constructors
    public Printer() { }
    public Printer(Printer prt)
    {
      NhaSX = prt.NhaSX;//Using properties to access fields
      GiaBan = prt.GiaBan;
    }
    //Nhap() function
    public virtual void Nhap()
    {
      Console.Write("Nhap nha san xuat: ");
      NhaSX = Console.ReadLine();
      Console.Write("Nhap gia ban: ");
      GiaBan = double.Parse(Console.ReadLine());
    }
    //Xuat() function
    public virtual void Xuat()
    {
      Console.WriteLine("Nha san xuat:{0}", NhaSX);
      Console.WriteLine("Gia ban:{0:F2}", GiaBan);
    }
  }
  class LaserPrinter : Printer
  {
    private string doPhanGiai;
    public string DoPhanGiai { get; set; }
    //Constructor
    public LaserPrinter() { }
    //Nhap() function is inheritance
    public override void Nhap()
    {
      base.Nhap();
      Console.Write("Nhap do phan giai:");
      DoPhanGiai = Console.ReadLine();
    }
    //Xuat() func is inheritance
    public override void Xuat()
    {
      base.Xuat();
      Console.WriteLine("Do phan giai:{0}", DoPhanGiai);
    }
  }
  class Program
  {
    static void Main()
    {
      List<LaserPrinter> ds = new List<LaserPrinter>();
      Console.Write("Nhap so may in laser:");
      int n = int.Parse(Console.ReadLine());
      for (int i = 0; i < n; i++)
      {
        Console.WriteLine("Nhap thong tin may in thu {0}", i + 1);
        LaserPrinter prt = new LaserPrinter();
        prt.Nhap();
        ds.Add(prt);
      }
      Console.WriteLine("Danh sach thong tin may in:");
      Console.WriteLine("==========");
      foreach (LaserPrinter prt in ds)
      {
        prt.Xuat();
        Console.WriteLine("==========");
      }
      var maxGia = ds.Max(prt => prt.GiaBan);
      var dsMaxGia = ds.Where(prt => prt.GiaBan == maxGia).ToList();
      Console.WriteLine("Danh sach may in gia cao nhat:");
      Console.WriteLine("**********************");
      foreach (LaserPrinter prt in dsMaxGia)
      {
        prt.Xuat();
      }
      var minGia = ds.Min(prt => prt.GiaBan);
      var dsMinGia = ds.Where(prt => prt.GiaBan == minGia).ToList();
      Console.WriteLine("Danh sach may in gia thap nhat:");
      Console.WriteLine("**********************");
      foreach (LaserPrinter prt in dsMinGia)
      {
        prt.Xuat();
      }
      Console.Write("Nhap ten hang can loc: ");
      string tenHang = Console.ReadLine();
      var dsLocTen = ds.Where(prt => prt.NhaSX == tenHang).ToList();
      Console.WriteLine("Danh sach loc theo ten hang:");
      Console.WriteLine("**********************");
      foreach (LaserPrinter prt in dsLocTen)
      {
        prt.Xuat();
        Console.WriteLine("==========");
      }
      var dsSXTang = ds.OrderBy(prt => prt.GiaBan).ToList();
      Console.WriteLine("Danh sach may in gia tang dan theo gia ban:");
      Console.WriteLine("**********************");
      foreach (LaserPrinter prt in dsSXTang)
      {
        prt.Xuat();
        Console.WriteLine("==========");
      }
    }
  }
}