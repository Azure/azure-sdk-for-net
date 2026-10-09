// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

[NonParallelizable]
public sealed class CancelBeforeContextProtocolTests
{
    [Test]
    public async Task CancelBeforeTaskContextAttachmentSignalsLaterContext()
    {
        var state = new CancellationRaceState();
        var handler = new TestHandler
        {
            EventFactory = (_, context, cancellationToken) =>
                ObserveCancellationAsync(context, state, cancellationToken),
        };
        using var factory = new TestWebApplicationFactory(
            handler,
            configureTestServices: services =>
            {
                services.AddSingleton(state);
                services.AddSingleton<ResponsesCancellationSignalProvider>(
                    state.CancellationProvider);
                services.AddKeyedScoped<
                    IResilientTaskHandler<ResponseTaskInput, ResponseTaskOutput>,
                    GatedResponsesTaskHandler>(
                    ResponsesResilientTaskHandler.MultiTurnTaskName);
            });
        using HttpClient client = factory.CreateClient();
        string responseId = IdGenerator.NewResponseId();
        using var createRequest = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new
                {
                    model = "test",
                    background = true,
                    conversation = new { id = "conv_cancel_before_context" },
                }),
                Encoding.UTF8,
                "application/json"),
        };
        createRequest.Headers.Add("x-agent-response-id", responseId);

        Task<HttpResponseMessage> createTask = client.SendAsync(createRequest);
        await state.TaskHandlerEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));

        Task<HttpResponseMessage> cancelTask =
            client.PostAsync($"/responses/{responseId}/cancel", content: null);
        await state.CancellationProvider.CancelCalled.Task.WaitAsync(TimeSpan.FromSeconds(10));
        state.ReleaseTaskHandler.TrySetResult();

        bool observed = await state.ContextObservedClientCancellation.Task
            .WaitAsync(TimeSpan.FromSeconds(10));
        using HttpResponseMessage cancelResponse = await cancelTask;
        using HttpResponseMessage createResponse = await createTask;

        Assert.Multiple(() =>
        {
            Assert.That(observed, Is.True);
            Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        });
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ObserveCancellationAsync(
        ResponseContext context,
        CancellationRaceState state,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        state.ContextObservedClientCancellation.TrySetResult(context.IsClientCancelled);
        var response = new ResponseObject(context.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
    }

    private sealed class CancellationRaceState
    {
        public TaskCompletionSource TaskHandlerEntered { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseTaskHandler { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<bool> ContextObservedClientCancellation { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TestCancellationProvider CancellationProvider { get; } = new();
    }

    private sealed class GatedResponsesTaskHandler
        : IResilientTaskHandler<ResponseTaskInput, ResponseTaskOutput>
    {
        private readonly CancellationRaceState _state;
        private readonly ResponseOrchestrator _orchestrator;
        private readonly ResponsesProvider _provider;
        private readonly ResponsesCancellationSignalProvider _cancellationProvider;
        private readonly ResponseExecutionTracker _tracker;
        private readonly IOptions<ResponsesServerOptions> _options;
        private readonly ILogger<ResponseOrchestrator> _logger;

        public GatedResponsesTaskHandler(
            CancellationRaceState state,
            ResponseOrchestrator orchestrator,
            ResponsesProvider provider,
            ResponsesCancellationSignalProvider cancellationProvider,
            ResponseExecutionTracker tracker,
            IOptions<ResponsesServerOptions> options,
            ILogger<ResponseOrchestrator> logger)
        {
            _state = state;
            _orchestrator = orchestrator;
            _provider = provider;
            _cancellationProvider = cancellationProvider;
            _tracker = tracker;
            _options = options;
            _logger = logger;
        }

        public async Task<ResponseTaskOutput> RunAsync(
            TaskContext<ResponseTaskInput> context,
            CancellationToken cancellationToken = default)
        {
            _state.TaskHandlerEntered.TrySetResult();
            await _state.ReleaseTaskHandler.Task.ConfigureAwait(false);
            var inner = new ResponsesResilientTaskHandler(
                _orchestrator,
                _provider,
                _cancellationProvider,
                _tracker,
                _options,
                _logger);
            return await inner.RunAsync(context, cancellationToken).ConfigureAwait(false);
        }
    }

    private sealed class TestCancellationProvider : ResponsesCancellationSignalProvider
    {
        private readonly ConcurrentDictionary<string, CancellationTokenSource> _signals = new();

        public TaskCompletionSource CancelCalled { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public override Task CancelResponseAsync(
            string responseId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            CancelCalled.TrySetResult();
            _signals.GetOrAdd(responseId, _ => new CancellationTokenSource()).Cancel();
            return Task.CompletedTask;
        }

        public override Task<CancellationToken> GetResponseCancellationTokenAsync(
            string responseId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(
                _signals.GetOrAdd(responseId, _ => new CancellationTokenSource()).Token);
        }
    }
}
