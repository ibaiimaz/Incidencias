namespace Incidencias.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Tecnico_Contacto_Aplicacio_migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Incidencia", "AplicacionId", "dbo.Aplicacion");
            DropForeignKey("dbo.Aplicacion", "TecnicoId", "dbo.Tecnico");
            DropForeignKey("dbo.Incidencia", "TecnicoId", "dbo.Tecnico");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            AddForeignKey("dbo.Incidencia", "AplicacionId", "dbo.Aplicacion", "ID");
            AddForeignKey("dbo.Aplicacion", "TecnicoId", "dbo.Tecnico", "ID");
            AddForeignKey("dbo.Incidencia", "TecnicoId", "dbo.Tecnico", "ID");
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "ID");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Incidencia", "TecnicoId", "dbo.Tecnico");
            DropForeignKey("dbo.Aplicacion", "TecnicoId", "dbo.Tecnico");
            DropForeignKey("dbo.Incidencia", "AplicacionId", "dbo.Aplicacion");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Incidencia", "TecnicoId", "dbo.Tecnico", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Aplicacion", "TecnicoId", "dbo.Tecnico", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Incidencia", "AplicacionId", "dbo.Aplicacion", "ID", cascadeDelete: true);
        }
    }
}
