using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParcial.Entidades
{
    public class Ubicaciones
    {
        [Key]
        public int IdUbicacion { get; set; }
        public string Descripcion { get; set; }

        public Ubicaciones()
        {
            IdUbicacion = 0;
            Descripcion = String.Empty;
        }
    }
}
