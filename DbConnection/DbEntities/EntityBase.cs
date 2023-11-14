using SQLite;

namespace DbConnection.DbEntities
{
    public class EntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
