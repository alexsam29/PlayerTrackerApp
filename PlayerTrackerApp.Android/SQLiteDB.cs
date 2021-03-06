using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(PlayerTrackerApp.Droid.SQLiteDB))]
namespace PlayerTrackerApp.Droid
{
    public class SQLiteDB : SQLiteDBinterface
    {
        public SQLiteDB() { }

        public SQLiteAsyncConnection createSQLiteDB()
        {
            var document_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(document_path, "playerDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}