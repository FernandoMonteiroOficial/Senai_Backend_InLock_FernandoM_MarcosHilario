 USE InLock_Games_Tarde;

 INSERT INTO Estudio (NomeEstudio)
 VALUES		('Blizzard'), ('Rockstar Studios'), ('Square Enix');

INSERT INTO Jogo (NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)
VALUES		('Diablo 3', ' um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', '20120515', 99, 1),
			(' Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western', '20181026', 120, 2);

INSERT INTO TipoUsuario (Titulo)
VALUES ('Administrador'), ('Cliente');

INSERT INTO Usuario (Email, Senha, IdTipoUsuario)
VALUES		('admin@admin.com', 'admin', 1),
			('cliente@cliente.com', 'cliente', 2);

			