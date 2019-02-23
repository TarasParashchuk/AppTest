using System;
using System.Collections.Generic;
using AppTest.ViewModel;
using Xamarin.Forms;

namespace AppTest
{
    public partial class CreatePage : ContentPage
    {
        public CreatePage(string title)
        {
            InitializeComponent();
            BindingContext = new ViewModelCreatePage(title) { Navigation = this.Navigation };
        }
    }
}
