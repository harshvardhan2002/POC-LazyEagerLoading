namespace LazyEagerLoadingPOC.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
