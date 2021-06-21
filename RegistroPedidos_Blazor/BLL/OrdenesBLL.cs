using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroPedidos_Blazor.Models;
using RegistroPedidos_Blazor.DAL;
using Microsoft.EntityFrameworkCore;

namespace RegistroPedidos_Blazor.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.OrdenId))
                return Insertar(ordenes);
            else
                return Modificar(ordenes);
        }
        private static bool Insertar(Ordenes ordenes)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                context.Ordenes.Add(ordenes);
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
        public static bool Modificar(Ordenes ordenes)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                context.Entry(ordenes).State = EntityState.Modified;
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
                var ordenes = context.Ordenes.Find(id);

                if (ordenes != null)
                {
                    context.Ordenes.Remove(ordenes);
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
        public static Ordenes Buscar(int id)
        {
            Contexto context = new Contexto();
            Ordenes ordenes;

            try
            {
                ordenes = context.Ordenes.Find(id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return ordenes;
        }
        public static bool Existe(int id)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                found = context.Ordenes.Any(p => p.OrdenId == id);

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

    }
}
