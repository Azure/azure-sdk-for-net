// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class TextResponseTests
{
    private static ResponseContext CreateContext() => new("resp_test");
    private static CreateResponse CreateRequest() => new() { Model = "gpt-4o" };

    // ── Constructor Validation ────────────────────────────────

    [Test]
    public void Constructor_CreateText_ThrowsOnNullContext()
    {
        Assert.That(
            () => new TextResponse(null!, CreateRequest(), createText: ct => Task.FromResult("hi")),
            Throws.ArgumentNullException);
    }

    [Test]
    public void Constructor_CreateText_ThrowsOnNullRequest()
    {
        Assert.That(
            () => new TextResponse(CreateContext(), null!, createText: ct => Task.FromResult("hi")),
            Throws.ArgumentNullException);
    }

    [Test]
    public void Constructor_CreateText_ThrowsOnNullDelegate()
    {
        Assert.That(
            () => new TextResponse(CreateContext(), CreateRequest(),
                createText: (Func<CancellationToken, Task<string>>)null!),
            Throws.ArgumentNullException);
    }

    [Test]
    public void Constructor_CreateTextStream_ThrowsOnNullContext()
    {
        Assert.That(
            () => new TextResponse(null!, CreateRequest(),
                createTextStream: ct => ToAsyncEnumerable()),
            Throws.ArgumentNullException);
    }

    [Test]
    public void Constructor_CreateTextStream_ThrowsOnNullRequest()
    {
        Assert.That(
            () => new TextResponse(CreateContext(), null!,
                createTextStream: ct => ToAsyncEnumerable()),
            Throws.ArgumentNullException);
    }

    [Test]
    public void Constructor_CreateTextStream_ThrowsOnNullDelegate()
    {
        Assert.That(
            () => new TextResponse(CreateContext(), CreateRequest(),
                createTextStream: (Func<CancellationToken, IAsyncEnumerable<string>>)null!),
            Throws.ArgumentNullException);
    }

    // ── Complete Text Mode ────────────────────────────────────

    [Test]
    public async Task CompleteText_EmitsCorrectEventSequence()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createText: ct => Task.FromResult("Hello, world!"));

        var events = await CollectEventsAsync(response);

        Assert.That(events, Has.Count.EqualTo(9));
        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[2]);
        XAssert.IsType<ResponseContentPartAddedEvent>(events[3]);
        XAssert.IsType<ResponseTextDeltaEvent>(events[4]);
        XAssert.IsType<ResponseTextDoneEvent>(events[5]);
        XAssert.IsType<ResponseContentPartDoneEvent>(events[6]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[7]);
        XAssert.IsType<ResponseCompletedEvent>(events[8]);
    }

    [Test]
    public async Task CompleteText_DeltaContainsFullText()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createText: ct => Task.FromResult("The answer is 42."));

        var events = await CollectEventsAsync(response);

        var delta = XAssert.IsType<ResponseTextDeltaEvent>(events[4]);
        Assert.That(delta.Delta, Is.EqualTo("The answer is 42."));
    }

    [Test]
    public async Task CompleteText_DoneContainsFullText()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createText: ct => Task.FromResult("The answer is 42."));

        var events = await CollectEventsAsync(response);

        var done = XAssert.IsType<ResponseTextDoneEvent>(events[5]);
        Assert.That(done.Text, Is.EqualTo("The answer is 42."));
    }

    [Test]
    public async Task CompleteText_SequenceNumbersAreMonotonic()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createText: ct => Task.FromResult("hi"));

        var events = await CollectEventsAsync(response);

        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }
    }

    [Test]
    public async Task CompleteText_ResponseStatusIsCompletedAtEnd()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createText: ct => Task.FromResult("done"));

        var events = await CollectEventsAsync(response);

        var completed = XAssert.IsType<ResponseCompletedEvent>(events[^1]);
        Assert.That(completed.Response.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    // ── Streaming Text Mode ──────────────────────────────────

    [Test]
    public async Task StreamingText_EmitsCorrectEventSequence()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createTextStream: ct => ToAsyncEnumerable("Hello", ", ", "world!"));

        var events = await CollectEventsAsync(response);

        // 4 preamble + 3 deltas + 1 text done + 2 closing + 1 completed = 11
        Assert.That(events, Has.Count.EqualTo(11));
        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[2]);
        XAssert.IsType<ResponseContentPartAddedEvent>(events[3]);
        XAssert.IsType<ResponseTextDeltaEvent>(events[4]);
        XAssert.IsType<ResponseTextDeltaEvent>(events[5]);
        XAssert.IsType<ResponseTextDeltaEvent>(events[6]);
        XAssert.IsType<ResponseTextDoneEvent>(events[7]);
        XAssert.IsType<ResponseContentPartDoneEvent>(events[8]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[9]);
        XAssert.IsType<ResponseCompletedEvent>(events[10]);
    }

    [Test]
    public async Task StreamingText_DeltasContainIndividualChunks()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createTextStream: ct => ToAsyncEnumerable("Hello", ", ", "world!"));

        var events = await CollectEventsAsync(response);

        var delta0 = XAssert.IsType<ResponseTextDeltaEvent>(events[4]);
        var delta1 = XAssert.IsType<ResponseTextDeltaEvent>(events[5]);
        var delta2 = XAssert.IsType<ResponseTextDeltaEvent>(events[6]);

        Assert.That(delta0.Delta, Is.EqualTo("Hello"));
        Assert.That(delta1.Delta, Is.EqualTo(", "));
        Assert.That(delta2.Delta, Is.EqualTo("world!"));
    }

    [Test]
    public async Task StreamingText_DoneContainsAccumulatedText()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createTextStream: ct => ToAsyncEnumerable("Hello", ", ", "world!"));

        var events = await CollectEventsAsync(response);

        var done = XAssert.IsType<ResponseTextDoneEvent>(events[7]);
        Assert.That(done.Text, Is.EqualTo("Hello, world!"));
    }

    [Test]
    public async Task StreamingText_SequenceNumbersAreMonotonic()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createTextStream: ct => ToAsyncEnumerable("a", "b"));

        var events = await CollectEventsAsync(response);

        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }
    }

    // ── Configure Callback ───────────────────────────────────

    [Test]
    public async Task Configure_IsCalledBeforeCreatedEvent()
    {
        double? capturedTemp = null;

        var response = new TextResponse(CreateContext(), CreateRequest(),
            configure: r => r.Temperature = 0.7,
            createText: ct => Task.FromResult("hi"));

        var events = await CollectEventsAsync(response);

        var created = XAssert.IsType<ResponseCreatedEvent>(events[0]);
        capturedTemp = created.Response.Temperature;
        Assert.That(capturedTemp, Is.EqualTo(0.7));
    }

    [Test]
    public async Task Configure_IsOptional()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createText: ct => Task.FromResult("hi"));

        var events = await CollectEventsAsync(response);

        Assert.That(events, Has.Count.EqualTo(9));
    }

    [Test]
    public async Task Configure_WorksWithStreamingMode()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            configure: r => r.Temperature = 0.9,
            createTextStream: ct => ToAsyncEnumerable("hi"));

        var events = await CollectEventsAsync(response);

        var created = XAssert.IsType<ResponseCreatedEvent>(events[0]);
        Assert.That(created.Response.Temperature, Is.EqualTo(0.9));
    }

    // ── Edge Cases ───────────────────────────────────────────

    [Test]
    public async Task CompleteText_EmptyStringProducesValidStream()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createText: ct => Task.FromResult(""));

        var events = await CollectEventsAsync(response);

        Assert.That(events, Has.Count.EqualTo(9));
        var delta = XAssert.IsType<ResponseTextDeltaEvent>(events[4]);
        Assert.That(delta.Delta, Is.EqualTo(""));
    }

    [Test]
    public async Task StreamingText_EmptyStreamProducesValidStream()
    {
        var response = new TextResponse(CreateContext(), CreateRequest(),
            createTextStream: ct => ToAsyncEnumerable());

        var events = await CollectEventsAsync(response);

        // 4 preamble + 0 deltas + 1 text done + 2 closing + 1 completed = 8
        Assert.That(events, Has.Count.EqualTo(8));
        var done = XAssert.IsType<ResponseTextDoneEvent>(events[4]);
        Assert.That(done.Text, Is.EqualTo(""));
    }

    [Test]
    public async Task CompleteText_ModelIsPreservedFromRequest()
    {
        var request = new CreateResponse { Model = "my-model" };
        var response = new TextResponse(CreateContext(), request,
            createText: ct => Task.FromResult("hi"));

        var events = await CollectEventsAsync(response);

        var created = XAssert.IsType<ResponseCreatedEvent>(events[0]);
        Assert.That(created.Response.Model, Is.EqualTo("my-model"));
    }

    // ── Helpers ──────────────────────────────────────────────

    private static async Task<List<ResponseStreamEvent>> CollectEventsAsync(
        IAsyncEnumerable<ResponseStreamEvent> source)
    {
        var events = new List<ResponseStreamEvent>();
        await foreach (var e in source)
        {
            events.Add(e);
        }
        return events;
    }

    private static async IAsyncEnumerable<string> ToAsyncEnumerable(
        params string[] chunks)
    {
        foreach (var chunk in chunks)
        {
            await Task.Yield();
            yield return chunk;
        }
    }
}
