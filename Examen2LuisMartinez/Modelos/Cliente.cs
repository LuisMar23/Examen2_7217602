using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2LuisMartinez.Modelos
{
    public class Cliente
    {
        [Key]
        public int idcliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public List<Pedido> pedidos { get; set; }
    }
}
