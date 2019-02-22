using System;
using System.IO;
using AppTest.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteForAndroid))]
namespace AppTest.Droid
{
    public class SqliteForAndroid : SqliteDB.ISQLite
    {
        public SqliteForAndroid()
        {
        }

        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}
