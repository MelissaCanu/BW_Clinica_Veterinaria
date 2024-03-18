namespace BW_Clinica_Veterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Armadietti")]
    public partial class Armadietti
    {
        [Key]
        public int ArmadiettoID { get; set; }

        public int CassettoID { get; set; }

        public virtual Cassetti Cassetti { get; set; }
    }
}
