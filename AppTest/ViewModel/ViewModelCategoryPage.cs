using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using AppTest.Model;
using Xamarin.Forms;

namespace AppTest.ViewModel
{
    public class ViewModelCategoryPage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ModelSqlite> Items; 
        public ICommand Add_category { protected set; get; }
        public INavigation Navigation { get; set; }
        public string title;

        public ViewModelCategoryPage(string title)
        {
            this.title = title;
            Items = new ObservableCollection<ModelSqlite>(App.Database.GetItems().Where(w => w.name_category == title).ToList());
            Add_category = new Command(Add);
        }

        public ObservableCollection<ModelSqlite> ListItems
        {
            get { return Items; }
            set
            {
                Items = value;
                OnPropertyChanged("ListItems");
            }
        }

        public void Add()
        {
            Navigation.PushAsync(new CreatePage(title));
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
