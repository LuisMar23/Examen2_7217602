using Examen2LuisMartinez.Contexto;
using Examen2LuisMartinez.Contratos;
using Examen2LuisMartinez.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2LuisMartinez.Implementacion
{
    public class EjerciciosLogicImplementacion : IEjerciciosLogic
    {
        private readonly ApplicationDbContext context;

        public EjerciciosLogicImplementacion(ApplicationDbContext context) 
        {
            this.context = context;
        }

      

        public async Task<bool> EliminarCliente(int id)
        {

            var consulta = context.Cliente.Include(e => e.pedidos).FirstOrDefaultAsync(x => x.idcliente == id);


            //Cliente cliente = await this.context.Cliente.FirstOrDefaultAsync(x=>x.idcliente==id);
            //Pedido pedido = await this.context.Pedido.FirstOrDefaultAsync(y => y.idcliente == id);
            //if (pedido == null && cliente==null)
            //{
            //    return false;
            //}
            //context.Pedido.Remove(pedido);
            //context.Cliente.Remove(cliente);
            //context.SaveChangesAsync();

            context.Remove(consulta);
            context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertarPedidoDetalle(Pedido Pedido, Detalle detalle)
        {
            bool sw = false;
            detalle.idpedido=Pedido.idPedido;
            context.AddRange(Pedido,detalle);
            int response = await context.SaveChangesAsync();
            if (response == 1)
            {
                sw = true;
            }
            return sw;

        }
    }
}
