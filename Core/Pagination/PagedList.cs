using System;
using System.Collections.Generic;
using System.Linq;
namespace Core.Pagination
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize) {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items);
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var sourceItems = source.ToList();
            var count = sourceItems.Count;
            var items = sourceItems
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
