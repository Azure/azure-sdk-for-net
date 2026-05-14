// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Orchestration;

/// <summary>
/// Tests for <see cref="ResponseOrchestrator.ProcessEventsAsync"/> covering:
/// - First event validation (B8: must be ResponseCreatedEvent)
/// - Auto-stamping of output items
/// - Full replacement on response.* events (via ReplaceResponse)
/// - Output list update on output_item.* events (via SetOutputItemAtIndex)
/// - Snapshot embedded in lifecycle events
/// - Publisher push for all events
/// - Background early-persist on response.created
/// </summary>
public class ProcessEventsTests : IDisposable
{
    private readonly TestHandler _handler;
    private readonly InMemoryResponsesProvider _provider;
    private readonly ResponseExecutionTracker _tracker;
    private readonly ResponseOrchestrator _orchestrator;

    public ProcessEventsTests()
    {
        _handler = new TestHandler();
        _provider = new InMemoryResponsesProvider(
            Options.Create(new InMemoryProviderOptions()), TimeProvider.System);
        _tracker = new ResponseExecutionTracker(NullLogger<ResponseExecutionTracker>.Instance);
        _orchestrator = new ResponseOrchestrator(
            _handler, _provider, new InMemoryCancellationSignalProvider(_provider), new InMemoryStreamProvider(_provider), _tracker,
            NullLogger<ResponseOrchestrator>.Instance);
    }

    [Test]
    public async Task FirstEvent_NotResponseCreated_ThrowsResponsesApiException()
    {
        // B8: first event must be ResponseCreatedEvent
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseInProgressEvent(0, new Models.ResponseObject(ctx.ResponseId, "test")));

        var (execution, publisher) = await CreateExecutionWithPublisher("resp_proc_01");
        var context = new ResponseContext("resp_proc_01");
        var request = new CreateResponse();

        var ex = Assert.ThrowsAsync<ResponsesApiException>(() =>
            ConsumeProcessedEvents(request, execution, context, publisher));

