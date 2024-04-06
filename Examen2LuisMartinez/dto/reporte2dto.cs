using Examen2LuisMartinez.Modelos;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examen2LuisMartinez.dto
{
    public class reporte2dto
    {

        //2.listar el siguiente reporte nombre del cliente ,fecha del pedido,nombre del producto y subtotal

        public string nombreCliente { get; set; }
        public DateTime fechapedido  { get; set; }
        public string nombreproducto { get; set; }
        public float subtotal { get; set; }
    }
}
