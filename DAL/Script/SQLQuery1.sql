create database Parcial1Db
go
use Parcial1Db

create table Productos
(
	ProductoId int primary key identity,
	Desripcion varchar(max),
	Existencia int,
	Costo int,
	ValorInventario int
)


create table Inventario
(
	ValorTotalInventario float
)
