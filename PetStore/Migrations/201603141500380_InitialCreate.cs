namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        MainDescription = c.String(),
                        DateRecieved = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Picture = c.Binary(),
                    })
                .PrimaryKey(t => t.AnimalID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Animals");
        }
    }
}
