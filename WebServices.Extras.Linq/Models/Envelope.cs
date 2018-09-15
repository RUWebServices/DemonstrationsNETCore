using System.Collections.Generic;

namespace WebServices.Extras.Linq.Models
{
    // An envelope which can be used for paged collections
    public class Envelope<TItem> where TItem : class
    {
        // The list of data within the envelope
        public IEnumerable<TItem> Items { get; set; }
        // Denotes which page I am currently on
        public int pageIndex { get; set; }
        // Denotes the size of the page
        public int pageSize { get; set; }
        // Denotes how many pages are available (based on pageIndex and pageSize)
        public int maxPages { get; set; }
    }
}