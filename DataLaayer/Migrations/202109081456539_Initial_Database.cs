namespace DataLaayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.pagecamments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Email = c.String(maxLength: 200),
                        WebSite = c.String(maxLength: 200),
                        Comment = c.String(nullable: false, maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.pages", t => t.PageID, cascadeDelete: true)
                .Index(t => t.PageID);
            
            CreateTable(
                "dbo.pages",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        ShortDescription = c.String(nullable: false, maxLength: 350),
                        Text = c.String(nullable: false),
                        Visit = c.Int(nullable: false),
                        ImageName = c.String(),
                        ShowInSlider = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PageID)
                .ForeignKey("dbo.pagegroups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.pagegroups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.pages", "GroupID", "dbo.pagegroups");
            DropForeignKey("dbo.pagecamments", "PageID", "dbo.pages");
            DropIndex("dbo.pages", new[] { "GroupID" });
            DropIndex("dbo.pagecamments", new[] { "PageID" });
            DropTable("dbo.pagegroups");
            DropTable("dbo.pages");
            DropTable("dbo.pagecamments");
        }
    }
}
