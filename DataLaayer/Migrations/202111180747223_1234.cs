namespace DataLaayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1234 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.pages", "Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.pages", "Text", c => c.String(nullable: false));
        }
    }
}
