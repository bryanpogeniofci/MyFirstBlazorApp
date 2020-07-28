using Microsoft.AspNetCore.Components;
using MyFirstBlazorApp.Data;
using MyFirstBlazorApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Bases
{
    public class ListBase : ComponentBase
    {
        #region Fields

        public List<TodoItem> _todoItems;

        #endregion

        #region Ctor

        public ListBase()
        {
            _todoItems = new List<TodoItem>();
        }

        #endregion

        #region Utilities

        private protected async Task GetTodoItems()
        {
            _todoItems = await TodoItemService.GetTodoItems();
        }

        #endregion

        #region Methods

        protected override Task OnInitializedAsync()
        {
            return GetTodoItems();
        }

        #endregion

        #region Properties

        [Inject]
        public ITodoItemService TodoItemService { get; set; }

        #endregion
    }
}
