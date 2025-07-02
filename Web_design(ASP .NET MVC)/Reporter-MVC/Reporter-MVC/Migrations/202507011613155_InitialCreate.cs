namespace Reporter_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Darkhasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        regDate = c.String(nullable: false),
                        name = c.String(nullable: false),
                        family = c.String(nullable: false),
                        NID = c.String(nullable: false),
                        type = c.String(nullable: false),
                        state = c.String(nullable: false),
                        returnDate = c.String(),
                        serialNumber = c.String(),
                        postSentDate = c.String(),
                        postReturnDate = c.String(),
                        deliveryToApplicant = c.String(),
                        referingOffic = c.String(),
                        resendDescription = c.String(nullable: false),
                        sendingType = c.String(nullable: false),
                        cost = c.Int(nullable: false),
                        officeCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Darkhasts");
        }
    }
}
