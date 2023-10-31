using FileBaseContext.Abstractions.Models.Entity;

namespace ToDoList.Entities.Common;

public interface IEntity : IFileSetEntity<Guid>
{
}
