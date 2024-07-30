// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class ServerSentEventFieldTests
{
    [Test]
    public void ParsesEventField()
    {
        string line = "event: event.name";
        ServerSentEventField field = new(line);

        Assert.AreEqual(ServerSentEventFieldKind.Event, field.FieldType);
        Assert.IsTrue("event.name".AsSpan().SequenceEqual(field.Value.Span));
    }
}
