using Examen2LuisMartinez.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2LuisMartinez.Contratos
{
    public interface IEjerciciosLogic
    {
  
        public Task<bool> EliminarCliente(int id);
        public Task<bool> InsertarPedidoDetalle(Pedido Pedido,Detalle detalle);
        //public Task<bool> InsertarDetalle(Detalle Detalle);
    }
}
