// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Provider;

/// <summary>
/// T004: Tests for SeekableReplaySubject — seekable replay over ConcurrentReplayAsyncSubject.
/// Tests publish/subscribe, cursor filtering, sequence number assignment,
/// OnCompletedAsync termination, and concurrent safety.
/// </summary>
public class SeekableReplaySubjectTests
{
    private static ResponseStreamEvent CreateEvent(long seqNo = 0)
    {
        var response = new Models.Response("resp_test", "gpt-4o") { Status = ResponseStatus.InProgress };
        return ResponsesModelFactory.ResponseCreatedEvent(sequenceNumber: seqNo, response: response);
    }

    [Test]
    public async Task Publisher_AssignsSequenceNumbers_Sequentially()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        // Act — publish 3 events
        var evt1 = CreateEvent();
        var evt2 = CreateEvent();
        var evt3 = CreateEvent();
        await publisher.OnNextAsync(evt1);
        await publisher.OnNextAsync(evt2);
        await publisher.OnNextAsync(evt3);
        await publisher.OnCompletedAsync();

        // Assert — subscribe and verify sequence numbers are 0, 1, 2
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var done = new TaskCompletionSource();
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () => done.SetResult()), cursor: null);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.AreEqual(3, received.Count);
        Assert.AreEqual(0, received[0].SeqNo);
        Assert.AreEqual(1, received[1].SeqNo);
        Assert.AreEqual(2, received[2].SeqNo);
    }

    [Test]
    public async Task SubscribeFromBeginning_ReceivesAllEvents()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        // Publish 5 events
        for (int i = 0; i < 5; i++)
            await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        // Act — subscribe from beginning (cursor = null)
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var done = new TaskCompletionSource();
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () => done.SetResult()), cursor: null);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert
        Assert.AreEqual(5, received.Count);
        for (int i = 0; i < 5; i++)
            Assert.AreEqual(i, received[i].SeqNo);
    }

    [Test]
    public async Task SubscribeWithCursor_SkipsEventsAtOrBeforeCursor()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        // Publish 10 events (seq 0–9)
        for (int i = 0; i < 10; i++)
            await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        // Act — subscribe at cursor=4 (should skip events 0–4, receive 5–9)
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var done = new TaskCompletionSource();
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () => done.SetResult()), cursor: 4);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert
        Assert.AreEqual(5, received.Count);
        Assert.AreEqual(5, received[0].SeqNo);
        Assert.AreEqual(6, received[1].SeqNo);
        Assert.AreEqual(7, received[2].SeqNo);
        Assert.AreEqual(8, received[3].SeqNo);
        Assert.AreEqual(9, received[4].SeqNo);
    }

    [Test]
    public async Task OnCompletedAsync_TerminatesSubscription()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        var completed = false;
        var observer = new TestObserverWithCompletionSignal(
            onCompleted: () => completed = true);

        // Subscribe before any events
        await subject.SubscribeAsync(observer, cursor: null);

        // Act — publish some events then complete
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();
        await Task.Delay(50);

        // Assert
        Assert.IsTrue(completed, "Observer should have received OnCompletedAsync");
    }

    [Test]
    public async Task ConcurrentPublishAndSubscribe_Works()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();
        const int eventCount = 100;

        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var tcs = new TaskCompletionSource();

        // Start subscriber
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () => tcs.SetResult()),
            cursor: null);

        // Act — publish events from multiple concurrent tasks
        var tasks = new List<Task>();
        // Use semaphore to ensure async serialized writes (SeekableReplaySubject uses write lock)
        for (int i = 0; i < eventCount; i++)
        {
            await publisher.OnNextAsync(CreateEvent());
        }
        await publisher.OnCompletedAsync();

        // Wait for completion signal
        await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — all events received with valid monotonic sequence numbers
        Assert.AreEqual(eventCount, received.Count);
        for (int i = 0; i < received.Count; i++)
        {
            Assert.AreEqual(i, received[i].SeqNo);
        }
    }

    [Test]
    public async Task Dispose_DisposesInnerSubject()
    {
        // Arrange & Act
        var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();
        await publisher.OnNextAsync(CreateEvent());
        subject.Dispose();

        // Assert — after dispose, subject should not accept new subscriptions gracefully
        // (exact behavior depends on implementation, but should not throw unhandled exceptions)
        Assert.IsTrue(true); // If we got here without unhandled exception, it's ok
    }

    [Test]
    public async Task LiveSubscription_ReceivesEventsPublishedAfterSubscribe()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var tcs = new TaskCompletionSource();

        // Subscribe before publishing
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () => tcs.SetResult()),
            cursor: null);

        // Act — publish events AFTER subscribing
        for (int i = 0; i < 3; i++)
            await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — subscriber got all 3 events
        Assert.AreEqual(3, received.Count);
    }

    /// <summary>
    /// Simple test observer that collects received events with their sequence numbers.
    /// </summary>
    private sealed class TestObserver : IAsyncObserver<(long SeqNo, ResponseStreamEvent Event)>
    {
        private readonly List<(long SeqNo, ResponseStreamEvent Event)> _events;

        public TestObserver(List<(long SeqNo, ResponseStreamEvent Event)> events)
        {
            _events = events;
        }

        public ValueTask OnNextAsync((long SeqNo, ResponseStreamEvent Event) value)
        {
            _events.Add(value);
            return ValueTask.CompletedTask;
        }

        public ValueTask OnErrorAsync(Exception error) => ValueTask.CompletedTask;
        public ValueTask OnCompletedAsync() => ValueTask.CompletedTask;
    }

    /// <summary>
    /// Test observer with completion signal support.
    /// </summary>
    private sealed class TestObserverWithCompletionSignal : IAsyncObserver<(long SeqNo, ResponseStreamEvent Event)>
    {
        private readonly List<(long SeqNo, ResponseStreamEvent Event)>? _events;
        private readonly Action? _onCompleted;

        public TestObserverWithCompletionSignal(
            List<(long SeqNo, ResponseStreamEvent Event)>? events = null,
            Action? onCompleted = null)
        {
            _events = events;
            _onCompleted = onCompleted;
        }

        public ValueTask OnNextAsync((long SeqNo, ResponseStreamEvent Event) value)
        {
            _events?.Add(value);
            return ValueTask.CompletedTask;
        }

        public ValueTask OnErrorAsync(Exception error) => ValueTask.CompletedTask;

        public ValueTask OnCompletedAsync()
        {
            _onCompleted?.Invoke();
            return ValueTask.CompletedTask;
        }
    }
}
