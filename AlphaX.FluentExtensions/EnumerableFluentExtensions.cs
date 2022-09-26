using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AlphaX.FluentExtensions
{
    public static class EnumerableFluentExtensions
    {
        /// <summary>
        /// Converts a collection to paged collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="perPageCount"></param>
        /// <returns></returns>
        public static IPagedEnumerable<T> ToPaged<T>(this IEnumerable<T> source, int perPageCount)
        {
            return new PagedEnumerable<T>(source, perPageCount);
        }

        /// <summary>
        /// Converts a collection to data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            return source.ToDataTableInternal(typeof(T).GetProperties().Select(x => new Mapping(x)));
        }

        /// <summary>
        /// Converts a collection to data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> source, Map<T> map)
        {
            return source.ToDataTableInternal(map.GetMappings());
        }

        private static DataTable ToDataTableInternal<T>(this IEnumerable<T> source, IEnumerable<Mapping> mappings)
        {
            var table = new DataTable();

            if (!mappings.Any())
                return table;

            foreach (var mapping in mappings)
                table.Columns.Add(new DataColumn(mapping.Name, mapping.Property.PropertyType));

            foreach (var item in source)
            {
                var row = table.NewRow();
                foreach (var mapping in mappings)
                    row[mapping.Name] = mapping.Property.GetValue(item);
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
