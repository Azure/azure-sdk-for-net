// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class AsyncServerSentEventEnumeratorTests
{
    [Test]
    public async Task EnumeratesSingleEvents()
    {
        Stream contentStream = BinaryData.FromString(_mockContent).ToStream();
        using ServerSentEventReader reader = new(contentStream);
        using AsyncServerSentEventEnumerator enumerator = new(reader);

        int i = 0;
        while (await enumerator.MoveNextAsync())
        {
            ServerSentEvent sse = enumerator.Current;

            Assert.IsTrue(sse.EventName.Span.SequenceEqual($"event.{i}".AsSpan()));
            Assert.IsTrue(sse.Data.Span.SequenceEqual($"{{ \"id\": \"{i}\", \"object\": {i} }}".AsSpan()));

            i++;
        }

        Assert.AreEqual(i, 3);
    }

    // TODO: Add tests for dispose and handling cancellation token
    // TODO: later, add tests for varying the _doneToken value.

    #region Helpers

    private string _mockContent = """
        event: event.0
        data: { "id": "0", "object": 0 }

        event: event.1
        data: { "id": "1", "object": 1 }

        event: event.2
        data: { "id": "2", "object": 2 }

        event: done
        data: [DONE]

        """;

    #endregion
}
