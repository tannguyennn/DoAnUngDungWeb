CREATE DATABASE homestay
GO
USE homestay
GO
--drop database homestay
CREATE TABLE KhachHang (
    IDKH INT PRIMARY KEY IDENTITY(1,1),
    TenKH NVARCHAR(100) NOT NULL,
    EmailKH VARCHAR(100) NOT NULL,
    SDTKH VARCHAR(20),
    MKKH VARCHAR(20) NOT NULL
);

CREATE TABLE NhanVien (
    IDNV INT PRIMARY KEY IDENTITY(1,1),
    TenNV NVARCHAR(100) NOT NULL,
    EmailNV VARCHAR(100) NOT NULL,
    SDTNV VARCHAR(20),
    MKNV VARCHAR(20) NOT NULL
);

CREATE TABLE LoaiPhong (
    IDLP INT PRIMARY KEY IDENTITY(1,1),
    TenLP NVARCHAR(100) NOT NULL
);

CREATE TABLE Phong (
    IDPhong INT PRIMARY KEY IDENTITY(1,1),
    SoPhong VARCHAR(20) NOT NULL,
    TrangThai int default 0,
    Gia DECIMAL(10, 2) NOT NULL,
    IDLP INT,
    HinhAnh VARCHAR(20) NOT NULL,
    MoTa NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (IDLP) REFERENCES LoaiPhong(IDLP)
);

CREATE TABLE DatPhong (
    IDDP INT PRIMARY KEY IDENTITY(1,1),
    IDKH INT,
    IDPhong INT,
    NgayDat DATE NOT NULL,
    NgayCheckIn DATE NOT NULL,
    NgayCheckOut DATE NOT NULL,
    TrangThaiDatPhong NVARCHAR(20) NOT NULL,
    FOREIGN KEY (IDKH) REFERENCES KhachHang(IDKH),
    FOREIGN KEY (IDPhong) REFERENCES Phong(IDPhong)
);

CREATE TABLE DanhGia (
    IDDanhGia INT PRIMARY KEY IDENTITY(1,1),
    IDKH INT,
    NoiDung TEXT NOT NULL,
    NgayDanhGia DATE NOT NULL,
    FOREIGN KEY (IDKH) REFERENCES KhachHang(IDKH)
);

CREATE TABLE ThanhToan (
    IDThanhToan INT PRIMARY KEY IDENTITY(1,1),
    IDDP INT,
    IDNV INT,
    NgayThanhToan DATE NOT NULL,
    Sotien DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (IDDP) REFERENCES DatPhong(IDDP),
    FOREIGN KEY (IDNV) REFERENCES NhanVien(IDNV)
);

INSERT INTO KhachHang (TenKH, EmailKH, SDTKH, MKKH) VALUES 
(N'Nguyễn Văn An', 'an@example.com', '0123456789', 'matkhau1'),
(N'Trần Thị Bình', 'binh@example.com', '0987654321', 'matkhau2'),
(N'Lê Văn Cường', 'cuong@example.com', '0912345678', 'matkhau3'),
(N'Phạm Thị Dung', 'dung@example.com', '0909876543', 'matkhau4'),
(N'Hoàng Văn Em', 'em@example.com', '0888888888', 'matkhau5'),
(N'Bùi Thị Phương', 'phuong@example.com', '0877777777', 'matkhau6'),
(N'Ngô Văn Giang', 'giang@example.com', '0866666666', 'matkhau7'),
(N'Phan Thị Hạnh', 'hanh@example.com', '0855555555', 'matkhau8'),
(N'Vũ Văn Tùng', 'tung@example.com', '0844444444', 'matkhau9'),
(N'Đỗ Thị Lan', 'lan@example.com', '0833333333', 'matkhau10');

-- NhanVien
INSERT INTO NhanVien (TenNV, EmailNV, SDTNV, MKNV) VALUES 
(N'Nguyễn Văn Lâm', 'lam@example.com', '0123456789', 'matkhau1'),
(N'Trần Thị Mai', 'mai@example.com', '0987654321', 'matkhau2'),
(N'Lê Văn Nam', 'nam@example.com', '0912345678', 'matkhau3'),
(N'Phạm Thị Phúc', 'phuc@example.com', '0909876543', 'matkhau4'),
(N'Hoàng Văn Quý', 'quy@example.com', '0888888888', 'matkhau5'),
(N'Bùi Thị Xuân', 'xuan@example.com', '0877777777', 'matkhau6'),
(N'Ngô Văn Sang', 'sang@example.com', '0866666666', 'matkhau7'),
(N'Phan Thị Thu', 'thu@example.com', '0855555555', 'matkhau8'),
(N'Vũ Văn Hải', 'hai@example.com', '0844444444', 'matkhau9'),
(N'Đỗ Thị Vân', 'van@example.com', '0833333333', 'matkhau10');

