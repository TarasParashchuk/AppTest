using System;
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
        public ModelSqlite task;

        public ViewModelCreatePage()
        {
            task = new ModelSqlite();
            SaveCommand = new Command(Save);
        }

        public string name_task
        {
            get { return task.name_task; }
            set
            {
                if (task.name_task != value)
                {
                    task.name_task = value;
                    OnPropertyChanged("name_task");
                }
            }
        }

        public string detail_task
        {
            get { return task.detail_task; }
            set
            {
                if (task.detail_task != value)
                {
                    task.detail_task = value;
                    OnPropertyChanged("detail_task");
                }
            }
        }

        public string start_date
        {
            get { return task.start_date; }
            set
            {
                if (task.start_date != value)
                {
                    task.start_date = value;
                    OnPropertyChanged("start_date");
                }
            }
        }

        public string start_time
        {
            get { return task.start_time; }
            set
            {
                if (task.start_time != value)
                {
                    task.start_time = value;
                    OnPropertyChanged("start_time");
                }
            }
        }

        public string end_date
        {
            get { return task.end_date; }
            set
            {
                if (task.end_date != value)
                {
                    task.end_date = value;
                    OnPropertyChanged("end_date");
                }
            }
        }

        public string end_time
        {
            get { return task.end_time; }
            set
            {
                if (task.end_time != value)
                {
                    task.end_time = value;
                    OnPropertyChanged("end_time");
                }
            }
        }

        private void Save()
        {
            //var task = (ModelSqlite)Navigation.BindingContext;
            if (!String.IsNullOrEmpty(task.name_task))
            {
                App.Database.SaveItem(task);
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
