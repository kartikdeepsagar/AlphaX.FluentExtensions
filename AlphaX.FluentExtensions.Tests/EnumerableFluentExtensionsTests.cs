using NUnit.Framework;
using System.Linq;

namespace AlphaX.FluentExtensions.Tests
{
    public class EnumerableFluentExtensionsTests : BaseExtensionsTest
    {
        [TestCase(5, 2, 5)]
        [TestCase(10, 3, 10)]
        [TestCase(10, 20, 0)]
        [TestCase(20, 2, 10)]
        public void ListToPaged_Test(int pageSize, int page, int expectedDataCount)
        {
            var pagedData = _usersList.ToPaged(pageSize);
            var pageData = pagedData.GetPageData(page);
            Assert.That(pageData.Count(), Is.EqualTo(expectedDataCount));
        }

        [TestCase]
        public void ListToDataTable_Test_Without_Map()
        {
            var usersTable = _usersList.ToDataTable();
            Assert.That(usersTable.Columns[0].ColumnName, Is.EqualTo("Id"));
            Assert.That(usersTable.Columns[1].ColumnName, Is.EqualTo("Age"));
            Assert.That(usersTable.Columns[2].ColumnName, Is.EqualTo("Name"));
            Assert.That(usersTable.Rows.Count, Is.EqualTo(_usersList.Count));
        }

        [TestCase]
        public void ListToDataTable_Test_With_Map()
        {
            var map = new UserModelMap();
            var usersTable = _usersList.ToDataTable(map);
            Assert.That(usersTable.Columns[0].ColumnName, Is.EqualTo("UserId"));
            Assert.That(usersTable.Columns[1].ColumnName, Is.EqualTo("Name"));
            Assert.That(usersTable.Rows.Count, Is.EqualTo(_usersList.Count));
        }
    }

    #region Models
    public class UserModel
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }

    public class UserModelMap : Map<UserModel>
    {
        public UserModelMap()
        {
            MapProperty(x => x.Id).WithName("UserId");
            MapProperty(x => x.Name);
        }
    }
    #endregion
}
