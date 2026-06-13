// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// ResponsesApiException is in the root namespace Azure.AI.AgentServer.Responses
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Orchestration;

/// <summary>
/// Tests for <see cref="ResponseOrchestrator.HandleExecutionExceptionAsync"/> covering
/// the consolidated 6-case error recovery matrix. This matrix was previously duplicated
/// 3x across the endpoint handler (bg branch, default branch) and SseResult.
/// </summary>
public class ErrorRecoveryTests : IDisposable
{
    private readonly TestHandler _handler;
    private readonly InMemoryResponsesProvider _provider;
    private readonly ResponseExecutionTracker _tracker;
    private readonly ResponseOrchestrator _orchestrator;

    public ErrorRecoveryTests()
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
    public async Task PreCreated_Exception_DoesNotMutateResponseAndDoesNotPublish()
    {
        // Case 1: Exception thrown before response.created was seen.
        // The response was never created in the API sense — no status mutation,
        // no event publishing. The caller (ThrowIfPreCreatedFailure / FinalizeExecutionAsync)
        // handles signaling the error to the client.
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_err_01");

        await _orchestrator.HandleExecutionExceptionAsync(
            execution, publisher, new InvalidOperationException("test"));

        // Models.ResponseObject remains null — it was never created.
        Assert.That(execution.Response, Is.Null);
    }

    [Test]
    public async Task CancelRequested_OperationCancelled_SetsCancelledAndPublishes()
    {
        // Case 2: OperationCanceledException when CancelRequested is true
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_err_02");
        execution.Response = new Models.ResponseObject("resp_err_02", "test") { Status = ResponseStatus.InProgress };
        execution.CancelRequested = true;
        var (events, observer) = await SubscribeToEvents("resp_err_02");

        await _orchestrator.HandleExecutionExceptionAsync(
            execution, publisher, new OperationCanceledException());
        await publisher.OnCompletedAsync();
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.That(execution.Response!.Status, Is.EqualTo(ResponseStatus.Cancelled));
        XAssert.Single(events);
        XAssert.IsType<ResponseFailedEvent>(events[0]);
    }

    [Test]
    public async Task ShutdownRequested_SetsFailedAndPublishes()
    {
        // Case 3: OperationCanceledException when ShutdownRequested is true
        // SDK never auto-emits incomplete — shutdown OCE is treated as failure
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_err_03");
        execution.Response = new Models.ResponseObject("resp_err_03", "test") { Status = ResponseStatus.InProgress };
        execution.ShutdownRequested = true;
        var (events, observer) = await SubscribeToEvents("resp_err_03");

        await _orchestrator.HandleExecutionExceptionAsync(
            execution, publisher, new OperationCanceledException());
        await publisher.OnCompletedAsync();
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.That(execution.Response!.Status, Is.EqualTo(ResponseStatus.Failed));
        XAssert.Single(events);
        XAssert.IsType<ResponseFailedEvent>(events[0]);
    }

    [Test]
    public async Task UnknownCancellation_SetsFailedAndPublishes()
    {
        // Case 4: OperationCanceledException with neither CancelRequested nor ShutdownRequested
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_err_04");
        execution.Response = new Models.ResponseObject("resp_err_04", "test") { Status = ResponseStatus.InProgress };
        var (events, observer) = await SubscribeToEvents("resp_err_04");

        await _orchestrator.HandleExecutionExceptionAsync(
            execution, publisher, new OperationCanceledException());
        await publisher.OnCompletedAsync();
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.That(execution.Response!.Status, Is.EqualTo(ResponseStatus.Failed));
        XAssert.Single(events);
        XAssert.IsType<ResponseFailedEvent>(events[0]);
    }

    [Test]
    public async Task GeneralException_SetsFailedAndPublishes()
    {
        // Case 5: General exception after response.created
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_err_05");
        execution.Response = new Models.ResponseObject("resp_err_05", "test") { Status = ResponseStatus.InProgress };
        var (events, observer) = await SubscribeToEvents("resp_err_05");

        await _orchestrator.HandleExecutionExceptionAsync(
            execution, publisher, new InvalidOperationException("oops"));
        await publisher.OnCompletedAsync();
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.That(execution.Response!.Status, Is.EqualTo(ResponseStatus.Failed));
        XAssert.Single(events);
        XAssert.IsType<ResponseFailedEvent>(events[0]);
    }

    [Test]
    public async Task AlreadyTerminal_DoesNotOverrideStatus()
    {
        // If the handler already emitted a terminal event, don't override
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_err_06");
        execution.Response = new Models.ResponseObject("resp_err_06", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();
        var (events, observer) = await SubscribeToEvents("resp_err_06");

        await _orchestrator.HandleExecutionExceptionAsync(
            execution, publisher, new InvalidOperationException("oops"));

        // Status should remain Completed, not changed to Failed
        Assert.That(execution.Response!.Status, Is.EqualTo(ResponseStatus.Completed));
        // No events should have been published
        Assert.That(events, Is.Empty);
    }

    [Test]
    public async Task ResponsesApiException_PostCreated_SetsFailedAndPublishes()
    {
        // Case 6: ResponsesApiException after response.created
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_err_07");
        execution.Response = new Models.ResponseObject("resp_err_07", "test") { Status = ResponseStatus.InProgress };
        var (events, observer) = await SubscribeToEvents("resp_err_07");

        var apiEx = new ResponsesApiException(
            new Error("server_error", "test error"), 500);

        await _orchestrator.HandleExecutionExceptionAsync(
            execution, publisher, apiEx);
        await publisher.OnCompletedAsync();
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.That(execution.Response!.Status, Is.EqualTo(ResponseStatus.Failed));
        XAssert.Single(events);
    }

    private async Task<(ResponseExecution Execution, IAsyncObserver<ResponseStreamEvent> Publisher)>
        CreateExecutionWithPublisher(string responseId)
    {
        var execution = _tracker.Create(responseId);
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

    public void Dispose()
    {
        _provider.Dispose();
        _tracker.Dispose();
    }
}
