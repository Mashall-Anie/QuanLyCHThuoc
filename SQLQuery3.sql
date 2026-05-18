CREATE DATABASE QLCHT;
USE QLCHT;

-- Danh mục thuốc
CREATE TABLE DanhMuc (
    MaDM    CHAR(20) PRIMARY KEY,
    TenDM   NVARCHAR(50) NOT NULL
);

-- Phân loại (thuộc DanhMuc)
CREATE TABLE PhanLoai (
    MaPL    CHAR(20) PRIMARY KEY,
    TenPL   NVARCHAR(50) NOT NULL,
    MaDM    CHAR(20) NOT NULL FOREIGN KEY REFERENCES DanhMuc(MaDM)
);

-- Nhà sản xuất
CREATE TABLE NSX (
    MaNSX   CHAR(20) PRIMARY KEY,
    TenNSX  NVARCHAR(50) NOT NULL,
    SDT     CHAR(20) NOT NULL
);

-- Sản phẩm (thuốc)
CREATE TABLE SanPham (
    MaSP        CHAR(20) PRIMARY KEY,
    TenSP       NVARCHAR(100) NOT NULL,
    MaPL        CHAR(20) NOT NULL FOREIGN KEY REFERENCES PhanLoai(MaPL),
    MaNSX       CHAR(20) NOT NULL FOREIGN KEY REFERENCES NSX(MaNSX),
    DonViTinh   NVARCHAR(20) NOT NULL,
    NSX         DATE NOT NULL,
    HSD         DATE NOT NULL,
    GiaNhap     MONEY NOT NULL,
    GiaBan      MONEY NOT NULL,
    SoLuong     INT  NOT NULL,
    GhiChu      NVARCHAR(255)
);

-- Khách hàng
CREATE TABLE KhachHang (
    SDT         CHAR(20) PRIMARY KEY,
    HoTenK      NVARCHAR(50) NOT NULL,
    TongDaMua   MONEY NOT NULL DEFAULT 0
);

-- Hóa đơn
CREATE TABLE HoaDon (
    SoHD        CHAR(20) PRIMARY KEY,
    NgayMua     DATE NOT NULL,
    SDT         CHAR(20) NOT NULL FOREIGN KEY REFERENCES KhachHang(SDT)
);

-- Chi tiết hóa đơn
CREATE TABLE ChiTietHD (
    SoHD        CHAR(20) NOT NULL FOREIGN KEY REFERENCES HoaDon(SoHD),
    MaSP        CHAR(20) NOT NULL FOREIGN KEY REFERENCES SanPham(MaSP),
    SoLuong     INT NOT NULL,
    GhiChu      NVARCHAR(255),
    PRIMARY KEY (SoHD, MaSP)
);

INSERT INTO DanhMuc VALUES ('DM001', N'Thuốc chữa bệnh'), ('DM002', N'Thực phẩm chức năng');
INSERT INTO NSX VALUES ('NSX001', N'Dược phẩm ABC', '0234567890');
INSERT INTO PhanLoai VALUES ('PL001', N'Giảm đau', 'DM001'), ('PL002', N'Vitamin', 'DM002');
INSERT INTO SanPham VALUES ('SP001', N'Paracetamol 500mg', 'PL001', 'NSX001', N'Viên', 
    '2024-01-01', '2026-01-01', 3000, 5000, 200, N'Hạ sốt, giảm đau');

INSERT INTO KhachHang VALUES ('0901234567', N'Nguyễn Văn A', 0);
INSERT INTO KhachHang VALUES ('0912345678', N'Trần Thị B', 150000);
INSERT INTO KhachHang VALUES ('0923456789', N'Lê Văn C', 300000);

INSERT INTO KhachHang VALUES ('0999999999', N'Khách Test', 3000000);
