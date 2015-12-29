namespace Incidencias.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_titulo_incidencia_migration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Incidencia", name: "ResponsableId", newName: "TecnicoId");
            RenameIndex(table: "dbo.Incidencia", name: "IX_ResponsableId", newName: "IX_TecnicoId");
            AddColumn("dbo.Incidencia", "Titulo", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incidencia", "Titulo");
            RenameIndex(table: "dbo.Incidencia", name: "IX_TecnicoId", newName: "IX_ResponsableId");
            RenameColumn(table: "dbo.Incidencia", name: "TecnicoId", newName: "ResponsableId");
        }
    }
}
