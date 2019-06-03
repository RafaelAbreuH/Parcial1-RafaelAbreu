using ProyectoParcial.DAL;
using ProyectoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParcial.BLL
{
    public class UbicacionesBLL
    {
        public static bool Guardar(Ubicaciones ubicacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Ubicacion.Add(ubicacion) != null)
                    paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose(); // cerrar la conexion
            }

            return paso;
        }

        //Modificar Ubicacion
        public static bool Modificar(Ubicaciones ubicacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(ubicacion).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        //Eliminar ubicacion
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.Ubicacion.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;

                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        //para Buscar los ubicacion
        public static Ubicaciones Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ubicaciones ubicacion = new Ubicaciones();
            try
            {
                ubicacion = contexto.Ubicacion.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ubicacion;
        }

        //Lista
        public static List<Ubicaciones> Getlist(Expression<Func<Ubicaciones, bool>> expression)
        {
            List<Ubicaciones> lista = new List<Ubicaciones>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Ubicacion.Where(expression).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
