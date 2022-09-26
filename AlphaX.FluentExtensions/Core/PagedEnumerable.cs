using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlphaX.FluentExtensions
{
    internal class PagedEnumerable<T> : IPagedEnumerable<T>
    {
        private IEnumerable<T> _source;

        public int TotalPages { get; }
        public int PerPageCount { get; }

        public PagedEnumerable(IEnumerable<T> source, int perPageCount)
        {
            _source = source;
            PerPageCount = perPageCount;
            TotalPages = _source.Count() / PerPageCount;
        }

        public IEnumerable<T> GetPageData(int page)
        {
            return _source.Skip(page * PerPageCount).Take(PerPageCount);
        }

        public IEnumerator<IEnumerator<T>> GetEnumerator()
        {
            int page = 0;
            var pages = new List<IEnumerator<T>>();
            while(page < TotalPages)
            {
                pages.Add(GetPageData(page).GetEnumerator());
                page++;
            }
            return pages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
