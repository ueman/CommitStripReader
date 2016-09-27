using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommitStrip.Core.Models;

namespace CommitStrip.Core.Services
{
    public interface ICommitStripDownloadService
    {
        void DownloadComics(int page);

        List<CommitStripItem> Comics { get; set; }

        Action<DownloadInformation> DownloadHandler { get; set; }
    }
}