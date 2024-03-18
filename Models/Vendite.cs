namespace BW_Clinica_Veterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendite")]
    public partial class Vendite
    {
        [Key]
        public int VenditaID { get; set; }

        public int ProprietarioID { get; set; }

        public int DettaglioID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        [Required]
        [StringLength(7)]
        public string Ricetta { get; set; }

        public virtual DettaglioVendite DettaglioVendite { get; set; }

        public virtual Proprietari Proprietari { get; set; }
    }
}
