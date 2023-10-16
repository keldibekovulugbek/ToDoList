using ToDoList.Data;
using ToDoList.Entities;

namespace ToDoList.Service
{
    public class ToDoService : IToDoService
    {
        private readonly IDataContext _dataContext;
        private readonly NotifyService _notifyService;
        public ToDoService(IDataContext dataContext, NotifyService notifySevice)
        {
            _dataContext = dataContext;
            _notifyService = notifySevice;
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

            _notifyService.NotifyHandler(entity);

            return entity;
        }

        public ValueTask<ToDo> UpdateAsync(Guid id, ToDo toDo, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
