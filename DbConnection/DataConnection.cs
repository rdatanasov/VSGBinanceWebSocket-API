namespace DbConnection
{
    public class DataConnection
    {
        static DbRepository database;

        // Create the database connection as a singleton.
        public static DbRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new DbRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Binaces.db3"));
                }
                return database;
            }
        }

    }
}
