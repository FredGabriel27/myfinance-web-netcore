# My Finance Web
MyFinance - Projeto do curso de Pós-Graduação de Engenharia de Software da PUC-MG

## Pré requisitos para implementação

Para realizar a impletação do software são necessários os seguintes pontos:

➔ Instalação do VS : https://code.visualstudio.com/download <br />
➔ Importação das extensões : <br />
<img src="docs\Extensao.png" alt="diagram"> <br />
➔ Instalação do .NET core : https://dotnet.microsoft.com/en-us/download <br />
➔ Impotação da classe DAL - Data Access Layer: : https://www.nuget.org/packages/System.Data.SqlClient <br />

<hr />

## Arquitetura Database

A figura abaixo representa a modelagem lógica do banco de dados da aplicaação no modelo DER - Diagrama de Entidades e Relacionamentos.

<img src="docs\DER.png" alt="diagram">

<hr />

## Script para a modelagem do DB

Na sequencia temos o script para implementar a lógica da base de dados

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

<hr />




