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
            Assert.That(eTag.ToString(), Is.SameAs(value));
            Assert.That(eTag.ToString("G"), Is.SameAs(value));
        }

        [Test]
        public void GetHashCodeNonDefault()
        {
            var eTag = new ETag("a");

            Assert.That(new ETag("a").GetHashCode(), Is.EqualTo(eTag.GetHashCode()));
            Assert.That(new ETag("A").GetHashCode(), Is.Not.EqualTo(eTag.GetHashCode()));
        }

        [Test]
        public void GetHashCodeDefault()
        {
            var eTag = new ETag();

            Assert.That(new ETag(null).GetHashCode(), Is.EqualTo(eTag.GetHashCode()));
        }

        [Test]
        public void EqualityOperatorsNonDefault()
        {
            var eTag = new ETag("a");

            Assert.That(eTag, Is.EqualTo(new ETag("a")));
            Assert.That(eTag == new ETag("A"), Is.False);

            Assert.That(eTag, Is.EqualTo(new ETag("a")));
            Assert.That(eTag != new ETag("A"), Is.True);
        }

        [Test]
        public void EqualityOperatorsDefault()
        {
            ETag eTag = default;

            Assert.That(eTag, Is.EqualTo(new ETag(null)));
            Assert.That(eTag, Is.EqualTo(default(ETag)));
        }

        [Test]
        public void EqualityMembersNonDefault()
        {
            var eTag = new ETag("a");

            Assert.That(eTag, Is.EqualTo(new ETag("a")));
            Assert.That(eTag.Equals(new ETag("A")), Is.False);

            Assert.That(eTag, Is.EqualTo((object)new ETag("a")));
            Assert.That(eTag.Equals((object)new ETag("A")), Is.False);
        }

        [Test]
        public void EqualityMembersDefault()
        {
            var eTag = new ETag();

            Assert.That(eTag, Is.EqualTo(new ETag(null)));

            Assert.That(eTag, Is.EqualTo((object)new ETag(null)));
        }

        [Theory]
        [TestCase("hello")]
        [TestCase("\"hello")]
        [TestCase("hello\"")]
        [TestCase("W/\"hello")]
        [TestCase("W/hello\"")]
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
            Assert.That(tag.ToString(), Is.EqualTo(expectedValue));
            Assert.That(tag.ToString("G"), Is.EqualTo(expectedValue));
        }

        [Theory]
        [TestCase("*", "*")]
        [TestCase("\"A\"", "\"A\"")]
        [TestCase("\"\"", "\"\"")]
        [TestCase("W/\"weakETag\"", "W/\"weakETag\"")]
        public void ParsesEtagToFormattedString(string value, string expectedValue)
        {
            ETag tag = ETag.Parse(value);
            Assert.That(tag.ToString("H"), Is.EqualTo(expectedValue));
        }

        [Theory]
        [TestCase("A")]
        [TestCase(null)]
        [TestCase("g")]
        [TestCase("h")]
        public void InvalidFormatThrows(string format)
        {
            ETag tag = new ETag("foo");
            Assert.Throws<ArgumentException>(() => tag.ToString(format));
        }

        [Theory]
        [TestCase(null)]
        [TestCase(default)]
        public void NullValueHasNoStringValue(string value)
        {
            ETag tag = new ETag(value);

            Assert.That(tag.ToString(), Is.Empty);
        }
    }
}
