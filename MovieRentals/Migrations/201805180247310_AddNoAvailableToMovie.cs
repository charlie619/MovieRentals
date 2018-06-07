namespace MovieRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoAvailableToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NoAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE Movies SET NoInStock = NoAvailable");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NoAvailable");
        }
    }
}
