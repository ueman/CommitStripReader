using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using CommitStrip.Core.Model;
using CommitStrip.Core.Model.JsonModel;
using CommitStrip.Core.Parser;
using Newtonsoft.Json;

namespace CommitStrip.Core.Services
{
    public class CommitStripDownloadService : ICommitStripDownloadService
    {

        // data ist im format http://www.commitstrip.com/en/feed/?paged=1
        // http://rss2json.com/api.json?rss_url=http://www.commitstrip.com/en/feed/?paged=1
        public async Task<List<CommitStripItem>> DownloadCommitStrip(int page)
        {
            var s = new JsonRoot();
            s.items = new List<JsonItem>();
            s.items.Add(new JsonItem());
            try
            {
                var response = await new HttpClient().GetStringAsync("http://rss2json.com/api.json?rss_url=http://www.commitstrip.com/en/feed/?paged="+page);
                var root = JsonConvert.DeserializeObject<JsonRoot>(response);
                var comics = new List<CommitStripItem>();
                if (root.status.Equals("ok"))
                {
                    foreach (var jsonItem in root.items)
                    {
                        var comic = new CommitStripItem()
                        {
                            Categories = jsonItem.categories,
                            Description = jsonItem.description,
                            Link = jsonItem.link,
                            Title = jsonItem.title,
                            ImageLink = ComicParser.GetImageLink(jsonItem.content)
                        };
                        comics.Add(comic);
                    }
                }
                return comics;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            return new List<CommitStripItem>();
        }
    }
}