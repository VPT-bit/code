using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_3_1
{
  class Xe
  {
    public string BienSo{get;set;}
    public int NamSanXuat{get;set;}

    public double Gia{get;set;}
    //Constructor khong tham so
    public Xe(){}

    //Constructor co tham so
    public Xe(string bienSo, int namSanXuat, double gia)
    {
      BienSo=bienSo;
      NamSanXuat=namSanXuat;
      Gia=gia;
    }
    //Cai dat phuong thuc Nhap() de nhap thong tin xe
    public virtual void Nhap()
    {
      Console.Write("Nhap bien so xe:");
      BienSo=Console.ReadLine();
      Console.Write("Nhap nam san xuat:");
      NamSanXuat=int.Parse(Console.ReadLine());
      Console.Write("Nhap gia xe:");
      Gia=double.Parse(Console.ReadLine());
    }
    //Cai dat phuong thuc Xuat() de xuat thong tin xe
    public virtual void Xuat()
    {
      Console.WriteLine("Bien so xe:"+BienSo);
      Console.WriteLine("Nam san xuat:"+NamSanXuat);
      Console.WriteLine("Gia xe:"+Gia);
    }
  }
  //Class XeCon ke thua class Xe
  class XeCon : Xe
  {

    public int SoChoNgoi{get;set;}
    public string LoaiXe{get;set;}
    
    //Constructor khong tham so
    public XeCon() {}

    //Constructor co tham so
    //base dung de goi constructor cua lop cha de khoi tao BienSo, NamSanXuat va Gia
    public XeCon(string bienSo, int namSanXuat, double gia,int soChoNgoi,string loaiXe):base(bienSo,namSanXuat,gia)
    {
      SoChoNgoi=soChoNgoi;
      LoaiXe=loaiXe;
    }
    //Cai dat phuong thuc Nhap() de nhap thong tin xe con va su dung tu khoa override de cai dat lai phuong thuc Nhap() cua lop cha
    public override void Nhap()
    {
      //Goi base.Nhap() de nhap thong tin co ban truoc
      base.Nhap();
      //Sau do nhap SoChoNgoi va LoaiXe
      Console.Write("Nhap so cho ngoi:");
      SoChoNgoi=int.Parse(Console.ReadLine());
      Console.Write("Nhap loai xe:");
      LoaiXe=Console.ReadLine();
    }
    public override void Xuat()
    {
      //Goi base.Xuat() de xuat thong tin co ban truoc
      base.Xuat();
      //Sau do xuat SoChoNgoi va LoaiXe
      Console.WriteLine("So cho ngoi:"+SoChoNgoi);
      Console.WriteLine("Loai xe:"+LoaiXe);
    }
  }
  public class Program
  {
    static void Main()
    {
      //Tao danh sach XeCon de chua cac xe con
      List<XeCon> dsXeCon=new List<XeCon>();

      //Nhap so luong xe con
      Console.Write("Nhap so luong xe con:");
      int n=int.Parse(Console.ReadLine());

      //Nhap thong tin cac xe con
      for(int i=0;i<n;i++)
      {
        Console.WriteLine("Nhap thong tin xe con thu:{0}",i+1);
        XeCon xe=new XeCon();
        xe.Nhap();
        dsXeCon.Add(xe);
      }
      //Xuat thong tin cac xe con
      Console.WriteLine("---------------------------");
      Console.WriteLine("Thong tin cac xe con:");
      Console.WriteLine("---------------------------");
      foreach(XeCon xe in dsXeCon)
      {
        xe.Xuat();
        Console.WriteLine("======");
      }
      //Tim xe co gia thap nhat
      var giaMin=dsXeCon.Min(xe=>xe.Gia);
      var giaXeMinList=dsXeCon.Where(xe=>xe.Gia==giaMin).ToList();
      Console.WriteLine("\nXe co gia thap nhat la:");
      //Xuat thong tin xe co gia thap nhat
      foreach(var xe in giaXeMinList)
      {
        xe.Xuat();
      }
     //Tim xe co gia cao nhat
      var giaMax=dsXeCon.Max(xe=>xe.Gia);
      var giaXeMaxList=dsXeCon.Where(xe=>xe.Gia==giaMax).ToList();
      Console.WriteLine("\nXe co gia cao nhat la:");
      //Xuat thong tin xe co gia cao nhat
      foreach(var xe in giaXeMaxList)
      {
        xe.Xuat();
      }

      //Loc xe theo bien so tinh
      Console.WriteLine("\nNhap 2 chu so dau bien so can tim");
      //Nhap 2 so dau cua bien so
      string bienSoTinh=Console.ReadLine();
      //Dung Where loc danh sach xe co bien so bat dau bang so do
      var bienSoTinhList=dsXeCon.Where(xe=>xe.BienSo.StartsWith(bienSoTinh)).ToList();
      Console.WriteLine("\nXe co bien so bat dau bang {0} la:",bienSoTinh);
      //Xuat thong tin cac xe co bien so bat dau bang so do
      foreach(var xe in bienSoTinhList)
      {
        xe.Xuat();
      }
      //Sap xep danh sach xe theo thu tu tang dan cua nam san xuat, in ra danh sach sau sap xep
      var dsXeConSapXep=dsXeCon.OrderBy(xe=>xe.NamSanXuat).ToList();
      Console.WriteLine("Danh sach xe sau sap xep theo nam san xuat tang dan:");
      foreach(var xe in dsXeConSapXep)
      {
        xe.Xuat();
      }
    }
  }
}