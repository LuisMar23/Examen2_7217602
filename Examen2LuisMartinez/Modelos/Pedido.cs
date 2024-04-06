using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2LuisMartinez.Modelos
{
    public class Pedido
    {
        [Key]
        public int idPedido { get; set; }

        public int idcliente { get; set; }
        public Cliente? cliente { get; set; }
        public DateTime fecha { get; set; }
        public  float total { get; set; }
        public string estado { get; set; }
    }
}
