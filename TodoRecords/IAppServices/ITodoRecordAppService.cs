namespace TodoRecords.IAppServices
{
    public interface ITodoRecordAppService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity, int id);
        Task<bool> DeleteById(int id);

    }
}
