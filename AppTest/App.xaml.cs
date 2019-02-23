using System;
using AppTest.SqliteDB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppTest
{
    public partial class App : Application
    {
        public const string nameDB = "DBfsdfasjnnvdccfjtest.db";
        public static SqliteRepository database;
        public static SqliteRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new SqliteRepository(nameDB);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
