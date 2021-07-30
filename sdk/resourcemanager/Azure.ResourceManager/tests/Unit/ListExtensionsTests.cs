using System;
using System.Collections.Generic;
using Azure.ResourceManager.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
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

        [Test]
        public void ValidTrimTest()
        {
            List<int> list1 = new List<int>() { 1, 2, 3 };
            List<int> list2 = new List<int>() { 3 };
            Assert.AreEqual(list2, list1.Trim(2));
        }
    }
}
