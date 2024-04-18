using TP_Todo_List.ContextDB;
using TP_Todo_List.Data.Entities;
using TP_Todo_List.Services.Interfaces;

namespace TP_Todo_List.Services.Implementations
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ContextTodo _context;
        public TodoItemService(ContextTodo context) 
        {
            _context = context;
        }

        public int CreateItem(TodoItem item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item.TodoItemId;
        }

        public void DeleteItem(int idItem)
        {
            var item = _context.TodoItems.FirstOrDefault(x => x.TodoItemId == idItem);
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
        }


        public TodoItem GetById(int id)
        {
            return _context.TodoItems.FirstOrDefault(i => i.TodoItemId == id);
        }

        public List<TodoItem> GetItems()
        {
            return _context.TodoItems.ToList();
        }

        public int UpdateItem(TodoItem item)
        {
            var existingItem = _context.TodoItems.FirstOrDefault(i => i.TodoItemId == item.TodoItemId);
            if (existingItem == null)
            {
                return 0; // Opcional: puedes lanzar una excepción o manejar de otra forma si el ítem no existe
            }

            existingItem.Title = item.Title;
            existingItem.Description = item.Description;

            _context.Update(existingItem);
            _context.SaveChanges();
            return existingItem.TodoItemId; // Devolver el ID del ítem actualizado
        }


        public List<TodoItem> GetItemsByUserId(int userId)
        {
            return _context.TodoItems.Where(i => i.UserId == userId).ToList();
        }

    }
}
