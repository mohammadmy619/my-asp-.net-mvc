namespace DataLaayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_adminlogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.adminlogins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.LoginID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.adminlogins");
        }
    }
}
