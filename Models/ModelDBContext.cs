using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BW_Clinica_Veterinaria.Models
{
    public partial class ModelDBContext : DbContext
    {
        public ModelDBContext()
            : base("name=ModelDBContext")
        {
        }

        public virtual DbSet<Animali> Animali { get; set; }
        public virtual DbSet<Armadietti> Armadietti { get; set; }
        public virtual DbSet<Cassetti> Cassetti { get; set; }
        public virtual DbSet<DettaglioVendite> DettaglioVendite { get; set; }
        public virtual DbSet<Fornitori> Fornitori { get; set; }
        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<Proprietari> Proprietari { get; set; }
        public virtual DbSet<Ricoveri> Ricoveri { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }
        public virtual DbSet<Vendite> Vendite { get; set; }
        public virtual DbSet<Visite> Visite { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animali>()
                .HasMany(e => e.Ricoveri)
                .WithRequired(e => e.Animali)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cassetti>()
                .HasMany(e => e.Armadietti)
                .WithRequired(e => e.Cassetti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DettaglioVendite>()
                .Property(e => e.Quantita)
                .IsFixedLength();

            modelBuilder.Entity<DettaglioVendite>()
                .HasMany(e => e.Vendite)
                .WithRequired(e => e.DettaglioVendite)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fornitori>()
                .HasMany(e => e.Prodotti)
                .WithRequired(e => e.Fornitori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prodotti>()
                .HasMany(e => e.Cassetti)
                .WithRequired(e => e.Prodotti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prodotti>()
                .HasMany(e => e.DettaglioVendite)
                .WithRequired(e => e.Prodotti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proprietari>()
                .HasMany(e => e.Vendite)
                .WithRequired(e => e.Proprietari)
                .WillCascadeOnDelete(false);
        }
    }
}
