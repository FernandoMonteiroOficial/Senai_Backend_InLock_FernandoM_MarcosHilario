using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controller
{
    [Route("api/[controller]")]

    [Produces("application/json")]

    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private TipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();

        }

        [HttpGet]
        public IEnumerable<TipoUsuarioDomain> Get()
        {
            return _tipoUsuarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain nome)
        {
            return Ok(_tipoUsuarioRepository.Inserir(nome));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuarioDomain tipoUsuario)
        {
            return Ok(_tipoUsuarioRepository.Atualizar(id, tipoUsuario));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_tipoUsuarioRepository.Deletar(id));
        }
    }
}
