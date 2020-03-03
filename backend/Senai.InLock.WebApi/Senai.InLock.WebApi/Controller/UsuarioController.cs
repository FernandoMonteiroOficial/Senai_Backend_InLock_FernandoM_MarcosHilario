using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controller
{

    [Produces("application/json")]

    
    [Route("api/[controller]")]

   
    [ApiController]

    
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }

       
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários e um status code 200 - Ok</returns>
        /// dominio/api/Usuarios
        [HttpGet]
        public IActionResult Get()
        {
            
            // Retorna a lista e um status code 200 - Ok
            return Ok(_usuarioRepository.Listar());
        }
    }
}
