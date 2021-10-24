using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PlayerTrackerApp
{
    public interface SQLiteDBinterface
    {
        SQLiteAsyncConnection createSQLiteDB();
    }
}
