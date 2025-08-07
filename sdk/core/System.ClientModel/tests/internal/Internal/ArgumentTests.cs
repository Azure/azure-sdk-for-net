// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.ClientModel.Internal;

namespace System.ClientModel.Tests.Internal;

public class ArgumentTests
{
    [TestCase("test")]
    public void NotNull(object? value)
    {
        Argument.AssertNotNull(value, "value");

        Assert.AreEqual("test", value!.ToString());
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
    public void NotNullOrEmptyString()
    {
        string value = "test";
        Argument.AssertNotNullOrEmpty(value, "value");
    }

    [Test]
    public void NotNullOrEmptyStringThrowsOnNull()
    {
        string? value = null;
        Assert.Throws<ArgumentNullException>(() => Argument.AssertNotNullOrEmpty(value!, "value"));
    }

    [Test]
    public void NotNullOrEmptyStringThrowsOnEmpty()
    {
        Assert.Throws<ArgumentException>(() => Argument.AssertNotNullOrEmpty(string.Empty, "value"));
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
}
