using System;
using System.Collections.Generic;
using AppTest.ViewModel;
using Xamarin.Forms;

namespace AppTest
{
    public partial class MessagePage : ContentPage
    {
        public MessagePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = new ViewModelMessage();
        }
    }
}
