
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string stringConexao = "Data Source=LAPTOP-6GS7ET34; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=123456";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string selectEmailSenha = "SELECT* FROM Usuario WHERE(Email = @Email) AND(Senha = @Senha)";

                using (SqlCommand cmd = new SqlCommand(selectEmailSenha, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            TipoUser = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                Titulo = rdr[1].ToString()
                            }
                        };

                        return usuario;
                    }
                }
                return null;
            }

        }

        public UsuarioDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> usuarios = new List<UsuarioDomain>();

            using(SqlConnection con = new SqlConnection (stringConexao))
            {
                string querySelectAll = " SELECT U.IdUsuario, U.Email, U.IdTipoUsuario, TU.Titulo FROM Usuario U INNER JOIN TipoUsuario TU ON U.IdTipoUsuario = TU.IdTipoUsuario";
                

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            
                            Email = rdr["Email"].ToString(),
                            
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            TipoUser = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };

                        
                        usuarios.Add(usuario);
                    }

                }
            }

            return usuarios;
        }
    }
}
