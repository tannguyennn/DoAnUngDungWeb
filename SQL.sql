CREATE DATABASE homestay
USE homestay
GO

CREATE TABLE KhachHang (
    IDKH INT PRIMARY KEY IDENTITY(1,1),
    TenKH VARCHAR(100) NOT NULL,
    EmailKH VARCHAR(100) NOT NULL,
    SDTKH VARCHAR(20),
    MKKH VARCHAR(20) NOT NULL,
);

CREATE TABLE NhanVien (
    IDNV INT PRIMARY KEY IDENTITY(1,1),
    TenNV VARCHAR(100) NOT NULL,
    EmailNV VARCHAR(100) NOT NULL,
    SDTNV VARCHAR(20),
    MKNV VARCHAR(20) NOT NULL,
);

CREATE TABLE Homestays (
    IDHomestay INT PRIMARY KEY IDENTITY(1,1),
    TenHomestay VARCHAR(100) NOT NULL,
    TrangThai VARCHAR(50) NOT NULL,
    HinhAnh VARCHAR(20) NOT NULL,
);

CREATE TABLE Phong (
    IDPhong INT PRIMARY KEY IDENTITY(1,1),
    SoPhong VARCHAR(20) NOT NULL,
    IDHomestay INT,
    TrangThai VARCHAR(50) NOT NULL,
    Gia DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (IDHomestay) REFERENCES Homestays(IDHomestay)
);

CREATE TABLE DatPhong (
    IDDP INT PRIMARY KEY IDENTITY(1,1),
    IDKH INT,
    IDPhong INT,
    NgayDat DATE NOT NULL,
    NgayCheckIn DATE NOT NULL,
    NgayCheckOut DATE NOT NULL,
    TrangThaiDatPhong VARCHAR(20) NOT NULL,
    FOREIGN KEY (IDKH) REFERENCES KhachHang(IDKH),
    FOREIGN KEY (IDPhong) REFERENCES Phong(IDPhong)
);

CREATE TABLE DanhGia (
    IDDanhGia INT PRIMARY KEY IDENTITY(1,1),
    IDHomestay INT,
    IDKH INT,
    NoiDung TEXT Not null,
    NgayDanhGia DATE not null,
    FOREIGN KEY (IDHomestay) REFERENCES Homestays(IDHomestay),
    FOREIGN KEY (IDKH) REFERENCES KhachHang(IDKH)
);

CREATE TABLE ThanhToan (
    IDThanhToan INT PRIMARY KEY IDENTITY(1,1),
	IDDP INT,
	IDNV INT,
    NgayThanhToan DATE not null,
    Sotien DECIMAL(10, 2) not null,
    FOREIGN KEY (IDDP) REFERENCES DatPhong(IDDP),
	FOREIGN KEY (IDNV) REFERENCES NhanVien(IDNV)
);
-- Chèn 10 b?n ghi vào b?ng KhachHang
INSERT INTO KhachHang (TenKH, EmailKH, SDTKH, MKKH)
VALUES
    (N'Nguy?n V?n A', 'nguyenvana@example.com', '0123456789', 'password1'),
    (N'Tr?n Th? B', 'tranthib@example.com', '0987654321', 'password2'),
    (N'Lê V?n C', 'levanc@example.com', NULL, 'password3'),
    (N'Ph?m Th? D', 'phamthid@example.com', '0369874123', 'password4'),
    (N'Hoàng V?n E', 'hoangvane@example.com', '0789456123', 'password5'),
    (N'?? Th? F', 'dothif@example.com', '0952368741', 'password6'),
    (N'Tr??ng V?n G', 'truongvang@example.com', NULL, 'password7'),
    (N'Nguy?n Th? H', 'nguyenthih@example.com', '0912345678', 'password8'),
    (N'Võ V?n I', 'vovani@example.com', '0857419632', 'password9'),
    (N'Bùi Th? K', 'buithik@example.com', '0975318642', 'password10');

-- Chèn 10 b?n ghi vào b?ng NhanVien
INSERT INTO NhanVien (TenNV, EmailNV, SDTNV, MKNV)
VALUES
    (N'Tr?n V?n X', 'tranvanx@example.com', '0123456789', 'password11'),
    (N'Lê Th? Y', 'lethiy@example.com', '0987654321', 'password12'),
    (N'Hoàng V?n Z', 'hoangvanz@example.com', NULL, 'password13'),
    (N'?? Th? M', 'dothim@example.com', '0369874123', 'password14'),
    (N'Nguy?n V?n N', 'nguyenvann@example.com', '0789456123', 'password15'),
    (N'Tr??ng Th? L', 'truongthil@example.com', '0952368741', 'password16'),
    (N'Võ V?n P', 'vovanp@example.com', NULL, 'password17'),
    (N'Bùi V?n Q', 'buivanq@example.com', '0912345678', 'password18'),
    (N'Ph?m Th? R', 'phamthir@example.com', '0857419632', 'password19'),
    (N'Hoàng V?n S', 'hoangvans@example.com', '0975318642', 'password20');

