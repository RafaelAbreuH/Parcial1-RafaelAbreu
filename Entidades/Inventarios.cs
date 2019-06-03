using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParcial.Entidades
{
    public class Inventarios
    {
        [Key]
        public int InventarioId { get; set; }
        public decimal ValorTotalInventario { get; set; }

        public Inventarios()
        {
            InventarioId = 0;
            ValorTotalInventario = 0;
        }
    }
}
