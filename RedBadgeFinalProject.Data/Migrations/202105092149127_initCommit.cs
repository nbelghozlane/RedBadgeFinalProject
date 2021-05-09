namespace RedBadgeFinalProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCommit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expense", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Guest", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Expense", "EventId", "dbo.Event");
            DropIndex("dbo.Expense", new[] { "EventId" });
            DropIndex("dbo.Expense", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Guest", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Event", "UserId", c => c.String());
            AddColumn("dbo.Expense", "IsPurchased", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Expense", "EventId", c => c.Int());
            CreateIndex("dbo.Expense", "EventId");
            AddForeignKey("dbo.Expense", "EventId", "dbo.Event", "EventId");
            DropColumn("dbo.Expense", "ApplicationUser_Id");
            DropColumn("dbo.Guest", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Guest", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Expense", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Expense", "EventId", "dbo.Event");
            DropIndex("dbo.Expense", new[] { "EventId" });
            AlterColumn("dbo.Expense", "EventId", c => c.Int(nullable: false));
            DropColumn("dbo.Expense", "IsPurchased");
            DropColumn("dbo.Event", "UserId");
            CreateIndex("dbo.Guest", "ApplicationUser_Id");
            CreateIndex("dbo.Expense", "ApplicationUser_Id");
            CreateIndex("dbo.Expense", "EventId");
            AddForeignKey("dbo.Expense", "EventId", "dbo.Event", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.Guest", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Expense", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
        }
    }
}
