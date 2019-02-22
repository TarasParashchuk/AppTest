using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AppTest.Model;
using SQLite;
using Xamarin.Forms;

namespace AppTest.SqliteDB
{
    public class SqliteRepository
    {
        SQLiteConnection database;

        public SqliteRepository(string filename)
        {
            var databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<ModelSqlite>();
        }

        public IEnumerable<ModelSqlite> GetItems()
        {
            return (from i in database.Table<ModelSqlite>() select i).ToList();
        }

        public ModelSqlite GetItem(int id)
        {
            return database.Get<ModelSqlite>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<ModelSqlite>(id);
        }

        public int SaveItem(ModelSqlite item)
        {
            if (item.ID != 0)
            {
                database.Update(item);
                return item.ID;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
