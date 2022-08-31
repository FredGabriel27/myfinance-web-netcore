create database my_finance;

create table plano_contas(
	id int identity(1,1) not null,
	descricao varchar(50) not null,
	tipo char(1) not null,
	primary key(id)
);

create table transacao(
	id bigint identity(1,1) not null,
	data datetime not null,
	valor decimal(18,2) not null,
	tipo char(1),
	historico text null,
	id_plano_conta int not null,
	primary key(id),
	foreign key(id_plano_conta) references plano_contas
);


insert into plano_contas(descricao,tipo) values ('Aluguel','C'); 
insert into plano_contas(descricao,tipo) values ('Alimentação','D'); 
insert into plano_contas(descricao,tipo) values ('Combustível','D'); 
insert into plano_contas(descricao,tipo) values ('Viagens','D'); 
insert into plano_contas(descricao,tipo) values ('Salario','C'); 

insert into transacao(data, valor,tipo,historico,id_plano_conta) values(GETDATE(),100.50,'D', 'Gasolina de viagens',3);
insert into transacao(data, valor,tipo,historico,id_plano_conta) values(GETDATE(),38.50,'D', 'Almoço',2);
insert into transacao(data, valor,tipo,historico,id_plano_conta) values(GETDATE()-1,55.50,'D', 'Almoço',2);
insert into transacao(data, valor,tipo,historico,id_plano_conta) values(GETDATE()-30,5500,'C', 'Salário empresa 1',5);





