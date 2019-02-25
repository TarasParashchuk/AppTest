using SQLite;

namespace AppTest.Model
{
    [Table ("Message")]
    public class ModelMessage
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }

        public string name_task { get; set; }
        public string current_date { get; set; }
        public string name_category { get; set; }
    }
}
