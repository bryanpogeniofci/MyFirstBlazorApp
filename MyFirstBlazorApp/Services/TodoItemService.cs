using MyFirstBlazorApp.Data;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Services
{
    public class TodoItemService : CommonHttpService, ITodoItemService
    {
        #region Ctor

        public TodoItemService(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        #endregion

        #region Methods

        public virtual async Task<List<TodoItem>> GetTodoItems()
        {
            return await JsonSerializer.DeserializeAsync<List<TodoItem>>
                (await _httpClient.GetStreamAsync($"api/TodoItems"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public virtual async Task<TodoItem> GetTodoItemById(int id)
        {
            return await JsonSerializer.DeserializeAsync<TodoItem>
                (await _httpClient.GetStreamAsync($"api/TodoItems/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public virtual async Task AddTodoItem(string name)
        {
            var todoItem = new TodoItem
            {
                Name = name,
                IsComplete = false
            };

            var content = new StringContent(JsonSerializer.Serialize(todoItem), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("api/TodoItems", content);
        }

        public virtual async Task UpdateTodoItem(TodoItem todoItem)
        {
            var content = new StringContent(JsonSerializer.Serialize(todoItem), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"api/TodoItems/{todoItem.Id}", content);
        }

        #endregion
    }
}
