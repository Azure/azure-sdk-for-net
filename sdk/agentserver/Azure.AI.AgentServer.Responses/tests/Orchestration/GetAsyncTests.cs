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
/// Tests for <see cref="ResponseOrchestrator.GetAsync"/> covering guard logic:
/// [T039] execution not found, store=false, non-bg not completed, non-bg cancelled, success.
/// </summary>
public class GetAsyncTests : IDisposable
{
    private readonly TestHandler _handler;
    private readonly InMemoryResponsesProvider _provider;
    private readonly ResponseExecutionTracker _tracker;
    private readonly ResponseOrchestrator _orchestrator;

    public GetAsyncTests()
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
            () => _orchestrator.GetAsync("resp_unknown", IsolationContext.Empty));
    }

    [Test]
    public async Task StoreFalse_ThrowsResourceNotFoundException()
    {
        var execution = _tracker.Create("resp_get_store", isBackground: false, isStreaming: false, store: false);
        execution.Response = new Models.ResponseObject("resp_get_store", "test") { Status = ResponseStatus.Completed };
        _tracker.MarkCompleted("resp_get_store");

        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _orchestrator.GetAsync("resp_get_store", IsolationContext.Empty));
    }

    [Test]
    public async Task NonBg_ResponseNull_ThrowsResourceNotFoundException()
    {
        _tracker.Create("resp_get_nrc", isBackground: false, isStreaming: false, store: true);
        // Models.ResponseObject stays null — response.created was never emitted

        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _orchestrator.GetAsync("resp_get_nrc", IsolationContext.Empty));
    }

    [Test]
    public async Task NonBg_NotCompleted_ThrowsResourceNotFoundException()
    {
        var execution = _tracker.Create("resp_get_nc", isBackground: false, isStreaming: false, store: true);
        execution.Response = new Models.ResponseObject("resp_get_nc", "test") { Status = ResponseStatus.InProgress };
        // CompletedAt is null — not completed yet

        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _orchestrator.GetAsync("resp_get_nc", IsolationContext.Empty));
    }

    [Test]
    public async Task NonBg_Cancelled_ThrowsResourceNotFoundException()
    {
        var execution = _tracker.Create("resp_get_can", isBackground: false, isStreaming: false, store: true);
        execution.Response = new Models.ResponseObject("resp_get_can", "test") { Status = ResponseStatus.Cancelled };
        _tracker.MarkCompleted("resp_get_can");

        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _orchestrator.GetAsync("resp_get_can", IsolationContext.Empty));
    }

    [Test]
    public async Task Success_ReturnsResponseSnapshot()
    {
        var execution = _tracker.Create("resp_get_ok", isBackground: false, isStreaming: false, store: true);
        execution.Response = new Models.ResponseObject("resp_get_ok", "test") { Status = ResponseStatus.Completed };
        _tracker.MarkCompleted("resp_get_ok");

        var result = await _orchestrator.GetAsync("resp_get_ok", IsolationContext.Empty);

        Assert.That(result.Id, Is.EqualTo("resp_get_ok"));
        Assert.That(result.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public async Task Background_ReturnsResponseEvenWhenNotCompleted()
    {
        var execution = _tracker.Create("resp_get_bg", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.ResponseObject("resp_get_bg", "test") { Status = ResponseStatus.InProgress };
        // Not completed — bg responses are accessible before completion

        var result = await _orchestrator.GetAsync("resp_get_bg", IsolationContext.Empty);

        Assert.That(result.Id, Is.EqualTo("resp_get_bg"));
    }

    public void Dispose()
    {
        _tracker.Dispose();
        _provider.Dispose();
    }
}
