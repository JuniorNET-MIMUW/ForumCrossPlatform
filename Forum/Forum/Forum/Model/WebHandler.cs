using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Forum.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Forum.Model
{
    static class WebHandler
    {
        private static readonly string ServerUri = "TODO WRITE SERVER URL"; //TODO add server uri
        
        public static async Task<List<string>> GetAllThreads()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUri);
                var httpResult = await client.GetAsync("api/forum/all");
                if (!httpResult.IsSuccessStatusCode)
                    throw new Exception(httpResult.StatusCode.ToString());

                var content = httpResult.Content;
                var stringContent = await content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<string>>(stringContent);
            }
        }

        public static async Task<ThreadViewModel> GetThreadByName(this string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUri);
                var httpResult = await client.GetAsync($"api/forum/get/{name}");
                if (!httpResult.IsSuccessStatusCode)
                {
                    var message = await httpResult.Content.ReadAsStringAsync();
                    //TODO display error message
                }

                var contentString = await httpResult.Content.ReadAsStringAsync();
                var thread = JsonConvert.DeserializeObject<ThreadViewModel>(contentString);
                return thread;
            }
        }
    }
}
