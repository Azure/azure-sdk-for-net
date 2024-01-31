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
        public void DefaultPrimitiveValueType<T>(T value) where T: struct
        {
            Optional<T> optional = default;
            Assert.False(Optional.ToNullable(optional).HasValue);

            optional = value;
            Assert.True(Optional.ToNullable(optional).HasValue);
        }

        [Test]
        public void DefaultStructValueType()
        {
            Optional<DateTimeOffset> optional = default;
            Assert.False(Optional.ToNullable(optional).HasValue);

            optional = DateTimeOffset.Now;
            Assert.True(Optional.ToNullable(optional).HasValue);
        }

        [Test]
        public void DefaultEnumValueType()
        {
            Optional<HttpStatusCode> optional = default;
            Assert.False(Optional.ToNullable(optional).HasValue);

            optional = HttpStatusCode.Accepted;
            Assert.True(Optional.ToNullable(optional).HasValue);
        }

        [TestCase("")]
        public void DefaultReferenceType<T>(T value)
        {
            Optional<T> optional = default;
            Assert.False(optional.HasValue);

            optional = value;
            Assert.True(optional.HasValue);
        }
    }
}
