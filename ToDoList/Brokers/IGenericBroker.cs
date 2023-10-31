using ToDoList.Entities.Common;

namespace ToDoList.Brokers
{
    public interface IGenericBroker<T>  where T: SoftDeletedEntity, new()
    {
        ValueTask<IQueryable<T>> Get();
        ValueTask<T> CreateAsync(T model);
        ValueTask<T> GetByIdAsync(Guid id);
        ValueTask<T> UpdateAsync(T model);
        ValueTask<bool> DeleteAsync(T model);
    }
}
