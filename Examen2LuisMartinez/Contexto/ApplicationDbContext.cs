using Examen2LuisMartinez.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2LuisMartinez.Contexto
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente {  get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Detalle> Detalle { get; set; }
        public DbSet<Producto> Producto { get; set; }
    }
}
