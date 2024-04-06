using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2LuisMartinez.Modelos
{
    public class Producto
    {
        [Key]
        public int idproducto { get; set; }
        public string nombre { get; set; }
    }
}
