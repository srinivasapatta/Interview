using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Test
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void Test_GetAll_ReturnsCountZero_WhenNoData()
        {
            var repository = new Repository<TestStorable<int>, int>();

            IEnumerable<TestStorable<int>> result = repository.GetAll();

            Assert.AreEqual(0, result.Count());
        }
    }
}
