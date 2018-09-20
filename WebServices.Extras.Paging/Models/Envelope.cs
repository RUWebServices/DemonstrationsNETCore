using System.Collections.Generic;

namespace WebServices.Extras.Paging.Models
{
    public class Envelope<T> where T : class
    {
        public Envelope(int pageSize, int pageNumber)
        {
            Items = new List<T>();
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
        
        public IEnumerable<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int MaxPages { get; set; }
    }
}