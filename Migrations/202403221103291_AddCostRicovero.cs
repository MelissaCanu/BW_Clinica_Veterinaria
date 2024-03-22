namespace BW_Clinica_Veterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCostRicovero : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ricoveri", "Costo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ricoveri", "Costo");
        }
    }
}
