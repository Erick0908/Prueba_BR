using ErickPrueba.Models;
using ErickPrueba.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ErickPrueba.Repositories
{
    public class CandidatoRepository
    {

        public List<Candidato> Lst()
        {
            List<Candidato> listado = new List<Candidato>();
            
            using (ERICKPRUEBAEntities db = new ERICKPRUEBAEntities())
            {
                listado = db.Candidato.ToList();

            }

            return listado;
        }

        public bool Validar(String cedula)
        {
            bool existe;
            using (ERICKPRUEBAEntities db = new ERICKPRUEBAEntities())
            {
                existe = db.Candidato.Any(e => e.Cedula.ToLower().Equals(cedula.ToLower()));

            }

            return existe;

        }

        public void Create(CandidatoViewModel model)
        {
            using (ERICKPRUEBAEntities db = new ERICKPRUEBAEntities())
            {
                var oCandidato = new Candidato();
                oCandidato.Cedula = model.Cedula;
                oCandidato.Nombres = model.Nombres;
                oCandidato.Apellidos = model.Apellidos;
                oCandidato.FechaDeNacimiento = model.FechaDeNacimiento;
                oCandidato.Trabajo_actual = model.Trabajo_Actual;
                oCandidato.Expectativa_Salarial = model.Expectativa_Salarial;

                db.Candidato.Add(oCandidato);
                db.SaveChanges();
            }

        }

        public Candidato Obtener(int Id)
        {
            var oCandidato = new Candidato();
            using (ERICKPRUEBAEntities db = new ERICKPRUEBAEntities())
            {
                oCandidato = db.Candidato.Find(Id);

            }
            return oCandidato;
        }

        public void Actualizar(CandidatoViewModel model)
        {
            using (ERICKPRUEBAEntities db = new ERICKPRUEBAEntities())
            {
                var oCandidato = db.Candidato.Find(model.Id);
                oCandidato.Cedula = model.Cedula;
                oCandidato.Nombres = model.Nombres;
                oCandidato.Apellidos = model.Apellidos;
                oCandidato.FechaDeNacimiento = model.FechaDeNacimiento;  //fecha cambiada
                oCandidato.Trabajo_actual = model.Trabajo_Actual;
                oCandidato.Expectativa_Salarial = model.Expectativa_Salarial;

                db.Entry(oCandidato).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

        }


        public Candidato Eliminar(int Id)
        {
            var oCandidato = new Candidato();
            using (ERICKPRUEBAEntities db = new ERICKPRUEBAEntities())
            {
                oCandidato = db.Candidato.Find(Id);
                db.Candidato.Remove(oCandidato);
                db.SaveChanges();

            }
            return oCandidato;
        }

    }
}