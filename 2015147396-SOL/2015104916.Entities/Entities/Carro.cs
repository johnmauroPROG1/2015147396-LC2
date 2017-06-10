using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015104916.Entities.Entities
{
    public abstract class Carro
    {

         public int idCarro { set; get; }
         public string NumSerieMotor { set; get; }
         public string NumSerieChasis { set; get; }
         public int idEnsambladora { set; get; }
       
        public List<Llanta> Llantas { set; get; }
         public List<Asiento> Asientos { set; get; }

         public TipoCarro TipoCarro { set; get; }

         
         public Propietario Propietario { set; get; }
         public Parabrisas Parabrisas { set; get; }
         public Volante Volante { set; get; }
         public Ensambladora Ensambladora { set; get; }
              
    }
}
