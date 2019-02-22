using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AppTest.Model;
using AppTest.ViewModel;
using Xamarin.Forms;
using System.ComponentModel;

namespace AppTest
{
    public partial class MainPage : ContentPage
    {
        MainObject tt;

        public MainPage()
        {
            InitializeComponent();
            tt = GetJson("http://200.7.98.16/xamarin_test/categories.json");
            BindingContext = new ViewModelMainPage(tt) { Navigation = this.Navigation };
            //Item_list.ItemTemplate = new DataTemplate(typeof(MyCell));
        }

        private MainObject GetJson(string url)
        {
            var json = string.Empty;
            var Deserialize_Object = new MainObject();

            using (var client = new WebClient())
            {
                json = client.DownloadString(new Uri(url));
            }

            if (json != string.Empty)
            {
                try
                {
                    Deserialize_Object = JsonConvert.DeserializeObject<MainObject>(json);
                }
                catch (Exception ex)
                {
                    Deserialize_Object = null;
                    //await DisplayAlert("Error", ex.ToString(), "OK");
                }
            }
            else
            {
                Deserialize_Object = null;
            }

            return Deserialize_Object;
        }
    }
    public class MyCell : ViewCell
    {
        public MyCell() : base()
        {
            RelativeLayout layout = new RelativeLayout();
            layout.SetBinding(Layout.BackgroundColorProperty, new Binding("BackgroundColor"));

            View = layout;
        }
    }

    public class MyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Color _backgroundColor;

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BackgroundColor"));
                }
            }
        }

        public void SetColors(bool isSelected)
        {
            if (isSelected)
            {
                BackgroundColor = Color.FromRgb(0.20, 0.20, 1.0);
            }
            else
            {
                BackgroundColor = Color.FromRgb(0.95, 0.95, 0.95);
            }
        }
    }
}
