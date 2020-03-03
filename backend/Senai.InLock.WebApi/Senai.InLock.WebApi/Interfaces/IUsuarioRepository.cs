using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {

        List<UsuarioDomain> Listar();

        
        UsuarioDomain BuscarPorId(int id);

       
       // void Cadastrar(UsuarioDomain novoUsuario);

      
       // void Deletar(int id);

        
       // void Atualizar(int id, UsuarioDomain UsuarioAtualizado);
    }
}
