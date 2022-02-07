using System;
using Microsoft.EntityFrameworkCore;
using Tarea_3.Entidades;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Tarea_3.BLL
{

    public class EstudianteBLL
    {
        public static bool Existe(int EstudianteId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Estudiantes.Any(l => l.EstudianteId == EstudianteId);

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

        public static bool Guardar(Estudiantes estudiantes)
        {
            if(!Existe(estudiantes.EstudianteId))
                return Insertar(estudiantes);
            else    
                return Modificar(estudiantes);
        }

        private static bool Insertar(Estudiantes estudiantes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Estudiantes.Add(estudiantes);
                paso = contexto.SaveChanges() > 0;

            }
            catch(Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Estudiantes estudiantes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(estudiantes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0; 


            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int estudianteId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var estudiantes = contexto.Estudiantes.Find(estudianteId);

                if(estudiantes != null)
                {
                    contexto.Estudiantes.Remove(estudiantes);
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Estudiantes Buscar(int estudianteId)
        {
            Contexto contexto = new Contexto();
            Estudiantes? estudiantes;
            try
            {
                estudiantes = contexto.Estudiantes.Find(estudianteId);

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return estudiantes;
        }

        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Estudiantes> lista = new List<Estudiantes>();
            try
            {
                lista = contexto.Estudiantes.Where(criterio).ToList();
            }
            catch(Exception)
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