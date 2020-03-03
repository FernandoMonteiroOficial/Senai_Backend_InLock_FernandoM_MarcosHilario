using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
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
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudiorepository;

        public EstudioController()
        {
            _estudiorepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudiorepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain EstudioBuscado = _estudiorepository.GetporId(id);
            if (EstudioBuscado != null)
            {
                return Ok(EstudioBuscado);
            }

            return NotFound("Nenhum Estudio encontrado");
        }

        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            if (novoEstudio.NomeEstudio == null)
            {
                return BadRequest("O nome do Estudio é obrigatório!");
            }
            _estudiorepository.Cadastrar(novoEstudio);

            return Created("http://localhost:5000/api/Estudio", novoEstudio);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EstudioDomain estudioAtualizado)
        {
            EstudioDomain estudioBuscado = _estudiorepository.GetporId(id);
            if (estudioBuscado != null)
            {
                try
                {
                    _estudiorepository.Atualizar(id, estudioAtualizado);
                    return Ok($"Estudio {id} atualizado com sucesso!");
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound
                (
                    new
                    {
                        mensagem = "Estudio não encontrado",
                        erro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EstudioDomain EstudioBuscado = _estudiorepository.GetporId(id);

            if (EstudioBuscado != null)
            {
                _estudiorepository.Delete(id);

                return Ok($"O Estudio {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum Estudio encontrado");
        }
    }
}
