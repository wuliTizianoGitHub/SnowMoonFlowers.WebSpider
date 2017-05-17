namespace SnowMoonFlowers.WebSpider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BiliBili_Data",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        TotalType = c.Int(nullable: false),
                        DataType = c.Int(nullable: false),
                        CoverUrl = c.String(maxLength: 255),
                        PlayTime = c.DateTime(nullable: false),
                        Audience = c.Long(nullable: false),
                        BarrageNumber = c.Long(nullable: false),
                        CoinsNumber = c.Long(nullable: false),
                        CollectionNumber = c.Long(nullable: false),
                        ShareNumber = c.Long(nullable: false),
                        Contributor = c.String(maxLength: 255),
                        ContributionsTime = c.DateTime(nullable: false),
                        Introduction = c.String(),
                        DataTag = c.String(maxLength: 255),
                        Contract = c.Long(nullable: false),
                        HtmlContent = c.String(),
                        ThemNumber = c.Long(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BiliBili_Source",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        Url = c.String(maxLength: 255),
                        ProtocolType = c.Int(nullable: false),
                        HtmlContent = c.String(),
                        IsWebStaticSite = c.Boolean(nullable: false),
                        FetchingTime = c.DateTime(nullable: false),
                        LastModifyTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BiliBiliWebsites",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BiliBiliWebsites");
            DropTable("dbo.BiliBili_Source");
            DropTable("dbo.BiliBili_Data");
        }
    }
}
