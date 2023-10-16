using FileBaseContext.Abstractions.Common;

namespace ToDoList.Entities
{
    public class ToDo : SoftDeletedEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime AtTime { get; set; }
    }
}
