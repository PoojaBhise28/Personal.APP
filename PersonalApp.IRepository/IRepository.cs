using PersonalApp.Dto;

namespace PersonalApp.IRepository
{


    public interface IRepository<T> where T :class
    {


        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsyc();

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);

    }
}

