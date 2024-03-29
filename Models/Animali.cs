namespace BW_Clinica_Veterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Animali")]
    public partial class Animali
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animali()
        {
            Ricoveri = new HashSet<Ricoveri>();
            Visite = new HashSet<Visite>();
        }

        [Key]
        public int AnimaleID { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data Registrazione")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataReg { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Colore Manto")]
        public string ColoreManto { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data di Nascita")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascita { get; set; }

        [Display(Name = "Chip")]
        public bool HasChip { get; set; }

        [StringLength(50)]
        [Display(Name = "Numero Chip")]
        public string NChip { get; set; }

        public int? ProprietarioID { get; set; }

        public string Foto { get; set; }

        public virtual Proprietari Proprietari { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ricoveri> Ricoveri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visite> Visite { get; set; }
    }
}
