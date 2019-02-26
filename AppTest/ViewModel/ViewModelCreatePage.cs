using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using AppTest.Model;
using Plugin.LocalNotifications;
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

        private TimeSpan start_t;
        private TimeSpan end_t;
        private DateTime start_d;
        private DateTime end_d;

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

        public DateTime start_date
        {
            get { return start_d; }
            set
            {
                start_d = value;
                OnPropertyChanged("start_date");
            }
        }

        public TimeSpan start_time
        {
            get { return start_t; }
            set
            { 
                start_t = value;
                end_t = value;
                OnPropertyChanged("end_time");
                OnPropertyChanged("start_time");
            }
        }

        public DateTime end_date
        {
            get { return end_d; }
            set
            {
                end_d = value;
                OnPropertyChanged("end_date");
            }
        }

        public TimeSpan end_time
        {
            get { return end_t; }
            set
            {
                end_t = value;
                OnPropertyChanged("end_time");
            }
        }

        private void Save()
        {
            if (!String.IsNullOrEmpty(data_task.name_task))
            {
                data_task.start_time = start_t.ToString(@"hh\:mm");
                data_task.end_time = end_t.ToString(@"hh\:mm");
                data_task.start_date = start_d.ToString(@"dd.MM.yyyy");
                data_task.end_date = end_d.ToString(@"dd.MM.yyyy");
                App.Database.SaveItem(data_task);

                data_message.name_task = data_task.name_task;
                var date_time = DateTime.Now;
                data_message.current_date = date_time.ToShortDateString() + "\n" + date_time.ToShortTimeString();
                App.database.SaveItem(data_message);

                CrossLocalNotifications.Current.Show("Создано новое задание " + data_task.name_task, "Категория: " + data_message.name_category);
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
