using TP_Todo_List.Data.Entities;

namespace TP_Todo_List.Services.Interfaces
{
    public interface ITodoItemService
    {
        public int CreateItem(TodoItem item);

        public int UpdateItem(TodoItem item);

        public void DeleteItem(int idItem);

        public List<TodoItem> GetItems();

        public TodoItem GetById(int id);

        public List<TodoItem> GetItemsByUserId(int userId);


    }
}
