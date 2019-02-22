using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AppTest.Model
{
    public class ModelItem
    {
        private string _icon;
        public string icon
        {
            get { return _icon; }
            set
            {
                _icon = "http://200.7.98.16/xamarin_test/" + value;
            }
        }

        public string icon_bg { get; set; }
        public string icon_fg { get; set; }
        public string title { get; set; }
    }

    public class MainObject
    {
        public int count { get; set; }
        public ObservableCollection<ModelItem> items { get; set; }
        public int result { get; set; }
    }
}
