using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    /// <summary>       
    /// Repositório dos TipoUsuarios
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        private string stringConexao = "Data Source=DEV701\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";


        /// <summary>
        /// Lista todos os tipousuarios com os nomes completos
        /// </summary>
        /// <returns>Retorna uma lista de tiposusuarios</returns>
        public List<TipoUsuarioDomain> Listar()
        {
            // Cria uma lista tipousuario onde serão armazenados os dados
            List<TipoUsuarioDomain> lista = new List<TipoUsuarioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TipoUsuario";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto estudio do tipo EstudioDomain
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            // Atribui à propriedade IdEstudio o valor da coluna IdEstudio da tabela do banco de dados
                            IdTipoUsuario = Convert.ToInt32(rdr[0])
                            ,

                            // Atribui à propriedade Nomeestudio o valor da coluna Nomeestudio da tabela do banco de dados                
                            Titulo = rdr["Titulo"].ToString()
                        };

                        // Adiciona o filme criado à lista funcionarios
                        lista.Add(tipoUsuario);
                    }
                }
            }

            return lista;
        }
    }
}
