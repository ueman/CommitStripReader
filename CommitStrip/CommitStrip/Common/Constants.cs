namespace CommitStrip.Core.Common
{
    public class Constants
    {
        public static string ComicFeed
        {
            get { return "http://www.commitstrip.com/en/feed"; }
        }

        public static string ComicFeedPage(int page)
        {
            return ComicFeed + "?paged=" + page;
        }

        public static string ComicFeedJson
        {
            get { return "http://rss2json.com/api.json?rss_url=http://www.commitstrip.com/en/feed"; }
        }

        public static string ComicFeedPageJson(int page)
        {
            return ComicFeedJson + "?paged=" + page;
        }
    }
}