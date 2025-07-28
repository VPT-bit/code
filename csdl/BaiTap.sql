create database BaiTap
go
use BaiTap
go

create table KhachSan(
MaKhachSan int constraint pk_KhachSan primary key,
TenKhachSan nvarchar(30),
DiaChi nvarchar(50))

create table Phong(
MaPhong int constraint pk_Phong primary key,
MaKhachSan int,
LoaiPhong nvarchar(30),
GiaPhong decimal(10, 2))

create table KhachHang(
MaKhachHang int constraint pk_KhachHang primary key,
HoTen nvarchar(30),
CMND char(9),
DiaChi nvarchar(50))

create table DatPhong(
MaDatPhong int constraint pk_DatPhong primary key,
MaKhachHang int,
MaPhong int,
NgayDen date,
NgayDi date,
SoNguoi int)

alter table Phong
add constraint fk_Phong_KhachSan foreign key (MaKhachSan) references KhachSan(MaKhachSan)

alter table DatPhong
add constraint fk_DatPhong_Phong foreign key (MaPhong) references Phong(MaPhong)
alter table DatPhong
add constraint fk_DatPhong_KhachHang foreign key (MaKhachHang) references KhachHang(MaKhachHang)

INSERT INTO KhachSan (MaKhachSan, TenKhachSan, DiaChi)
VALUES (1, N'Khách Sạn A', N'Hà Nội'),
       (2, N'Khách Sạn B', N'Đà Nẵng'),
       (3, N'Khách Sạn C', N'Hồ Chí Minh');

INSERT INTO Phong (MaPhong, MaKhachSan, LoaiPhong, GiaPhong)
VALUES (101, 1, N'Tiêu chuẩn', 500000),
       (102, 1, N'Cao cấp', 1000000),
       (201, 2, N'Tiêu chuẩn', 600000),
       (202, 2, N'Cao cấp', 1200000),
       (301, 3, N'Tiêu chuẩn', 700000);

INSERT INTO KhachHang (MaKhachHang, HoTen, CMND, DiaChi)
VALUES (1, N'Nguyễn Văn A', '123456789', N'Hà Nội'),
       (2, N'Trần Thị B', '987654321', N'Đà Nẵng'),
       (3, N'Lê Văn C', '567890123', N'Hồ Chí Minh');

INSERT INTO DatPhong (MaDatPhong, MaKhachHang, MaPhong, NgayDen, NgayDi, SoNguoi)
VALUES (1, 1, 101, '2024-06-10', '2024-06-15', 2),
       (2, 2, 201, '2024-06-05', '2024-06-08', 3),
       (3, 3, 301, '2024-06-20', '2024-06-22', 4),
       (4, 1, 102, '2024-07-01', '2024-07-03', 2),
       (5, 2, 202, '2024-06-12', '2024-06-16', 2);

select * from KhachSan;
select * from Phong;
select * from KhachHang;
select * from DatPhong;

--3
select KH.HoTen, KH.CMND, KS.TenKhachSan, P.LoaiPhong
from KhachSan KS
join Phong P on KS.MaKhachSan=P.MaKhachSan
join DatPhong DP on P.MaPhong=DP.MaPhong
join KhachHang KH on DP.MaKhachHang=KH.MaKhachHang
where month(DP.NgayDen)=6 and year(DP.NgayDi)=2024;

--4
select ks.TenKhachSan , sum(datediff(day, dp.NgayDen, dp.NgayDi) * p.GiaPhong) TongDoanhThu
from DatPhong dp
join Phong p on dp.MaPhong=p.MaPhong
join KhachSan ks on p.MaKhachSan=ks.MaKhachSan
where year(dp.NgayDen)=2024
group by ks.TenKhachSan;

--5
select top 1 ks.TenKhachSan , sum(datediff(day, dp.NgayDen, dp.NgayDi) * p.GiaPhong) TongDoanhThu
from DatPhong dp
join Phong p on dp.MaPhong=p.MaPhong
join KhachSan ks on p.MaKhachSan=ks.MaKhachSan
where year(dp.NgayDen)=2024
group by ks.TenKhachSan
order by TongDoanhThu desc;

--6
select kh.HoTen
from DatPhong dp
join KhachHang kh on dp.MaKhachHang=kh.MaKhachHang
join Phong p on dp.MaPhong=p.MaPhong
join KhachSan ks on p.MaKhachSan=ks.MaKhachSan
group by kh.HoTen
having count(distinct ks.MaKhachSan) = (select count(MaKhachSan) from KhachSan);


-- 7
create procedure ChenDuLieu @MaDatPhong int, @MaKhachHang int, @MaPhong int, @NgayDen date, @NgayDi date, @SoNguoi int
as
begin
	insert into DatPhong
	values (@MaDatPhong, @MaKhachHang, @MaPhong, @NgayDen, @NgayDi, @SoNguoi);
end;
go

execute ChenDuLieu 9, 2, 102, '2023-9-1', '2023-10-12', 3;

--8
create function dbo.DanhSachDatPhongTheoCMND (@CMND varchar(9)) returns table
as
return(
	select kh.MaKhachHang, kh.HoTen, kh.CMND, dp.MaDatPhong, dp.NgayDen, dp.NgayDi, dp.SoNguoi
	from DatPhong dp
	join KhachHang kh on dp.MaKhachHang=kh.MaKhachHang
	where kh.CMND=@CMND
);
go

select * from DanhSachDatPhongTheoCMND('123456789');

create function dbo.LietKeTongSoPhongTheoMaKH (@MaKhachHang int)
returns int
as
begin
	declare @TongSoPhong int = 0;
	select @TongSoPhong = count(distinct MaDatPhong)
	from DatPhong
	where MaKhachHang=@MaKhachHang;
	return @TongSoPhong;
end

select dbo.LietKeTongSoPhongTheoMaKH(1);

--10
create trigger dbo.RangBuocSoNguoi on DatPhong for insert, update
as 
begin
	if exists (
		select 1
		from inserted i
		join Phong p on p.MaPhong=i.MaPhong
		where i.SoNguoi > 4 and p.LoaiPhong='Tiêu chuẩn'
	)
	begin
		rollback transaction;
	end;
end;
go

drop trigger dbo.RangBuocSoNguoi;