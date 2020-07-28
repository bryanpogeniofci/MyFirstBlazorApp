using MyFirstBlazorApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Services
{
    public interface ITodoItemService
    {
        Task<List<TodoItem>> GetTodoItemList();
        Task AddTodoItem(string name);
    }
}
