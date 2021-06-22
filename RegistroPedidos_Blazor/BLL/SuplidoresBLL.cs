using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroPedidos_Blazor.Models;
using RegistroPedidos_Blazor.DAL;
using Microsoft.EntityFrameworkCore;

namespace RegistroPedidos_Blazor.BLL
{
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidores)
        {
            if (!Existe(suplidores.SuplidorId))
                return Insertar(suplidores);
            else
                return Modificar(suplidores);
        }
        private static bool Insertar(Suplidores suplidores)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                context.Suplidores.Add(suplidores);
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
        public static bool Modificar(Suplidores suplidores)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                context.Entry(suplidores).State = EntityState.Modified;
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
                var suplidores = context.Suplidores.Find(id);

                if (suplidores != null)
                {
                    context.Suplidores.Remove(suplidores);
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
        public static Suplidores Buscar(int id)
        {
            Contexto context = new Contexto();
            Suplidores suplidores;

            try
            {
                suplidores = context.Suplidores.Find(id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return suplidores;
        }
        public static bool Existe(int id)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                found = context.Suplidores.Any(p => p.SuplidorId == id);

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

        public static List<Suplidores> GetList()
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Suplidores.ToList();
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
