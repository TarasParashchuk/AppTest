using System;
using System.Globalization;
using SQLite;

namespace AppTest.Model
{
    [Table ("Task")]
    public class ModelSqlite
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }

        public string name_task { get; set; }
        public string detail_task { get; set; }
        public string start_date { get; set; }

        public string start_time { get; set; }

        public string end_date { get; set; }

        public string end_time { get; set; }
        public string current_date { get; set; }
        public string name_category { get; set; }
    }
}
