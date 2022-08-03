using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ErickPrueba.Models.ViewModels
{
    public class LisCandidatoViewModel
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaDeNacimiento  { get; set; }
        
        public string Trabajo_Actual { get; set; }

        public int Expectativa_Salarial { get; set; }

    }
}