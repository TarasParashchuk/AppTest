using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using AppTest.Model;
using Xamarin.Forms;

namespace AppTest.ViewModel
{
    public class ViewModelCategoryPage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ModelSqlite> ListItems { get; set; }
        public ICommand Add_category { protected set; get; }
        public INavigation Navigation { get; set; }

        public ModelItem itemList { get; set; }

        public ViewModelCategoryPage()
        {
            //var t = App.Database.GetItems();
            ListItems = new ObservableCollection<ModelSqlite>(App.Database.GetItems());
            Add_category = new Command(Add);
        }

        public void Add()
        {
            Navigation.PushAsync(new CreatePage());
        }

        protected void OnPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
