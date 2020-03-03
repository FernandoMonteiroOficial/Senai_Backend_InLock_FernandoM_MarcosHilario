using Microsoft.AspNetCore.Mvc;
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
    public class TipoUsuarioController
    {
        private TipoUsuarioRepository _tipousuariorepository;


    }
}
