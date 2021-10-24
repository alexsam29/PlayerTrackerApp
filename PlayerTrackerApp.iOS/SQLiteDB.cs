using Foundation;
using SQLite;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(PlayerTrackerApp.iOS.SQLiteDB))]
namespace PlayerTrackerApp.iOS
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