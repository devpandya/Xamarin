using Android.OS;
using SQLite;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.DatabaseAccess;
using XamarinApp.Droid.Common;

[assembly: Dependency(typeof(SqliteDatabase))]
namespace XamarinApp.Droid.Common
{
    public class SqliteDatabase : ISqliteDatabase
    {
        public async Task<SQLiteAsyncConnection> GetNativeSqlConnectionAsync()
        {
            return new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "xamarinapp.db"));
        }
    }
}