
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Tarea_3.Entidades;


namespace Tarea_3.BLL
{
    public class CarrerasBLL
    {
        public static bool Existe(int CarreraId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                paso = contexto.Carreras.Any(L => L.CarreraId == CarreraId);
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

        public static bool Guardar(Carreras carreras)
        {
            if(!Existe(carreras.CarreraId))
                return Insertar(carreras);
            else    
                return Modificar(carreras);
        
        }

        public static bool Insertar(Carreras carreras)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try{
                contexto.Carreras.Add(carreras);
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

        public static bool Modificar(Carreras carreras)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(carreras).State = EntityState.Modified;
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

        public static bool Eliminar(int CarreraId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var carreras = contexto.Carreras.Find(CarreraId);

                if(carreras != null)
                {
                    contexto.Carreras.Remove(carreras);
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

        public static Carreras Buscar(int CarreraId)
        {
            Contexto contexto = new Contexto();
            Carreras? carreras;

            try
            {
                carreras = contexto.Carreras.Find(CarreraId);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return carreras;
        }

        public static List<Carreras> GetList(Expression<Func<Carreras, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Carreras> lista = new List<Carreras>();
            
            try 
            {
                lista = contexto.Carreras.Where(criterio).ToList();
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