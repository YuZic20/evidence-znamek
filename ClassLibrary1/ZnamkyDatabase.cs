using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ZnamkyDatabase
    {
        SQLiteAsyncConnection connection;
        public ZnamkyDatabase(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<Znamky>().Wait();
        }
        public Task<List<Znamky>> GetItemsAsync()
        {
            return connection.Table<Znamky>().ToListAsync();
        }

        public Task<List<Znamky>> GetItemsNotDoneAsync()
        {
            return connection.QueryAsync<Znamky>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Znamky> GetItemAsync(int id)
        {
            return connection.Table<Znamky>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Znamky item)
        {
            if (item.Id != 0)
            {
                return connection.UpdateAsync(item);
            }
            else
            {
                return connection.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Znamky item)
        {
            return connection.DeleteAsync(item);
        }
    }
}
