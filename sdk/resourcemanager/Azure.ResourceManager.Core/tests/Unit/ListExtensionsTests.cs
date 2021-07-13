using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class ListExtensionsTests
    {
        [Test]
        public void InvalidTrimTest()
        {
            List<int> list = null;
            Assert.Throws<ArgumentNullException>(() => { list.Trim(2); });

            list = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentOutOfRangeException>(() => { list.Trim(-1); });
            Assert.Throws<ArgumentOutOfRangeException>(() => { list.Trim(4); });
        }
    }
}
