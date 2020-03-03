using Microsoft.AspNetCore.Mvc;
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
    }
}
