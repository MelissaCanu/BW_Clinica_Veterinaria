namespace BW_Clinica_Veterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ricoveri")]
    public partial class Ricoveri
    {
        [Key]
        public int RicoveroID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataIN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataOUT { get; set; }
        [Display(Name = "Animale")]
        public int AnimaleID { get; set; }

        public virtual Animali Animali { get; set; }
    }
}
