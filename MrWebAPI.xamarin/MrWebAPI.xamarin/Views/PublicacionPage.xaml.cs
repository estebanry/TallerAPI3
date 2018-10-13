using MrWebAPI.xamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrWebAPI.xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicacionPage : ContentPage
    {
        public PublicacionPage()
        {
            InitializeComponent();
            CargarProductos();
        }

        
        private async Task CargarProductos()
        {
            HttpClient publis = new HttpClient();

            publis.BaseAddress = new Uri("url del sitio(que no tenemos)");
            var request = await publis.GetAsync("/api/Publicacion");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<List<Publicacion>>(responseJson);
                listPublicaciones.ItemsSource = response;

                foreach (var item in response)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
        }
    }
}