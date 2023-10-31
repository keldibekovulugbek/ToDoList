using Microsoft.AspNetCore.Mvc;
using ToDoList.Entities;

namespace ToDoList.Service
{
    public interface IUserService
    {
        //DTO-data transfor objec
        ValueTask<IEnumerable<User>> Get (CancellationToken cancellationToken = default);
        ValueTask<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        ValueTask<User> CreateAsync(User user, bool SaveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<User> UpdateAsync(Guid id, User user, bool SaveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<bool> DeleteAsync(Guid id, bool SaveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<User> UploadImageAsync(Guid id, UploadImageDTO imageDTO, bool SaveChanges = true, CancellationToken cancellationToken = default);
    }
}
