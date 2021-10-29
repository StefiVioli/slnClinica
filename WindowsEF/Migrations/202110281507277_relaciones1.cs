namespace WindowsEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relaciones1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        FechaInicioActividades = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Habitacion",
                c => new
                    {
                        IdHabitacion = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 6, unicode: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdHabitacion)
                .ForeignKey("dbo.Clinica", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Habitacion", "Id", "dbo.Clinica");
            DropIndex("dbo.Habitacion", new[] { "Id" });
            DropTable("dbo.Habitacion");
            DropTable("dbo.Clinica");
        }
    }
}
