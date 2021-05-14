using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PersonalFactsApp
{
    public class FactDataDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public FactDataDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<FactData>().Wait();
        }

        //Microsoft's methods
        public Task<List<FactData>> GetFactDataAsync()
        {
            return _database.Table<FactData>().ToListAsync();
        }

        public Task<int> SaveFactDataAsync(FactData factData)
        {
            return _database.InsertAsync(factData);
        }

        //Matt's methods
        public Task<int> InsertList(IEnumerable<FactData> factDatas)
        {
            return _database.InsertAllAsync(factDatas);
        }

        public Task<int> DeleteItemAsync(FactData factData)
        {
            return _database.DeleteAsync(factData);
        }

        public Task<int> ClearAllAsync()
        {
            return _database.DeleteAllAsync<FactData>();
        }
    }
}
