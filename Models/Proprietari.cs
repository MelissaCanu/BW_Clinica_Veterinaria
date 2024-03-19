namespace BW_Clinica_Veterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proprietari")]
    public partial class Proprietari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proprietari()
        {
            Animali = new HashSet<Animali>();
            Vendite = new HashSet<Vendite>();
        }

        [Key]
        public int ProprietarioID { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Proprietario")]
        public string Nome { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Cognome Proprietario")]
        public string Cognome { get; set; }

        [Required]
        [StringLength(16)]
        [Display(Name = "Codice Fiscale")]
        public string CodFisc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Animali> Animali { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vendite> Vendite { get; set; }
    }
}
