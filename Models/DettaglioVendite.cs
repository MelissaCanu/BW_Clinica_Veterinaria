namespace BW_Clinica_Veterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DettaglioVendite")]
    public partial class DettaglioVendite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DettaglioVendite()
        {
            Vendite = new HashSet<Vendite>();
        }

        [Key]
        public int DettaglioID { get; set; }

        [StringLength(10)]
        public string Quantita { get; set; }

        public int ProdottoID { get; set; }

        public virtual Prodotti Prodotti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vendite> Vendite { get; set; }
    }
}
