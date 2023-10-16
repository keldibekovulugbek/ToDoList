using FileBaseContext.Abstractions.Common;

namespace ToDoList.Entities
{
    public class User : SoftDeletedEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ImagePath { get; set; } = null;
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
