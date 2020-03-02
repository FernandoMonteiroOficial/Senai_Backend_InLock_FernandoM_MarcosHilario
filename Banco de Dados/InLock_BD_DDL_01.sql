 CREATE DATABASE InLock_Games_Tarde; USE InLock_Games_Tarde; CREATE TABLE Estudio (	IdEstudio		INT PRIMARY KEY IDENTITY,	NomeEstudio		VARCHAR(100) NOT NULL UNIQUE ); CREATE TABLE Jogo (	IdJogo			INT PRIMARY KEY IDENTITY,	NomeJogo		VARCHAR(100),	Descricao		VARCHAR(200),	DataLancamento	DATE, 	Valor			DOUBLE,	IdEstudio		INT FOREIGN KEY REFERENCES Estudio(IdEstudio)); CREATE TABLE TipoUsuario (
	IdTipoUsuario	INT PRIMARY KEY IDENTITY,
	Titulo			VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Usuario (
	IdUsuario		INT PRIMARY KEY IDENTITY,
	Email			VARCHAR(100) NOT NULL UNIQUE,
	Senha			VARCHAR(100) NOT NULL,
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
);select * from jogo