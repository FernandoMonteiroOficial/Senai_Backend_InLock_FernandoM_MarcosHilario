﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public string NomeJogo { get; set; }

        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        public float Valor { get; set; }

        public int IdEstudio { get; set; }

        EstudioDomain Estudio { get; set; }
    }
}
