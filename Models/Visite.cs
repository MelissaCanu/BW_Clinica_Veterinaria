namespace BW_Clinica_Veterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visite")]
    public partial class Visite
    {
        [Key]
        public int VisitaID { get; set; }

        public int? AnimaleID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        [Required]
        [StringLength(100)]
        public string Esame { get; set; }

        [Required]
        public string Cura { get; set; }

        public virtual Animali Animali { get; set; }
    }
}
