
using ToDoList.Entities;

namespace ToDoList.Security
{
    public interface IAuthManager
    {
        public string GenerateToken(User user);
    }
}
