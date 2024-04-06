using Examen2LuisMartinez.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2LuisMartinez.Contratos
{
    public interface IProductoLogic
    {
        public Task<bool> InsertarProducto(Producto Producto);
        public Task<bool> ModificarProducto(Producto Producto, int id);

        public Task<bool> EliminarProducto(int id);

        public Task<List<Producto>> ListarProductoesTodos();

        public Task<Producto> ObtenerProducto(int id);
    }
}
