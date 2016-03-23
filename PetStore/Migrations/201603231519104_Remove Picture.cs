namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePicture : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Animals", "Picture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "Picture", c => c.Binary());
        }
    }
}
