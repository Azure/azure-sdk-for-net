// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ArgumentTests
    {
        [TestCase("test")]
        public void NotNull(object? value)
        {
            Argument.AssertNotNull(value, "value");

            // With nullability enabled and without [NotNull] attributed on the first parameter above, this would fail compilation.
            Assert.AreEqual("test", value.ToString());
        }

        [Test]
        public void NotNullThrowsOnNull()
        {
            object? value = null;
            Assert.Throws<ArgumentNullException>(() => Argument.AssertNotNull(value, "value"));
        }

        [Test]
        public void NotNullNullableInt32()
        {
            int? value = 1;
            Argument.AssertNotNull(value, "value");
        }

        [Test]
        public void NotNullNullableInt32ThrowsOnNull()
        {
            int? value = null;
            Assert.Throws<ArgumentNullException>(() => Argument.AssertNotNull(value, "value"));
        }

        [Test]
        public void NotNullOrEmptyCollection()
        {
            string[] value = { "test" };
            Argument.AssertNotNullOrEmpty(value, "value");
        }

        [Test]
        public void NotNullOrEmptyCollectionThrowsOnNull()
        {
            string[]? value = null;
            Assert.Throws<ArgumentNullException>(() => Argument.AssertNotNullOrEmpty(value, "value"));
        }

        [TestCaseSource(nameof(GetNotNullOrEmptyCollectionThrowsOnEmptyCollectionData))]
        public void NotNullOrEmptyCollectionThrowsOnEmptyCollection(IEnumerable<string>? value)
        {
            Assert.Throws<ArgumentException>(() => Argument.AssertNotNullOrEmpty(value, "value"));
        }

        [Test]
        public void NotNullOrEmptyString()
        {
            string value = "test";
            Argument.AssertNotNullOrEmpty(value, "value");
        }

        [Test]
        public void NotNullOrEmptyStringThrowsOnNull()
        {
            string? value = null;
            Assert.Throws<ArgumentNullException>(() => Argument.AssertNotNullOrEmpty(value, "value"));
        }

        [Test]
        public void NotNullOrEmptyStringThrowsOnEmpty()
        {
            Assert.Throws<ArgumentException>(() => Argument.AssertNotNullOrEmpty(string.Empty, "value"));
        }

        [Test]
        public void NotNullOrWhiteSpace()
        {
            string value = "test";
            Argument.AssertNotNullOrWhiteSpace(value, "value");
        }

        [Test]
        public void NotNullOrWhiteSpaceThrowsOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => Argument.AssertNotNullOrWhiteSpace(null, "value"));
        }

        [Test]
        public void NotNullOrWhiteSpaceThrowsOnEmpty()
        {
            Assert.Throws<ArgumentException>(() => Argument.AssertNotNullOrWhiteSpace(string.Empty, "value"));
        }

        [Test]
        public void NotNullOrWhiteSpaceThrowsOnWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => Argument.AssertNotNullOrWhiteSpace(string.Empty, " "));
        }

        [Test]
        public void NotDefault()
        {
            TestStructure value = new TestStructure("test", 1);
            Argument.AssertNotDefault(ref value, "value");
        }

        [Test]
        public void NotDefaultThrows()
        {
            TestStructure value = default;
            Assert.Throws<ArgumentException>(() => Argument.AssertNotDefault(ref value, "value"));
        }

        [TestCase(0, 0, 2)]
        [TestCase(1, 0, 2)]
        [TestCase(2, 0, 2)]
        public void InRangeInt32(int value, int minimum, int maximum)
        {
            Argument.AssertInRange(value, minimum, maximum, "value");
        }

        [TestCase(-1, 0, 2)]
        [TestCase(3, 0, 2)]
        public void InRangeInt32Throws(int value, int minimum, int maximum)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Argument.AssertInRange(value, minimum, maximum, "value"));
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
