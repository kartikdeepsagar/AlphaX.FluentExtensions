using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaX.FluentExtensions.Tests
{
    internal class DataTableFluentExtensionsTests : BaseExtensionsTest
    {
        [TestCase]
        public void DataTableToXML_Test()
        {
            var usersTable = _usersList.ToDataTable();
            var xml = usersTable.ToXML(XmlWriteMode.WriteSchema);
            Assert.IsNotNull(xml);
            var dataTable = new DataTable();
            dataTable.ReadXml(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
            Assert.AreEqual(usersTable.Rows.Count, dataTable.Rows.Count);
            Assert.AreEqual(usersTable.Columns.Count, dataTable.Columns.Count);
        }

        [TestCase]
        public void DataTableToXML_Test_NoTableName()
        {
            var usersTable = _usersList.ToDataTable();
            usersTable.TableName = null;
            Assert.Throws<InvalidOperationException>(() => usersTable.ToXML(XmlWriteMode.WriteSchema));
        }
    }
}
