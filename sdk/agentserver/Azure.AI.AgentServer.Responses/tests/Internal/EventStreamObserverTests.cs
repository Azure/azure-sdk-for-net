// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ServerSentEvents;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Responses.Internal;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

public sealed class EventStreamObserverTests
{
    [Test]
    public async Task TaskStreamErrorPropagatesToCoreTaskOwner()
    {
        EventStreamObserver observer =
            await EventStreamObserver.CreateAsync(new StubTaskStreamWriter());
        var expected = new InvalidOperationException("task stream failed");

        InvalidOperationException actual = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await observer.OnErrorAsync(expected))!;

        Assert.That(actual, Is.SameAs(expected));
    }

    private sealed class StubTaskStreamWriter : TaskStreamWriter
    {
        public override ValueTask EmitAsync(
            SseItem<string> item,
            CancellationToken cancellationToken = default)
            => ValueTask.CompletedTask;

        public override ValueTask<string?> GetLastEventIdAsync(
            CancellationToken cancellationToken = default)
            => new((string?)null);
    }
}
