using ToDoList.Entities;
using ToDoList.Events;

namespace ToDoList.Service
{
   public class NotifyService
    {
        private readonly ToDoEventStore _eventStore;

        public NotifyService(ToDoEventStore eventStore) 
        {
            _eventStore = eventStore;
            _eventStore.OnCompleted += NotifyHandler;
        }

        public ValueTask NotifyHandler(ToDo toDo)
        {
            Console.WriteLine($"Todo vaqti bo'ldi   {toDo.AtTime.ToString()}");

            return new ValueTask();
        }
    }
}
