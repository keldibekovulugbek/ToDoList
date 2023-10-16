using FileBaseContext.Abstractions.Models.Entity;

namespace FileBaseContext.Abstractions.Common;

public interface IEntity : IFileSetEntity<Guid>
{
}
