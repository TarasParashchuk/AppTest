using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using AppTest.Model;
using Xamarin.Forms;

namespace AppTest.ViewModel
{
    public class ViewModelCreatePage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public ICommand SaveCommand { protected set; get; }
        public ModelTask data_task;
        public ModelMessage data_message;

        public ViewModelCreatePage(string name_category)
        {
            data_task = new ModelTask();
            data_message = new ModelMessage();
            data_message.name_category = name_category;
            SaveCommand = new Command(Save);
        }

        public string name_task
        {
            get { return data_task.name_task; }
            set
            {
                if (data_task.name_task != value)
                {
                    data_task.name_task = value;
                    OnPropertyChanged("name_task");
                }
            }
        }

        public string detail_task
        {
            get { return data_task.detail_task; }
            set
            {
                if (data_task.detail_task != value)
                {
                    data_task.detail_task = value;
                    OnPropertyChanged("detail_task");
                }
            }
        }

        public string start_date
        {
            get { return data_task.start_date; }
            set
            {
                if (data_task.start_date != value)
                {
                    data_task.start_date = value;
                    OnPropertyChanged("start_date");
                }
            }
        }

        public string start_time
        {
            get { return data_task.start_time; }
            set
            {
                if (data_task.start_time != value)
                {
                    data_task.start_time = value;
                    OnPropertyChanged("start_time");
                }
            }
        }

        public string end_date
        {
            get { return data_task.end_date; }
            set
            {
                if (data_task.end_date != value)
                {
                    data_task.end_date = value;
                    OnPropertyChanged("end_date");
                }
            }
        }

        public string end_time
        {
            get { return data_task.end_time; }
            set
            {
                if (data_task.end_time != value)
                {
                    data_task.end_time = value;
                    OnPropertyChanged("end_time");
                }
            }
        }

        private void Save()
        {
            if (!String.IsNullOrEmpty(data_task.name_task))
            {
                App.Database.SaveItem(data_task);

                var last_item = App.Database.GetLast<ModelTask>();
                data_message.name_task = last_item.name_task;

                var date_time = DateTime.Now;
                data_message.current_date = date_time.ToShortDateString() + "\n" + date_time.ToShortTimeString();
                App.database.SaveItem(data_message);
            }

            Navigation.PopAsync();
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
