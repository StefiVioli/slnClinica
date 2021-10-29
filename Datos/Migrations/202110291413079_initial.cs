namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        MedicoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Matricula = c.Int(nullable: false),
                        EspecialidadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicoId)
                .ForeignKey("dbo.Especialidad", t => t.EspecialidadId, cascadeDelete: true)
                .Index(t => t.EspecialidadId);
            
            CreateTable(
                "dbo.Especialidad",
                c => new
                    {
                        EspecialidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.EspecialidadId);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        FechaNacimiento = c.DateTime(nullable: false, storeType: "date"),
                        NroHistoriaClinica = c.Int(nullable: false),
                        MedicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.MedicoId, cascadeDelete: true)
                .Index(t => t.MedicoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paciente", "MedicoId", "dbo.Medicos");
            DropForeignKey("dbo.Medicos", "EspecialidadId", "dbo.Especialidad");
            DropForeignKey("dbo.Habitacion", "Id", "dbo.Clinica");
            DropIndex("dbo.Paciente", new[] { "MedicoId" });
            DropIndex("dbo.Medicos", new[] { "EspecialidadId" });
            DropIndex("dbo.Habitacion", new[] { "Id" });
            DropTable("dbo.Paciente");
            DropTable("dbo.Especialidad");
            DropTable("dbo.Medicos");
            DropTable("dbo.Habitacion");
            DropTable("dbo.Clinica");
        }
    }
}
