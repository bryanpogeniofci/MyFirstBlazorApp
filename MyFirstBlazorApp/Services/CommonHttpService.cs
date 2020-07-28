using System.Net.Http;

namespace MyFirstBlazorApp.Services
{
    public class CommonHttpService
    {
        #region Fields

        public readonly HttpClient _httpClient;

        #endregion

        #region Ctor

        public CommonHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion
    }
}
