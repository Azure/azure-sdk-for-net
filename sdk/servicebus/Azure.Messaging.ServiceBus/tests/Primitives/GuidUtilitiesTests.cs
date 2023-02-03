// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus.Primitives;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests;

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
    public void CanWriteGuidBytes()
    {
        var input = Guid.NewGuid();
        var buffer = new byte[16];

        GuidUtilities.WriteGuidBytes(input, buffer);
        CollectionAssert.AreEqual(input.ToByteArray(), buffer);
    }
}
