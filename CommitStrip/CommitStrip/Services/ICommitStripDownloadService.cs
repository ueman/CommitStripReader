using System.Collections.Generic;
using System.Threading.Tasks;
using CommitStrip.Core.Models;

namespace CommitStrip.Core.Services
{
    public interface ICommitStripDownloadService
    {
        Task<List<CommitStripItem>> DownloadCommitStrip(int page);
    }
}