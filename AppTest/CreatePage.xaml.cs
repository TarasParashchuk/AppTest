using System;
using System.Collections.Generic;
using AppTest.ViewModel;
using Xamarin.Forms;

namespace AppTest
{
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
        {
            InitializeComponent();
            BindingContext = new ViewModelCreatePage() { Navigation = this.Navigation };
        }
    }
}
