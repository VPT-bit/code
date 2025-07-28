create database QLSV
go
use QLSV;
go

create table KHOA(
MaKhoa varchar(10) constraint pk_KHOA primary key not null,
TenKhoa nvarchar(50) not null,
SL_CBGD smallint not null)

create table SINHVIEN(
MSSV varchar(5) constraint pk_SINHVIEN primary key not null,
Ten nvarchar(50) not null,
GioiTinh varchar(5) not null,
DiaChi nvarchar(100) not null,
DienThoai varchar(20) null,
MaKhoa varchar(10) constraint fk_SINHVIEN foreign key references KHOA(MaKHoa) null)

create table GIAOVIEN(
MaGV varchar(5) constraint pk_GIAOVIEN primary key not null,
TenGV nvarchar(50) not null,
MaKhoa varchar(10) constraint fk_GIAOVIEN foreign key references KHOA(MaKhoa) null)

create table MONHOC(
MaMH varchar(5) constraint pk_MONHOC primary key not null,
tenMH nvarchar(50) not null,
SoTC smallint not null)

create table GIANGDAY(
MaKhoaHoc varchar(5) constraint pk_GIANGDAY primary key not null,
MaGV varchar(5) constraint fk1_GIANGDAY foreign key references GIAOVIEN(MaGV) null,
MaMH varchar(5) constraint fk2_GIANGDAY foreign key references MONHOC(MaMH) null,
HocKy smallint not null,
Nam int not null)

create table KETQUA(
MaSV varchar(5) constraint fk1_KETQUA foreign key references SINHVIEN(MSSV) not null,
MaKhoaHoc varchar(5) constraint fk2_KETQUA foreign key references GIANGDAY(MaKHoaHoc) not null,
Diem decimal(3,1) not null,
constraint pk_KETQUA primary key (MaSV, MaKhoaHoc))

insert into KHOA
values ('CNTT', N'Công nghệ thông tin', 15), ('TOAN', N'Toán', 20), ('SINH', N'Sinh học', 7)

insert into SINHVIEN
values ('SV001', N'BUI THUY AN', 'NU', N'223 TRAN HUNG DAO .HCM', '0843132202', 'CNTT'),
('SV002', N'NGUYEN THANH TUNG', 'NAM', N'140 CONG QUYNH .HCM', '0581526678', 'CNTT'),
('SV003', N'NGUYEN THANH LONG', 'NAM', N'112/4 CONG QUYNH .HCM', '0918345623', 'TOAN'),
('SV004', N'HOANG THI HOA', 'NU', N'90 NGUYEN VAN CU .HCM', '0988320123', 'CNTT'),
('SV005', N'TRAN HONG SON', 'NAM', N'54 CAO THANG .HANOI', '0928345987', 'TOAN')

insert into MONHOC 
values ('CSDL', N'CO SO DU LIEU', 3),
('CTDL', N'CAU TRUC DƯ LIEU', 4),
('KTLT', N'KY THUAT LAP TRINH', 5),
('CWIN', N'LAP TRINH TREN WINDOW', 4)

insert into GIAOVIEN
values ('GV01', N'PHAM THI THAO', 'CNTT'),
('GV02', N'LAM HOANG VU', 'TOAN'),
('GV03', N'TRAN VAN TIEN', 'CNTT'),
('GV04', N'HOANG VUONG', 'CNTT')

insert into GIANGDAY
values ('K1', 'GV01', 'CSDL', 1, 2021),
('K2', 'GV04', 'KTLT', 2, 2020),
('K3', 'GV03', 'CTDL', 1, 2020),
('K4', 'GV04', 'CWIN', 1, 2020),
('K5', 'GV01', 'CSDL', 1, 2021)

insert into KETQUA
values
('SV001', 'K1', 8.5),
('SV002', 'K3', 7.0),
('SV003', 'K4', 7.5),
('SV001', 'K2', 9.0),
('SV004', 'K3', 6.0),
('SV005', 'K3', 7.0),
('SV002', 'K1', 7.0),
('SV003', 'K2', 8.5),
('SV005', 'K5', 7.0),
('SV004', 'K4', 2.0)

--Bai tap 1 / Cau 38--
select SV.MSSV, SV.Ten, max(KQ.Diem) N'Điểm cao nhât'
from SINHVIEN SV join KETQUA KQ on KQ.MaSV=SV.MSSV
group by SV.MSSV, SV.Ten

--Bai tap 1 / Cau 39--
select min(SoTC) N'Số tín chỉ nhỏ nhất'
from MONHOC

--Bai tap 1 / Cau 40--
select MH1.tenMH N'Môn có nhiều chỉ nhất'
from MONHOC MH1
where MH1.SoTC=(
	select max(MH2.SoTC)
	from MONHOC MH2
)

--Bai tap 1 / Cau 41--
select *
from KHOA K1
where K1.SL_CBGD=(
	select min(K2.SL_CBGD)
	from KHOA K2
)

--bài 1.42 Tên các sinh viên có điểm cao nhất trong môn "Kỹ thuật lập trình"
select SV1.Ten
from KETQUA KQ1
join GIANGDAY GD1 on KQ1.MaKhoaHoc=GD1.MaKhoaHoc
join SINHVIEN SV1 on KQ1.MaSV=SV1.MSSV
join MONHOC MH1 on GD1.MaMH=MH1.MaMH
where MH1.TenMH='KY THUAT LAP TRINH'
and KQ1.Diem=(
	select max(KQ2.Diem)
	from KETQUA KQ2
	join GIANGDAY GD2 on KQ2.MaKhoaHoc=GD2.MaKhoaHoc
	join MONHOC MH2 on GD2.MaMH=MH2.MaMH
	where MH2.TenMH='KY THUAT LAP TRINH'
)

--bai tap 1 / Cau 48--
with TongSoTC as (
	select SV.Ten, SV.MSSV, sum(MH.SoTC) TongTC
	from SINHVIEN SV
	join KETQUA KQ on SV.MSSV=KQ.MaSV
	join GIANGDAY GD on KQ.MaKhoaHoc=GD.MaKhoaHoc
	join MONHOC MH on GD.MaMH=MH.MaMH
	group by SV.Ten, SV.MSSV
)
select * 
from TongSoTC 
where TongTC = (select max(TongTC) from TongSoTC)

--Bài 1 / Câu 28: Cho biết mã, tên, địa chỉ, điểm trung bình của từng sinh viên
select SV.MSSV, SV.Ten, SV.DiaChi, DTB.DiemTB
from SINHVIEN SV join (
	select MaSV
	from (
		select KQ.MaSV, sum(KQ.Diem * MH.SoTC) Diem, sum(MH.SoTC)
		from KETQUA KQ
		join GIANGDAY GD on KQ.MaKhoaHoc=GD.MaKhoaHoc
		join MONHOC MH on GD.MaMH=MH.MaMH
	) as BangDiem
	group by MaSV, SoTC
) as DTB on SV.MSSV=DTB.MaSV