namespace DeveloperTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kunal_07_01_2020_modify_tbl_message_second_time : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Subject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Subject");
        }
    }
}
