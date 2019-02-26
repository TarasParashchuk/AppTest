using System;
using System.Net;
using System.Threading.Tasks;
using AppTest.Model;
using AppTest.ViewModel;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace AppTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ViewModelMainPage() { Navigation = this.Navigation };
        }
    }
}
