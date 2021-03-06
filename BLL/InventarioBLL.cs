﻿using ProyectoParcial.DAL;
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
    public class InventarioBLL
    {
        public static Inventarios Buscar()
        {

            Contexto contexto = new Contexto();
            Inventarios valor = new Inventarios();
            int id = 1;
            try
            {
                valor = contexto.Inventario.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return valor;
        }

        public static bool Guardar(Inventarios valor)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (contexto.Inventario.Add(valor) != null)
                {
                    paso = contexto.SaveChanges() > 0;
                }
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

        public static void ModificarValor(decimal total)
        {

            Inventarios valor = new Inventarios(){InventarioId = 1, ValorTotalInventario = total };

            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(valor).State = EntityState.Modified;
                contexto.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

        }
        public static List<Inventarios> GetList(Expression<Func<Inventarios, bool>> valor)
        {
            List<Inventarios> Lista = new List<Inventarios>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.Inventario.Where(valor).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        public static void Actualizar() // Actualizar 
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                lista = ProductosBLL.Getlist(p => true);
                decimal total = 0.0m;

                foreach (var obj in lista)
                {
                    total += obj.ValorInventario;
                }

                InventarioBLL.ModificarValor(total);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
