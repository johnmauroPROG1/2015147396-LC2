﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2015104916.API.DTO
{
    public class CinturonDTO
    {
        public int CinturonId { set; get; }
        public string NumSerie { set; get; }
        public int Metraje { set; get; }
        public int AsientoId { get; set; }

        public AsientoDTO Asiento { set; get; }
    }
}