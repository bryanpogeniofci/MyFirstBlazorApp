using Microsoft.AspNetCore.Components;
using MyFirstBlazorApp.Data;
using MyFirstBlazorApp.Models;
using MyFirstBlazorApp.Services;
using System;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Bases
{
    public class EditBase : ComponentBase
    {
        #region Fields

        public TodoItemModel _todoItemModel;

        #endregion

        #region Ctor

        public EditBase()
        {
            _todoItemModel = new TodoItemModel();
        }

        #endregion

        #region Utilities

        private protected async Task GetTodoItem()
        {
            var todoItem = await TodoItemService.GetTodoItemById(Convert.ToInt32(Id));

            _todoItemModel = new TodoItemModel
            {
                Id = Convert.ToInt32(todoItem.Id),
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
        }

        #endregion

        #region Methods

        protected override Task OnInitializedAsync()
        {
            return GetTodoItem();
        }

        public async Task EditItem()
        {
            var todoItem = new TodoItem 
            {
                Id = _todoItemModel.Id,
                Name = _todoItemModel.Name,
                IsComplete = _todoItemModel.IsComplete
            };

            await TodoItemService.UpdateTodoItem(todoItem);
        }

        #endregion

        #region Properties

        [Inject]
        public ITodoItemService TodoItemService { get; set; }

        [Parameter]
        public string Id { get; set; }

        #endregion
    }
}
