-- Create/recreate database
USE Master
ALTER DATABASE QuanPCChuot SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE QuanPCChuot
GO
CREATE DATABASE QuanPCChuot
GO
USE QuanPCChuot
GO

-- Table 'Account'
-- Manage created account for login and manage in database.
CREATE TABLE Account (
	-- ID tài khoản (tự tạo)
	ID				BIGINT NOT NULL IDENTITY(1,1),
	-- Tên đăng nhập
	Username		VARCHAR(32) NOT NULL,
	-- Mật khẩu
	Password		VARCHAR(32) NOT NULL,
	-- Tên hiển thị
	Name			NVARCHAR(MAX),
	-- Số điện thoại
	Telephone		VARCHAR(20),
	-- Có phải là quản trị viên? (1: có, 0: không)
	IsAdmin			BIT NOT NULL DEFAULT 0,
	-- Ngày tạo (tự tạo)
	CreatedDate		DATETIME NOT NULL DEFAULT GETDATE(),
	-- Đặt ID làm khóa chính
	PRIMARY KEY (ID)
)
GO

-- Table 'ItemGroup'
-- Manage item group for items in inventory for easier to find.
CREATE TABLE ItemGroup (
	-- ID nhóm (tự tạo)
	ID				BIGINT NOT NULL IDENTITY(1,1),
	-- Tên nhóm
	Name			NVARCHAR(MAX) NOT NULL,
	-- Nội dung nhóm
	Description		NVARCHAR(MAX),
	-- Ngày tạo (tự tạo)
	CreatedDate		DATETIME NOT NULL DEFAULT GETDATE(),
	-- Đặt ID làm khóa chính
	PRIMARY KEY (ID)
)

-- Table 'Inventory'
CREATE TABLE Inventory (
	-- ID (tự động tạo)
	ID				BIGINT NOT NULL IDENTITY(1,1),
	-- Tên link kiện/máy tính
	Name			NVARCHAR(MAX) NOT NULL,
	-- Nhà sản xuất
	Manufacturer	NVARCHAR(MAX),
	-- Số lượng
	Count			BIGINT NOT NULL DEFAULT 0,
	-- Chú thích
	Description		NVARCHAR(MAX),
	-- Giá mua
	CostPrice		DECIMAL NOT NULL DEFAULT 0,
	-- Giá bán
	SellPrice		DECIMAL NOT NULL DEFAULT 0,
	-- Bảo hành theo tháng (0 là không bảo hành)
	Warranty		INT NOT NULL DEFAULT 0,
	-- ID nhóm (để phân loại)
	GroupID			BIGINT NOT NULL,
	-- Đơn vị tính (bằng chữ)
	Unit			NVARCHAR(MAX),
	-- Ngày thêm vào (tự động tạo)
	LastAddDate		DATETIME NOT NULL DEFAULT GETDATE(),
	-- Đặt ID làm khóa chính
	PRIMARY KEY (ID),
	-- Liên kết GroupID với ID của ItemGroup
	FOREIGN KEY (GroupID) REFERENCES ItemGroup(ID)
)
GO

-- Table 'Bill'
CREATE TABLE Bill (
	-- ID của hóa đơn
	ID					BIGINT NOT NULL IDENTITY(1,1),
	-- Khách hàng
	CustomerName		NVARCHAR(MAX),
	-- Địa chỉ (để giao hàng)
	CustomerAddress		NVARCHAR(MAX),
	-- Số đt khách hàng
	CustomerTelephone	VARCHAR(20),
	-- ID tài khoản thực hiện
	StaffID				BIGINT NOT NULL,
	-- ID các dịch vụ đã mua
	ServiceIDs			NVARCHAR(MAX),
	-- Có giảm giá không? (1: có, 0: không)
	DiscountEnabled		BIT NOT NULL DEFAULT 0,
	-- Chế độ giảm giá (1: theo phần trăm, 0: theo số tiền)
	DiscountType		BIT NOT NULL DEFAULT 0,
	-- Giá trị giảm giá
	DiscountValue		DECIMAL NOT NULL DEFAULT 0,
	-- Đã thanh toán (2: xong, 1: hủy, 0: chưa)
	Purchased			INT NOT NULL DEFAULT 0,
	-- Ngày tạo hóa đơn
	CreatedDate		DATETIME NOT NULL DEFAULT GETDATE(),
	-- Đặt ID làm khóa chính
	PRIMARY KEY (ID),
	-- Liên kết StaffID với ID của Account
	FOREIGN KEY (StaffID) REFERENCES Account(ID),
)
GO

