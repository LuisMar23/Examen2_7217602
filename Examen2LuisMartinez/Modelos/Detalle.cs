using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2LuisMartinez.Modelos
{
    public class Detalle
    {


        public int idpedido { get; set; }
        public Pedido? pedido { get; set; }
        public int idproducto { get; set; }
        public Producto? producto { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public float subtotal { get; set; }
    }
}
