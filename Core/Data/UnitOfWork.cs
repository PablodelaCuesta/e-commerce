using System;
using System.Collections;
using System.Threading.Tasks;
using Models.Entities;
using Models.Interfaces;

namespace Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repos;
        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repos is null) _repos = new Hashtable();
            
            var type = typeof(TEntity).Name;
            if (!_repos.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repos.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>) _repos[type];
        }
    }
}