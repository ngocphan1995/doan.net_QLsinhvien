USE [master]
GO
/****** Object:  Database [D8CNPM]    Script Date: 6/28/2016 2:47:51 PM ******/
CREATE DATABASE [D8CNPM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'D8CNPM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\D8CNPM.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'D8CNPM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\D8CNPM_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [D8CNPM] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [D8CNPM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [D8CNPM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [D8CNPM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [D8CNPM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [D8CNPM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [D8CNPM] SET ARITHABORT OFF 
GO
ALTER DATABASE [D8CNPM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [D8CNPM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [D8CNPM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [D8CNPM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [D8CNPM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [D8CNPM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [D8CNPM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [D8CNPM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [D8CNPM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [D8CNPM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [D8CNPM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [D8CNPM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [D8CNPM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [D8CNPM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [D8CNPM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [D8CNPM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [D8CNPM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [D8CNPM] SET RECOVERY FULL 
GO
ALTER DATABASE [D8CNPM] SET  MULTI_USER 
GO
ALTER DATABASE [D8CNPM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [D8CNPM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [D8CNPM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [D8CNPM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [D8CNPM] SET DELAYED_DURABILITY = DISABLED 
GO
USE [D8CNPM]
GO
/****** Object:  Table [dbo].[Diem]    Script Date: 6/28/2016 2:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diem](
	[MaSv] [int] NOT NULL,
	[MaMon] [int] NOT NULL,
	[DiemTP] [float] NULL,
	[DiemThi] [float] NULL,
	[DiemTongKet] [float] NULL,
	[NgayCapNhat] [datetime] NULL,
 CONSTRAINT [PK_Diem] PRIMARY KEY CLUSTERED 
(
	[MaSv] ASC,
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 6/28/2016 2:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[MaKhoa] [int] IDENTITY(1,1) NOT NULL,
	[TenKhoa] [nvarchar](50) NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichThi]    Script Date: 6/28/2016 2:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichThi](
	[MaLich] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [nvarchar](max) NULL,
	[ThoiGianBatDau] [datetime] NULL,
	[ThoiGianKetThuc] [datetime] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[TieuDe] [nvarchar](max) NULL,
 CONSTRAINT [PK_LichThi] PRIMARY KEY CLUSTERED 
(
	[MaLich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lop]    Script Date: 6/28/2016 2:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[MaLop] [int] IDENTITY(1,1) NOT NULL,
	[TenLop] [nvarchar](50) NULL,
	[MaKhoa] [nvarchar](50) NULL,
 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 6/28/2016 2:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMon] [int] IDENTITY(1,1) NOT NULL,
	[TenMon] [nvarchar](100) NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuangCao]    Script Date: 6/28/2016 2:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuangCao](
	[MaQuangCao] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](100) NULL,
	[HinhAnh] [nvarchar](100) NULL,
	[LinkLK] [nvarchar](255) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[ViTriQuangCao] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuangCao] PRIMARY KEY CLUSTERED 
(
	[MaQuangCao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 6/28/2016 2:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSv] [int] NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[MaLop] [int] NULL,
	[NgaySinh] [datetime] NULL,
	[GioiTinh] [bit] NULL,
	[QueQuan] [nvarchar](100) NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[MaSv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTheLoai]    Script Date: 6/28/2016 2:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTheLoai](
	[MaTheLoai] [int] IDENTITY(1,1) NOT NULL,
	[tentheloai] [nvarchar](50) NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTinBai]    Script Date: 6/28/2016 2:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTinBai](
	[MaTinTuc] [int] IDENTITY(1,1) NOT NULL,
	[MaTheLoai] [int] NULL,
	[NgayUpdate] [datetime] NULL,
	[NoiDung] [nvarchar](max) NULL,
	[TrangThaiTin] [int] NULL,
	[HinhDaiDien] [nvarchar](100) NULL,
	[Mota] [nvarchar](max) NULL,
	[TieuDe] [nvarchar](100) NULL,
 CONSTRAINT [PK_TinTuc] PRIMARY KEY CLUSTERED 
(
	[MaTinTuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 6/28/2016 2:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[PhanQuyen] [nvarchar](100) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThanhVien]    Script Date: 6/28/2016 2:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhVien](
	[MaThanhVien] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [int] NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThanhVien] PRIMARY KEY CLUSTERED 
(
	[MaThanhVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310011, 1, 4, 5, 4.7, CAST(N'2016-06-27 12:12:25.403' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310012, 1, 7, 6, 6.2999999999999989, CAST(N'2016-06-27 12:12:25.427' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310013, 1, 4, 9, 7.5, CAST(N'2016-06-27 12:12:25.440' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310014, 1, 8, 8, 8, CAST(N'2016-06-27 12:12:25.440' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310015, 2, 7, 8, 7.6999999999999993, CAST(N'2016-06-27 12:12:25.457' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310016, 2, 5, 5, 5, CAST(N'2016-06-27 12:12:25.470' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310017, 2, 9, 6, 6.8999999999999986, CAST(N'2016-06-27 12:12:25.470' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310018, 2, 4, 4, 4, CAST(N'2016-06-27 12:12:25.493' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310019, 2, 2, 4, 3.4, CAST(N'2016-06-27 12:12:25.503' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310020, 3, 3, 5, 4.4, CAST(N'2016-06-27 12:12:25.503' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310021, 3, 9, 9, 9, CAST(N'2016-06-27 12:12:25.520' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310022, 3, 9, 8, 8.2999999999999989, CAST(N'2016-06-27 12:12:25.537' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310023, 3, 5, 7, 6.3999999999999995, CAST(N'2016-06-27 12:12:25.560' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310024, 3, 7, 6, 6.2999999999999989, CAST(N'2016-06-27 12:12:25.570' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310025, 3, 3, 2, 2.3, CAST(N'2016-06-27 12:12:25.580' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310026, 3, 1, 0, 0.3, CAST(N'2016-06-27 12:12:25.580' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310027, 3, 6, 8, 7.3999999999999995, CAST(N'2016-06-27 12:12:25.603' AS DateTime))
INSERT [dbo].[Diem] ([MaSv], [MaMon], [DiemTP], [DiemThi], [DiemTongKet], [NgayCapNhat]) VALUES (1381310028, 3, 7, 9, 8.4, CAST(N'2016-06-27 12:12:25.537' AS DateTime))
SET IDENTITY_INSERT [dbo].[Khoa] ON 

INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (3, N'Công Nghệ Thông Tin')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (4, N'Công Nghệ Tự Động')
SET IDENTITY_INSERT [dbo].[Khoa] OFF
SET IDENTITY_INSERT [dbo].[LichThi] ON 

INSERT [dbo].[LichThi] ([MaLich], [NoiDung], [ThoiGianBatDau], [ThoiGianKetThuc], [DiaChi], [TieuDe]) VALUES (1, N'Kiểm tra môn Phát triển phần mềm trên web', CAST(N'2016-06-07 09:00:00.000' AS DateTime), CAST(N'2016-06-07 11:00:00.000' AS DateTime), N'Phòng A207', N'Kiểm Tra Môn Phát Triển Phần Mềm')
INSERT [dbo].[LichThi] ([MaLich], [NoiDung], [ThoiGianBatDau], [ThoiGianKetThuc], [DiaChi], [TieuDe]) VALUES (2, N'Lịch thi học kỳ 2 năm học 2015 – 2016

1/ Các đơn vị và Sinh viên cập nhật lịch thi học kỳ 2 trên trang Sinh viên đảm bảo chất lượng.
2/ Nhà trường đã triển khai lịch thi đến các đơn vị; phòng Khảo thí và đảm bảo chất lượng để rà soát lại các môn thi trong học kỳ từ ngày 20/4/2016 đến ngày 27/4/2016. Phòng Đào tạo nhận được phản hồi về lịch thi học kỳ 2 năm học 2015 - 2016 từ các Khoa: Công nghệ tự động; Công nghệ thông tin; Khoa học cơ bản; Quản lý năng lượng và đã điều chỉnh lịch thi phù hợp.
3/ Trong quá trình thực hiện nếu có vướng mắc đề nghị các đơn vị và sinh viên liên hệ phòng Đào tạo hoặc phòng Khảo thí và đảm bảo chất lượng để kịp thời giải quyết.', CAST(N'2016-05-22 16:45:00.000' AS DateTime), CAST(N'2016-06-04 18:00:00.000' AS DateTime), N'Trường đại học điện lực', N'Lịch thi học kỳ 2 năm học 2015 – 2016')
INSERT [dbo].[LichThi] ([MaLich], [NoiDung], [ThoiGianBatDau], [ThoiGianKetThuc], [DiaChi], [TieuDe]) VALUES (3, N'Lịch thi môn:Automat & ngôn ngữ hình thức', CAST(N'2016-06-08 09:00:00.000' AS DateTime), CAST(N'2016-06-09 10:45:00.000' AS DateTime), N'Phòng A208 ', N'Lịch thi môn:Automat & ngôn ngữ hình thức')
INSERT [dbo].[LichThi] ([MaLich], [NoiDung], [ThoiGianBatDau], [ThoiGianKetThuc], [DiaChi], [TieuDe]) VALUES (4, N'Lịch thi môn:Phần mềm mã nguồn mở
Hình thức:Thi vấn đáp
Lưu ý:Sinh viên phải đến đúng giờ', CAST(N'2016-06-10 07:00:00.000' AS DateTime), CAST(N'2016-06-10 11:00:00.000' AS DateTime), N'Phòng máy A201', N'Lịch thi môn:Phần mềm mã nguồn mở')
INSERT [dbo].[LichThi] ([MaLich], [NoiDung], [ThoiGianBatDau], [ThoiGianKetThuc], [DiaChi], [TieuDe]) VALUES (5, N'Lịch thi môn:Máy học
Hình thức thi:Vấn đáp
Lưu ý:Sinh viên phải đến trước 10 phút để nộp báo cáo', CAST(N'2016-06-12 07:00:00.000' AS DateTime), CAST(N'2016-06-10 11:00:00.000' AS DateTime), N'Phòng máy A201', N'Lịch thi môn:Máy học')
SET IDENTITY_INSERT [dbo].[LichThi] OFF
SET IDENTITY_INSERT [dbo].[Lop] ON 

INSERT [dbo].[Lop] ([MaLop], [TenLop], [MaKhoa]) VALUES (1, N'D8CNPM', N'1')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [MaKhoa]) VALUES (2, N'D8DHN', N'1')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [MaKhoa]) VALUES (3, N'D8TMDT', N'2')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [MaKhoa]) VALUES (4, N'D9DTVT', N'2')
SET IDENTITY_INSERT [dbo].[Lop] OFF
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310011, N'Hoàng Tuấn Anh', 1, CAST(N'1995-11-07 00:00:00.000' AS DateTime), 1, N'Hà Nội', N'98765432')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310012, N'Trương Tuấn Anh', 2, CAST(N'1996-11-03 00:00:00.000' AS DateTime), 1, N'Hải Phòng', N'9876543')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310013, N'Trương Việt Anh', 3, CAST(N'1996-04-05 00:00:00.000' AS DateTime), 0, N'Nghệ An', N'87654342325')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310014, N'Ngô Xuân Bách', 1, CAST(N'1995-02-01 00:00:00.000' AS DateTime), 1, N'TP.HCM', N'98765432')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310015, N'Vũ Đình Cương', 1, CAST(N'1995-07-11 00:00:00.000' AS DateTime), 0, N'Phú Thọ', N'9862455632')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310016, N'Nguyễn Cao Đạt', 2, CAST(N'1996-04-04 00:00:00.000' AS DateTime), 1, N'Nghệ An', N'4563464544')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310017, N'Trần Anh Đức', 1, CAST(N'1995-01-16 00:00:00.000' AS DateTime), 0, N'Vĩnh Phúc', N'754367665')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310018, N'Nguyễn Thị Thùy Dương', 3, NULL, 0, N'Huế', N'6554543645')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310019, N'Hoàng Thừa Duy', 3, CAST(N'1995-08-09 00:00:00.000' AS DateTime), 1, N'Nha Trang', N'63465475474')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310020, N'Nguyễn Văn Giang', 4, CAST(N'1995-05-11 00:00:00.000' AS DateTime), 0, N'Hà Tĩnh', N'874787476')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310021, N'Đỗ Thị Hà', 4, CAST(N'1994-03-07 00:00:00.000' AS DateTime), 0, N'Hà Nội', N'4577443664')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310022, N'Lê Trung Hiếu', 2, CAST(N'1994-05-01 00:00:00.000' AS DateTime), 1, N'Hà Nội', N'4475475634')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310023, N'Dương Mạnh Hùng', 2, CAST(N'1996-02-04 00:00:00.000' AS DateTime), 1, N'Vĩnh Phúc', N'76654543434')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310024, N'Bùi Quóc Hưng', 2, CAST(N'1995-03-09 00:00:00.000' AS DateTime), 0, N'TP.HCM', N'7656456')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310025, N'Quách Trường An', 4, CAST(N'1994-05-07 00:00:00.000' AS DateTime), 1, N'Hà Nam', N'736256522')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310026, N'Bùi Thu Anh', 1, CAST(N'1992-04-06 00:00:00.000' AS DateTime), 0, N'Đà Nẵng', N'576325252')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310027, N'Lưu Ánh Linh', 4, CAST(N'1997-07-01 00:00:00.000' AS DateTime), 0, N'Hà Tĩnh', N'667487654567')
INSERT [dbo].[SinhVien] ([MaSv], [HoTen], [MaLop], [NgaySinh], [GioiTinh], [QueQuan], [SDT]) VALUES (1381310028, N'Ngô Quang Hải', 1, CAST(N'1994-09-09 00:00:00.000' AS DateTime), 1, N'Cà Mau', N'57545633764')
SET IDENTITY_INSERT [dbo].[tblTheLoai] ON 

INSERT [dbo].[tblTheLoai] ([MaTheLoai], [tentheloai]) VALUES (1, N'Xã Hội')
INSERT [dbo].[tblTheLoai] ([MaTheLoai], [tentheloai]) VALUES (2, N'Giáo Dục')
SET IDENTITY_INSERT [dbo].[tblTheLoai] OFF
SET IDENTITY_INSERT [dbo].[tblTinBai] ON 

INSERT [dbo].[tblTinBai] ([MaTinTuc], [MaTheLoai], [NgayUpdate], [NoiDung], [TrangThaiTin], [HinhDaiDien], [Mota], [TieuDe]) VALUES (1, 2, CAST(N'2016-05-21 10:47:59.690' AS DateTime), N'Ngày 15/4/2016 vừa qua, Samsung Vietnam Mobile R&D Center (viết tắt là SVMC) đã có buổi làm việc với khoa Công nghệ thông tin – Trường Đại học Điện Lực. Buổi làm việc tập trung vào 2 vấn đề chính và quan trọng nhất đó là: nhu cầu tuyển dụng của Samsung trong 10 năm tới và sự hỗ trợ đầu tư từ phía Samsung cho quá trình nâng cao chất lượng đào tạo nguồn nhân lực Công nghệ thông tin tại trường Đại học Điện Lực.

Trong một vài năm trở lại đây, nhu cầu nhân lực công nghệ thông tin chất lượng cao đang ngày càng được mở rộng. Kèm theo đó là thách thức rất lớn tới chất lượng đào tạo cho phù hợp với nhu cầu tuyển dụng của đa phần các doanh nghiệp.', 1, N'800px-Internet1.jpg', N'Ngày 15/4/2016 vừa qua, Samsung Vietnam Mobile R&D Center ', N'samsung')
INSERT [dbo].[tblTinBai] ([MaTinTuc], [MaTheLoai], [NgayUpdate], [NoiDung], [TrangThaiTin], [HinhDaiDien], [Mota], [TieuDe]) VALUES (5, 2, CAST(N'2016-05-21 22:08:47.503' AS DateTime), N' - Đến ngày 21/04/2016 Phòng Đào tạo đã hoàn thành quá trình cập nhập điểm học kỳ 1 năm học 2015-2016 (Học kỳ 151) trên trang dkmh.epu.edu.vn. Phòng Đào tạo đề nghị:
          - Sinh viên theo dõi điểm học tập của mình. Phòng Đào tạo nhận ý kiến kiểm tra điểm của sinh viên từ ngày 22/04/2016 đến ngày 29/04/2016 tại cửa số 5 Phòng Đào Tạo(theo giờ tiếp sinh viên).
          - Trong quá trình kiểm tra điểm đề nghị Sinh viên, Giáo viên và Các đơn vị phối hợp với bộ phận Điểm của Phòng Đào tạo để cùng giải quyết.', 1, N'h1.jpg', N' - Đến ngày 21/04/2016 Phòng Đào tạo đã hoàn thành quá trình cập ', N'Thông báo điểm học kỳ 1 năm học 2015-2016')
INSERT [dbo].[tblTinBai] ([MaTinTuc], [MaTheLoai], [NgayUpdate], [NoiDung], [TrangThaiTin], [HinhDaiDien], [Mota], [TieuDe]) VALUES (6, 2, CAST(N'2016-05-21 22:08:59.307' AS DateTime), N'Căn cứ theo kế hoạch tổ chức tốt nghiệp cho hệ đại học chính quy và hệ liên thông vào sáng và chiều ngày Thứ 5_14/1/2016 và Thứ 6_15/1/2016.
Nhà trường cần sử dụng các phòng học và cán bộ giáo viên làm công tác coi thi, toàn bộ các lớp có lịch học lý thuyết vào 2 ngày trên được nghỉ học.
Giáo viên bộ môn liên hệ với lớp môn học lên kế hoạch dạy bù và nộp đăng ký về Phòng Đào tạo để xếp phòng học theo quy định.
Hạn cuối tổ chức học và dạy bù Tuần 34_ngày 31/3/2016.
Trân trọng', 1, N'a1.jpg', N'Căn cứ theo kế hoạch tổ chức tốt nghiệp cho hệ đại học chính quy và hệ liên thông vào sáng và chiều ngày ', N'TKB: Thông báo về lịch điều chỉnh phòng học')
INSERT [dbo].[tblTinBai] ([MaTinTuc], [MaTheLoai], [NgayUpdate], [NoiDung], [TrangThaiTin], [HinhDaiDien], [Mota], [TieuDe]) VALUES (10, 2, CAST(N'2016-05-22 17:33:26.820' AS DateTime), N'Đúng 7h sáng nay 22/5, ngày bầu cử đại biểu Quốc hội khóa XIV và đại biểu Hội đồng nhân dân các cấp nhiệm kỳ 2016-2021 chính thức bắt đầu. Tại các điểm bầu cử ở Hà Nội và Hải Phòng, Tổng Bí thư Nguyễn Phú Trọng, Chủ tịch nước Trần Đại Quang, Chủ tịch Quốc hội Nguyễn Thị Kim Ngân và Thủ tướng Nguyễn Xuân Phúc là những người đầu tiên bỏ phiếu.
 >> 69 triệu cử tri cả nước đi bầu cử
7h11 sáng 22/5, tổ bầu cử tại số 58 Nguyễn Du tiến hành kiểm tra hòm phiếu. 2 cử tri được mời chứng kiến, giám sát việc kiểm tra và niêm phong hòm phiếu. Các cử tri xác nhận hòm phiếu trống tại thời điểm này. Quy trình niêm phong được thực hiện ngay trước mặt những người tham dự lễ khai mạc.

Tổ bầu cử mời Tổng Bí thư Nguyễn Phú Trọng ra khu vực nhận phiếu, thực hiện việc bỏ phiếu. Cùng với Tổng Bí thư, cụ bà Bùi Thị Sáu là cử tri cao tuổi nhất và anh Nguyễn Hữu Hòa là cử tri trẻ tuổi nhất thực hiện việc bỏ những lá phiếu đầu tiên tại điểm bầu cử này.

Sau ít phút nghiên cứu, ghi phiếu tại quầy thông tin, Tổng Bí thư Nguyễn Phú Trọng cùng cụ bà Bùi Thị Sáu (SN 1930) đã thả lá phiếu vào hòm phiếu.


Tổng Bí thư Nguyễn Phú Trọng bỏ phiếu tại tổ bầu cử số 3, phường Nguyễn Du, quận Hai Bà Trưng, Hà Nội (Ảnh: Quý Đoàn)
', 1, N'no-image-large.jpg', N'Đúng 7h sáng nay 22/5, ngày bầu cử đại biểu Quốc hội khóa XIV và đại biểu Hội đồng nhân dân các cấp nhiệm kỳ 2016-2021 chính thức bắt đầu.', N'Toàn cảnh cử tri cả nước đi bầu cử')
INSERT [dbo].[tblTinBai] ([MaTinTuc], [MaTheLoai], [NgayUpdate], [NoiDung], [TrangThaiTin], [HinhDaiDien], [Mota], [TieuDe]) VALUES (11, 2, CAST(N'2016-05-22 16:58:44.260' AS DateTime), N'Là một chương trình trao đổi giáo viên được thiết lập từ năm 2008, cho đến nay Chương trình đã xây dựng được 243 quan hệ đối tác BRIDGE, thu hút sự tham gia của 486 trường phổ thông và 745 giáo viên từ các quốc gia Australia, Trung Quốc, Ấn Độ, Indonesia, Malaysia, Hàn Quốc và Thái Lan.

Chương trình đã và đang được triển khai rất thành công. Vì vậy Chính phủ Australia quyết định nhân rộng chương trình ra toàn bộ các nước thuộc khu vực ASEAN, khởi đầu là sự tham gia của Thái Lan, Malaysia và Việt Nam trong năm 2016.
BRIDGE là chữ viết tắt của cụm từ “Thiết lập Quan hệ thông qua Đối thoại Liên Văn hóa và Gia tăng Hợp tác” (nguyên văn tiếng Anh là: Building Relationships through Intercultural Dialogue and Growing Engagement). Đây là một mô hình kết hợp cả việc học tập chuyên môn thông qua gặp gỡ trực tiếp và các hoạt động giao lưu trực tuyến giúp kết nối giáo viên, học sinh và các cộng đồng trường học ở Australia và các nước Đông Nam Á nhằm nâng cao hiểu biết về đất nước Australia và châu Á đương đại.

Chương trình nhằm mục tiêu xây dựng các mối quan hệ giữa các cá nhân tham gia chương trình, giữa các trường và giúp giáo viên hiểu biết thêm về văn hóa, tăng cường khả năng ngoại ngữ, có thêm các kỹ năng công nghệ thông tin, truyền thông và kỹ năng sư phạm mới, từ đó tạo ra những trải nghiệm và kết quả học tập có chất lượng cho học sinh và dẫn dắt sự thay đổi của nhà trường.

Chương trình sẽ có sự tham gia của 05 trường tiểu học và trung học cơ sở của Việt Nam và 05 trường học đối tác của Australia năm 2016. Các giáo viên tham gia năm nay đến từ trường Tiểu học Đoàn Thị Điểm, Trung học cơ sở Phan Chu Trinh, Trung học Cơ sở Thăng Long tại Hà Nội và Trường Tiểu học Lê Ngọc Hân và Trường Trung học Cơ sở Lê Quý Đôn tại TP. Hồ Chí Minh.

Các giáo viên sẽ tham gia một chương trình tập huấn chuyên môn dài 12 ngày tại Australia từ ngày 28/5 đến 8/6. Họ sẽ dự giờ các lớp học, tham gia giảng dạy theo nhóm, tham dự các cuộc họp giáo viên, các cuộc họp nhóm về chương trình giảng dạy, các hoạt động thu hút sự tham gia của phụ huynh và các hoạt động dã ngoại với trường đối tác của họ ở Australia.

Sau đó, các giáo viên này và trường của họ sẽ tiếp đón các giáo viên của trường đối tác trong 10 ngày vào tháng 10 năm nay đồng thời tham gia cộng đồng học trực tuyến của Chương trình.

Các giáo viên được lựa chọn tham gia chương trình có khả năng Anh ngữ tốt, có kỹ năng vi tính và hứng thú với việc sử dụng công nghệ thông tin, truyền thông trong quá trình dạy học trên lớp. Các trường học được lựa chọn là những trường có năng lực công nghệ thông tin phù hợp, đồng thời quan tâm tới việc đẩy mạnh sử dụng công nghệ thông tin và truyền thông trong hoạt động giảng dạy của nhà trường và có thể tham gia chương trình cộng đồng học trực tuyến với các trường thành viên ở các quốc gia khác.

Theo biên bản ghi nhớ giữa Bộ Giáo dục và Đào tạo Việt Nam và Quỹ Giáo dục Châu Á (AEF), trực thuộc Trường Đại học Melbourne, là đơn vị thực hiện thay mặt cho Chính phủ Australia, ít nhất 13 giáo viên của 13 trường phổ thông Việt Nam sẽ được lựa chọn tham gia Chương trình này trong giai đoạn 2016-2018.

Lễ khai trương chính thức Chương trình Quan hệ đối tác (BRIDGE) giữa các trường học Australia và ASEAN năm 2016 sẽ được tổ chức tại Canberra, Australia vào ngày 30/5 tới.', 1, N'viet-nam-tham-gia-chuong-trinh-trao-doi-giao-vien-voi-australia-va-asean.jpg', N'Năm nay sẽ là năm đầu tiên Việt Nam tham gia Chương trình Quan hệ đối tác (BRIDGE) giữa các trường học Australia và ASEAN.', N'Việt Nam tham gia chương trình trao đổi giáo viên với Australia và ASEAN')
INSERT [dbo].[tblTinBai] ([MaTinTuc], [MaTheLoai], [NgayUpdate], [NoiDung], [TrangThaiTin], [HinhDaiDien], [Mota], [TieuDe]) VALUES (1007, 2, CAST(N'2016-06-04 10:22:06.300' AS DateTime), N'', 0, N'Capture.JPG', N'', N'')
INSERT [dbo].[tblTinBai] ([MaTinTuc], [MaTheLoai], [NgayUpdate], [NoiDung], [TrangThaiTin], [HinhDaiDien], [Mota], [TieuDe]) VALUES (1008, 2, CAST(N'2016-06-04 10:30:39.000' AS DateTime), N'', 0, N'Capture.JPG', N'', N'')
SET IDENTITY_INSERT [dbo].[tblTinBai] OFF
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([id], [TenDangNhap], [MatKhau], [PhanQuyen]) VALUES (4, N'thuvp', N'123456', N'Admin')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Lop] FOREIGN KEY([MaLop])
REFERENCES [dbo].[Lop] ([MaLop])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Lop]
GO
ALTER TABLE [dbo].[tblTinBai]  WITH CHECK ADD  CONSTRAINT [FK_TinTuc_TheLoai] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[tblTheLoai] ([MaTheLoai])
GO
ALTER TABLE [dbo].[tblTinBai] CHECK CONSTRAINT [FK_TinTuc_TheLoai]
GO
/****** Object:  StoredProcedure [dbo].[delete_tinbai]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_tinbai] 
	@matin int
AS
BEGIN
	delete from tblTinBai where MaTinTuc=@matin
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteDiem]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[DeleteDiem]
@MaSv int,
@MaMon int
as begin
delete from Diem where MaSv=@MaSv and MaMon=@MaMon
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteKhoa]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[DeleteKhoa]
@MaKhoa int
as
begin
delete from Khoa where MaKhoa=@MaKhoa
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteLop]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[DeleteLop]
@MaLop int
as
begin
delete from Lop where MaLop=@MaLop
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteMonHoc]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[DeleteMonHoc]
@MaMon int
as
begin
delete from MonHoc where MaMon=@MaMon
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteSV]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[DeleteSV]
@MaSV int
as
begin
delete from SinhVien where MaSv=@MaSV
end
GO
/****** Object:  StoredProcedure [dbo].[KiemTraUser]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KiemTraUser] 
	@username varchar(50),
	@password varchar(50)
AS
BEGIN
	select * from tblUser where username=@username and password=@password
END


GO
/****** Object:  StoredProcedure [dbo].[NhapTheLoai]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NhapTheLoai]
@tentheloai nvarchar(50)
	AS
BEGIN
	insert into tblTheLoai(tentheloai) values(@tentheloai)
END


GO
/****** Object:  StoredProcedure [dbo].[them_lich]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[them_lich] 
	@tieude nvarchar(max),@noidung nvarchar(max),@thoigianbatdau datetime,@thoigianketthuc datetime,@diachi nvarchar(50)
AS
BEGIN
	insert into LichThi(TieuDe,NoiDung,ThoiGianBatDau,ThoiGianKetThuc,DiaChi) values(@tieude,@noidung,@thoigianbatdau,@thoigianketthuc,@diachi)
END


GO
/****** Object:  StoredProcedure [dbo].[them_tinbai]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[them_tinbai]
	@noidung nvarchar(max),@trangthai int,@hinhdaidien nvarchar(100),@mota nvarchar(max),@tieude nvarchar(100),@matheloai int
AS
BEGIN

	insert into tblTinBai(MaTheLoai,NgayUpdate,NoiDung,TrangThaiTin,HinhDaiDien,Mota,TieuDe) values(@matheloai,(SELECT {fn NOW()}),@noidung,@trangthai,@hinhdaidien,@mota,@tieude)
END


GO
/****** Object:  StoredProcedure [dbo].[them_user]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[them_user] 
	@tendn nvarchar(50),@matkhau nvarchar(50),@phanquyen nvarchar(100)
AS
BEGIN
	insert into tblUser(TenDangNhap,MatKhau,PhanQuyen) values(@tendn,@matkhau,@phanquyen)
	end

GO
/****** Object:  StoredProcedure [dbo].[ThemDiemSV]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemDiemSV]
@MaSv int,
@MaMon int,
@DiemTP float,
@DiemThi float,
@NgayCapNhat datetime
as
begin
insert into Diem(MaSv,MaMon,DiemTP,DiemThi,NgayCapNhat)values(@MaSv,@MaMon,@DiemTP,@DiemThi,@NgayCapNhat)
end
/*create proc UpdateMonHoc
@MaMon int,
@TenMon nvarchar(50)
as begin
update MonHoc set TenMon=@TenMon where MaMon=@MaMon
end*/
/*create proc DeleteMonHoc
@MaMon int
as
begin
delete from MonHoc where MaMon=@MaMon
end*/
GO
/****** Object:  StoredProcedure [dbo].[ThemKhoa]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemKhoa]
@TenKhoa nvarchar(50)
as
begin
insert into Khoa(TenKhoa)values(@TenKhoa)
end

GO
/****** Object:  StoredProcedure [dbo].[ThemLop]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemLop]
@TenLop nvarchar(50)
as
begin
insert into Lop(TenLop)values(@TenLop)
end


GO
/****** Object:  StoredProcedure [dbo].[ThemMonHoc]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemMonHoc]
@TenMH nvarchar(50)
as
begin
insert into MonHoc(TenMon)values(@TenMH)
end

GO
/****** Object:  StoredProcedure [dbo].[ThemSV]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ThemSV]
@Masv int,
@Ten nvarchar(100),
@MaLop int,
@NgaySinh datetime,
@GioiTinh bit,
@QueQuan nvarchar(100),
@SDT nvarchar(50)

as
begin
insert into SinhVien(Masv,HoTen,MaLop,NgaySinh,GioiTinh,QueQuan,SDT) values(@Masv,@Ten,@MaLop,@NgaySinh,@GioiTinh,@QueQuan,@SDT)
end
GO
/****** Object:  StoredProcedure [dbo].[timkiem_baitin]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[timkiem_baitin] 
	@tieude nvarchar(100)
AS
BEGIN
	select * from tblTinBai where TieuDe like N'%"+@tieude+"%'
END


GO
/****** Object:  StoredProcedure [dbo].[update_baitin]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_baitin]
	@matintuc int,@noidung nvarchar(max),@trangthai int,@hinhdaidien nvarchar(100),@mota nvarchar(max),@tieude nvarchar(100),@matheloai int
AS
BEGIN
if(@hinhdaidien!='')
	update tblTinBai set MaTheLoai=@matheloai,NgayUpdate=(SELECT {fn NOW()}),NoiDung=@noidung,TrangThaiTin=@trangthai,HinhDaiDien=@hinhdaidien,Mota=@mota,TieuDe=@tieude where MaTinTuc=@matintuc
else
update tblTinBai set MaTheLoai=@matheloai,NgayUpdate=(SELECT {fn NOW()}),NoiDung=@noidung,TrangThaiTin=@trangthai,Mota=@mota,TieuDe=@tieude where MaTinTuc=@matintuc

END


GO
/****** Object:  StoredProcedure [dbo].[update_TheLoai]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_TheLoai]
	
@id int,@tentheloai nvarchar(50)
	as
BEGIN
	update tblTheLoai set tentheloai=@tentheloai where MaTheLoai=@id
END


GO
/****** Object:  StoredProcedure [dbo].[update_user]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_user] 
	@id int,@tendn nvarchar(50),@matkhau nvarchar(50),@phanquyen nvarchar(100)
AS
BEGIN
	update tblUser set TenDangNhap=@tendn,MatKhau=@matkhau,PhanQuyen=@phanquyen where id=@id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateDiem]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[UpdateDiem]
@MaSv int,
@MaMon int,
@DiemTP float,
@DiemThi float,
@NgayCapNhat datetime
as begin
update Diem set DiemTP=@DiemTP,DiemThi=@DiemThi,NgayCapNhat=@NgayCapNhat where MaSv=@MaSv and MaMon=@MaMon
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateKhoa]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[UpdateKhoa]
@MaKhoa int,
@TenKhoa nvarchar(50)

as begin
update Khoa set TenKhoa=@TenKhoa where MaKhoa=@MaKhoa
end
/*create proc DeleteKhoa
@MaKhoa int
as
begin
delete from Khoa where MaKhoa=@MaKhoa
end*/
GO
/****** Object:  StoredProcedure [dbo].[UpdateLop]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*create proc ThemLop
@TenLop nvarchar(50)
as
begin
insert into Lop(TenLop)values(@TenLop)
end*/

create proc [dbo].[UpdateLop]
@MaLop int,
@TenLop nvarchar(50)

as begin
update Lop set TenLop=@TenLop where MaLop=@MaLop
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateMonHoc]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[UpdateMonHoc]
@MaMon int,
@TenMon nvarchar(50)
as begin
update MonHoc set TenMon=@TenMon where MaMon=@MaMon
end
/*create proc DeleteKhoa
@MaKhoa int
as
begin
delete from Khoa where MaKhoa=@MaKhoa
end*/
GO
/****** Object:  StoredProcedure [dbo].[UpdateSV]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdateSV]
@MaSv int,
@Ten nvarchar(100),
@MaLop int,
@NgaySinh datetime,
@GioiTinh bit,
@QueQuan nvarchar(100),
@SDT nvarchar(50)

as begin

update SinhVien set HoTen=@Ten,MaLop=@MaLop,NgaySinh=@NgaySinh,GioiTinh=@GioiTinh,QueQuan=@QueQuan,SDT=@SDT where MaSv=@MaSv
end
GO
/****** Object:  StoredProcedure [dbo].[xoa_TheLoai]    Script Date: 6/28/2016 2:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[xoa_TheLoai]
	-- Add the parameters for the stored procedure here
@id int
AS
BEGIN
	delete from tblTheLoai where MaTheLoai=@id
END


GO
USE [master]
GO
ALTER DATABASE [D8CNPM] SET  READ_WRITE 
GO
