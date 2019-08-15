using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.DatabaseAccess
{
    public class DatabaseConnection
    {
        private static SQLiteAsyncConnection _sqlConnection;
        private static bool _isInitComplete;

        public static async Task<SQLiteAsyncConnection> GetSqlConnectionAsync()
        {
            if (_sqlConnection == null)
            {
                _sqlConnection = await DependencyService.Get<ISqliteDatabase>().GetNativeSqlConnectionAsync().ConfigureAwait(false);
                await InitializeTables();
                _isInitComplete = true;
            }
            await Task.Run(() =>
            {
                while (!_isInitComplete) { }
            });
            return _sqlConnection;
        }

        private static async Task InitializeTables()
        {
            List<Task> createTableTaskList = new List<Task>
            {
                _sqlConnection.CreateTableAsync<Student>(CreateFlags.ImplicitPK | CreateFlags.AutoIncPK),
                
            };
            await Task.WhenAll(createTableTaskList);
        }
    }
}
