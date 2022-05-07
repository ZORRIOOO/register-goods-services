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

        public Controller(string dbPath)
        {
            _database = (new Database<T>(dbPath)).database;
        }

        public Task<List<T>> GetAllRecordsAsync(int pageNumber, int pageSize = 10)
        {
            List<T> records = _database.Table<T>().ToListAsync().Result;

            return (Task<List<T>>)GetPage(records, pageNumber, pageSize);
        }

        static IList<T> GetPage(IList<T> list, int pageNumber, int pageSize = 10)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public Task<T> GetRecordAsync(T record)
        {
            return _database.Table<T>().ElementAtAsync(record.ID);
        }

        public Task<int> SaveRecordAsync(T record)
        {
            return _database.InsertAsync(record);
        }

        public Task<int> UpdateRecordAsync(T record)
        {
            return _database.UpdateAsync(record);
        }

        public void DeleteRecordasync(T record)
        {
            _database.DeleteAsync(record);
        }
    }
}
