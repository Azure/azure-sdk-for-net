// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class OptionalTests
    {
        [TestCase(int.MinValue)]
        [TestCase(float.MinValue)]
        [TestCase(false)]
        [TestCase('a')]
        public void DefaultPrimitiveValueType<T>(T value) where T : struct
        {
            Optional<T> optional = default;
            Assert.That(Optional.ToNullable(optional).HasValue, Is.False);

            optional = value;
            Assert.That(Optional.ToNullable(optional).HasValue, Is.True);
        }

        [Test]
        public void DefaultStructValueType()
        {
            Optional<DateTimeOffset> optional = default;
            Assert.That(Optional.ToNullable(optional).HasValue, Is.False);

            optional = DateTimeOffset.Now;
            Assert.That(Optional.ToNullable(optional).HasValue, Is.True);
        }

        [Test]
        public void DefaultEnumValueType()
        {
            Optional<HttpStatusCode> optional = default;
            Assert.That(Optional.ToNullable(optional).HasValue, Is.False);

            optional = HttpStatusCode.Accepted;
            Assert.That(Optional.ToNullable(optional).HasValue, Is.True);
        }

        [TestCase("")]
        public void DefaultReferenceType<T>(T value)
        {
            Optional<T> optional = default;
            Assert.That(optional.HasValue, Is.False);

            optional = value;
            Assert.That(optional.HasValue, Is.True);
        }
    }
}
