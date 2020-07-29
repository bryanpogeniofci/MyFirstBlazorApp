using Microsoft.AspNetCore.Components;
using MyFirstBlazorApp.Services;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Bases
{
    public class CreateBase : ComponentBase
    {
        #region Fields

        public string _itemName;

        #endregion

        #region Ctor

        public CreateBase()
        {
            _itemName = string.Empty;
        }

        #endregion

        #region Methods

        public async Task AddItem()
        {
            // added comment for rebase
            // added comment for 2nd rebase
            await TodoItemService.AddTodoItem(_itemName);
        }

        #endregion

        #region Properties

        [Inject]
        public ITodoItemService TodoItemService { get; set; }

        #endregion
    }
}
