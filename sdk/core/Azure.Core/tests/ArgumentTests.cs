// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ArgumentTests
    {
        [Test]
        public void NotNull()
        {
            Argument.NotNull(new object(), "value");
        }

        [Test]
        public void NotNullThrowsOnNull()
        {
            object value = null;
            Assert.Throws<ArgumentNullException>(() => Argument.NotNull(value, "value"));
        }

        [Test]
        public void NotNullNullableInt32()
        {
            int? value = 1;
            Argument.NotNull(value, "value");
        }

        [Test]
        public void NotNullNullableInt32ThrowsOnNull()
        {
            int? value = null;
            Assert.Throws<ArgumentNullException>(() => Argument.NotNull(value, "value"));
        }

        [Test]
        public void NotNullOrEmptyCollection()
        {
            string[] value = { "test" };
            Argument.NotNullOrEmpty(value, "value");
        }

        [Test]
        public void NotNullOrEmptyCollectionThrowsOnNull()
        {
            string[] value = null;
            Assert.Throws<ArgumentNullException>(() => Argument.NotNullOrEmpty(value, "value"));
        }

        [TestCaseSource(nameof(GetNotNullOrEmptyCollectionThrowsOnEmptyCollectionData))]
        public void NotNullOrEmptyCollectionThrowsOnEmptyCollection(IEnumerable<string> value)
        {
            Assert.Throws<ArgumentException>(() => Argument.NotNullOrEmpty(value, "value"));
        }

        [Test]
        public void NotNullOrEmptyString()
        {
            string value = "test";
            Argument.NotNullOrEmpty(value, "value");
        }

        [Test]
        public void NotNullOrEmptyStringThrowsOnNull()
        {
            string value = null;
            Assert.Throws<ArgumentNullException>(() => Argument.NotNullOrEmpty(value, "value"));
        }

        [Test]
        public void NotNullOrEmptyStringThrowsOnEmpty()
        {
            Assert.Throws<ArgumentException>(() => Argument.NotNullOrEmpty(string.Empty, "value"));
        }

        [Test]
        public void NotNullOrWhiteSpace()
        {
            string value = "test";
            Argument.NotNullOrWhiteSpace(value, "value");
        }

        [Test]
        public void NotNullOrWhiteSpaceThrowsOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => Argument.NotNullOrWhiteSpace(null, "value"));
        }

        [Test]
        public void NotNullOrWhiteSpaceThrowsOnEmpty()
        {
            Assert.Throws<ArgumentException>(() => Argument.NotNullOrWhiteSpace(string.Empty, "value"));
        }

        [Test]
        public void NotNullOrWhiteSpaceThrowsOnWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => Argument.NotNullOrWhiteSpace(string.Empty, " "));
        }

        [Test]
        public void NotDefault()
        {
            TestStructure value = new TestStructure("test", 1);
            Argument.NotDefault(ref value, "value");
        }

        [Test]
        public void NotDefaultThrows()
        {
            TestStructure value = default;
            Assert.Throws<ArgumentException>(() => Argument.NotDefault(ref value, "value"));
        }

        [TestCase(0, 0, 2)]
        [TestCase(1, 0, 2)]
        [TestCase(2, 0, 2)]
        public void InRangeInt32(int value, int minimum, int maximum)
        {
            Argument.InRange(value, minimum, maximum, "value");
        }

        [TestCase(-1, 0, 2)]
        [TestCase(3, 0, 2)]
        public void InRangeInt32Throws(int value, int minimum, int maximum)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Argument.InRange(value, minimum, maximum, "value"));
        }

        private readonly struct TestStructure : IEquatable<TestStructure>
        {
            internal readonly string A;
            internal readonly int B;

            internal TestStructure(string a, int b)
            {
                A = a;
                B = b;
            }

            public bool Equals(TestStructure other) => string.Equals(A, other.A, StringComparison.Ordinal) && B == other.B;
        }

        private static IEnumerable<IEnumerable<string>> GetNotNullOrEmptyCollectionThrowsOnEmptyCollectionData()
        {
            static IEnumerable<string> NotNullOrEmptyCollectionThrowsOnEmptyCollection()
            {
                yield break;
            }

            yield return new string[0];
            yield return NotNullOrEmptyCollectionThrowsOnEmptyCollection();
        }
    }
}
