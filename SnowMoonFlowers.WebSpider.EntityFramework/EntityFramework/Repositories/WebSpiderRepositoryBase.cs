using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace SnowMoonFlowers.WebSpider.EntityFramework.Repositories
{
    public abstract class WebSpiderRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<WebSpiderDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected WebSpiderRepositoryBase(IDbContextProvider<WebSpiderDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class WebSpiderRepositoryBase<TEntity> : WebSpiderRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected WebSpiderRepositoryBase(IDbContextProvider<WebSpiderDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
