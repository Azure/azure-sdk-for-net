// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Expressions.DataFactory.Tests
{
    public class DataFactoryMaskedStringTests
    {
        [Test]
        public void CanCreateFromString()
        {
           var maskedString = new DataFactoryMaskedString("foo");
           Assert.AreEqual("foo", maskedString.Value);
        }

        [Test]
        public void CanCreateFromStringImplicitCast()
        {
            DataFactoryMaskedString maskedString = "foo";
            Assert.AreEqual("foo", maskedString.Value);
        }

        [Test]
        public void CanCreateFromInt()
        {
            var maskedString = new DataFactoryMaskedString(4);
            Assert.AreEqual("4", maskedString.Value);
        }

        [Test]
        public void CanCreateFromIntImplicitCast()
        {
            DataFactoryMaskedString maskedString = 4;
            Assert.AreEqual("4", maskedString.Value);
        }

        [Test]
        public void CanCreateFromDouble()
        {
            var maskedString = new DataFactoryMaskedString(4.1);
            Assert.AreEqual("4.1", maskedString.Value);
        }

        [Test]
        public void CanCreateFromDoubleImplicitCast()
        {
            DataFactoryMaskedString maskedString = 4.1;
            Assert.AreEqual("4.1", maskedString.Value);
        }

        [Test]
        public void CanCreateFromTimeSpan()
        {
            var maskedString = new DataFactoryMaskedString(TimeSpan.FromSeconds(1));
            Assert.AreEqual(TimeSpan.FromSeconds(1).ToString(), maskedString.Value);
        }

        [Test]
        public void CanCreateFromTimeSpanImplicitCast()
        {
            DataFactoryMaskedString maskedString = TimeSpan.FromSeconds(1);
            Assert.AreEqual(TimeSpan.FromSeconds(1).ToString(), maskedString.Value);
        }

        [Test]
        public void CanCreateFromDateTimeOffset()
        {
            var now = DateTimeOffset.UtcNow;
            var maskedString = new DataFactoryMaskedString(now);
            Assert.AreEqual(now.ToString(), maskedString.Value);
        }

        [Test]
        public void CanCreateFromDateTimeOffsetImplicitCast()
        {
            var now = DateTimeOffset.UtcNow;
            DataFactoryMaskedString maskedString = now;
            Assert.AreEqual(now.ToString(), maskedString.Value);
        }

        [Test]
        public void CanCreateFromUri()
        {
            var maskedString = new DataFactoryMaskedString(new Uri("https://www.microsoft.com"));;
            Assert.AreEqual("https://www.microsoft.com/", maskedString.Value);
        }

        [Test]
        public void CanCreateFromUriImplicitCast()
        {
            DataFactoryMaskedString maskedString = new Uri("https://www.microsoft.com");
            Assert.AreEqual("https://www.microsoft.com/", maskedString.Value);
        }
    }
}