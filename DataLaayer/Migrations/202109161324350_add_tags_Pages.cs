namespace DataLaayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tags_Pages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.pages", "Tages", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.pages", "Tages");
        }
    }
}
