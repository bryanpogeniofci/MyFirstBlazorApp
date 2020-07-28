using MyFirstBlazorApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Services
{
    public interface ITodoItemService
    {
        Task<List<TodoItem>> GetTodoItems();
        Task<TodoItem> GetTodoItemById(int id);
        Task AddTodoItem(string name);
        Task UpdateTodoItem(TodoItem todoItem);
    }
}
