using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using MrWebAPI.Models;

namespace ConsumoAPI
{
    class Program
    {

        static async void Main(string[] args)
        {
            InvocarAPI();
        }

        private static async void InvocarAPIAsync()
        {
            HttpClient publis = new HttpClient();

            publis.BaseAddress = new Uri("192.168.1.12");
            var request = await publis.GetAsync("/api/Publicacion");
            if (request.IsSuccessStatusCode)
            {
                var response = await request.Content.ReadAsStringAsync();

            }
        }

        private static void InvocarAPI()
        {
            HttpClient publis = new HttpClient();   

            publis.BaseAddress = new Uri("http://localhost/PublicApis");
            var request = publis.GetAsync("/api/Publicacion").Result;
            if (request.IsSuccessStatusCode)
            {
                var responseJson = request.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<List<Publicacion>>(responseJson);

                foreach (var item in response)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
        }
    }
}