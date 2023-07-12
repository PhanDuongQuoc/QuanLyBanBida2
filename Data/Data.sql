CREATE DATABASE QuanLyQuanBida
GO

USE QuanLyQuanBida
GO

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo

CREATE TABLE TableBida
(
	id INT IDENTITY PRIMARY	KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Ban chua co ten',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trong', -- Trong || Co Nguoi
)
GO

CREATE TABLE Account
(
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Staff',
	UserName NVARCHAR(100) PRIMARY KEY,
	PassWord NVARCHAR(1000) NOT NULL,
	Type INT NOT NULL DEFAULT 0 -- 1: admin && 0: staff
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY	KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chua dat ten',
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY	KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chua dat ten',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL,

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id),
)
GO

CREATE TABLE BILL 
(
	id INT IDENTITY PRIMARY	KEY,
	DateChecKIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: da thanh toan && 0: chua thanh toan

	FOREIGN KEY (idTable) REFERENCES dbo.TableBida(id),
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY	KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0,

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id),
)
Go
-- Thêm dữ liệu vào table account
INSERT INTO dbo.Account
		( UserName,
		  DisplayName,
		  PassWord,
		  Type
		)
VALUES	( N'Staff',
		  N'Staff',
		  N'1',
		 1
		)
INSERT INTO dbo.Account
		( UserName,
		  DisplayName,
		  PassWord,
		  Type
		)
VALUES	( N'Admin',
		  N'Admin',
		  N'1',
		 0
		)

CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO

EXEC dbo.USP_GetAccountByUserName @userName = N'Admin' --nvarchar(100)

GO
-- Kiểm tra login
CREATE PROC USP_Login
@userName nvarchar(100) , @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO
-- Thêm bàn
declare @i INT =1
While @i <=10
Begin
	Insert dbo.TableBida (name) values ( N'Bàn'+cast(@i as nvarchar(100)))
set @i = @i+1
End
-- Thêm Loại đồ ăn
INSERT FoodCategory
		(name)
VALUES ( N'Nước ngọt' -- name - nvachar(100)
		)

INSERT FoodCategory
		(name)
VALUES ( N'Trái cây' -- name - nvachar(100)
		)

INSERT FoodCategory
		(name)
VALUES ( N'Bia' -- name - nvachar(100)
		)

-- Thêm món ăn

INSERT Food
	(name,idCategory,price)
VALUES ( N'Sting', -- name - nvarchar(100)
		1, -- idCategory - int
		15000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'Pessi', -- name - nvarchar(100)
		1, -- idCategory - int
		15000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'Coca', -- name - nvarchar(100)
		1, -- idCategory - int
		15000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'7Up', -- name - nvarchar(100)
		1, -- idCategory - int
		15000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'Bò cụng', -- name - nvarchar(100)
		1, -- idCategory - int
		15000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'Mận', -- name - nvarchar(100)
		2, -- idCategory - int
		25000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'Ổi', -- name - nvarchar(100)
		2, -- idCategory - int
		20000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'Nho', -- name - nvarchar(100)
		2, -- idCategory - int
		30000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'Thơm thái', -- name - nvarchar(100)
		2, -- idCategory - int
		20000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'Dưa hấu', -- name - nvarchar(100)
		2, -- idCategory - int
		18000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'SaiGon', -- name - nvarchar(100)
		3, -- idCategory - int
		30000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'Heniken', -- name - nvarchar(100)
		3, -- idCategory - int
		50000
		)
INSERT Food
	(name,idCategory,price)
VALUES ( N'Tiger', -- name - nvarchar(100)
		3, -- idCategory - int
		45000
		)
-- Thêm bill
INSERT BILL
	()
VALUES ( GETDATE()
-- Thêm bàn
declare @i INT =1
While @i <=20
Begin
	Insert dbo.BILL(DateChecKIn,DateCheckOut,idTable,status) values (GETDATE(),null,@i,0)
set @i = @i+1
End
Select * from dbo.TableBida
drop table dbo.BILL


CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableBida
GO

EXEC dbo.USP_GetTableList


Select * from dbo.BILL
go

select * from dbo.BillInfo
go

select * from dbo.Food
go

select * from dbo.FoodCategory
go