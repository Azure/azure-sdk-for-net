// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Shared;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests;

public class GuidUtilitiesTests
{
    [Test]
    public void CanParseGuidBytes()
    {
        var input = Guid.NewGuid();

        Assert.IsTrue(GuidUtilities.TryParseGuidBytes(input.ToByteArray(), out Guid output));
        Assert.AreEqual(input, output);
    }

    [Test]
    public void TryParseGuidBytesReturnsFalseOnInvalidInput()
    {
        Assert.IsFalse(GuidUtilities.TryParseGuidBytes(new byte[15], out Guid guid));
        Assert.AreEqual(default(Guid), guid);
    }

    [Test]
    public void CanWriteGuidBytes()
    {
        var input = Guid.NewGuid();
        var buffer = new byte[16];

        GuidUtilities.WriteGuidToBuffer(input, buffer);
        CollectionAssert.AreEqual(input.ToByteArray(), buffer);
    }

    [Test]
    public void WriteGuidBytesThrowsOnInvalidBuffer()
    {
        var input = Guid.NewGuid();
        var buffer = new byte[15];
        Assert.Throws<ArgumentException>(() => GuidUtilities.WriteGuidToBuffer(input, buffer));
    }
}
