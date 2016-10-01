namespace CommitStrip.Core.Common
{
    public class Constants
    {
        public static string ComicFeed => "http://www.commitstrip.com/en/feed";

        public static string ComicFeedPage(int page)
        {
            return ComicFeed + "?paged=" + page;
        }

        public static string CommitStripLink = "http://commitstrip.com/";
    }
}