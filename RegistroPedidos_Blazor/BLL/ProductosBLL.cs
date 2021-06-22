using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroPedidos_Blazor.DAL;
using RegistroPedidos_Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroPedidos_Blazor.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos productos)
        {
            if (!Existe(productos.ProductoId))
                return Insertar(productos);
            else
                return Modificar(productos);
        }
        private static bool Insertar(Productos productos)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                context.Productos.Add(productos);
                found = context.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }
        public static bool Modificar(Productos productos)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                context.Entry(productos).State = EntityState.Modified;
                found = context.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }
        public static bool Eliminar(int id)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                var productos = context.Productos.Find(id);

                if (productos != null)
                {
                    context.Productos.Remove(productos);
                    found = context.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }
        public static Productos Buscar(int id)
        {
            Contexto context = new Contexto();
            Productos productos;

            try
            {
                productos = context.Productos.Find(id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return productos;
        }
        public static bool Existe(int id)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                found = context.Productos.Any(p => p.ProductoId == id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }

        public static List<Productos> GetList()
        {
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Productos.ToList();
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
