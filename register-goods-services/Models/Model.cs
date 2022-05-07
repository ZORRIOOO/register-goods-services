using SQLite;

namespace registergoodsservices
{
    public abstract class Model
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
