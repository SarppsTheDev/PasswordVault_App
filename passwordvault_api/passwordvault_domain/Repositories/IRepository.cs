using passwordvault_domain.Entities;

namespace passwordvault_domain.Repositories;

public interface IRepository<T>
{
    Task<int> Create(T entity);
    Task<LoginItem> Update(T entity);
    Task<int> Delete(int id);
}