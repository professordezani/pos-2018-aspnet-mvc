create database BDTarefa
go
use BDTarefa
go

create table Tarefa
(
	TarefaId int primary key identity,
	Nome varchar(200) not null,
	Concluida bit not null,
	Data datetime not null
)

insert into Tarefa values ('Lavar o carro', 0, GETDATE())

select * from Tarefa