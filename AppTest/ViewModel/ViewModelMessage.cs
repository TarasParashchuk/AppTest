using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using AppTest.Model;
using Xamarin.Forms;

namespace AppTest.ViewModel
{
    public class ViewModelMessage : INotifyPropertyChanged
    {
        public ObservableCollection<ModelMessage> ListItemsMessage { get; set; }
        public ICommand DeleteCommand { protected set; get; }
        private ObservableCollection<ModelMessage> Items;
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelMessage()
        {
            ListItemsMessage = new ObservableCollection<ModelMessage>(App.Database.GetItems<ModelMessage>());
            DeleteCommand = new Command(Delete);
        }

        public ObservableCollection<ModelMessage> ListItems
        {
            get { return Items; }
            set
            {
                Items = value;
                OnPropertyChanged("ListItemsMessage");
            }
        }

        public void Delete()
        {
            Items = null;
            OnPropertyChanged("ListItemsMessage");
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
