﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    /// <summary>
    /// These tests are related to our generated struct behavior.
    /// </summary>
    public class PageInfoTest
    {
        [Test]
        public void EqualsReturnsTrueForEqualValues()
        {
            var hash = new byte[] { 1, 2, 3 };

            var info1 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                hash,
                hash,
                1,
                "key1");

            var info2 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                hash,
                hash,
                1,
                "key1");

            Assert.True(info1.Equals(info2));
            Assert.True(info2.Equals(info1));

            Assert.AreEqual(info1.GetHashCode(), info2.GetHashCode());
        }

        [Test]
        public void EqualsReturnsTrueForNullValues()
        {
            var info1 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                null,
                null,
                1,
                null);

            var info2 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                null,
                null,
                1,
                null);

            Assert.True(info1.Equals(info2));
            Assert.True(info2.Equals(info1));

            Assert.AreEqual(info1.GetHashCode(), info2.GetHashCode());

        }

        [Test]
        public void EqualsReturnsTrueIfCompareContentHashByValues()
        {
            var hash1 = new byte[] { 1, 2, 3 };
            var hash2 = new byte[] { 1, 2, 3 };

            var info1 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                hash1,
                hash1,
                1,
                "key1");

            var info2 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                hash2,
                hash1,
                1,
                "key1");

            Assert.True(info1.Equals(info2));
            Assert.True(info2.Equals(info1));

            Assert.AreEqual(info1.GetHashCode(), info2.GetHashCode());
        }

        [Test]
        public void EqualsReturnsTrueIfCompareContentCrc64ByValues()
        {
            var hash1 = new byte[] { 1, 2, 3 };
            var hash2 = new byte[] { 1, 2, 3 };

            var info1 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                hash1,
                hash1,
                1,
                "key1");

            var info2 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                hash1,
                hash2,
                1,
                "key1");

            Assert.True(info1.Equals(info2));
            Assert.True(info2.Equals(info1));

            Assert.AreEqual(info1.GetHashCode(), info2.GetHashCode());
        }

        [Test]
        public void EqualsReturnsFalseIfCompareContentHashWithNull()
        {
            var hash = new byte[] { 1, 2, 3 };

            var info1 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                null,
                hash,
                1,
                "key1");

            var info2 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                hash,
                hash,
                1,
                "key1");

            Assert.True(!info1.Equals(info2));
            Assert.True(!info2.Equals(info1));

            Assert.AreNotEqual(info1.GetHashCode(), info2.GetHashCode());

        }

        [Test]
        public void EqualsReturnsFalseIfCompareContentCrc64WithNull()
        {
            var hash = new byte[] { 1, 2, 3 };

            var info1 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                hash,
                null,
                1,
                "key1");

            var info2 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                hash,
                hash,
                1,
                "key1");

            Assert.True(!info1.Equals(info2));
            Assert.True(!info2.Equals(info1));

            Assert.AreNotEqual(info1.GetHashCode(), info2.GetHashCode());

        }


        [Test]
        public void EqualsReturnFalseIfCompareDifferentValues()
        {
            var hash = new byte[] { 1, 2, 3 };

            var info1 = new PageInfo(
                new ETag("B"),
                new DateTimeOffset(2019, 9, 25, 1, 1, 1, TimeSpan.Zero),
                hash,
                hash,
                1,
                "key1");

            var info2 = new PageInfo(
                new ETag("A"),
                new DateTimeOffset(2019, 11, 25, 1, 1, 1, TimeSpan.Zero),
                hash,
                hash,
                2,
                "key2");

            Assert.True(!info1.Equals(info2));
            Assert.True(!info2.Equals(info1));

            Assert.AreNotEqual(info1.GetHashCode(), info2.GetHashCode());
        }
    }
}