        Assert.That(ex.StatusCode, Is.EqualTo(500));
        Assert.That(ex.Message, Is.EqualTo("An internal server error occurred."));
    }

    [Test]
    public async Task EmptyEnumerable_ThrowsResponsesApiException()
    {
        // B32/S-015: empty enumerable — bad handler
        _handler.EventFactory = (req, ctx, ct) => EmptyStream();

        var (execution, publisher) = await CreateExecutionWithPublisher("resp_proc_02");
        var context = new ResponseContext("resp_proc_02");
        var request = new CreateResponse();

        var ex = Assert.ThrowsAsync<ResponsesApiException>(() =>
            ConsumeProcessedEvents(request, execution, context, publisher));

        Assert.That(ex.StatusCode, Is.EqualTo(500));
        Assert.That(ex.Message, Is.EqualTo("An internal server error occurred."));
    }

    [Test]
    public async Task FirstEvent_ResponseCreated_SetsResponse()
    {
        var response = new Models.ResponseObject("resp_proc_03", "test") { Status = ResponseStatus.InProgress };
        var completedResponse = new Models.ResponseObject("resp_proc_03", "test") { Status = ResponseStatus.Completed };
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseCompletedEvent(1, completedResponse));

        var (execution, publisher) = await CreateExecutionWithPublisher("resp_proc_03");
        var context = new ResponseContext("resp_proc_03");

        await ConsumeProcessedEvents(new CreateResponse(), execution, context, publisher);

        Assert.That(execution.Response, Is.Not.Null);
    }

    [Test]
    public async Task ResponseEvents_FullReplacement_ExecutionResponseIsEventResponse()
    {
        // After ResponseCreatedEvent, execution.Response should be the event's Models.ResponseObject (full replacement)
        var handlerResponse = new Models.ResponseObject("resp_proc_04", "custom-model")
        {
            Status = ResponseStatus.InProgress,
        };
        var completedResponse = new Models.ResponseObject("resp_proc_04", "custom-model")
        {
            Status = ResponseStatus.Completed,
        };
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, handlerResponse),
            new ResponseCompletedEvent(1, completedResponse));

        var (execution, publisher) = await CreateExecutionWithPublisher("resp_proc_04");
        var context = new ResponseContext("resp_proc_04");

        await ConsumeProcessedEvents(new CreateResponse(), execution, context, publisher);

        // Full replacement: execution.Response should have the handler's custom model
        Assert.That(execution.Response.Model, Is.EqualTo("custom-model"));
    }

    [Test]
    public async Task OutputItemEvents_UpdateOutputList()
    {
        var response = new Models.ResponseObject("resp_proc_05", "test") { Status = ResponseStatus.InProgress };
        var outputItem = CreateOutputMessage("item_01", "hello");
        var completedResponse = new Models.ResponseObject("resp_proc_05", "test") { Status = ResponseStatus.Completed };
        completedResponse.Output.Add(outputItem);

        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseOutputItemAddedEvent(1, 0, outputItem),
            new ResponseCompletedEvent(2, completedResponse));

        var (execution, publisher) = await CreateExecutionWithPublisher("resp_proc_05");
        var context = new ResponseContext("resp_proc_05");

        await ConsumeProcessedEvents(new CreateResponse(), execution, context, publisher);

        XAssert.Single(execution.Response.Output);
        var msg = XAssert.IsType<OutputItemMessage>(execution.Response.Output[0]);
        Assert.That(msg.Id, Is.EqualTo("item_01"));
    }

    [Test]
    public async Task SnapshotEmbedded_EventResponseIsNotSameReference()
    {
        var response = new Models.ResponseObject("resp_proc_06", "test") { Status = ResponseStatus.InProgress };
        var completedResponse = new Models.ResponseObject("resp_proc_06", "test") { Status = ResponseStatus.Completed };

        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseCompletedEvent(1, completedResponse));

        var (execution, publisher) = await CreateExecutionWithPublisher("resp_proc_06");
        var context = new ResponseContext("resp_proc_06");

        // Subscribe to publisher to capture emitted events
        var (events, observer) = await SubscribeToEvents("resp_proc_06");

        await ConsumeProcessedEvents(new CreateResponse(), execution, context, publisher);
        await publisher.OnCompletedAsync();
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));

        // The ResponseCreatedEvent sent to publisher should have a snapshot, not the mutable reference
        var createdEvt = events.OfType<ResponseCreatedEvent>().First();
        Assert.That(createdEvt.Response, Is.Not.SameAs(execution.Response));
    }

    [Test]
    public async Task AllEvents_PublishedToPublisher()
    {
        var response = new Models.ResponseObject("resp_proc_07", "test") { Status = ResponseStatus.InProgress };
        var completedResponse = new Models.ResponseObject("resp_proc_07", "test") { Status = ResponseStatus.Completed };
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseInProgressEvent(1, response),
            new ResponseCompletedEvent(2, completedResponse));

        var (execution, publisher) = await CreateExecutionWithPublisher("resp_proc_07");
        var context = new ResponseContext("resp_proc_07");
        var (events, observer) = await SubscribeToEvents("resp_proc_07");

        await ConsumeProcessedEvents(new CreateResponse(), execution, context, publisher);
        await publisher.OnCompletedAsync();
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.That(events.Count, Is.EqualTo(3));
        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseCompletedEvent>(events[2]);
    }

    [Test]
    public async Task BackgroundWithStore_PersistsOnFirstEvent()
    {
        var response = new Models.ResponseObject("resp_proc_08", "test") { Status = ResponseStatus.InProgress };
        var completedResponse = new Models.ResponseObject("resp_proc_08", "test") { Status = ResponseStatus.Completed };
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseCompletedEvent(1, completedResponse));

        var (execution, publisher) = await CreateExecutionWithPublisher("resp_proc_08",
            isBackground: true, store: true);
        var context = new ResponseContext("resp_proc_08");

        await ConsumeProcessedEvents(new CreateResponse(), execution, context, publisher);

        // Background + store: should have persisted at response.created time
        var stored = await _provider.GetResponseAsync("resp_proc_08", IsolationContext.Empty);
        Assert.That(stored, Is.Not.Null);
    }

    [Test]
    public async Task AutoStamp_OutputItemResponseIdSet()
    {
        var response = new Models.ResponseObject("resp_proc_09", "test") { Status = ResponseStatus.InProgress };
        var outputItem = CreateOutputMessage("item_auto", "hello");
        var completedResponse = new Models.ResponseObject("resp_proc_09", "test") { Status = ResponseStatus.Completed };
        completedResponse.Output.Add(outputItem);

        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseOutputItemAddedEvent(1, 0, outputItem),
            new ResponseCompletedEvent(2, completedResponse));

        var (execution, publisher) = await CreateExecutionWithPublisher("resp_proc_09");
        var context = new ResponseContext("resp_proc_09");

        await ConsumeProcessedEvents(new CreateResponse(), execution, context, publisher);

        // Auto-stamp should have set ResponseId on the output item
        Assert.That(execution.Response.Output[0].ResponseId, Is.EqualTo("resp_proc_09"));
    }

    // --- Helpers ---

    private async Task ConsumeProcessedEvents(
        CreateResponse request,
        ResponseExecution execution,
        ResponseContext context,
        IAsyncObserver<ResponseStreamEvent> publisher)
    {
        await foreach (var _ in _orchestrator.ProcessEventsAsync(
            request, execution, context, publisher, CancellationToken.None))
        {
            // Consume all events
        }
    }

    private async Task<(ResponseExecution Execution, IAsyncObserver<ResponseStreamEvent> Publisher)>
        CreateExecutionWithPublisher(string responseId,
            bool isBackground = false, bool store = true)
    {
        var execution = _tracker.Create(responseId, isBackground, store: store);
        var publisher = await _provider.CreateEventPublisherAsync(responseId);
        return (execution, publisher);
    }

    private async Task<(List<ResponseStreamEvent> Events, CollectingObserver Observer)>
        SubscribeToEvents(string responseId)
    {
        var events = new List<ResponseStreamEvent>();
        var observer = new CollectingObserver(events);
        await _provider.SubscribeToEventsAsync(responseId, observer);
        return (events, observer);
    }

    private static OutputItemMessage CreateOutputMessage(string id, string text)
    {
        var content = new MessageContentOutputTextContent(
            text: text,
            annotations: Array.Empty<Annotation>(),
            logprobs: Array.Empty<LogProb>());
        return new OutputItemMessage(
            id: id,
            content: new List<MessageContent> { content },
            status: MessageStatus.Completed);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> YieldEvents(
        params ResponseStreamEvent[] events)
    {
        foreach (var evt in events)
        {
            yield return evt;
        }

        await Task.CompletedTask;
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmptyStream()
    {
        await Task.CompletedTask;
        yield break;
    }

    public void Dispose()
    {
        _provider.Dispose();
        _tracker.Dispose();
    }
}
