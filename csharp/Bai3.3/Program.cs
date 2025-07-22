using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_3_3
{
  abstract class HinhVe
  {
    //Phuong thuc DienTich() duoc khai bao abstract bat buoc cac lop ke thua phai override(dinh nghia lai)
    public abstract double DienTich();
  }
  class HinhChuNhat : HinhVe
  {
    public double Width { get; set; }
    public double Height { get; set; }
    public HinhChuNhat() { }
    public HinhChuNhat(double width, double height)
    {
      Width=width;
      Height=height;
    }
    public override double DienTich()
    {
      return Width * Height;
    }
  }
  class HinhVuong : HinhChuNhat
  {
    public HinhVuong(double width) : base(width, width) { }
  }
  class HinhTron : HinhVe
  {
    public double BanKinh { get; set; }
    public HinhTron(double banKinh)
    {
      BanKinh = banKinh;
    }
    public override double DienTich()
    {
      return Math.PI * BanKinh * BanKinh;
    }
  }
  class Program
  {
    static void Main()
    {
      HinhVe hinh = null;
      Console.WriteLine("Tinh dien tich HCN:1, HV:2, HT:3");
      int chon = int.Parse(Console.ReadLine());
      switch (chon)
      {
        case 1:
          Console.Write("Nhap chieu dai:");
          double Width = double.Parse(Console.ReadLine());
          Console.Write("Nhap chieu rong:");
          double Height = double.Parse(Console.ReadLine());
          hinh = new HinhChuNhat(Width, Height);
          break;
        case 2:
          Console.Write("\nNhap 1 canh:");
          double Canh = double.Parse(Console.ReadLine());
          hinh = new HinhVuong(Canh);
          break;
          case 3:
          Console.Write("\nNhap ban kinh:");
          double BanKinh = double.Parse(Console.ReadLine());
          hinh = new HinhTron(BanKinh);
          break;
          default:
          Console.WriteLine("Khong hop le");
          return;
      }
      Console.WriteLine("Dien tich la: {0:F2}", hinh.DienTich());
    }
  }
}