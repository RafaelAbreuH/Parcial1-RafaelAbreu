using ProyectoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParcial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Producto { get; set; }
        public DbSet<Inventario> Inventario { get; set; }

        public Contexto() : base("ConStr")
        { }

    }
}