-- Table 'Log'
-- Manage user activites
CREATE TABLE Log (
	-- ID của bản ghi
	ID				        BIGINT NOT NULL IDENTITY(1,1),
    -- ID tài khoản thực hiện
    StaffID			        BIGINT NOT NULL,
    -- Nội dung thực hiện
    Description             NVARCHAR(MAX),
    -- Ngày bản ghi
    CreatedDate             DATETIME NOT NULL DEFAULT GETDATE(),
	-- Đặt ID làm khóa chính
	PRIMARY KEY (ID),
	-- Liên kết StaffID với ID của Account
    FOREIGN KEY (StaffID)   REFERENCES Account(ID),
)
GO

-- Delete previous data from all table
USE QuanPCChuot
DELETE FROM Log
GO
DELETE FROM Bill
GO
DELETE FROM Inventory
GO
DELETE FROM ItemGroup
GO
DELETE FROM Account
GO

-- Account
INSERT INTO Account (Username, Password, Name, IsAdmin)
VALUES (N'Administrator', N'e10adc3949ba59abbe56e057f20f883e', N'Administrator', 1)
GO
INSERT INTO Account (Username, Password, Name, IsAdmin)
VALUES (N'Staff', N'e10adc3949ba59abbe56e057f20f883e', N'Staff', 0)
GO

-- Item Group
INSERT INTO ItemGroup(Name)
VALUES (N'CPU')
GO
INSERT INTO ItemGroup(Name)
VALUES (N'RAM')
GO
INSERT INTO ItemGroup(Name)
VALUES (N'Laptop')
GO
INSERT INTO ItemGroup(Name)
VALUES (N'PC')
GO
INSERT INTO ItemGroup(Name)
VALUES (N'Accessories')
GO

-- Inventory
INSERT INTO Inventory(Name, Manufacturer, Count, CostPrice, SellPrice, Warranty, GroupID, Unit)
VALUES (N'Intel Core i3-9100', N'Intel', 100, 2806000, 2806000, 36, 6, N'cái')
GO
INSERT INTO Inventory(Name, Manufacturer, Count, CostPrice, SellPrice, Warranty, GroupID, Unit)
VALUES (N'Intel Core i3-9100F', N'Intel', 100, 2231000, 2231000, 36, 6, N'cái')
GO
INSERT INTO Inventory(Name, Manufacturer, Count, CostPrice, SellPrice, Warranty, GroupID, Unit)
VALUES (N'Intel Core i3-9100F', N'Intel', 100, 2231000, 2231000, 36, 6, N'cái')
GO
INSERT INTO Inventory(Name, Manufacturer, Count, CostPrice, SellPrice, Warranty, GroupID, Unit)
VALUES (N'RAM desktop Gskill Trident Z Neo (F4-3600C16D-16GTZNC) 8GB DDR4 3600MHz', N'Gskill', 100, 3099000, 3099000, 36, 7, N'cái')
GO
INSERT INTO Inventory(Name, Manufacturer, Count, CostPrice, SellPrice, Warranty, GroupID, Unit)
VALUES (N'RAM desktop DDRam 4 Kingston ECC 32GB/2666 - KSM26RD4/32HAI Registered', N'Kingston', 100, 6190000, 6190000, 36, 7, N'cái')
GO
INSERT INTO Inventory(Name, Manufacturer, Count, CostPrice, SellPrice, Warranty, GroupID, Unit)
VALUES (N'RAM desktop DDR4 Micron ECC 16GB/2133Mhz (ECC Registered)', N'Micron', 100, 1399000, 1399000, 36, 7, N'cái')
GO
INSERT INTO Inventory(Name, Manufacturer, Count, CostPrice, SellPrice, Warranty, GroupID, Unit)
VALUES (N'RAM desktop AXPRO 2GB (1x2GB) DDR3 1600MHz', N'AXPRO', 100, 259000, 259000, 36, 7, N'cái')
GO

