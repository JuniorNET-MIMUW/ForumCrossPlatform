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
    public partial class ThreadPage : ContentPage
    {
        private ThreadViewModel _model;

        public ThreadPage(ThreadViewModel model)
        {
            _model = model;
            InitializeComponent();

            BindingContext = _model;
            
            var cell = new TextCell();

        }

        private async void CommentSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Comments.SelectedItem

        }
    }
}
