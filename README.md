# Projeto base para Calculadora.Console

**Calculadora.Console** é um modelo inicial para o segundo projeto PDI jr.

## Criando um projeto baseado no Calculadora.Console

A forma mais simples de criar um projeto baseado no **Calculadora.Console** é obtendo o mesmo em seu diretorio.

Bons estudos!

SCRIPT BD

Create database calculadora_frwk

Use calculadora_frwk
go

Create table OperacoesHistorico
(
Id int IDENTITY(1,1) not null,
NomeOperacao varchar(50) not null,
Resultado float not null,
DataHoraOperacao datetime not null,
constraint Pk_OperacaoHistorico primary key clustered (Id ASC)
);