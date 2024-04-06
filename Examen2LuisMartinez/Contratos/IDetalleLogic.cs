using Examen2LuisMartinez.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2LuisMartinez.Contratos
{
    public interface IDetalleLogic
    {
        public Task<bool> InsertarDetalle(Detalle Detalle);
        public Task<bool> ModificarDetalle(Detalle Detalle, int id);

        public Task<bool> EliminarDetalle(int id);

        public Task<List<Detalle>> ListarDetalleesTodos();

        public Task<Detalle> ObtenerDetalle(int id);
    }
}
