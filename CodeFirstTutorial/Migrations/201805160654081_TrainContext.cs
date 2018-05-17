namespace CodeFirstTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainStations",
                c => new
                    {
                        StationID = c.Int(nullable: false, identity: true),
                        StationName = c.String(),
                        StationAddress = c.String(),
                    })
                .PrimaryKey(t => t.StationID);
            
            AddColumn("dbo.Trains", "StationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Trains", "StationID");
            AddForeignKey("dbo.Trains", "StationID", "dbo.TrainStations", "StationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trains", "StationID", "dbo.TrainStations");
            DropIndex("dbo.Trains", new[] { "StationID" });
            DropColumn("dbo.Trains", "StationID");
            DropTable("dbo.TrainStations");
        }
    }
}
