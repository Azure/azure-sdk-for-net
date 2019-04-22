// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ETagTests
    {
        [Test]
        public void StringRoundtrips()
        {
            var s = "tag";
            var eTag = new ETag(s);
            Assert.AreSame(s, eTag.ToString());
        }

        [Test]
        public void ComparisonOperators()
        {
            var eTag = new ETag("a");

            Assert.True(eTag == new ETag("a"));
            Assert.False(eTag == new ETag("A"));

            Assert.False(eTag != new ETag("a"));
            Assert.True(eTag != new ETag("A"));

            Assert.True(eTag.Equals(new ETag("a")));
            Assert.False(eTag.Equals(new ETag("A")));

            Assert.AreEqual(eTag.GetHashCode(), new ETag("a").GetHashCode());
            Assert.AreNotEqual(eTag.GetHashCode(), new ETag("A").GetHashCode());
        }

        [Test]
        public void DefaultComparisonOperators()
        {
            var eTag = new ETag();

            Assert.True(eTag == new ETag(null));
            Assert.True(eTag == default);

            Assert.True(eTag.Equals(new ETag(null)));;

            Assert.AreEqual(eTag.GetHashCode(), new ETag(null).GetHashCode());
        }
    }
}
