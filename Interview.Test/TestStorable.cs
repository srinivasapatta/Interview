using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interview;

namespace Interview.Test
{
    [TestClass]
    public class TestStorable<T> : IStoreable<T>
    {
        public string Data { get; set; }
        public T Id { get; set; }
    }
}
