using System.Data.Entity.Migrations;

namespace SnowMoonFlowers.WebSpider.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WebSpider.EntityFramework.WebSpiderDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebSpider";
        }

        protected override void Seed(WebSpider.EntityFramework.WebSpiderDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
