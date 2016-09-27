using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using CommitStrip.Core.Common;
using CommitStrip.Core.Models;
using CommitStrip.Core.Models.JsonModel;
using CommitStrip.Core.Parser;
using CommitStrip.Core.Utilities;
using Newtonsoft.Json;

namespace CommitStrip.Core.Services
{
    public class CommitStripDownloadService : ICommitStripDownloadService
    {
        public async Task<List<CommitStripItem>> DownloadCommitStrip(int page)
        {
            var s = new JsonRoot();
            s.items = new List<JsonItem>();
            s.items.Add(new JsonItem());
            try
            {
                var response = await new HttpClient().GetStringAsync(Constants.ComicFeedPage(page));

                return ParseRss(response);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            return new List<CommitStripItem>();
        }

        private List<CommitStripItem> ParseRss(string rss)
        {
            var xdoc = XDocument.Parse(rss);
            var id = 0;

            var comics = new List<CommitStripItem>();
            var items = xdoc.Descendants("item");
            XNamespace nsContent = "http://purl.org/rss/1.0/modules/content/";

            foreach (var item in items)
            {
                var comic = new CommitStripItem()
                {
                    Title = (string) item.Element("title"),
                    Description =  (string) item.Element(nsContent + "encoded"),
                    Link = (string) item.Element("link"),
                    //PubDate = DateTime.Now, // TODO: parse date
                    ImageLink = ComicParser.GetImageLink((string) item.Element(nsContent + "encoded")),
                    Id = StringHelper.RemoveSpecialCharacters((string)item.Element("link"))
                };
                comics.Add(comic);
            }
            return comics;
        } 
    }
}