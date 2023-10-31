using FileBaseContext.Abstractions.Models.FileSet;
using ToDoList.Data;
using ToDoList.Entities;
using ToDoList.Entities.Common;

namespace ToDoList.Brokers
{
    #pragma warning disable
    public class GenericBroker<T> : IGenericBroker<T> where T : SoftDeletedEntity, new()
    {
        private readonly IFileSet<T, Guid> _fileSet;
        private readonly IDataContext _dataContext;
        
        public GenericBroker(IDataContext context)
        {
            _dataContext = context;
            if (typeof(T) == typeof(User))
            {
                _fileSet = (IFileSet<T,Guid>) context.Users;
            }
            if (typeof(T) == typeof(ToDo))
            {
                _fileSet = (IFileSet<T, Guid>)context.ToDos;
            }
        }

        public async ValueTask<T> CreateAsync (T model)
        {
            await _fileSet.AddAsync(model);

            _dataContext.SaveChangesAsync();

            return model;
        }

        public async ValueTask<bool> DeleteAsync (T model)
        {
            await _fileSet.RemoveAsync(model);
            
            _dataContext.SaveChangesAsync();

            return true;
        }

        public async ValueTask<IQueryable<T>> Get()
        {
            var models = _fileSet.AsQueryable();

            return models;
        }

        public async ValueTask<T> GetByIdAsync (Guid id)
        {
            var model = _fileSet.FirstOrDefault(x => x.Id == id);

            return model!;
        }


        public async ValueTask<T> UpdateAsync (T model)
        {
           await _fileSet.UpdateAsync(model);
           _dataContext.SaveChangesAsync();
            
            return model;
        }
    }
}
