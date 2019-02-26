using System.Collections.ObjectModel;
using System.ComponentModel;
using AppTest.Model;
using Xamarin.Forms;
using System.Windows.Input;
using Plugin.Connectivity;

namespace AppTest.ViewModel
{
    public class ViewModelMainPage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AlertCommand { protected set; get; }
        public INavigation Navigation { get; set; }

        private ObservableCollection<ModelItem> Items;
        private ModelItem select_item;
        private bool refresh;

        public ViewModelMainPage()
        {
            if (CrossConnectivity.Current.IsConnected)
                Items = GetData.GetJson().Result.items;
            else
            {
                Items = null;
                Application.Current.MainPage.DisplayAlert("Нет подключения к интернету", "Проверьте все соединения", "OK");
                isRefreshing = false;
            }
            AlertCommand = new Command(Alert_Clicked);
        }

        public ObservableCollection<ModelItem> ListItemsMainPage
        {
            get
            {
                if (Items == null)
                {
                    Items = new ObservableCollection<ModelItem>();
                }
                return Items;
            }
            set
            {
                Items = value;
                OnPropertyChanged("ListItemsMainPage");
            }
        }

        public ModelItem Selected_Item
        {
            get { return select_item; }
            set
            {
                if (select_item != value)
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

        public bool isRefreshing
        {
            get { return refresh; }
            set
            {

                refresh = value;
                OnPropertyChanged("isRefreshing");
            }
        }

        public ICommand RefreshingCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (isRefreshing)
                        return;

                    isRefreshing = true;
                    MainObject json = new MainObject();
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        json = await GetData.GetJson();
                        ListItemsMainPage = json.items;
                    }
                    else
                        ListItemsMainPage = null;
                    isRefreshing = false;
                });
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
