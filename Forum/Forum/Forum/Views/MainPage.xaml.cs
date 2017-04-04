using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Model;
using Forum.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Forum.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //var webHandler = new WebHandler();
            var task = WebHandler.GetAllThreads();
            task.Wait();
            Threads = task.Result;

            InitializeComponent();

            BindingContext = this;
        }

        public List<string> Threads { get; set; }

        private async void ThreadSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var webHandler = new WebHandler();
            ThreadsList.SelectedItem = null;
            ThreadViewModel thread = await e.SelectedItem.ToString().GetThreadByName();
            await Navigation.PushAsync(new ThreadPage(thread));
        }
    }
}
