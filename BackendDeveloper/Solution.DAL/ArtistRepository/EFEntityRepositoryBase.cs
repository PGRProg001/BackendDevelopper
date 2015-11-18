using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.ArtistRepository
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        //
        // .AsNoTracking() is being used to turn off entity change tracking.  
        //  Only Read Operations are required - just get Artist from db
        //

        public List<TEntity> GetList(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                    int? page = null, int? pageSize = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking();
                if (filter != null)
                    query = query.Where(filter);

                if (orderBy != null)
                    query = orderBy(query);

                if (page != null && pageSize != null && page > 0 && pageSize > 0)
                    query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

                return query.ToList();
            }
        }

        public int GetCount(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).Count();
            }
        }
    }
}
