CREATE DATABASE QUANLIQUANBIDA
GO

USE QUANLIQUANBIDA
GO

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo

CREATE TABLE TableBida
(
	id INT PRIMARY	KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Ban chua co ten',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trong', -- Trong || Co Nguoi
)
GO
SET IDENTITY_INSERT TableBida OFF 



CREATE TABLE Account
(
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Staff',
	UserName NVARCHAR(100) PRIMARY KEY,
	PassWord NVARCHAR(1000) NOT NULL,
	Type INT NOT NULL DEFAULT 0 -- 1: admin && 0: staff
)
GO
SET IDENTITY_INSERT Account OFF 

CREATE TABLE FoodCategory
(
	id INT PRIMARY	KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chua dat ten',
)
GO
SET IDENTITY_INSERT FoodCategory OFF 

CREATE TABLE Food
(
	id INT PRIMARY	KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chua dat ten',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL,

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id),
)
GO
SET IDENTITY_INSERT food OFF 

CREATE TABLE BILL 
(
	id INT  PRIMARY	KEY,
	DateChecKIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE NOT NULL,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: da thanh toan && 0: chua thanh toan

	FOREIGN KEY (idTable) REFERENCES dbo.TableBida(id),
)
GO

SET IDENTITY_INSERT Bill OFF 

-- Set giá trị của Date lại thành null
Alter table BILL
Alter column DateCheckOut DATE null

CREATE TABLE BillInfo
(
	id INT  PRIMARY	KEY,
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



--Tạo thủ tục tìm account từ username
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
		(id,name)
VALUES ( 1,N'Nước ngọt' -- name - nvachar(100)
		)

INSERT FoodCategory
		(id,name)
VALUES ( 2,N'Trái cây' -- name - nvachar(100)
		)

INSERT FoodCategory
		(id,name)
VALUES ( 3,N'Bia' -- name - nvachar(100)
		)

-- Thêm món ăn

INSERT dbo.Food
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
-- Thêm bill
declare @i INT =1
While @i <=20
Begin
	Insert dbo.BILL(DateChecKIn,DateCheckOut,idTable,status) values (1,GETDATE(),null,@i,0)
set @i = @i+1
End
-- Thêm billInfo

declare @i INT =141
declare @j int =14
While @i <=160
Begin
	While @j <=26
	begin
			Insert dbo.BillInfo(idBill,idFood,count) values (@i,@j,1)
			set @j=@j+1
	end

set @i = @i+1
End

-- Lấy thông tin bàn
CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableBida
GO
EXEC dbo.USP_GetTableList


select id from dbo.BILL where idTable=3 and status = 0
select * from dbo.BillInfo where idBill=141

select f.name, bi.count, f.price, f.price * bi.count as totalPrice from dbo.BILL as b,dbo.Food as f,dbo.BillInfo as bi 
where bi.idBill=b.id and bi.idFood=f.id and b.idTable = 1


Select * from dbo.BILL
go

select * from dbo.BillInfo
go

select * from dbo.Food
go

select * from dbo.FoodCategory
go

create table DANHMUC
(
	id varchar(100) primary key,
	name nvarchar(100)


)
go