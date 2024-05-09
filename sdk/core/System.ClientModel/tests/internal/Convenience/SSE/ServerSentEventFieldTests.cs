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

        Assert.AreEqual(field.FieldType, ServerSentEventFieldKind.Event);
        Assert.IsTrue(field.Value.Span.SequenceEqual("event.name".AsSpan()));
    }
}
