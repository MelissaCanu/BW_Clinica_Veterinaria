namespace BW_Clinica_Veterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn(
                "dbo.Fornitori",
                "ProdottoID");            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fornitori", "ProdottoID", c => c.Int(nullable: false));
        }
    }
}
