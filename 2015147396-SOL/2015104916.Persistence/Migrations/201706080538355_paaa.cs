namespace _2015104916.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paaa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asientos",
                c => new
                    {
                        AsientoId = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(),
                        idCarro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AsientoId)
                .ForeignKey("dbo.Carros", t => t.idCarro, cascadeDelete: true)
                .Index(t => t.idCarro);
            
            CreateTable(
                "dbo.Carros",
                c => new
                    {
                        idCarro = c.Int(nullable: false),
                        NumSerieMotor = c.String(),
                        NumSerieChasis = c.String(),
                        idEnsambladora = c.Int(nullable: false),
                        TipoCarro = c.Int(nullable: false),
                        TipoAuto = c.Int(),
                        TipoBus = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.idCarro)
                .ForeignKey("dbo.Ensambladoras", t => t.idEnsambladora, cascadeDelete: true)
                .ForeignKey("dbo.Parabrisas", t => t.idCarro)
                .ForeignKey("dbo.Propietarios", t => t.idCarro)
                .ForeignKey("dbo.Volantes", t => t.idCarro)
                .Index(t => t.idCarro)
                .Index(t => t.idEnsambladora);
            
            CreateTable(
                "dbo.Ensambladoras",
                c => new
                    {
                        idEnsambladora = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.idEnsambladora);
            
            CreateTable(
                "dbo.Llantas",
                c => new
                    {
                        LlantaId = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(),
                        idCarro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LlantaId)
                .ForeignKey("dbo.Carros", t => t.idCarro, cascadeDelete: true)
                .Index(t => t.idCarro);
            
            CreateTable(
                "dbo.Parabrisas",
                c => new
                    {
                        idParabrisas = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(),
                    })
                .PrimaryKey(t => t.idParabrisas);
            
            CreateTable(
                "dbo.Propietarios",
                c => new
                    {
                        PropietarioId = c.Int(nullable: false, identity: true),
                        Dni = c.String(),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Licencia = c.String(),
                    })
                .PrimaryKey(t => t.PropietarioId);
            
            CreateTable(
                "dbo.Volantes",
                c => new
                    {
                        VolanteId = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(),
                    })
                .PrimaryKey(t => t.VolanteId);
            
            CreateTable(
                "dbo.Cinturon",
                c => new
                    {
                        CinturonId = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(),
                        Metraje = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CinturonId)
                .ForeignKey("dbo.Asientos", t => t.CinturonId)
                .Index(t => t.CinturonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cinturon", "CinturonId", "dbo.Asientos");
            DropForeignKey("dbo.Asientos", "idCarro", "dbo.Carros");
            DropForeignKey("dbo.Carros", "idCarro", "dbo.Volantes");
            DropForeignKey("dbo.Carros", "idCarro", "dbo.Propietarios");
            DropForeignKey("dbo.Carros", "idCarro", "dbo.Parabrisas");
            DropForeignKey("dbo.Llantas", "idCarro", "dbo.Carros");
            DropForeignKey("dbo.Carros", "idEnsambladora", "dbo.Ensambladoras");
            DropIndex("dbo.Cinturon", new[] { "CinturonId" });
            DropIndex("dbo.Llantas", new[] { "idCarro" });
            DropIndex("dbo.Carros", new[] { "idEnsambladora" });
            DropIndex("dbo.Carros", new[] { "idCarro" });
            DropIndex("dbo.Asientos", new[] { "idCarro" });
            DropTable("dbo.Cinturon");
            DropTable("dbo.Volantes");
            DropTable("dbo.Propietarios");
            DropTable("dbo.Parabrisas");
            DropTable("dbo.Llantas");
            DropTable("dbo.Ensambladoras");
            DropTable("dbo.Carros");
            DropTable("dbo.Asientos");
        }
    }
}
