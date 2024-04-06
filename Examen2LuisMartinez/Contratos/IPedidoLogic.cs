using Examen2LuisMartinez.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2LuisMartinez.Contratos
{
    public interface IPedidoLogic
    {
        public Task<bool> InsertarPedido(Pedido Pedido);
        public Task<bool> ModificarPedido(Pedido Pedido, int id);

        public Task<bool> EliminarPedido(int id);

        public Task<List<Pedido>> ListarPedidoesTodos();

        public Task<Pedido> ObtenerPedido(int id);
    }
}
