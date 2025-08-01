namespace locktopus_domain.Repositories;

public interface IQueryRepository<T>
{
    Task<T> GetById(long id);
}