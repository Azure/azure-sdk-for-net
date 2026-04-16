// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Orchestration;

/// <summary>
/// Tests for <see cref="ResponseOrchestrator.CancelAsync"/> covering guard logic:
/// [T040] execution not found, non-bg, terminal statuses, already cancelled (idempotent), success.
/// </summary>
public class CancelAsyncTests : IDisposable
{
    private readonly TestHandler _handler;
    private readonly InMemoryResponsesProvider _provider;
    private readonly ResponseExecutionTracker _tracker;
    private readonly ResponseOrchestrator _orchestrator;

    public CancelAsyncTests()
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
    public async Task NotFound_ThrowsResourceNotFoundException()
    {
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _orchestrator.CancelAsync("resp_unknown", IsolationContext.Empty));
    }

    [Test]
    public async Task NonBackground_InFlight_ThrowsResourceNotFoundException()
    {
        // B16: non-background in-flight responses are not findable — cancel returns 404
        _tracker.Create("resp_cancel_nb", isBackground: false, isStreaming: false, store: true);

        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _orchestrator.CancelAsync("resp_cancel_nb", IsolationContext.Empty));
    }

    [Test]
    public async Task NonBackground_Completed_FallsToProvider_ThrowsBadRequest()
    {
        // After eviction, non-bg completed responses hit the provider path.
        // Spec: "Cannot cancel a synchronous response." (B1 — background check first)
        var response = new Models.ResponseObject("resp_cancel_nbc", "test") { Status = ResponseStatus.Completed };
        await _provider.CreateResponseAsync(
            new Responses.CreateResponseRequest(response, null, null), IsolationContext.Empty);

        var ex = Assert.ThrowsAsync<BadRequestException>(
            () => _orchestrator.CancelAsync("resp_cancel_nbc", IsolationContext.Empty));
        Assert.That(ex!.Message, Is.EqualTo("Cannot cancel a synchronous response."));
    }

    [Test]
    public async Task Completed_ThrowsBadRequestException()
    {
        // Spec: "Cannot cancel a completed response." (B12)
        var execution = _tracker.Create("resp_cancel_c", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.ResponseObject("resp_cancel_c", "test") { Status = ResponseStatus.Completed };

        var ex = Assert.ThrowsAsync<BadRequestException>(
            () => _orchestrator.CancelAsync("resp_cancel_c", IsolationContext.Empty));
        Assert.That(ex!.Message, Is.EqualTo("Cannot cancel a completed response."));
    }

    [Test]
    public async Task Failed_ThrowsBadRequestException()
    {
        // Spec: "Cannot cancel a failed response." (B12)
        var execution = _tracker.Create("resp_cancel_f", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.ResponseObject("resp_cancel_f", "test") { Status = ResponseStatus.Failed };

        var ex = Assert.ThrowsAsync<BadRequestException>(
            () => _orchestrator.CancelAsync("resp_cancel_f", IsolationContext.Empty));
        Assert.That(ex!.Message, Is.EqualTo("Cannot cancel a failed response."));
    }

    [Test]
    public async Task Incomplete_ThrowsBadRequestException()
    {
        // Spec: "Cannot cancel a response in terminal state." (B12)
        var execution = _tracker.Create("resp_cancel_i", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.ResponseObject("resp_cancel_i", "test") { Status = ResponseStatus.Incomplete };

        var ex = Assert.ThrowsAsync<BadRequestException>(
            () => _orchestrator.CancelAsync("resp_cancel_i", IsolationContext.Empty));
        Assert.That(ex!.Message, Is.EqualTo("Cannot cancel a response in terminal state."));
    }

    [Test]
    public async Task AlreadyCancelled_ReturnsIdempotent()
    {
        var execution = _tracker.Create("resp_cancel_ac", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.ResponseObject("resp_cancel_ac", "test") { Status = ResponseStatus.Cancelled };

        var result = await _orchestrator.CancelAsync("resp_cancel_ac", IsolationContext.Empty);

        Assert.That(result.Id, Is.EqualTo("resp_cancel_ac"));
        Assert.That(result.Status, Is.EqualTo(ResponseStatus.Cancelled));
    }

    [Test]
    public async Task InProgress_SetsCancelRequested()
    {
        var execution = _tracker.Create("resp_cancel_ip", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.ResponseObject("resp_cancel_ip", "test") { Status = ResponseStatus.InProgress };

        var result = await _orchestrator.CancelAsync("resp_cancel_ip", IsolationContext.Empty);

        Assert.That(execution.CancelRequested, Is.True);
    }

    public void Dispose()
    {
        _tracker.Dispose();
        _provider.Dispose();
    }
}
