using System;
using System.IO;
using AppTest.iOS;
using AppTest.SqliteDB;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteForiOS))]
namespace AppTest.iOS
{
    public class SQLiteForiOS : ISQLite
    {
        public SQLiteForiOS()
        {
        }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);

            return path;
        }
    }
}
