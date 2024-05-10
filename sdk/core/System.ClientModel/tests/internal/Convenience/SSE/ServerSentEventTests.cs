// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class ServerSentEventTests
{
    [Test]
    public void ParsesReconnectionTime()
    {
        string retryTimeInMillis = "2500";
        ServerSentEvent sse = new("message", "data", id: default, retryTimeInMillis);

        Assert.AreEqual("message", sse.EventType);
        Assert.AreEqual("data", sse.Data);
        Assert.IsNull(sse.Id);
        Assert.AreEqual(new TimeSpan(0, 0, 0, 2, 500), sse.ReconnectionTime);
    }
}
