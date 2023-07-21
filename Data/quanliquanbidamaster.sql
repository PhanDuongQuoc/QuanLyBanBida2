CREATE DATABASE QuanLyQuanBidamaster
GO

USE QuanLyQuanBidamaster
GO

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo

CREATE TABLE TableBida
(
	id INT  PRIMARY	KEY,
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
	id INT  PRIMARY	KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chua dat ten',
)
GO

CREATE TABLE Food
(
	id INT PRIMARY	KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chua dat ten',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL,

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id),
)
GO

CREATE TABLE BILL 
(
	id INT PRIMARY	KEY,
	DateChecKIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE NOT NULL,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: da thanh toan && 0: chua thanh toan

	FOREIGN KEY (idTable) REFERENCES dbo.TableBida(id),
)
GO
-- Set giá trị của Date lại thành null
Alter table BILL
Alter column DateCheckOut DATE null

CREATE TABLE BillInfo
(
	id INT PRIMARY	KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0,

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id),
)
Go



-- bảng thông tin khách hàng



CREATE TABLE Customer (
	idcustomer varchar(100) PRIMARY KEY,
	name nvarchar(100),
	gender nvarchar(100),
	phonenumber nvarchar(100),
	daycheckin varchar(100),
	idcategorycustomer nvarchar(100),

);
drop table Customer

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
While @i <=20
Begin

	Insert dbo.TableBida (id,name) values (@i, N'Bàn'+cast(@i as nvarchar(100)))

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
VALUES (3, N'Bia' -- name - nvachar(100)
		)

-- Thêm món ăn

INSERT dbo.Food
	(id,name,idCategory,price)
VALUES (1, N'Sting', -- name - nvarchar(100)
		1, -- idCategory - int
		15000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES ( 2,N'Pessi', -- name - nvarchar(100)
		1, -- idCategory - int
		15000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES (3, N'Coca', -- name - nvarchar(100)
		1, -- idCategory - int
		15000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES (4, N'7Up', -- name - nvarchar(100)
		1, -- idCategory - int
		15000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES (5, N'Bò cụng', -- name - nvarchar(100)
		1, -- idCategory - int
		15000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES ( 6,N'Mận', -- name - nvarchar(100)
		2, -- idCategory - int
		25000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES ( 7,N'Ổi', -- name - nvarchar(100)
		2, -- idCategory - int
		20000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES (8, N'Nho', -- name - nvarchar(100)
		2, -- idCategory - int
		30000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES (9, N'Thơm thái', -- name - nvarchar(100)
		2, -- idCategory - int
		20000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES ( 10,N'Dưa hấu', -- name - nvarchar(100)
		2, -- idCategory - int
		18000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES (11, N'SaiGon', -- name - nvarchar(100)
		3, -- idCategory - int
		30000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES (12, N'Heniken', -- name - nvarchar(100)
		3, -- idCategory - int
		50000
		)
INSERT Food
	(id,name,idCategory,price)
VALUES (13, N'Tiger', -- name - nvarchar(100)
		3, -- idCategory - int
		45000
		)
-- Thêm bill
INSERT BILL
	()
VALUES ( GETDATE())
-- Thêm bill
declare @i INT =1
While @i <=20
Begin
	Insert dbo.BILL(id,DateChecKIn,DateCheckOut,idTable,status) values (@i,GETDATE(),null,@i,0)
set @i = @i+1
End
-- Thêm billInfo

/*DECLARE @i INT = 1
DECLARE @j INT = 1
DECLARE @k INT

WHILE @i <= 20
BEGIN
    SET @k = @i
	set @j=1;

    WHILE @j <= 13
	 
    BEGIN
        INSERT INTO dbo.BillInfo (id, idBill, idFood, count)
        VALUES (@i, @k, @j, 1)
        
        SET @j = @j + 1
    END
    
    SET @i = @i + 1
END*/

insert BillInfo(id,idBill,idFood,count) values(1,01,1,3)
go
insert BillInfo(id,idBill,idFood,count) values(2,02,4,2)
go
insert BillInfo(id,idBill,idFood,count) values(3,03,3,3)
go
insert BillInfo(id,idBill,idFood,count) values(4,04,2,1)
go
insert BillInfo(id,idBill,idFood,count) values(5,05,5,4)
go
insert BillInfo(id,idBill,idFood,count) values(6,06,2,3)
go
insert BillInfo(id,idBill,idFood,count) values(7,07,1,2)
go
insert BillInfo(id,idBill,idFood,count) values(8,08,2,4)
go
insert BillInfo(id,idBill,idFood,count) values(9,09,6,6)
insert BillInfo(id,idBill,idFood,count) values(10,10,11,8)
go
insert BillInfo(id,idBill,idFood,count) values(11,11,1,3)
go
insert BillInfo(id,idBill,idFood,count) values(12,12,1,2)
go
insert BillInfo(id,idBill,idFood,count) values(13,13,2,3)
go
insert BillInfo(id,idBill,idFood,count) values(14,14,6,3)
go
insert BillInfo(id,idBill,idFood,count) values(15,15,2,2)
go
insert BillInfo(id,idBill,idFood,count) values(16,16,3,5)
go
insert BillInfo(id,idBill,idFood,count) values(17,17,2,2)
go
insert BillInfo(id,idBill,idFood,count) values(18,18,6,4)
go
insert BillInfo(id,idBill,idFood,count) values(19,19,3,6)
go
insert BillInfo(id,idBill,idFood,count) values(20,20,9,3)
go



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

select *from dbo.TableBida


/*chèn dữ liệu vào bill*/

alter proc USP_chendulieuvaobill1
@idTable int
as
begin 
	insert dbo.BILL(id ,DateChecKIn,DateCheckOut,idTable,status,discount) values (1,GETDATE(),null,@idTable,0,0)

end


create proc USP_adddulieubillinfo2
@id int,@idBill int ,@idFood int, @count int
as
begin
	insert dbo.BillInfo(id,idBill,idFood,count) values (@id,@idBill,@idFood,@count)


end

select max(id) from bill


CREATE TRIGGER UTG_UPDATEBILLINFO
on dbo.BillInfo for insert,update 
as
begin 
	declare @idBill int 
	select @idBill=idBill from Inserted
	declare @idTable int 
	select @idTable=idTable from dbo.BILL where id=@idBill and status=0
	Update dbo.TableBida set status=N'Có Người' Where id =@idTable

end
go


create trigger UTG_UPDATEBILL
ON dbo.Bill for Update 
as
begin
	declare @idBill int 
	select @idBill=id from Inserted
	declare @idTable int 
	select @idTable=idTable from dbo.BILL where id=@idBill
	declare @count int =0
	select @count=count(*)from dbo.BILL where idTaBle=@idTable and status=0
	if(@count=0)
		update dbo.TableBida set status=N'Trống'where id=@idTable
end
go

alter Table dbo.BILL
add discount int 

update dbo.BILL set discount=0

select *from dbo.BILL