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

        /*https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/data/databases#create-a-database-access-class
         *      
         * Create a database access class
         * A database wrapper class abstracts the data access layer from the rest of the app.This class centralizes query logic and simplifies the management of database initialization, making it easier to refactor or expand data operations as the app grows.The Todo app defines a TodoItemDatabase class for this purpose.
         * 
         * Lazy initialization
         * The TodoItemDatabase uses asynchronous lazy initialization, represented by the custom AsyncLazy<T> class, to delay initialization of the database until it's first accessed:*/

        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<FactDataDatabase> Instance = new AsyncLazy<FactDataDatabase>(async () =>
        {
            var instance = new FactDataDatabase();
            CreateTableResult result = await Database.CreateTableAsync<FactData>();
            return instance;
        });

        public FactDataDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        /* Asynchronous lazy initialization
         * 
         * In order to start the database initialization, avoid blocking execution, and have the opportunity to catch exceptions, the sample application uses asynchronous lazy initalization, represented by the AsyncLazy<T> class:*/

        public class AsyncLazy<T> : Lazy<Task<T>>
        {
            readonly Lazy<Task<T>> instance;

            public AsyncLazy(Func<T> factory)
            {
                instance = new Lazy<Task<T>>(() => Task.Run(factory));
            }

            public AsyncLazy(Func<Task<T>> factory)
            {
                instance = new Lazy<Task<T>>(() => Task.Run(factory));
            }

            public TaskAwaiter<T> GetAwaiter()
            {
                return instance.Value.GetAwaiter();
            }
        }

        public Task<List<FactData>> GetItemsAsync()
        {
            return Database.Table<FactData>().ToListAsync();
        }

        public Task<List<FactData>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<FactData>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<FactData> GetItemAsync(int id)
        {
            return Database.Table<FactData>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(FactData item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(FactData item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<int> ClearAllAsync()
        {
            return Database.DeleteAllAsync<FactData>();
        }

        public Task<int> InsertList(IEnumerable<FactData> items)
        {
            return Database.InsertAllAsync(items);
        }
    }
}
