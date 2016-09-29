using System;
using System.Collections.Generic;
using SQLite;

namespace CommitStrip.Core.Models
{
    [Table("Comics")]
    public class CommitStripItem
    {
        
        public string Title { get; set; }

        public string Link { get; set; }

        public DateTime PubDate { get; set; }

        public List<string> Categories { get; set; }

        public string Description { get; set; }

        public string ImageLink { get; set; }

        public string ImagePath { get; set; }

        [PrimaryKey]
        public string Id { get; set; }
    }
}