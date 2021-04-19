namespace RedBadgeFinalProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFKToGuest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guest", "EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Guest", "EventId");
            AddForeignKey("dbo.Guest", "EventId", "dbo.Event", "EventId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guest", "EventId", "dbo.Event");
            DropIndex("dbo.Guest", new[] { "EventId" });
            DropColumn("dbo.Guest", "EventId");
        }
    }
}
