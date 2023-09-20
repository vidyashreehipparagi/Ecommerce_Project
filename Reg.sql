---Database==>MVC_Emp_Dept
select * from Category
select * from Product
drop table product
--Product Table---
create table product(
id int primary key identity(1,1),
name varchar(50),
price numeric(10,2),
imageUrl varchar(200),
Cid int,
constraint fk_cid foreign key(Cid) references Category(Cid)
)

alter table Product alter column name varchar(200)
sp_help Product

-----User Table-----

create table Registration(
id int primary key identity(1,1),
firstName varchar(30),
lastName varchar(30),
userName varchar(30),
password varchar(50),
confirmpwd varchar(50),
gender varchar(30),
email varchar(50),
phoneNumber varchar(50),
address varchar(150),
city varchar(60),
state varchar(60),
pincode int,
RoleId int default 0
)
drop table Registration
select * from Registration
delete Registration where id=2

insert into Registration values('Vidyashree','Hipparagi','admin','admin@123','admin@123','Female','vhipparagi@gmail.com','9975676412','Ramrao Nagar','Jath','Maharashtra',416404,1)
----Cart Table----------
create table Cart(
CartId int primary key identity(1,1),
id  int,
constraint fk_prd foreign key(id) references Product(id),
uid int,
constraint fk_Reg foreign key(uid) references Registration(uid),
Qunatity int
)
select * from Cart
EXEC sp_rename 'Registration.id', 'uid';
 
 select p.*, c.Qunatity from Product p join Cart c on c.id=p.id where c.uid=4
 delete from Cart where CartId=4

 ---Order Table----
 create table Orders(
 OrderId int primary key identity(1,1),
 Qunatity int,
 Date_time DateTime,
CartId int constraint fk_Cart foreign key(CartId) references Cart(CartId),
id  int,
constraint fk_prd_ord foreign key(id) references Product(id),
uid int,
constraint fk_Reg_ord foreign key(uid) references Registration(uid),
)
ALTER TABLE Orders ADD Date_time DATETIME DEFAULT GETDATE();
select * from Orders 
select p.*,o.OrderId,o.Qunatity from Product p join Orders o on o.id=p.id 
select * from Orders values 
select p.*,o.OrderId,o.Qunatity from Product p join Orders o on o.id=p.id

select GETDATE()
alter table Orders drop column CartId
alter table Orders drop constraint fk_Cart
exec sp_help orders
select * from Orders
truncate table orders



CREATE TABLE Orders3 (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    Quantity INT,
    Date_time DATETIME DEFAULT GETDATE(), -- Set the default value to the current date and time
   
);
SELECT * FROM Orders3
INSERT INTO Orders3 VALUES(1,'')
INSERT INTO Orders3 (Quantity) VALUES (10);