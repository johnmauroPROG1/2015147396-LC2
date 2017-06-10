using _2015104916.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2015104916.API.DTO
{
    public class LLantaDTO
    {
        public int LlantaId { set; get; }
        public string NumSerie { set; get; }
        public int idCarro { get; set; }
        public Carro Carro { set; get; }
    }
}