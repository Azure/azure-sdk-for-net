// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public void GetHashCodeNonDefault()
        {
            var eTag = new ETag("a");

            Assert.AreEqual(eTag.GetHashCode(), new ETag("a").GetHashCode());
            Assert.AreNotEqual(eTag.GetHashCode(), new ETag("A").GetHashCode());
        }

        [Test]
        public void GetHashCodeDefault()
        {
            var eTag = new ETag();

            Assert.AreEqual(eTag.GetHashCode(), new ETag(null).GetHashCode());
        }

        [Test]
        public void EqualityOperatorsNonDefault()
        {
            var eTag = new ETag("a");

            Assert.True(eTag == new ETag("a"));
            Assert.False(eTag == new ETag("A"));

            Assert.False(eTag != new ETag("a"));
            Assert.True(eTag != new ETag("A"));
        }

        [Test]
        public void EqualityOperatorsDefault()
        {
            ETag eTag = default;

            Assert.True(eTag == new ETag(null));
            Assert.True(eTag == default);
        }

        [Test]
        public void EqualityMembersNonDefault()
        {
            var eTag = new ETag("a");

            Assert.True(eTag.Equals(new ETag("a")));
            Assert.False(eTag.Equals(new ETag("A")));

            Assert.True(eTag.Equals((object)new ETag("a")));
            Assert.False(eTag.Equals((object)new ETag("A")));
        }


        [Test]
        public void EqualityMembersDefault()
        {
            var eTag = new ETag();

            Assert.True(eTag.Equals(new ETag(null)));

            Assert.True(eTag.Equals((object)new ETag(null)));
        }

        [Test]
        public void ThrowsForEtagsWithoutQuotes()
        {
            Assert.Throws<ArgumentException>(() => ETag.Parse("lalala"));
        }

        [Test]
        public void ThrowsForParseWeakEtag()
        {
            Assert.Throws<NotSupportedException>(() => ETag.Parse("W/\"lalala\""));
        }

        [Theory]
        [TestCase("*", "*")]
        [TestCase("\"A\"", "A")]
        [TestCase("\"\"", "")]
        public void ParsesEtag(string value, string expectedValue)
        {
            ETag tag = ETag.Parse(value);
            Assert.AreEqual(expectedValue, tag.ToString());
        }
    }
}
