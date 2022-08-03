using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ErickPrueba.Models.ViewModels
{
    public class CandidatoViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(11)]
        [Display(Name = "Cedula")]
        public string Cedula { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
         public DateTime FechaDeNacimiento { get; set; }


        [Display(Name = "Trabajo actual")]
        public string Trabajo_Actual { get; set; }

        [Display(Name = "Expectativa salarial")]
        public int Expectativa_Salarial { get; set; }

        public string Validador { get; set; }

   
    }
}