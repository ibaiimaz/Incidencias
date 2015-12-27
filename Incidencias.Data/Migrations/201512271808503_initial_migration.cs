namespace Incidencias.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aplicacion",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Incidencia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 2000),
                        AplicacionId = c.Int(nullable: false),
                        Comentario = c.String(maxLength: 2000),
                        Contacto = c.String(nullable: false, maxLength: 100),
                        FechaAlta = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        FechaCierre = c.DateTime(),
                        ResponsableId = c.Int(nullable: false),
                        Prioridad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Aplicacion", t => t.AplicacionId, cascadeDelete: true)
                .ForeignKey("dbo.Tecnico", t => t.ResponsableId, cascadeDelete: true)
                .Index(t => t.AplicacionId)
                .Index(t => t.ResponsableId);
            
            CreateTable(
                "dbo.Tecnico",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Iniciales = c.String(nullable: false, maxLength: 4),
                        Nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        HashedPassword = c.String(nullable: false, maxLength: 200),
                        Salt = c.String(nullable: false, maxLength: 200),
                        IsLocked = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Incidencia", "ResponsableId", "dbo.Tecnico");
            DropForeignKey("dbo.Incidencia", "AplicacionId", "dbo.Aplicacion");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Incidencia", new[] { "ResponsableId" });
            DropIndex("dbo.Incidencia", new[] { "AplicacionId" });
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.Error");
            DropTable("dbo.Tecnico");
            DropTable("dbo.Incidencia");
            DropTable("dbo.Aplicacion");
        }
    }
}
