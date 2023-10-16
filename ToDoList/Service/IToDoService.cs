using ToDoList.Entities;

namespace ToDoList.Service
{
    public interface IToDoService
    {
        ValueTask<ICollection<ToDo>> Get(CancellationToken cancellationToken = default);
        ValueTask<ToDo> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        ValueTask<ToDo> CreateAsync(ToDo toDo, bool SaveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<ToDo> UpdateAsync(Guid id, ToDo toDo, bool SaveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<ToDo> DeleteAsync(Guid id, bool SaveChanges = true, CancellationToken cancellationToken = default);
    }
}
