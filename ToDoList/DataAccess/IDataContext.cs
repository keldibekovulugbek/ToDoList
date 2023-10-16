using FileBaseContext.Abstractions.Models.FileSet;
using ToDoList.Entities;

namespace ToDoList.Data
{
    public interface IDataContext
    {
        IFileSet<User, Guid> Users { get; }

        public IFileSet<ToDo, Guid> ToDos { get; }

        ValueTask SaveChangesAsync();
    }
}
