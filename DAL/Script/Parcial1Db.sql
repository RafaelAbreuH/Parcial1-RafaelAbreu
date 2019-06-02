create database Parcial1Db
go
use Parcial1Db

create table Productos
(
	ProductoId int primary key identity,
	Descripcion varchar(max),
	Existencia int,
	Costo int,
	ValorInventario int
)


create table Inventario
(
    InventarioId int primary key identity,
	ValorTotalInventario float
)

