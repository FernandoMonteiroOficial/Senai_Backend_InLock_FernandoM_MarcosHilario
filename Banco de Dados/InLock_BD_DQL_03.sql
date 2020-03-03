 USE InLock_Games_Tarde;

 SELECT * FROM Estudio;

 SELECT * FROM Jogo;

 SELECT * FROM TipoUsuario;

 SELECT * FROM Usuario;

 SELECT Jogo.NomeJogo, Estudio.NomeEstudio FROM Jogo
 INNER JOIN Estudio 
 ON Jogo.IdJogo = Estudio.IdEstudio; 

 SELECT Jogo.NomeJogo, Estudio.NomeEstudio FROM Jogo
 RIGHT JOIN Estudio 
 ON Jogo.IdJogo = Estudio.IdEstudio; 

 SELECT * FROM Jogo 
 WHERE IdJogo = 2;

 SELECT * FROM Estudio
 WHERE IdEstudio = 2;


 SELECT U.IdUsuario, U.Email, U.Senha , U.IdTipoUsuario, T.Titulo FROM Usuario U INNER JOIN TipoUsuario T ON U.IdTipoUsuario = T.IdTipoUsuario 
 WHERE Email = 'admin@admin.com' and Senha= 'admin';

 





