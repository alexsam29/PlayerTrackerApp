using SQLite;

namespace PlayerTrackerApp
{
    public interface SQLiteDBinterface
    {
        SQLiteAsyncConnection createSQLiteDB();
    }
}
