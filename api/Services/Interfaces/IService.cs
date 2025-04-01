namespace api.Interfaces
{
    public interface IService<T, K> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> CreateAsync(K brandDTO);
        Task UpdateAsync(Guid id, K brandDTO);
        Task DeleteAsync(Guid id);
    }
}