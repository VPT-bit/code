using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NhanVien
{
  private string hoTen;
  public string HoTen{get;set;}
  private DateTime ngaySinh;
  public DateTime NgaySinh{get;set;}
  private double luong;
  public double Luong{get;protected set;}
  public NhanVien() { }
  public NhanVien(string ten, DateTime ns, double luong)
  {
    HoTen = ten;
    NgaySinh = ns;
    Luong = luong;
  }
  public NhanVien(NhanVien nv)
  {
    HoTen = nv.HoTen;
    NgaySinh = nv.NgaySinh;
    Luong = nv.Luong;
  }
  public virtual void Nhap()
  {
    Console.Write("Nhap ho ten:");
    hoTen = Console.ReadLine();
    Console.Write("Nhap ngay sinh(dd/MM/yyyy):");
    ngaySinh=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
    Console.Write("Nhap luong:");
    luong = double.Parse(Console.ReadLine());
  }
  public virtual void Xuat()
  {
    Console.WriteLine("Ho ten:{0}", hoTen);
    Console.WriteLine("Ngay sinh:{0}", ngaySinh);
    Console.WriteLine("Luong:{0:F2}", luong);
  }
  //Phuong thuc ao se duoc lop con trien khai
  public virtual void TinhLuong(){}
}
class NhanVienSanXuat:NhanVien
{
  private double luongCanBan;
  public double LuongCanBan{get;set;}
  private int soSanPham;
  public int SoSanPham{get;set;}
  public override void Nhap()
  {
    base.Nhap();
    Console.Write("Nhap luong can ban:");
    luongCanBan=double.Parse(Console.ReadLine());
    Console.Write("Nhap so san pham:");
    soSanPham=int.Parse(Console.ReadLine());
  }
  public override void TinhLuong()
  {
    Luong=LuongCanBan+SoSanPham*5000;
  }
  public override void Xuat()
  {
    base.Xuat();
    Console.WriteLine("Luong can ban:{0:F2}", luongCanBan);
    Console.WriteLine("So san pham:{0}", soSanPham);
  }
}
class NhanVienVanPhong:NhanVien
{
  private int soNgayLam;
  public int SoNgayLam{get;set;}

  public override void TinhLuong()
  {
    Luong=SoNgayLam*100000;
  }
  public override void Nhap()
  {
    base.Nhap();
    Console.Write("Nhap so ngay lam:");
    soNgayLam=int.Parse(Console.ReadLine());
  }
  public override void Xuat()
  {
    base.Xuat();
    Console.WriteLine("So ngay lam:{0}", soNgayLam);
  }
}
class Program
{
  static void Main()
  {
    List<NhanVien> ds=new List<NhanVien>();
    Console.Write("Nhap so luong nhan vien:");
    int n=int.Parse(Console.ReadLine());
    for(int i=0;i<n;i++)
    {
      Console.WriteLine("Nhap nhan vien thu {0}:", i+1);
      Console.Write("Nhap loai nhan vien(1:San xuat, 2:Van phong):");
      int loai=int.Parse(Console.ReadLine());
      NhanVien nv;
      if(loai==1)
      {
        nv=new NhanVienSanXuat();
      }
      else
      {
        nv=new NhanVienVanPhong();
      }
      nv.Nhap();
      ds.Add(nv);
    }
    Console.WriteLine("=========================================");
    Console.WriteLine("Danh sach nhan vien:");
    foreach(var nv in ds)
    {
      nv.TinhLuong();
      nv.Xuat();
      Console.WriteLine("--------");
    }
    Console.WriteLine("=========================================");
    Console.WriteLine("Danh sach nhan vien thu tu giam dan theo luong");
    var dsGiamLuong=ds.OrderByDescending(nv=>nv.Luong).ToList();
    foreach(var nv in dsGiamLuong)
    {
      nv.Xuat();
      Console.WriteLine("--------");
    }
  }
}