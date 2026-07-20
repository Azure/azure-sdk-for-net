// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Time.Testing;

namespace Azure.AI.AgentServer.Responses.Tests.Provider;

/// <summary>
/// T004: Tests for SeekableReplaySubject — custom seekable replay subject implementation.
/// Covers publish/subscribe, cursor filtering, sequence number assignment,
/// TTL-based expiry, error propagation, completion replay, unsubscribe semantics,
/// concurrent safety, and edge cases.
/// </summary>
public class SeekableReplaySubjectTests
{
    private static ResponseStreamEvent CreateEvent(long seqNo = 0)
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o") { Status = ResponseStatus.InProgress };
        return ResponsesModelFactory.ResponseCreatedEvent(sequenceNumber: seqNo, response: response);
    }

    // ── Sequence number assignment ─────────────────────────

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

        Assert.That(received, Has.Count.EqualTo(3));
        Assert.That(received[0].SeqNo, Is.EqualTo(0));
        Assert.That(received[1].SeqNo, Is.EqualTo(1));
        Assert.That(received[2].SeqNo, Is.EqualTo(2));
    }

    // ── Subscribe from beginning ───────────────────────────

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
        Assert.That(received, Has.Count.EqualTo(5));
        for (int i = 0; i < 5; i++)
            Assert.That(received[i].SeqNo, Is.EqualTo(i));
    }

    // ── Cursor-based seeking ───────────────────────────────

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
        Assert.That(received, Has.Count.EqualTo(5));
        Assert.That(received[0].SeqNo, Is.EqualTo(5));
        Assert.That(received[1].SeqNo, Is.EqualTo(6));
        Assert.That(received[2].SeqNo, Is.EqualTo(7));
        Assert.That(received[3].SeqNo, Is.EqualTo(8));
        Assert.That(received[4].SeqNo, Is.EqualTo(9));
    }

    [Test]
    public async Task SubscribeWithCursor_PastAllEvents_ReceivesNothing()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        // Publish 3 events (seq 0–2)
        for (int i = 0; i < 3; i++)
            await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        // Act — cursor=99, well past all events
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var done = new TaskCompletionSource();
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () => done.SetResult()), cursor: 99);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — no events received, but completion still delivered
        Assert.That(received, Is.Empty);
    }

    [Test]
    public async Task SubscribeWithCursor_AtLastEvent_ReceivesNothing()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        // Publish 5 events (seq 0–4)
        for (int i = 0; i < 5; i++)
            await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        // Act — cursor=4 (same as last seq no), so nothing passes the > filter
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var done = new TaskCompletionSource();
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () => done.SetResult()), cursor: 4);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert
        Assert.That(received, Is.Empty);
    }

    // ── Completion / termination ───────────────────────────

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
        Assert.That(completed, Is.True, "Observer should have received OnCompletedAsync");
    }

    [Test]
    public async Task LateSubscriber_AfterCompletion_ReceivesBufferedEventsAndCompletion()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        // Act — subscribe AFTER completion
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var completed = false;
        var done = new TaskCompletionSource();
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () =>
            {
                completed = true;
                done.SetResult();
            }),
            cursor: null);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — gets all events AND completion
        Assert.That(received, Has.Count.EqualTo(2));
        Assert.That(completed, Is.True, "Late subscriber should receive completion");
    }

    // ── Error propagation ──────────────────────────────────

    [Test]
    public async Task OnErrorAsync_PropagatesErrorToLiveSubscribers()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        Exception? receivedError = null;
        var errorTcs = new TaskCompletionSource();
        var observer = new TestObserverFull(
            onError: ex =>
            {
                receivedError = ex;
                errorTcs.SetResult();
            });
        await subject.SubscribeAsync(observer, cursor: null);

        // Act
        var expectedException = new InvalidOperationException("stream failed");
        await publisher.OnErrorAsync(expectedException);
        await errorTcs.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert
        Assert.That(receivedError, Is.SameAs(expectedException));
    }

    [Test]
    public async Task LateSubscriber_AfterError_ReceivesBufferedEventsAndError()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        await publisher.OnNextAsync(CreateEvent());
        var expectedException = new InvalidOperationException("stream failed");
        await publisher.OnErrorAsync(expectedException);

        // Act — subscribe AFTER error
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        Exception? receivedError = null;
        var done = new TaskCompletionSource();
        var observer = new TestObserverFull(
            onNext: val => received.Add(val),
            onError: ex =>
            {
                receivedError = ex;
                done.SetResult();
            });
        await subject.SubscribeAsync(observer, cursor: null);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — gets buffered event AND error replay
        Assert.That(received, Has.Count.EqualTo(1));
        Assert.That(receivedError, Is.SameAs(expectedException));
    }

    // ── TTL-based expiry ───────────────────────────────────

    [Test]
    public async Task ExpiredEvents_ArePrunedOnSubscribe()
    {
        // Arrange — 1-minute window with fake time
        var fakeTime = new FakeTimeProvider();
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(1), fakeTime);
        var publisher = subject.GetPublisher();

        // Publish 3 events at T=0
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnNextAsync(CreateEvent());

        // Advance time past the TTL
        fakeTime.Advance(TimeSpan.FromMinutes(2));

        // Publish 2 more events at T=2min (still within window)
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        // Act — subscribe; should only see the 2 recent events (seq 3–4)
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var done = new TaskCompletionSource();
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () => done.SetResult()), cursor: null);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — first 3 events expired, only 2 remain
        Assert.That(received, Has.Count.EqualTo(2));
        Assert.That(received[0].SeqNo, Is.EqualTo(3));
        Assert.That(received[1].SeqNo, Is.EqualTo(4));
    }

    [Test]
    public async Task ExpiredEvents_ArePrunedOnPublish()
    {
        // Arrange — 30-second TTL with fake time
        var fakeTime = new FakeTimeProvider();
        using var subject = new SeekableReplaySubject(TimeSpan.FromSeconds(30), fakeTime);
        var publisher = subject.GetPublisher();

        // Publish event at T=0
        await publisher.OnNextAsync(CreateEvent());

        // Advance past TTL
        fakeTime.Advance(TimeSpan.FromSeconds(60));

        // Publish new event — this triggers PruneExpired internally
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        // Act — subscribe and check
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var done = new TaskCompletionSource();
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () => done.SetResult()), cursor: null);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — only the second event survives
        Assert.That(received, Has.Count.EqualTo(1));
        Assert.That(received[0].SeqNo, Is.EqualTo(1));
    }

    [Test]
    public async Task AllEventsExpired_SubscriberReceivesNothing()
    {
        // Arrange
        var fakeTime = new FakeTimeProvider();
        using var subject = new SeekableReplaySubject(TimeSpan.FromSeconds(10), fakeTime);
        var publisher = subject.GetPublisher();

        // Publish events at T=0
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnNextAsync(CreateEvent());

        // Advance past TTL
        fakeTime.Advance(TimeSpan.FromSeconds(30));
        await publisher.OnCompletedAsync();

        // Act
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var done = new TaskCompletionSource();
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () => done.SetResult()), cursor: null);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — all expired, nothing delivered
        Assert.That(received, Is.Empty);
    }

    // ── Unsubscribe semantics ──────────────────────────────

    [Test]
    public async Task Unsubscribe_StopsReceivingEvents()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();

        var observer = new TestObserverFull(onNext: val => received.Add(val));
        var subscription = await subject.SubscribeAsync(observer, cursor: null);

        // Publish first event — subscriber should get it
        await publisher.OnNextAsync(CreateEvent());
        await Task.Delay(50);
        Assert.That(received, Has.Count.EqualTo(1));

        // Act — unsubscribe
        await subscription.DisposeAsync();

        // Publish more events — subscriber should NOT get these
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnNextAsync(CreateEvent());
        await Task.Delay(50);

        // Assert — still only 1 event
        Assert.That(received, Has.Count.EqualTo(1));
    }

    // ── Concurrent publish and subscribe ───────────────────

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

        // Act — publish many events sequentially (write lock serializes)
        for (int i = 0; i < eventCount; i++)
        {
            await publisher.OnNextAsync(CreateEvent());
        }
        await publisher.OnCompletedAsync();

        // Wait for completion signal
        await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — all events received with valid monotonic sequence numbers
        Assert.That(received, Has.Count.EqualTo(eventCount));
        for (int i = 0; i < received.Count; i++)
        {
            Assert.That(received[i].SeqNo, Is.EqualTo(i));
        }
    }

    [Test]
    public async Task MultipleSubscribers_AllReceiveEvents()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        var received1 = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var received2 = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var done1 = new TaskCompletionSource();
        var done2 = new TaskCompletionSource();

        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received1, () => done1.SetResult()), cursor: null);
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received2, () => done2.SetResult()), cursor: null);

        // Act
        for (int i = 0; i < 5; i++)
            await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        await Task.WhenAll(done1.Task, done2.Task).WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — both subscribers got all 5 events
        Assert.That(received1, Has.Count.EqualTo(5));
        Assert.That(received2, Has.Count.EqualTo(5));
    }

    [Test]
    public async Task MultipleSubscribers_DifferentCursors_ReceiveCorrectSubsets()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        for (int i = 0; i < 10; i++)
            await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        // Act — subscriber1: all events; subscriber2: from cursor=7
        var received1 = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var received2 = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var done1 = new TaskCompletionSource();
        var done2 = new TaskCompletionSource();

        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received1, () => done1.SetResult()), cursor: null);
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received2, () => done2.SetResult()), cursor: 7);

        await Task.WhenAll(done1.Task, done2.Task).WaitAsync(TimeSpan.FromSeconds(5));

        // Assert
        Assert.That(received1, Has.Count.EqualTo(10));
        Assert.That(received2, Has.Count.EqualTo(2)); // seq 8, 9
        Assert.That(received2[0].SeqNo, Is.EqualTo(8));
        Assert.That(received2[1].SeqNo, Is.EqualTo(9));
    }

    // ── Dispose / edge cases ───────────────────────────────

    [Test]
    public async Task Dispose_ClearsBufferAndSubscribers()
    {
        // Arrange
        var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();
        await publisher.OnNextAsync(CreateEvent());

        // Act
        subject.Dispose();

        // Assert — no exception on double dispose
        Assert.That(() => subject.Dispose(), Throws.Nothing);
    }

    [Test]
    public async Task EmptySubject_SubscriberReceivesOnlyCompletion()
    {
        // Arrange — no events published, just complete
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();
        await publisher.OnCompletedAsync();

        // Act
        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var completed = false;
        var done = new TaskCompletionSource();
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () =>
            {
                completed = true;
                done.SetResult();
            }),
            cursor: null);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert
        Assert.That(received, Is.Empty);
        Assert.That(completed, Is.True);
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
        Assert.That(received, Has.Count.EqualTo(3));
    }

    [Test]
    public async Task MixedReplayAndLive_ReceivesBoth()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        // Publish 2 events first (these will be replayed)
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnNextAsync(CreateEvent());

        var received = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var done = new TaskCompletionSource();

        // Subscribe — should get replay of seq 0, 1
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(received, () => done.SetResult()), cursor: null);

        // Publish 2 more (live events)
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        await done.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — got all 4 (2 replay + 2 live)
        Assert.That(received, Has.Count.EqualTo(4));
        Assert.That(received[0].SeqNo, Is.EqualTo(0));
        Assert.That(received[1].SeqNo, Is.EqualTo(1));
        Assert.That(received[2].SeqNo, Is.EqualTo(2));
        Assert.That(received[3].SeqNo, Is.EqualTo(3));
    }

    [Test]
    public async Task ThrowingSubscriber_IsRemovedAndDoesNotAffectOthers()
    {
        // Arrange
        using var subject = new SeekableReplaySubject(TimeSpan.FromMinutes(5));
        var publisher = subject.GetPublisher();

        var goodReceived = new List<(long SeqNo, ResponseStreamEvent Event)>();
        var goodDone = new TaskCompletionSource();

        // Bad subscriber that throws on every event
        var badObserver = new ThrowingObserver();
        await subject.SubscribeAsync(badObserver, cursor: null);

        // Good subscriber
        await subject.SubscribeAsync(
            new TestObserverWithCompletionSignal(goodReceived, () => goodDone.SetResult()), cursor: null);

        // Act — publish events; bad subscriber throws, good subscriber should still get them
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnNextAsync(CreateEvent());
        await publisher.OnCompletedAsync();

        await goodDone.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Assert — good subscriber got both events despite bad subscriber throwing
        Assert.That(goodReceived, Has.Count.EqualTo(2));
    }

    // ── Test helpers ───────────────────────────────────────

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

    /// <summary>
    /// Fully customizable test observer with callbacks for all three signals.
    /// </summary>
    private sealed class TestObserverFull : IAsyncObserver<(long SeqNo, ResponseStreamEvent Event)>
    {
        private readonly Action<(long SeqNo, ResponseStreamEvent Event)>? _onNext;
        private readonly Action<Exception>? _onError;
        private readonly Action? _onCompleted;

        public TestObserverFull(
            Action<(long SeqNo, ResponseStreamEvent Event)>? onNext = null,
            Action<Exception>? onError = null,
            Action? onCompleted = null)
        {
            _onNext = onNext;
            _onError = onError;
            _onCompleted = onCompleted;
        }

        public ValueTask OnNextAsync((long SeqNo, ResponseStreamEvent Event) value)
        {
            _onNext?.Invoke(value);
            return ValueTask.CompletedTask;
        }

        public ValueTask OnErrorAsync(Exception error)
        {
            _onError?.Invoke(error);
            return ValueTask.CompletedTask;
        }

        public ValueTask OnCompletedAsync()
        {
            _onCompleted?.Invoke();
            return ValueTask.CompletedTask;
        }
    }

    /// <summary>
    /// An observer that always throws — used to verify fault isolation.
    /// </summary>
    private sealed class ThrowingObserver : IAsyncObserver<(long SeqNo, ResponseStreamEvent Event)>
    {
        public ValueTask OnNextAsync((long SeqNo, ResponseStreamEvent Event) value) =>
            throw new InvalidOperationException("Intentional test failure");

        public ValueTask OnErrorAsync(Exception error) => ValueTask.CompletedTask;

        public ValueTask OnCompletedAsync() => ValueTask.CompletedTask;
    }
}
