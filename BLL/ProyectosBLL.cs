using Microsoft.EntityFrameworkCore;
using SegundoPacialAna.DAL;
using SegundoPacialAna.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SegundoPacialAna.BLL
{
    class ProyectosBLL
    {
        public static bool Guardar(Proyectos proyectos)
        {
            bool paso;

            if (!Existe(proyectos.ProyectoId))
                paso = Insertar(proyectos);
            else
                paso = Modificar(proyectos);

            return paso;
        }
        
        public static bool Insertar(Proyectos proyectos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Proyectos.Add(proyectos);
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
        
        public static bool Modificar(Proyectos proyectos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                //Borrar el detalle anterior.
                contexto.Database.ExecuteSqlRaw($"Delete From ProyectosDetalle Where ProyectosId={proyectos.ProyectoId}");

                foreach (var item in proyectos.Detalles)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(proyectos).State = EntityState.Modified;
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
        
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var proyectos = contexto.Proyectos.Find(id);
                if (proyectos != null)
                {
                    contexto.Proyectos.Remove(proyectos);
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
        
        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool>> criterio)
        {
            List<Proyectos> lista = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Proyectos.Where(criterio).ToList();
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
        
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Proyectos.Any(p => p.ProyectoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
       
        public static Proyectos Buscar(int id)
        {
            Proyectos Proyecto = new Proyectos();
            Contexto contexto = new Contexto();

            try
            {
                Proyecto = contexto.Proyectos.Include(p => p.Detalles)
                .Where(p => p.ProyectoId == id)
                    .SingleOrDefault();

                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Proyecto;
        }
    }
}
