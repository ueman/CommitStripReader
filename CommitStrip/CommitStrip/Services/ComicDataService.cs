using CommitStrip.Core.Models;
using MvvmCross.Platform;
using MvvmCross.Plugins.Sqlite;
using SQLite;

namespace CommitStrip.Core.Services
{
    public class ComicDataService : IComicDataSerivce
    {

        private readonly SQLiteConnection _connection;

        public ComicDataService()
        {
            var factory = Mvx.Resolve<IMvxSqliteConnectionFactory>();
            _connection = factory.GetConnection("comic.sql");
            _connection.CreateTable<CommitStripItem>();

        }

        public void UpdateComic(CommitStripItem item)
        {
            _connection.Update(item);
        }

        public void SaveComic(CommitStripItem item)
        {
            _connection.Insert(item);
        }

        public void DeleteComic(CommitStripItem item)
        {
            _connection.Delete(item);
        }

        public CommitStripItem GetComic(string id)
        {
            _connection.Find<CommitStripItem>(item => item.Id.Equals(id));
            return _connection.Get<CommitStripItem>(id);
        }
    }
}