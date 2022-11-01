using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AlphaX.FluentExtensions.Tests
{
    public class BaseExtensionsTest
    {
        protected List<UserModel> _usersList;

        [OneTimeSetUp]
        public void Setup()
        {
            var rnd = new Random();
            _usersList = Enumerable.Range(1, 50).Select(x => new UserModel()
            {
                Id = x,
                Age = rnd.Next(18, 30),
                Name = $"Name {x}"
            }).ToList();
        }
    }
}
