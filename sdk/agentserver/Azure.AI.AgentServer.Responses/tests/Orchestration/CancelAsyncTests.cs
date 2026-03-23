// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            _handler, _provider, _provider, _provider, _tracker,
            NullLogger<ResponseOrchestrator>.Instance);
    }

    [Test]
    public async Task NotFound_ThrowsResourceNotFoundException()
    {
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _orchestrator.CancelAsync("resp_unknown"));
    }

    [Test]
    public async Task NonBackground_ThrowsBadRequestException()
    {
        _tracker.Create("resp_cancel_nb", isBackground: false, isStreaming: false, store: true);

        Assert.ThrowsAsync<BadRequestException>(
            () => _orchestrator.CancelAsync("resp_cancel_nb"));
    }

    [Test]
    public async Task Completed_ThrowsBadRequestException()
    {
        var execution = _tracker.Create("resp_cancel_c", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.Response("resp_cancel_c", "test") { Status = ResponseStatus.Completed };

        Assert.ThrowsAsync<BadRequestException>(
            () => _orchestrator.CancelAsync("resp_cancel_c"));
    }

    [Test]
    public async Task Failed_ThrowsBadRequestException()
    {
        var execution = _tracker.Create("resp_cancel_f", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.Response("resp_cancel_f", "test") { Status = ResponseStatus.Failed };

        Assert.ThrowsAsync<BadRequestException>(
            () => _orchestrator.CancelAsync("resp_cancel_f"));
    }

    [Test]
    public async Task Incomplete_ThrowsBadRequestException()
    {
        var execution = _tracker.Create("resp_cancel_i", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.Response("resp_cancel_i", "test") { Status = ResponseStatus.Incomplete };

        Assert.ThrowsAsync<BadRequestException>(
            () => _orchestrator.CancelAsync("resp_cancel_i"));
    }

    [Test]
    public async Task AlreadyCancelled_ReturnsIdempotent()
    {
        var execution = _tracker.Create("resp_cancel_ac", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.Response("resp_cancel_ac", "test") { Status = ResponseStatus.Cancelled };

        var result = await _orchestrator.CancelAsync("resp_cancel_ac");

        Assert.AreEqual("resp_cancel_ac", result.Id);
        Assert.AreEqual(ResponseStatus.Cancelled, result.Status);
    }

    [Test]
    public async Task InProgress_SetsCancelRequested()
    {
        var execution = _tracker.Create("resp_cancel_ip", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.Response("resp_cancel_ip", "test") { Status = ResponseStatus.InProgress };

        var result = await _orchestrator.CancelAsync("resp_cancel_ip");

        Assert.IsTrue(execution.CancelRequested);
    }

    public void Dispose()
    {
        _tracker.Dispose();
        _provider.Dispose();
    }
}
