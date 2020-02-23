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

        [TestMethod]
        public void Test_Save_NewItem()
        {
            var repository = new Repository<TestStorable<int>, int>();
            TestStorable<int> newItemToBeSaved = new TestStorable<int> { Id = 1, Data = "FirstItem" };
            repository.Save(newItemToBeSaved);
            IEnumerable<TestStorable<int>> result = repository.GetAll();

            Assert.IsTrue((result.Contains(newItemToBeSaved)));
        }

        [TestMethod]
        public void Test_Get_ByExistingId_ReturnsExpectedItem()
        {
            var repository = new Repository<TestStorable<int>, int>();

            repository.Save(new TestStorable<int> { Id = 1, Data = "FirstItem" });
            repository.Save(new TestStorable<int> { Id = 2, Data = "SecondItem" });
            repository.Save(new TestStorable<int> { Id = 3, Data = "ThirdItem" });

            TestStorable<int> result = repository.Get(2);

            Assert.AreEqual("SecondItem", result.Data);
        }

        [TestMethod]
        public void Test_Get_NonExistingId_ReturnsNull()
        {
            var repository = new Repository<TestStorable<int>, int>();

            repository.Save(new TestStorable<int> { Id = 1, Data = "FirstItem" });
            repository.Save(new TestStorable<int> { Id = 2, Data = "SecondItem" });
            repository.Save(new TestStorable<int> { Id = 3, Data = "ThirdItem" });

            TestStorable<int> result = repository.Get(4);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void Test_Delete_ExistingId_RemovesExpectedItem()
        {
            var repository = new Repository<TestStorable<int>, int>();

            repository.Save(new TestStorable<int> { Id = 1, Data = "FirstItem" });
            repository.Save(new TestStorable<int> { Id = 2, Data = "SecondItem" });
            repository.Save(new TestStorable<int> { Id = 3, Data = "ThirdItem" });

            repository.Delete(2);

            IEnumerable<TestStorable<int>> result = repository.GetAll();

            Assert.AreEqual(2, result.Count());

            Assert.IsFalse((result.Contains(new TestStorable<int> { Id = 2, Data = "SecondItem" })));
        }

        [TestMethod]
        public void Test_Delete_NotExistingId_NoChangeToItems()
        {
            var repository = new Repository<TestStorable<int>, int>();

            repository.Save(new TestStorable<int> { Id = 1, Data = "FirstItem" });
            repository.Save(new TestStorable<int> { Id = 2, Data = "SecondItem" });
            repository.Save(new TestStorable<int> { Id = 3, Data = "ThirdItem" });

            repository.Delete(4);

            IEnumerable<TestStorable<int>> result = repository.GetAll();

            Assert.AreEqual(3, result.Count());
        }
    }
}
