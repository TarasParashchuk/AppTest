﻿using System.Collections.Generic;
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
            database.CreateTable<ModelTask>();
            database.CreateTable<ModelMessage>();
        }

        public List<T> GetItems<T>() where T : new()
        {
            return (from i in database.Table<T>() select i).ToList();
        }

        public T GetItem<T>(int id) where T : new()
        {
            return database.Get<T>(id);
        }
        /*
        public T GetLast<T>() where T : new()
        {
            return database.Table<T>().Last();
        }

        public int DeleteItem<T>(int id) where T : new()
        {
            return database.Delete<T>(id);
        }*/

        public void DeleteAll<T>() where T : new()
        {
            database.DeleteAll<T>();
        }

        public int SaveItem<T>(T item) where T : new()
        {
            return database.Insert(item);
        }
    }
}
