namespace BW_Clinica_Veterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodotti")]
    public partial class Prodotti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodotti()
        {
            Cassetti = new HashSet<Cassetti>();
            DettaglioVendite = new HashSet<DettaglioVendite>();
        }

        [Key]
        public int ProdottoID { get; set; }

        public int FornitoreID { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        public bool IsMedicinale { get; set; }

        [Required]
        [StringLength(150)]
        public string Utilizzo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cassetti> Cassetti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DettaglioVendite> DettaglioVendite { get; set; }

        public virtual Fornitori Fornitori { get; set; }
    }
}
