CREATE DATABASE BaiTap1;
GO

USE BaiTap1;
GO

CREATE TABLE NHANVIEN (
    MSNV CHAR(5),
    Hoten NVARCHAR(100) NOT NULL,
    Gioitinh NVARCHAR(10) CHECK (Gioitinh IN ('Nam', 'Nữ')),
    Diachi NVARCHAR(255),
    Luong DECIMAL(18,2) CHECK (Luong > 0),
    CONSTRAINT PK_NHANVIEN PRIMARY KEY (MSNV)
);

CREATE TABLE KHO (
    MSKHO CHAR(5),
    TenKho NVARCHAR(100) NOT NULL,
    Diachi NVARCHAR(255),
    CONSTRAINT PK_KHO PRIMARY KEY (MSKHO)
);

CREATE TABLE VATTU (
    MSVT CHAR(5),
    TenVT NVARCHAR(100) NOT NULL,
    DVT NVARCHAR(50),
    Dongia DECIMAL(18,2) CHECK (Dongia >= 0),
    MSKHO CHAR(5) NOT NULL,
    CONSTRAINT PK_VATTU PRIMARY KEY (MSVT)
);

CREATE TABLE NHACUNGCAP (
    MSNCC CHAR(5),
    TenNCC NVARCHAR(100) NOT NULL,
    Diachi NVARCHAR(255),
    CONSTRAINT PK_NHACUNGCAP PRIMARY KEY (MSNCC)
);

CREATE TABLE NHAPKHO (
    SoPN CHAR(6),
    MSVT CHAR(5) NOT NULL,
    MSNCC CHAR(5) NOT NULL,
    Soluong INT CHECK (Soluong > 0),
    Ngaynhap DATE NOT NULL,
    MSNV CHAR(5) NOT NULL,
    CONSTRAINT PK_NHAPKHO PRIMARY KEY (SoPN)
);

-- Thiết lập khóa ngoại
ALTER TABLE VATTU ADD CONSTRAINT FK_VATTU_KHO FOREIGN KEY (MSKHO) REFERENCES KHO(MSKHO);
ALTER TABLE NHAPKHO ADD CONSTRAINT FK_NHAPKHO_VATTU FOREIGN KEY (MSVT) REFERENCES VATTU(MSVT);
ALTER TABLE NHAPKHO ADD CONSTRAINT FK_NHAPKHO_NHACUNGCAP FOREIGN KEY (MSNCC) REFERENCES NHACUNGCAP(MSNCC);
ALTER TABLE NHAPKHO ADD CONSTRAINT FK_NHAPKHO_NHANVIEN FOREIGN KEY (MSNV) REFERENCES NHANVIEN(MSNV);

-- Nhập dữ liệu
INSERT INTO NHANVIEN VALUES
('NV001', 'Nguyen Van A', 'Nam', 'Ha Noi', 10000000),
('NV002', 'Tran Thi B', 'Nữ', 'Hai Phong', 12000000),
('NV003', 'Le Van C', 'Nam', 'Da Nang', 9000000),
('NV004', 'Pham Thi D', 'Nữ', 'HCM', 15000000),
('NV005', 'Bui Van E', 'Nam', 'Can Tho', 11000000);

INSERT INTO KHO VALUES
('KHO01', 'Kho A', 'Ha Noi'),
('KHO02', 'Kho B', 'Hai Phong'),
('KHO03', 'Kho C', 'Da Nang'),
('KHO04', 'Kho D', 'HCM'),
('KHO05', 'Kho E', 'Can Tho');

INSERT INTO VATTU VALUES
('VT001', 'Gach', 'Vien', 5000, 'KHO01'),
('VT002', 'Xi Mang', 'Kg', 7000, 'KHO02'),
('VT003', 'Sat', 'Kg', 15000, 'KHO03'),
('VT004', 'Go', 'M3', 120000, 'KHO04'),
('VT005', 'Son', 'Lit', 25000, 'KHO05');

INSERT INTO NHACUNGCAP VALUES
('NCC01', 'Cong ty A', 'Ha Noi'),
('NCC02', 'Cong ty B', 'Hai Phong'),
('NCC03', 'Cong ty C', 'Da Nang'),
('NCC04', 'Cong ty D', 'HCM'),
('NCC05', 'Cong ty E', 'Can Tho');

INSERT INTO NHAPKHO VALUES
('PN1001', 'VT001', 'NCC01', 100, '2024-03-01', 'NV001'),
('PN1002', 'VT002', 'NCC02', 200, '2024-03-02', 'NV002'),
('PN1003', 'VT003', 'NCC03', 150, '2024-03-03', 'NV003'),
('PN1004', 'VT004', 'NCC04', 120, '2024-03-04', 'NV004'),
('PN1005', 'VT005', 'NCC05', 180, '2024-03-05', 'NV005');

-- Truy vấn danh sách vật tư có giá trị tồn kho lớn hơn 100000
SELECT V.MSVT, V.TenVT, V.DVT, V.Dongia, V.MSKHO
FROM VATTU V
WHERE V.Dongia > 100000;

-- Truy vấn danh sách nhà cung cấp, vật tư họ cung cấp, số lượng nhập, sắp xếp theo ngày nhập gần nhất
SELECT NCC.TenNCC, V.TenVT, N.Soluong, N.Ngaynhap
FROM NHAPKHO N
JOIN NHACUNGCAP NCC ON N.MSNCC = NCC.MSNCC
JOIN VATTU V ON N.MSVT = V.MSVT
ORDER BY N.Ngaynhap DESC;

-- Tổng số tiền nhập kho theo từng kho hàng trong năm 2024
SELECT K.TenKho, SUM(N.Soluong * V.Dongia) AS TongTienNhap
FROM NHAPKHO N
JOIN VATTU V ON N.MSVT = V.MSVT
JOIN KHO K ON V.MSKHO = K.MSKHO
WHERE YEAR(N.Ngaynhap) = 2024
GROUP BY K.TenKho;

-- Nhân viên nhập nhiều vật tư nhất trong tháng 3 năm 2024
SELECT TOP 1 NV.Hoten, SUM(N.Soluong) AS TongSoLuong
FROM NHAPKHO N
JOIN NHANVIEN NV ON N.MSNV = NV.MSNV
WHERE YEAR(N.Ngaynhap) = 2024 AND MONTH(N.Ngaynhap) = 3
GROUP BY NV.Hoten
ORDER BY TongSoLuong DESC;

-- Danh sách kho chứa đủ tất cả các loại vật tư của công ty
SELECT K.TenKho
FROM KHO K
JOIN VATTU V ON K.MSKHO = V.MSKHO
GROUP BY K.TenKho
HAVING COUNT(DISTINCT V.MSVT) = (SELECT COUNT(*) FROM VATTU);