-- Chèn 10 b?n ghi vào b?ng Homestays
INSERT INTO Homestays (TenHomestay, TrangThai, HinhAnh)
VALUES
    (N'Homestay A', N'Available', 'image1.jpg'),
    (N'Homestay B', N'Booked', 'image2.jpg'),
    (N'Homestay C', N'Available', 'image3.jpg'),
    (N'Homestay D', N'Available', 'image4.jpg'),
    (N'Homestay E', N'Booked', 'image5.jpg'),
    (N'Homestay F', N'Available', 'image6.jpg'),
    (N'Homestay G', N'Available', 'image7.jpg'),
    (N'Homestay H', N'Booked', 'image8.jpg'),
    (N'Homestay I', N'Available', 'image9.jpg'),
    (N'Homestay J', N'Available', 'image10.jpg');

-- Chèn 10 b?n ghi vào b?ng Phong
INSERT INTO Phong (SoPhong, IDHomestay, TrangThai, Gia)
VALUES
    ('101', 1, N'Available', 100),
    ('102', 1, N'Booked', 120),
    ('201', 2, N'Available', 90),
    ('202', 2, N'Available', 110),
    ('301', 3, N'Booked', 80),
    ('302', 3, N'Available', 100),
    ('401', 4, N'Available', 120),
    ('402', 4, N'Booked', 130),
    ('501', 5, N'Available', 110),
    ('502', 5, N'Available', 120);

-- Chèn 10 b?n ghi vào b?ng DatPhong
INSERT INTO DatPhong (IDKH, IDPhong, NgayDat, NgayCheckIn, NgayCheckOut, TrangThaiDatPhong)
VALUES
    (1, 1, '2024-05-01', '2024-05-10', '2024-05-15', N'Confirmed'),
    (2, 2, '2024-05-02', '2024-05-11', '2024-05-13', N'Confirmed'),
    (3, 3, '2024-05-03', '2024-05-12', '2024-05-14', N'Confirmed'),
    (4, 4, '2024-05-04', '2024-05-13', '2024-05-16', N'Confirmed'),
    (5, 5, '2024-05-05', '2024-05-14', '2024-05-17', N'Confirmed'),
    (6, 6, '2024-05-06', '2024-05-15', '2024-05-18', N'Confirmed'),
    (7, 7, '2024-05-07', '2024-05-16', '2024-05-19', N'Confirmed'),
    (8, 8, '2024-05-08', '2024-05-17', '2024-05-20', N'Confirmed'),
    (9, 9, '2024-05-09', '2024-05-18', '2024-05-21', N'Confirmed'),
    (10, 10, '2024-05-10', '2024-05-19', '2024-05-22', N'Confirmed');

-- Chèn 10 b?n ghi vào b?ng DanhGia
INSERT INTO DanhGia (IDHomestay, IDKH, NoiDung, NgayDanhGia)
VALUES
    (1, 1, N'N?i t?t ?? ?', '2024-05-16'),
    (2, 2, N'D?ch v? tuy?t v?i!', '2024-05-17'),
    (3, 3, N'S?ch s? và tho?i mái', '2024-05-18'),
    (4, 4, N'Nhân viên thân thi?n', '2024-05-19'),
    (5, 5, N'V? trí ??p', '2024-05-20'),
    (6, 6, N'Giá tr? t?t cho ti?n b?c', '2024-05-21'),
    (7, 7, N'Nên gi?i thi?u', '2024-05-22'),
    (8, 8, N'Kinh nghi?m tuy?t v?i', '2024-05-23'),
    (9, 9, N'S? quay l?i l?n n?a', '2024-05-24'),
    (10, 10, N'L?u trú tuy?t v?i!', '2024-05-25');

-- Chèn 10 b?n ghi vào b?ng ThanhToan
INSERT INTO ThanhToan (IDDP, IDNV, NgayThanhToan, Sotien)
VALUES
    (1, 1, '2024-05-15', 500),
    (2, 2, '2024-05-16', 240),
    (3, 3, '2024-05-17', 180),
    (4, 4, '2024-05-18', 390),
    (5, 5, '2024-05-19', 440),
    (6, 6, '2024-05-20', 300),
    (7, 7, '2024-05-21', 420),
    (8, 8, '2024-05-22', 520),
    (9, 9, '2024-05-23', 600),
    (10, 10, '2024-05-24', 350);

