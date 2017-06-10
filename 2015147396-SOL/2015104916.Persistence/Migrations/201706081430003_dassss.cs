namespace _2015104916.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dassss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cinturon", "CinturonId", "dbo.Asientos");
            DropIndex("dbo.Cinturon", new[] { "CinturonId" });
            AddColumn("dbo.Cinturon", "AsientoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cinturon", "AsientoId");
            AddForeignKey("dbo.Cinturon", "AsientoId", "dbo.Asientos", "AsientoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cinturon", "AsientoId", "dbo.Asientos");
            DropIndex("dbo.Cinturon", new[] { "AsientoId" });
            DropColumn("dbo.Cinturon", "AsientoId");
            CreateIndex("dbo.Cinturon", "CinturonId");
            AddForeignKey("dbo.Cinturon", "CinturonId", "dbo.Asientos", "AsientoId");
        }
    }
}
