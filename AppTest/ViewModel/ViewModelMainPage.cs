using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AppTest.Model;
using Xamarin.Forms;
using System.Windows.Input;

namespace AppTest.ViewModel
{
    public class ViewModelMainPage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ModelItem> ListItems { get; set; }
        public ICommand AlertCommand { protected set; get; }
        public INavigation Navigation { get; set; }
        public ModelItem select_item;

        public ViewModelMainPage(MainObject item)
        {
            ListItems = item.items;
            AlertCommand = new Command(Alert_Clicked);
        }

        public ModelItem Selected_Item
        {
            get { return select_item; }
            set
            {
                if(select_item != value)
                {
                    select_item = null;
                    OnPropertyChanged("Selected_Item");
                    Navigation.PushAsync(new CategoryPage(value.title));
                }
            }
        }

        private void Alert_Clicked()
        {
            Navigation.PushAsync(new MessagePage());
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
