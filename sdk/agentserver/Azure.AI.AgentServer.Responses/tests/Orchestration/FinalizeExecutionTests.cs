// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using CreateResponseRequest = Azure.AI.AgentServer.Responses.CreateResponseRequest;

namespace Azure.AI.AgentServer.Responses.Tests.Orchestration;

/// <summary>
/// Tests for <see cref="ResponseOrchestrator.FinalizeExecutionAsync"/> covering the shared
/// finally-block logic: publisher completion, conditional persistence, and eager tracker eviction.
/// This logic was previously duplicated in the endpoint handler (bg branch, default branch) and SseResult.
/// </summary>
public class FinalizeExecutionTests : IDisposable
{
    private readonly TestHandler _handler;
    private readonly InMemoryResponsesProvider _provider;
    private readonly ResponseExecutionTracker _tracker;
    private readonly IEventStreamRegistry _eventStreamRegistry;
    private readonly ResponseOrchestrator _orchestrator;

    public FinalizeExecutionTests()
    {
        _handler = new TestHandler();
        _provider = new InMemoryResponsesProvider(
            Options.Create(new InMemoryProviderOptions()), TimeProvider.System);
        _tracker = new ResponseExecutionTracker(NullLogger<ResponseExecutionTracker>.Instance);
        _eventStreamRegistry = TestEventStreams.CreateInMemoryRegistry();
        _orchestrator = new ResponseOrchestrator(
            _handler, _provider, new InMemoryCancellationSignalProvider(_provider), _eventStreamRegistry, _tracker,
            NullLogger<ResponseOrchestrator>.Instance,
            Options.Create(new ResponsesServerOptions()));
    }

