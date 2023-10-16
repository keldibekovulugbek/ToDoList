using ToDoList.Entities;

namespace ToDoList.Events
{
    public class ToDoEventStore
    {
        public event Func<ToDo, ValueTask> OnCompleted;

        public async ValueTask TimeCompletetedHandler(ToDo toDo)
        {
            if(toDo.AtTime.Equals(DateTime.Now))
                 await OnCompleted(toDo);
        }

    }
}
