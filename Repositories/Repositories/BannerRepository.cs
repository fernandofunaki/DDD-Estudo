using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BannerRepository : IBannerRepository
    {
        private DbContext _context;
        public BannerRepository(IUnitOfWork uow)
        {
            this._context = uow.Context as DbContext;
        }
        public void Add(BannerEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(BannerEntity entity)
        {
            var item = _context.Set<BannerEntity>().Find(entity.Id);
            _context.Entry(item).CurrentValues.SetValues(entity);
        }

        public void Delete(int id)
        {
            var item = _context.Set<BannerEntity>().Find(id);
            _context.Set<BannerEntity>().Remove(item);
        }

        public IQueryable<BannerEntity> Query(System.Linq.Expressions.Expression<Func<BannerEntity, bool>> expression, params System.Linq.Expressions.Expression<Func<BannerEntity, object>>[] includes)
        {
            IQueryable<Domain.BannerEntity> query = _context.Set<Domain.BannerEntity>();
            includes.ToList().ForEach(a => query.Include(a));
            return query.Where(expression).AsNoTracking();
        }

        public BannerEntity FindById(int id)
        {
            var banner = _context.Set<BannerEntity>().FirstOrDefault(n => n.Id.Equals(id));
            //_context.Entry(banner).Collection(n => n.Banner).Load();
            return banner;
        }
    }
}
