using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Models.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}