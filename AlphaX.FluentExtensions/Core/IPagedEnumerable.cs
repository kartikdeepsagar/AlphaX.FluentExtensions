using System.Collections.Generic;

namespace AlphaX.FluentExtensions
{
    public interface IPagedEnumerable<T> : IEnumerable<IEnumerator<T>>
    {
        /// <summary>
        /// Gets the total pages available.
        /// </summary>
        int TotalPages { get; }
        /// <summary>
        /// Gets the per page item count.
        /// </summary>
        int PerPageCount { get; }
        /// <summary>
        /// Gets the data of a page.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        IEnumerable<T> GetPageData(int page);
    }
}
