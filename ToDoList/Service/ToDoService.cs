using ToDoList.Data;
using ToDoList.Entities;

namespace ToDoList.Service
{
    public class ToDoService : IToDoService
    {
        private readonly IDataContext _dataContext;

        public ToDoService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async ValueTask<ToDo> CreateAsync(ToDo toDo, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            var entity = await _dataContext.ToDos.AddAsync(toDo);
            await _dataContext.SaveChangesAsync();
            
            return toDo;
        }

        public ValueTask<ToDo> DeleteAsync(Guid id, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<ToDo>> Get(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<ToDo> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity =  _dataContext.ToDos.FirstOrDefault(t=> t.Id==id);

            

            return entity;
        }

        public ValueTask<ToDo> UpdateAsync(Guid id, ToDo toDo, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