-- Insert into LoaiPhong
INSERT INTO LoaiPhong (TenLP) VALUES 
(N'Phòng standard 1'),
(N'Phòng standard 2'),
(N'Phòng premium');

-- Insert into Phong
INSERT INTO Phong (SoPhong, TrangThai, Gia, IDLP, HinhAnh, MoTa) VALUES 
('101', 1, 500000, 1, 'room-1.jpg', N'Phòng tiêu chuẩn với tiện nghi cơ bản.'),
('102', 0, 500000, 1, 'room-2.jpg', N'Phòng tiêu chuẩn đã được đặt.'),
('201', 1, 700000, 2, 'room-3.jpg', N'Phòng tiêu chuẩn nâng cao với tầm nhìn ra vườn.'),
('202', 1, 700000, 2, 'room-4.jpg', N'Phòng tiêu chuẩn nâng cao đã được đặt.'),
('301', 0, 1500000, 3, 'room-5.jpg', N'Phòng cao cấp với nội thất sang trọng và tầm nhìn toàn cảnh.'),
('302', 0, 1500000, 3, 'room-6.jpg', N'Phòng cao cấp đã được đặt.'),
('401', 0, 3000000, 1, 'room-7.jpg', N'Phòng tiêu chuẩn với tiện nghi bổ sung.'),
('402', 1, 3000000, 2, 'room-8.jpg', N'Phòng tiêu chuẩn nâng cao đã được đặt.'),
('501', 0, 2000000, 3, 'room-9.jpg', N'Phòng cao cấp với dịch vụ bổ sung.');

-- DatPhong
INSERT INTO DatPhong (IDKH, IDPhong, NgayDat, NgayCheckIn, NgayCheckOut, TrangThaiDatPhong) VALUES 
(1, 1, '2024-05-01', '2024-05-10', '2024-05-15', N'Đã xác nhận'),
(2, 2, '2024-05-03', '2024-05-12', '2024-05-17', N'Đã xác nhận'),
(3, 3, '2024-05-05', '2024-05-15', '2024-05-20', N'Đã xác nhận'),
(4, 4, '2024-05-07', '2024-05-17', '2024-05-22', N'Đã xác nhận'),
(5, 5, '2024-05-09', '2024-05-19', '2024-05-24', N'Đã xác nhận'),
(6, 6, '2024-05-11', '2024-05-21', '2024-05-26', N'Đã xác nhận'),
(7, 7, '2024-05-13', '2024-05-23', '2024-05-28', N'Đã xác nhận'),
(8, 8, '2024-05-15', '2024-05-25', '2024-05-30', N'Đã xác nhận'),
(9, 9, '2024-05-17', '2024-05-27', '2024-06-01', N'Đã xác nhận');

-- DanhGia
INSERT INTO DanhGia (IDKH, NoiDung, NgayDanhGia) VALUES 
(1, N'Phòng sạch sẽ và dịch vụ tốt.', '2024-05-16'),
(2, N'Nhân viên thân thiện và chu đáo.', '2024-05-17'),
(3, N'Không gian yên tĩnh và thoải mái.', '2024-05-18'),
(4, N'Giá cả hợp lý và tiện nghi đầy đủ.', '2024-05-19'),
(5, N'Vị trí thuận tiện cho việc đi lại.', '2024-05-20'),
(6, N'Phòng đẹp và rộng rãi.', '2024-05-21'),
(7, N'Dịch vụ chăm sóc khách hàng tốt.', '2024-05-22'),
(8, N'Tiện nghi hiện đại và đầy đủ.', '2024-05-23'),
(9, N'Sẽ quay lại lần sau.', '2024-05-24'),
(10, N'Rất hài lòng với kỳ nghỉ.', '2024-05-25');

-- ThanhToan
INSERT INTO ThanhToan (IDDP, IDNV, NgayThanhToan, Sotien) VALUES 
(1, 1, '2024-05-16', 500000),
(2, 2, '2024-05-18', 700000),
(3, 3, '2024-05-20', 1500000),
(4, 4, '2024-05-22', 3000000),
(5, 5, '2024-05-24', 2000000),
(6, 6, '2024-05-26', 500000),
(7, 7, '2024-05-28', 700000),
(8, 8, '2024-05-30', 1500000),
(9, 9, '2024-06-01', 3000000);
