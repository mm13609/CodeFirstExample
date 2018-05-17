namespace CodeFirstTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        TrainID = c.Int(nullable: false, identity: true),
                        TrainSymbol = c.String(),
                        Speed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trains");
        }
    }
}
