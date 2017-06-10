using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015104916.Entities.Entities
{
    public class Volante
    {
        public int VolanteId { set; get; }
        public string NumSerie{set;get;}
    
        public Carro Carro { set; get; }
        

    }
}
