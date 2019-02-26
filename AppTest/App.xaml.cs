using AppTest.SqliteDB;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppTest
{
    public partial class App : Application
    {
        public const string nameDB = "DBAppTest.db";
        public const string url = "http://200.7.98.16/xamarin_test/categories.json";
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
