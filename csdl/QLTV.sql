create database QLTV
go
use QLTV
go

create table DocGia(
Ma_DocGia varchar(10) not null primary key,
Ho nvarchar(20) not null,
TenLot nvarchar(20) not null,
Ten nvarchar(20) not null,
NgaySinh date not null
);

create table NguoiLon(
Ma_DocGia varchar(10) not null primary key,
SoNha nvarchar(10) not null,
Duong nvarchar(50) not null,
Quan nvarchar(50) not null,
DienThoai int not null,
HanSuDung date not null,
constraint fk_NguoiLon_DocGia foreign key (Ma_DocGia) references DocGia(Ma_DocGia)
);

create table TreEm(
Ma_DocGia varchar(10) not null primary key,
Ma_DocGia_NguoiLon varchar(10) not null,
constraint fk_TreEm_DocGia foreign key (Ma_DocGia) references DocGia(Ma_DocGia),
constraint fk_TreEm_NguoiLon foreign key (Ma_DocGia_NguoiLon) references NguoiLon(Ma_DocGia)
);

create table TuaSach(
Ma_TuaSach varchar(10) not null primary key,
TuaSach nvarchar(30) not null,
TacGia nvarchar(50) not null,
TomTat nvarchar(200) not null
);

create table DauSach(
ISBN varchar(13) not null primary key,
Ma_TuaSach varchar(10) not null,
NgonNgu nvarchar(20) not null,
Bia nvarchar(10) not null,
TrangThai nvarchar(10) not null,
constraint fk_DauSach_TuaSach foreign key(Ma_TuaSach) references TuaSach(Ma_TuaSach)
);

create table DangKy(
ISBN varchar(13) not null,
Ma_DocGia varchar(10) not null,
NgayDK Date not null,
GhiChu nvarchar(100) not null,
constraint fk_DangKy_DauSach foreign key (ISBN) references DauSach(ISBN),
constraint fk_DangKy_DocGia foreign key (Ma_DocGia) references DocGia(Ma_DocGia),
primary key (ISBN, Ma_DocGia)
);

create table Muon(
ISBN varchar(13) not null,
Ma_CuonSach varchar(10) not null,
Ma_DocGia varchar(10) not null,
NgayMuon Date not null,
NgayHetHan Date not null,
constraint fk_Muon_DocGia foreign key (Ma_DocGia) references DocGia(Ma_DocGia),
primary key (ISBN, Ma_CuonSach)
);

create table CuonSach(
ISBN varchar(13) not null,
Ma_CuonSach varchar(10) not null,
TinhTrang nvarchar(10) not null,
constraint fk_CuonSach_DauSach foreign key (ISBN) references DauSach(ISBN),
constraint fk_CuonSach_Muon foreign key (ISBN, Ma_CuonSach) references Muon(ISBN, Ma_CuonSach),
primary key (ISBN, Ma_CuonSach)
);

create table QuaTrinhMuon(
ISBN varchar(13) not null,
Ma_CuonSach varchar(10) not null,
NgayMuon Date not null,
Ma_DocGia varchar(10) not null,
NgayHetHan Date not null,
NgayTra Date not null,
TienMuon int not null,
TienDaTra int not null,
TienDatCoc int not null,
GhiChu nvarchar(100) not null,
constraint fk_QTM_DocGia foreign key (Ma_DocGia) references DocGia(Ma_DocGia),
constraint fk_QTM_CuonSach foreign key (ISBN, Ma_CuonSach) references CuonSach(ISBN, Ma_CuonSach),
primary key (ISBN, Ma_CuonSach, NgayMuon),
);

--Bài 5/ Câu 20: Tìm độc giả chưa từng mượn sách
select DG.Ma_DocGia, DG.Ho, DG.Ten, DG.Ten
from DocGia DG left join Muon M on DG.Ma_DocGia=M.Ma_DocGia
where M.Ma_DocGia=null

--Bài 5 / Câu 11
