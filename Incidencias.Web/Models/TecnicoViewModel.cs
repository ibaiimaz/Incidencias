﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incidencias.Web.Models
{
    public class TecnicoViewModel
    {
        public int ID { get; set; }
        public string Iniciales { get; set; }
        public string Nombre { get; set; }
        public int NumeroIncidencias { get; set; }
    }
}