    [Test]
    public async Task FinalizeExecution_CompletesPublisher()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_01");
        execution.Response = new Models.ResponseObject("resp_fin_01", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        // Subscribe before finalize so we can observe OnCompleted
        var (events, observer) = await SubscribeToEvents("resp_fin_01");

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Publisher should have been completed — observer's Completed task resolves
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));
    }

    [Test]
    public async Task FinalizeExecution_BackgroundWithStore_UpdatesResponse()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_02",
            isBackground: true, store: true);
        execution.Response = new Models.ResponseObject("resp_fin_02", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        // First create the response so UpdateResponseAsync can find it
        await _provider.CreateResponseAsync(new CreateResponseRequest(execution.Response, null, null), PlatformContext.Empty);

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Should call UpdateResponseAsync (bg=true: Create already happened at response.created)
        var stored = await _provider.GetResponseAsync("resp_fin_02", PlatformContext.Empty);
        Assert.That(stored, Is.Not.Null);
        Assert.That(stored!.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public async Task FinalizeExecution_NonBgWithStore_CreatesResponse_WhenNonCancelledTerminal()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_03",
            isBackground: false, store: true);
        execution.Response = new Models.ResponseObject("resp_fin_03", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Should call CreateResponseAsync (bg=false: single persist at terminal state)
        var stored = await _provider.GetResponseAsync("resp_fin_03", PlatformContext.Empty);
        Assert.That(stored, Is.Not.Null);
    }

    [Test]
    public async Task FinalizeExecution_StreamingSteeringCompletion_ForegroundPersists()
    {
        // Non-cooperative steering supersession (FR-053): a STREAMING foreground turn was superseded,
        // its token tripped, and the framework fallback (EmitTerminalCompletionAsync) set the response
        // Completed and pushed response.completed to the client — but that terminal was NOT produced by
        // the CreateStreamingAsync while-loop, so StreamingTerminalPersisted stays false. Finalize must
        // still durably persist the completed turn so it is valid conversation context for the draining
        // steered turn (and so next-lifetime recovery does not see a non-terminal record and re-invoke).
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_stream_fg",
            isBackground: false, isStreaming: true, store: true);
        execution.SteeringRequested = true;
        execution.Response = new Models.ResponseObject("resp_fin_stream_fg", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        var stored = await _provider.GetResponseAsync("resp_fin_stream_fg", PlatformContext.Empty);
        Assert.That(stored, Is.Not.Null);
        Assert.That(stored!.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public async Task FinalizeExecution_StreamingSteeringCompletion_BackgroundUpdatesToCompleted()
    {
        // Background variant of the above: response.created already Created the in_progress record, so
        // finalize must UPDATE it to completed rather than leaving it in_progress.
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_stream_bg",
            isBackground: true, isStreaming: true, store: true);
        execution.SteeringRequested = true;
        execution.Response = new Models.ResponseObject("resp_fin_stream_bg", "test") { Status = ResponseStatus.InProgress };

        // response.created wrote the in_progress snapshot durably.
        await _provider.CreateResponseAsync(new CreateResponseRequest(execution.Response, null, null), PlatformContext.Empty);
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        var stored = await _provider.GetResponseAsync("resp_fin_stream_bg", PlatformContext.Empty);
        Assert.That(stored, Is.Not.Null);
        Assert.That(stored!.Status, Is.EqualTo(ResponseStatus.Completed),
            "the steering-completed streaming turn must be durably completed, not left in_progress");
    }

    [Test]
    public async Task FinalizeExecution_StreamingTerminalAlreadyPersisted_DoesNotDoubleCreate()
    {
        // Cooperative streaming completion: the while-loop already persisted the terminal
        // (StreamingTerminalPersisted=true), so finalize must NOT persist again (a second foreground
        // CreateResponseAsync would be a duplicate). Regression guard for the steering-completion fix.
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_stream_dbl",
            isBackground: false, isStreaming: true, store: true);
        execution.StreamingTerminalPersisted = true;
        execution.Response = new Models.ResponseObject("resp_fin_stream_dbl", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Not persisted by finalize (the while-loop owns the persist for the cooperative path).
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_fin_stream_dbl", PlatformContext.Empty));
    }

    [Test]
    public async Task FinalizeExecution_NonBgCancelled_DoesNotPersist()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_04",
            isBackground: false, store: true);
        execution.Response = new Models.ResponseObject("resp_fin_04", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCancelled();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Cancelled non-bg responses are not persisted
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_fin_04", PlatformContext.Empty));
    }

    [Test]
    public async Task FinalizeExecution_NoStore_DoesNotPersist()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_05",
            isBackground: false, store: false);
        execution.Response = new Models.ResponseObject("resp_fin_05", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // store=false -> no persistence
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_fin_05", PlatformContext.Empty));
    }

    [Test]
    public async Task FinalizeExecution_EvictsFromTracker()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_06");
        execution.Response = new Models.ResponseObject("resp_fin_06", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        Assert.That(_tracker.TryGet("resp_fin_06", out _), Is.False,
            "Completed execution should be evicted from tracker");
    }

    [Test]
    public async Task FinalizeExecution_SignalsFinalizedAfterEviction()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_08");
        execution.Response = new Models.ResponseObject("resp_fin_08", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        Assert.That(execution.FinalizedSignal.Task.IsCompletedSuccessfully, Is.True);
    }

    [Test]
    public async Task FinalizeExecution_PreCreatedNotSeen_DoesNotPersist()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_07",
            isBackground: true, store: true);
        // Models.ResponseObject stays null — response.created was never emitted

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Models.ResponseObject is null -> no persistence regardless of store/bg
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_fin_07", PlatformContext.Empty));
    }

    private async Task<(ResponseExecution Execution, IAsyncObserver<ResponseStreamEvent> Publisher)>
        CreateExecutionWithPublisher(string responseId,
            bool isBackground = false, bool store = true, bool isStreaming = false)
    {
        var execution = _tracker.Create(responseId, isBackground, isStreaming: isStreaming, store: store);
        var publisher = await TestEventStreams.CreatePublisherAsync(_eventStreamRegistry, responseId);
        return (execution, publisher);
    }

    private Task<(List<ResponseStreamEvent> Events, TestSubscription Observer)>
        SubscribeToEvents(string responseId)
    {
        var events = new List<ResponseStreamEvent>();
        var subscription = TestEventStreams.Subscribe(_eventStreamRegistry, responseId, events);
        return Task.FromResult((events, subscription));
    }

    public void Dispose()
    {
        _provider.Dispose();
        _tracker.Dispose();
    }
}
