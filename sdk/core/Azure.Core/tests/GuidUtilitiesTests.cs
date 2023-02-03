// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Shared;
using NUnit.Framework;

namespace Azure.Core.Tests;

public class GuidUtilitiesTests
{
    [Test]
    public void CanParseGuidBytes()
    {
        var input = Guid.NewGuid();

        Guid output = GuidUtilities.ParseGuidBytes(input.ToByteArray());
        Assert.AreEqual(input, output);
    }

    [Test]
    public void ParseGuidBytesThrowsOnInvalidInput()
    {
        Assert.Throws<ArgumentException>(() => GuidUtilities.ParseGuidBytes(new byte[15]));
    }

    [Test]
    public void CanWriteGuidBytes()
    {
        var input = Guid.NewGuid();
        var buffer = new byte[16];

        GuidUtilities.WriteGuidBytes(input, buffer);
        CollectionAssert.AreEqual(input.ToByteArray(), buffer);
    }

    [Test]
    public void WriteGuidBytesThrowsOnInvalidBuffer()
    {
        var input = Guid.NewGuid();
        var buffer = new byte[15];
        Assert.Throws<ArgumentException>(() => GuidUtilities.WriteGuidBytes(input, buffer));
    }
}
