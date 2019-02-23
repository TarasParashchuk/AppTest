using System;
using System.Collections.Generic;
using AppTest.ViewModel;
using Xamarin.Forms;

namespace AppTest
{
    public partial class CategoryPage : ContentPage
    {
        public string title;
        public CategoryPage(string title)
        {
            InitializeComponent();

            this.Title = title;
            this.title = title;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new ViewModelCategoryPage(title) { Navigation = this.Navigation };
        }
    }
}
