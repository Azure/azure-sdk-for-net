// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Orchestration;

/// <summary>
/// Tests for <see cref="ResponseOrchestrator.FinalizeExecutionAsync"/> covering the shared
/// finally-block logic: publisher completion, conditional persistence, and MarkCompleted.
/// This logic was previously duplicated in the endpoint handler (bg branch, default branch) and SseResult.
/// </summary>
public class FinalizeExecutionTests : IDisposable
{
    private readonly TestHandler _handler;
    private readonly InMemoryResponsesProvider _provider;
    private readonly ResponseExecutionTracker _tracker;
    private readonly ResponseOrchestrator _orchestrator;

    public FinalizeExecutionTests()
    {
        _handler = new TestHandler();
        _provider = new InMemoryResponsesProvider(
            Options.Create(new InMemoryProviderOptions()), TimeProvider.System);
        _tracker = new ResponseExecutionTracker(NullLogger<ResponseExecutionTracker>.Instance);
        _orchestrator = new ResponseOrchestrator(
            _handler, _provider, _provider, _provider, _tracker,
            NullLogger<ResponseOrchestrator>.Instance);
    }

    [Test]
    public async Task FinalizeExecution_CompletesPublisher()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_01");
        execution.Response = new Models.Response("resp_fin_01", "test") { Status = ResponseStatus.InProgress };
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
        execution.Response = new Models.Response("resp_fin_02", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        // First create the response so UpdateResponseAsync can find it
        await _provider.CreateResponseAsync(execution.Response, null, null);

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Should call UpdateResponseAsync (bg=true: Create already happened at response.created)
        var stored = await _provider.GetResponseAsync("resp_fin_02");
        Assert.IsNotNull(stored);
        Assert.AreEqual(ResponseStatus.Completed, stored!.Status);
    }

    [Test]
    public async Task FinalizeExecution_NonBgWithStore_CreatesResponse_WhenNonCancelledTerminal()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_03",
            isBackground: false, store: true);
        execution.Response = new Models.Response("resp_fin_03", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Should call CreateResponseAsync (bg=false: single persist at terminal state)
        var stored = await _provider.GetResponseAsync("resp_fin_03");
        Assert.IsNotNull(stored);
    }

    [Test]
    public async Task FinalizeExecution_NonBgCancelled_DoesNotPersist()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_04",
            isBackground: false, store: true);
        execution.Response = new Models.Response("resp_fin_04", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCancelled();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Cancelled non-bg responses are not persisted
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_fin_04"));
    }

    [Test]
    public async Task FinalizeExecution_NoStore_DoesNotPersist()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_05",
            isBackground: false, store: false);
        execution.Response = new Models.Response("resp_fin_05", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // store=false -> no persistence
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_fin_05"));
    }

    [Test]
    public async Task FinalizeExecution_MarkCompleted_SetsCompletedAt()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_06");
        execution.Response = new Models.Response("resp_fin_06", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        Assert.IsNotNull(execution.CompletedAt);
    }

    [Test]
    public async Task FinalizeExecution_PreCreatedNotSeen_DoesNotPersist()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_07",
            isBackground: true, store: true);
        // Models.Response stays null — response.created was never emitted

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Models.Response is null -> no persistence regardless of store/bg
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_fin_07"));
    }

    private async Task<(ResponseExecution execution, IAsyncObserver<ResponseStreamEvent> publisher)>
        CreateExecutionWithPublisher(string responseId,
            bool isBackground = false, bool store = true)
    {
        var execution = _tracker.Create(responseId, isBackground, store: store);
        var publisher = await _provider.CreateEventPublisherAsync(responseId);
        return (execution, publisher);
    }

    private async Task<(List<ResponseStreamEvent> events, CollectingObserver observer)>
        SubscribeToEvents(string responseId)
    {
        var events = new List<ResponseStreamEvent>();
        var observer = new CollectingObserver(events);
        await _provider.SubscribeToEventsAsync(responseId, observer);
        return (events, observer);
    }

    public void Dispose()
    {
        _provider.Dispose();
        _tracker.Dispose();
    }
}
