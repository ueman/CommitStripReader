using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;
using CommitStrip.Core.Common;
using CommitStrip.Core.Models;
using CommitStrip.Core.Models.JsonModel;
using CommitStrip.Core.Parser;
using CommitStrip.Core.Utilities;

namespace CommitStrip.Core.Services
{
    public class CommitStripDownloadService : ICommitStripDownloadService
    {
        public List<CommitStripItem> Comics { get; set; } 

        public Action<DownloadInformation> DownloadHandler { get; set; } 

        public async void DownloadComics(int page)
        {
            var s = new JsonRoot();
            s.items = new List<JsonItem>();
            s.items.Add(new JsonItem());
            try
            {
                var response = await new HttpClient().GetStringAsync(Constants.ComicFeedPage(page));

                Comics = ParseRss(response);
                DownloadHandler(new DownloadInformation(DownloadStatus.Success));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Comics = new List<CommitStripItem>();
            DownloadHandler(new DownloadInformation(DownloadStatus.Failed));
        }

        private List<CommitStripItem> ParseRss(string rss)
        {
            var xdoc = XDocument.Parse(rss);

            var comics = new List<CommitStripItem>();
            var items = xdoc.Descendants("item");
            XNamespace nsContent = "http://purl.org/rss/1.0/modules/content/";

            foreach (var item in items)
            {
                var categoryList = item.Elements("category").Select(category => (string) category).ToList();
                var comic = new CommitStripItem()
                {
                    Title = (string) item.Element("title"),
                    Description =  (string) item.Element(nsContent + "encoded"),
                    Link = (string) item.Element("link"),
                    PubDate = parseTime((string) item.Element("pubDate")),
                    ImageLink = ComicParser.GetImageLink((string) item.Element(nsContent + "encoded")),
                    Id = StringHelper.RemoveSpecialCharacters((string)item.Element("link")),
                    Categories = categoryList
                };
                comics.Add(comic);
            }
            return comics;
        }

        private DateTime parseTime(string dateString)
        {
            string parseFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";
            return DateTime.ParseExact(dateString, parseFormat, CultureInfo.InvariantCulture);
        }
    }
}