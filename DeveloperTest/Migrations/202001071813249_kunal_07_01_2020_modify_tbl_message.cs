namespace DeveloperTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kunal_07_01_2020_modify_tbl_message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsArchive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsArchive");
        }
    }
}
