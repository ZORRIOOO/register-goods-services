using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace registergoodsservices
{
    public class Database<T>
        where T: new()
    {
        public SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<T>();
        }
    }
}
