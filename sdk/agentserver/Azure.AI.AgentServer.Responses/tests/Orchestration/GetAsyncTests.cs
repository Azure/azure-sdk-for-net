// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

using CreateResponseRequest = Azure.AI.AgentServer.Responses.CreateResponseRequest;

namespace Azure.AI.AgentServer.Responses.Tests.Orchestration;

/// <summary>
/// Tests for <see cref="ResponseOrchestrator.GetAsync"/> covering guard logic:
/// in-flight guards (store=false, non-bg) and provider fallback for completed responses.
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
    public async Task StoreFalse_InFlight_ThrowsResourceNotFoundException()
    {
        var execution = _tracker.Create("resp_get_store", isBackground: true, isStreaming: false, store: false);
        execution.Response = new Models.ResponseObject("resp_get_store", "test") { Status = ResponseStatus.InProgress };

        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _orchestrator.GetAsync("resp_get_store", IsolationContext.Empty));
    }

    [Test]
    public async Task NonBg_InFlight_ThrowsResourceNotFoundException()
    {
        _tracker.Create("resp_get_nrc", isBackground: false, isStreaming: false, store: true);

        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _orchestrator.GetAsync("resp_get_nrc", IsolationContext.Empty));
    }

    [Test]
    public async Task NonBg_Completed_FallsThroughToProvider()
    {
        // After FinalizeExecutionAsync evicts from tracker, GET falls to provider.
        var response = new Models.ResponseObject("resp_get_ok", "test") { Status = ResponseStatus.Completed };
        await _provider.CreateResponseAsync(
            new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        var result = await _orchestrator.GetAsync("resp_get_ok", IsolationContext.Empty);

        Assert.That(result.Id, Is.EqualTo("resp_get_ok"));
        Assert.That(result.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public async Task Background_InFlight_ReturnsSnapshot()
    {
        var execution = _tracker.Create("resp_get_bg", isBackground: true, isStreaming: false, store: true);
        execution.Response = new Models.ResponseObject("resp_get_bg", "test") { Status = ResponseStatus.InProgress };

        var result = await _orchestrator.GetAsync("resp_get_bg", IsolationContext.Empty);

        Assert.That(result.Id, Is.EqualTo("resp_get_bg"));
    }

    [Test]
    public async Task Background_Completed_FallsThroughToProvider()
    {
        // After eviction, bg responses are served from provider too.
        var response = new Models.ResponseObject("resp_get_bg_done", "test") { Status = ResponseStatus.Completed };
        await _provider.CreateResponseAsync(
            new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        var result = await _orchestrator.GetAsync("resp_get_bg_done", IsolationContext.Empty);

        Assert.That(result.Id, Is.EqualTo("resp_get_bg_done"));
        Assert.That(result.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    public void Dispose()
    {
        _tracker.Dispose();
        _provider.Dispose();
    }
}
