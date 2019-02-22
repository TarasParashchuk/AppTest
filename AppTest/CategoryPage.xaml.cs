using System;
using System.Collections.Generic;
using AppTest.ViewModel;
using Xamarin.Forms;

namespace AppTest
{
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage(string title)
        {
            InitializeComponent();

            this.Title = title;
            BindingContext = new ViewModelCategoryPage() { Navigation = this.Navigation};
        }
    }
}
