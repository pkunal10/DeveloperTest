namespace DeveloperTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kunal_07_01_2020_add_tbl_user_message : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderEmailId = c.String(),
                        RecevierEmailId = c.String(),
                        MessageData = c.String(),
                        SentTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmailId = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
        }
    }
}
