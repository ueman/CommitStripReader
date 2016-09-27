using CommitStrip.Core.Models;

namespace CommitStrip.Core.Services
{
    public interface IComicDataSerivce
    {
        void UpdateComic(CommitStripItem item);

        CommitStripItem GetComic(string id);

        void DeleteComic(CommitStripItem item);

        void SaveComic(CommitStripItem item);
    }
}