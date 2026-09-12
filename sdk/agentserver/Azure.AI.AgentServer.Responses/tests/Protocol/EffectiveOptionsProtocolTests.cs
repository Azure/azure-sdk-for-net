// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

[TestFixture]
[NonParallelizable]
public sealed class EffectiveOptionsProtocolTests
{
    [Test]
    public async Task SeparateOptionsConfigurationControlsSteeringAndStreamBacking()
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "responses-effective-options-" + Guid.NewGuid().ToString("N"));
        string? previousRoot = Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT");
        var firstEntered = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseFirst = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var steeredEntered = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var handler = new TestHandler
        {
            EventFactory = (request, context, cancellationToken) =>
                RunSteeringTurnAsync(
                    request,
                    context,
                    firstEntered,
                    releaseFirst,
                    steeredEntered,
                    cancellationToken),
        };

        try
        {
            Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", root);
            string tasksDirectory = Path.Combine(root, "tasks");
            string responsesDirectory = Path.Combine(root, "responses");
            Directory.CreateDirectory(tasksDirectory);
            Directory.CreateDirectory(responsesDirectory);

            using var factory = new TestWebApplicationFactory(
                handler,
                configureTestServices: services =>
                {
                    services.AddSingleton<ITaskStore>(
                        _ => new LocalTaskStore(tasksDirectory));
                    services.AddSingleton(
                        _ => new FileResponsesProvider(responsesDirectory));
                },
                configureAfterResponsesServices: services =>
                    services.Configure<ResponsesServerOptions>(options =>
                    {
                        options.ResilientBackground = true;
                        options.SteerableConversations = true;
                    }));
            using HttpClient client = factory.CreateClient();

            AgentEventStreamRegistry streams =
                factory.Services.GetRequiredService<AgentEventStreamRegistry>();
            AgentEventStream probe =
                await streams.GetOrCreateAsync("effective-options-probe");
            Assert.That(
                probe.GetType().Name,
                Is.EqualTo("FileBackedReplayEventStream"));
            await streams.DeleteAsync("effective-options-probe");

            using HttpResponseMessage first = await client.PostAsync(
                "/responses",
                Json(new
                {
                    model = "agent",
                    input = "first",
                    store = true,
                    background = true,
                    conversation = "effective-options-conversation",
                }));
            Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            await firstEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));

            using HttpResponseMessage second = await client.PostAsync(
                "/responses",
                Json(new
                {
                    model = "agent",
                    input = "second",
                    store = true,
                    background = true,
                    conversation = "effective-options-conversation",
                }));
            Assert.That(second.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using JsonDocument secondBody =
                JsonDocument.Parse(await second.Content.ReadAsStringAsync());
            Assert.That(
                secondBody.RootElement.GetProperty("status").GetString(),
                Is.EqualTo("queued"));

            await steeredEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
        }
        finally
        {
            releaseFirst.TrySetResult();
            Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", previousRoot);
            if (Directory.Exists(root))
            {
                Directory.Delete(root, recursive: true);
            }
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> RunSteeringTurnAsync(
        CreateResponse request,
        ResponseContext context,
        TaskCompletionSource firstEntered,
        TaskCompletionSource releaseFirst,
        TaskCompletionSource steeredEntered,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = new ResponseObject(context.ResponseId, request.Model ?? "agent");
        yield return new ResponseCreatedEvent(0, response);

        if (context.IsSteeredTurn)
        {
            steeredEntered.TrySetResult();
        }
        else
        {
            firstEntered.TrySetResult();
            await releaseFirst.Task.WaitAsync(cancellationToken);
        }

        response.SetCompleted();
        yield return new ResponseCompletedEvent(1, response);
    }

    private static StringContent Json(object value)
        => new(
            JsonSerializer.Serialize(value),
            Encoding.UTF8,
            "application/json");
}
