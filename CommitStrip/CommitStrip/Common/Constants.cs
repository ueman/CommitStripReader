namespace CommitStrip.Core.Common
{
    public class Constants
    {
        public static string ComicFeed => "http://www.commitstrip.com/en/feed";

        public static string EnglishLanguageComicCode = "en";
        public static string FrenchLanguageComicCode = "fr";

        public static string ComicFeedPage(int page)
        {
            return ComicFeed + "?paged=" + page;
        }

        // language is either "en" or "fr"
        public static string ComicFeedPage(int page, string language)
        {
            return CommitStripLinkLanguage(language) + "?paged=" + page;
        }

        public static string CommitStripLink = "http://commitstrip.com/";

        // language is either "en" or "fr"
        public static string CommitStripLinkLanguage(string language)
        {
            return "http://www.commitstrip.com/" + language + "/feed/";
        }
    }
}