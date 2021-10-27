using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace PlayerTrackerApp
{
    public class DatabaseManager
    {
        SQLiteAsyncConnection _connection;
        public DatabaseManager()
        {
            _connection = DependencyService.Get<SQLiteDBinterface>().createSQLiteDB();
        }

        public async Task<ObservableCollection<Player>> createTable()
        {
            await _connection.CreateTableAsync<Player>();
            var playersFromDB = await _connection.Table<Player>().ToListAsync();
            var allPlayers = new ObservableCollection<Player>(playersFromDB);

            return allPlayers;
        }

        public async void addPlayer(Player newPlayer)
        {
            await _connection.InsertAsync(newPlayer);
        }

        public async void removePlayer(Player remove)
        {
            await _connection.DeleteAsync(remove);
        }

        public async void removeAll()
        {
            await _connection.DeleteAllAsync<Player>();
        }

        public async Task<bool> isAdded(Player player)
        {
            Player found = null;

            found = await _connection.FindAsync<Player>(player.id);

            if (found == null)
                return false;
            else
                return true;
        }
    }
}
