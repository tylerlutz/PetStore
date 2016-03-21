namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "PicturePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "PicturePath");
        }
    }
}
