using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace registergoodsservices
{
    public abstract class Controller<T>
            where T : Model, new()
    {
        protected readonly SQLiteAsyncConnection _database;

        protected Controller(string dbPath)
        {
            _database = (new Database<T>(dbPath)).database;
        }

        protected List<T> GetAllRecordsAsync(int pageNumber, int pageSize = 10)
        {
            List<T> records = _database.Table<T>().ToListAsync().Result;

            return GetPage(records, pageNumber, pageSize);
        }

        protected static List<T> GetPage(IList<T> list, int pageNumber, int pageSize = 10)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        protected Task<T> GetRecordAsync(T record)
        {
            return _database.Table<T>().ElementAtAsync(record.ID);
        }

        protected Task<int> SaveRecordAsync(T record)
        {
            return _database.InsertAsync(record);
        }

        protected Task<int> UpdateRecordAsync(T record)
        {
            return _database.UpdateAsync(record);
        }

        protected void DeleteRecordasync(T record)
        {
            _database.DeleteAsync(record);
        }
    }
}
