namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Animals", "ShortDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Animals", "MainDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "MainDescription", c => c.String());
            AlterColumn("dbo.Animals", "ShortDescription", c => c.String());
            AlterColumn("dbo.Animals", "Name", c => c.String());
        }
    }
}
