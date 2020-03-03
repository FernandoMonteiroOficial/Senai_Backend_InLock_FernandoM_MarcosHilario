
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

        public UsuarioDomain BuscarPorId(int id)
        {
            
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
