// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ETagTests
    {
        [Theory]
        [TestCase("tag")]
        [TestCase("\"tag\"")]
        [TestCase("W/\"weakETag\"")]
        public void StringRoundtrips(string value)
        {
            var eTag = new ETag(value);
            Assert.AreSame(value, eTag.ToString());
            Assert.AreSame(value, eTag.ToString("G"));
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

        [Theory]
        [TestCase("lalala")]
        [TestCase("\"lalala")]
        [TestCase("lalala\"")]
        [TestCase("W/\"lalala")]
        [TestCase("W/lalala\"")]
        public void ThrowsForEtagsWithoutQuotes(string value)
        {
            Assert.Throws<ArgumentException>(() => ETag.Parse(value));
        }

        [Theory]
        [TestCase("*", "*")]
        [TestCase("\"A\"", "A")]
        [TestCase("\"\"", "")]
        [TestCase("W/\"weakETag\"", "W/\"weakETag\"")]
        public void ParsesEtag(string value, string expectedValue)
        {
            ETag tag = ETag.Parse(value);
            Assert.AreEqual(expectedValue, tag.ToString());
            Assert.AreEqual(expectedValue, tag.ToString("G"));
        }

        [Theory]
        [TestCase("*", "*")]
        [TestCase("\"A\"", "\"A\"")]
        [TestCase("\"\"", "\"\"")]
        [TestCase("W/\"weakETag\"", "W/\"weakETag\"")]
        public void ParsesEtagToFormattedString(string value, string expectedValue)
        {
            ETag tag = ETag.Parse(value);
            Assert.AreEqual(expectedValue, tag.ToString("H"));
        }

        [Theory]
        [TestCase("A")]
        [TestCase(null)]
        [TestCase("g")]
        [TestCase("h")]
        public void InvalidFormatThrows(string format)
        {
            ETag tag  = new ETag("foo");
            Assert.Throws<ArgumentException>(() => tag.ToString(format));
        }
    }
}
