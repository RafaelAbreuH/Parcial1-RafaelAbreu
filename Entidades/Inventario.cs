using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParcial.Entidades
{
    public class Inventario
    {
        [Key]
        public int InventarioId { get; set; }
        public float ValorTotalInventario { get; set; }

        public Inventario()
        {
            InventarioId = 0;
            ValorTotalInventario = 0f;
        }
    }
}
