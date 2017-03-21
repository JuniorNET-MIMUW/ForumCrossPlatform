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
            var webHandler = new WebHandler();
            Threads = webHandler.GetAllThreads().Result;

            InitializeComponent();

            BindingContext = this;
        }

        public List<string> Threads { get; set; }

        private async void ThreadSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var webHandler = new WebHandler();
            ThreadViewModel thread = await webHandler.GetThreadByName(e.SelectedItem.ToString());
            //TODO display view
        }
    }
}
