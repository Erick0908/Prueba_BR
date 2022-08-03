using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ErickPrueba.Models;
using ErickPrueba.Models.ViewModels;
using ErickPrueba.Repositories;

namespace ErickPrueba.Controllers
{
    public class CandidatoController : Controller
    {
        // GET: Candidato

        CandidatoRepository candidatoRepository = new CandidatoRepository();

        public ActionResult Index()

        {
            List<Candidato> listado = candidatoRepository.Lst();
            var modelo = listado.Select((Candidato d) => new LisCandidatoViewModel
            {
                Id = d.ID,
                Cedula = d.Cedula,
                Nombres = d.Nombres,
                Apellidos = d.Apellidos,
                FechaDeNacimiento = d.FechaDeNacimiento,
                Trabajo_Actual = d.Trabajo_actual,
                Expectativa_Salarial = (int)d.Expectativa_Salarial

            }).ToList();

            return View(modelo);
        }


        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(CandidatoViewModel model)
        {
            bool existe = candidatoRepository.Validar(model.Cedula);

            if (existe)
            {
                model.Validador = "La cedula existe, Favor colocar una diferente";
            }

            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        candidatoRepository.Create(model);
                        return Redirect("~/Candidato/");
                    }

                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return View(model);
        }

        public ActionResult Editar(int Id)
        {
            var candidato = candidatoRepository.Obtener(Id);
            var model = new CandidatoViewModel
            {
                Id = candidato.ID,
                Cedula = candidato.Cedula,
                Nombres = candidato.Nombres,
                Apellidos = candidato.Apellidos,
                FechaDeNacimiento = candidato.FechaDeNacimiento,
                Trabajo_Actual = candidato.Trabajo_actual,
                Expectativa_Salarial = (int)candidato.Expectativa_Salarial
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(CandidatoViewModel model)
        {
     
                try
                {
                    if (ModelState.IsValid)
                    {
                        candidatoRepository.Actualizar(model);
                        return Redirect("~/Candidato/");

                }
                
            }
                
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            
            return View(model);

        }

        //Eliminar
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            var candidato = candidatoRepository.Eliminar(Id);
            return Content("1");
        }

    }

}
