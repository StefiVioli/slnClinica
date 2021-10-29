namespace WindowsEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relaciones2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Especialidad",
                c => new
                    {
                        EspecialidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50, unicode: false),
                        MedicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EspecialidadId)
                .ForeignKey("dbo.Medicos", t => t.MedicoId, cascadeDelete: true)
                .Index(t => t.MedicoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Especialidad", "MedicoId", "dbo.Medicos");
            DropIndex("dbo.Especialidad", new[] { "MedicoId" });
            DropTable("dbo.Especialidad");
        }
    }
}
