create database cafe 
go
use cafe 

create table workers 
(
	idWorker int primary key identity (1,1) not null,
	[Name] nvarchar(50) not null,
	[Role] nvarchar(15) not null,
	[Login] nvarchar(25) unique not null,
	[Password] nvarchar(25) not null,
	[Status] bit not null
)

create table orders 
(
	idOrder int primary key identity (1,1) not null,
	[Name] nvarchar(50) not null,
	[Status] bit not null,
	Place int not null,
	People int not null,
)

create table [changes]
(
	idWorker int foreign key references workers(idWorker) not null,
	[Name] nvarchar(50) not null
)

insert into workers values ('sakerjbgn', 'Администратор', 'admin', 'admin', 1)
insert into workers values ('sakerjbgn', 'Повар', 'a', 'a', 1)
insert into workers values ('sakerjbgn', 'Повар', 'b', 'b', 1)
insert into workers values ('sakerjbgn', 'Повар', 'c', 'c', 1)
insert into workers values ('sakerjbgn', 'Официант', 'd', 'd', 1)

insert into [changes] values (1, '1 смена')
insert into [changes] values (2, '1 смена')
insert into [changes] values (3, '1 смена')
insert into [changes] values (4, '1 смена')
insert into [changes] values (5, '1 смена')

insert into orders values ('odrash', 0, 1, 1)
insert into orders values ('hrtweb', 0, 1, 1)
insert into orders values ('vwtr', 0, 1, 1)
insert into orders values ('wrtv', 0, 1, 1)
insert into orders values ('sadfg', 0, 1, 1)

