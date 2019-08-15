using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.DatabaseAccess
{
    public interface ISqliteDatabase
    {
        Task<SQLiteAsyncConnection> GetNativeSqlConnectionAsync();
    }
}
