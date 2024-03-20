using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BW_Clinica_Veterinaria.Models
{
    public class RicoveriAnimaliViewModel
    {
        public int RicoveroID { get; set; }
        public DateTime DataIN { get; set; }
        public DateTime? DataOUT { get; set; }
        public int AnimaleID { get; set; }

        //animali
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string ColoreManto { get; set; }
        public DateTime? DataNascita { get; set; }
        public DateTime DataReg {  get; set; }
        public bool HasChip { get; set; }
        public string NChip { get; set; }
        public string Foto { get; set; }
    }
}