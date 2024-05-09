// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class ServerSentEventTests
{
    //[Test]
    //public void SetsPropertiesFromFields()
    //{
    //    string eventLine = "event: event.name";
    //    string dataLine = """data: {"id":"a","object":"value"}""";

    //    List<ServerSentEventField> fields = new() {
    //        new ServerSentEventField(eventLine),
    //        new ServerSentEventField(dataLine)
    //    };

    //    ServerSentEvent ssEvent = new(fields);

    //    Assert.IsNull(ssEvent.ReconnectionTime);
    //    Assert.IsTrue(ssEvent.EventType.AsSpan().SequenceEqual("event.name".AsSpan()));
    //    Assert.IsTrue(ssEvent.Data.AsSpan().SequenceEqual("""{"id":"a","object":"value"}""".AsSpan()));
    //    Assert.AreEqual(ssEvent.Id.Length, 0);
    //}
}
