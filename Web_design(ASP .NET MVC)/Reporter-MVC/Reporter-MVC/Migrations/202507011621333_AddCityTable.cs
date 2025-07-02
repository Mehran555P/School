namespace Reporter_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        code = c.String(nullable: false),
                        fromCode = c.String(nullable: false),
                        toCode = c.String(nullable: false),
                        stateName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cities");
        }
    }
}
