namespace CommitStrip.Core.Models
{
    public class DownloadInformation
    {
        public DownloadStatus Status { get; set; }

        public DownloadInformation(DownloadStatus status)
        {
            Status = status;
        }
    }

    public enum DownloadStatus
    {
        Success = 1,
        Failed = 2,
        NoMorePages = 3
    }
}