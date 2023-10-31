using ToDoList.Entities.Common;

namespace ToDoList.Entities
{
    public class ToDo : SoftDeletedEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public DateTime AtTime { get; set; }
    }
}
