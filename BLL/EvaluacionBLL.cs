using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL;
using Entidades;

namespace BLL
{
    public class EvaluacionBLL
    {



        public static bool Guardar(Evaluacion evaluacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto(); 

            try
            {
                if (contexto.Set<Evaluacion>().Add(evaluacion) != null)
                {


                    contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Modificar(Evaluacion evaluacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(evaluacion).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


      public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

          
                var eliminar = db.Evaluacion.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

    }




   }

