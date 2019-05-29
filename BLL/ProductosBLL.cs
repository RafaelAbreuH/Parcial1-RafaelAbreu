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
    public class ProductosBLL
    {
        public static bool Guardar(Productos producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Producto.Add(producto) != null)
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

        //Modificar Producto
        public static bool Modificar(Productos producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
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

        //Eliminar producto
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.Producto.Find(id);
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

        //para Buscar los producto
        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos producto = new Productos();
            try
            {
                producto = contexto.Producto.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return producto;
        }

        //Lista
        public static List<Productos> Getlist(Expression<Func<Productos, bool>> expression)
        {
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Producto.Where(expression).ToList();

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
