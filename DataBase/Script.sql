create database botan
on 
(
	name = botan,
	filename = 'I:\Demo\БД\botan.mdf' -- Путь должен быть свой
)
log on 
(
	name = botan_log,
	filename = 'I:\Demo\БД\botan_log.ldf' -- Путь должен быть свой
)
collate Cyrillic_General_CI_AS
go
use botan

create table workers
(
	idWorker int primary key identity (1,1) not null,
	[Name] nvarchar(50) not null,
	[Role] nvarchar(20) not null,
	[Login] nvarchar(25) unique not null,
	[Password] nvarchar(25) not null,
	Dissamble bit default 0 not null
)

create table [changes]
(
	idChanges int primary key identity (1,1) not null,
	idWorker int foreign key references workers(idWorker) not null,
	[Name] nvarchar(10) not null
)

create table orders
(
	idOrder int primary key identity (1,1) not null,
	nameClient nvarchar(50) not null,
	Phone nvarchar(15) not null,
	Gotovnost bit default 0 not null,
	Prinat bit default 0 not null
)

insert into workers values ('aeh', 'Заведующий', 'admin', 'admin', 0)
insert into workers values ('aeh', 'Техник', 'teh', 'teh', 0)
insert into workers values ('aeh', 'Организатор', 'org', 'org', 0)