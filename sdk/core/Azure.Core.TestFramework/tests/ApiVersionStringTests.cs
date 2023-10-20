// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ApiVersionStringTests
    {
        [TestCase("2020-01-02", "2020-01-01")]
        [TestCase("2020-02-01", "2020-01-01")]
        [TestCase("2021-01-01", "2020-01-01")]
        [TestCase("2020-01-01", "2020-01-01-alpha.1")]
        [TestCase("2020-01-01-alpha.2", "2020-01-01-alpha.1")]
        [TestCase("2020-01-01-beta.1", "2020-01-01-alpha.2")]
        public void ShouldBeGreaterAndLess(string left, string right)
        {
            var leftAvs = new ApiVersionString(left);
            var rightAvs = new ApiVersionString(right);
            Assert.Greater(leftAvs.CompareTo(rightAvs), 0);
            Assert.Less(rightAvs.CompareTo(leftAvs), 0);
        }

        [TestCase("2020-01-01", "2020-01-01")]
        [TestCase("2020-01-01-alpha.1", "2020-01-01-alpha.1")]
        public void ShouldBeEqual(string left, string right)
        {
            var leftAvs = new ApiVersionString(left);
            var rightAvs = new ApiVersionString(right);
            Assert.AreEqual(0, left.CompareTo(right));
        }
    }
}
