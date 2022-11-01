using System.Data;
using System.IO;

namespace AlphaX.FluentExtensions
{
    public static class DataTableFluentExtensions
    {
        /// <summary>
        /// Converts a datatable to xml string.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static string ToXML(this DataTable table, XmlWriteMode mode = XmlWriteMode.IgnoreSchema)
        {
            using (StringWriter sw = new StringWriter())
            {
                table.WriteXml(sw, mode);
                return sw.ToString();
            }
        }
    }
}
