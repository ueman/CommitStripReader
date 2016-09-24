namespace CommitStrip.Core.Parser
{
    public class ComicParser
    {
        public static string GetImageLink(string desc)
        {
            //pretty naive
            var start = desc.IndexOf("src=\"") + 5;
            var end = desc.IndexOf("\" alt");
            return desc.Substring(start, end - start);
        } 
    }
}