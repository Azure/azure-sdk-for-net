// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.ServerSentEvents;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

[TestFixture]
[NonParallelizable]
public class TaskStreamTerminalPatchFailureProtocolTests
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task StreamingTerminalTaskPatchFailure_EmitsErrorAndLeavesRecoverableStreamOpen(
        bool multiTurn)
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-terminal-patch-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        string? previousStateRoot = Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT");
        Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", root);

        try
        {
            var store = new SpyTaskStore(new LocalTaskStore(Path.Combine(root, "tasks")))
            {
                ThrowOnPatch = new IOException("Injected terminal task patch failure."),
                PatchFailurePredicate = patch => string.Equals(
                    patch.Status,
                    multiTurn ? TaskWireKeys.StatusSuspended : TaskWireKeys.StatusCompleted,
                    StringComparison.Ordinal),
            };
            var logger = new CapturingLogger<ResponseEndpointHandler>();

            using var factory = new TestWebApplicationFactory(
                configureOptions: options => options.ResilientBackground = true,
                configureTestServices: services =>
                {
                    services.AddSingleton<ITaskStore>(store);
                    services.AddSingleton<ILogger<ResponseEndpointHandler>>(logger);
                });
            using HttpClient client = factory.CreateClient();
            string responseId = IdGenerator.NewResponseId();
            var payload = new Dictionary<string, object?>
            {
                ["model"] = "test",
                ["stream"] = true,
                ["background"] = true,
                ["store"] = true,
            };
            if (multiTurn)
            {
                payload["conversation"] = new { id = "conv_terminal_patch_failure" };
            }

            using var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
            {
                Content = new StringContent(
                    JsonSerializer.Serialize(payload),
                    Encoding.UTF8,
                    "application/json"),
            };
            request.Headers.Add("x-agent-response-id", responseId);

            using HttpResponseMessage response = await client.SendAsync(
                request,
                HttpCompletionOption.ResponseHeadersRead);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            string body = await response.Content.ReadAsStringAsync()
                .WaitAsync(TimeSpan.FromSeconds(10));
            Assert.That(body, Does.Contain("event: response.created"));
            Assert.That(body, Does.Contain("event: error"),
                "The relay must surface the task completion failure instead of waiting forever for EOF.");
            Assert.That(logger.LastException, Is.InstanceOf<ResilientTaskException>(),
                "SseResult must handle the task completion fault, not a concurrent enumerator cleanup error.");

            var registry =
                (ITaskEventStreamRegistry)factory.Services.GetRequiredService<AgentEventStreamRegistry>();
            string taskId = store.LastCreateRequest!.Id!;
            AgentEventStream? taskStream = await registry.GetTaskStreamAsync(taskId, responseId);
            Assert.That(taskStream, Is.Not.Null);
            Assert.DoesNotThrowAsync(async () =>
                await taskStream!.EmitAsync(
                    new SseItem<string>("recovery-probe") { EventId = "recovery-probe" }));
            await taskStream!.CloseAsync();
        }
        finally
        {
            Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", previousStateRoot);
            try
            {
                Directory.Delete(root, recursive: true);
            }
            catch (IOException)
            {
            }
        }
    }

    private sealed class CapturingLogger<T> : ILogger<T>
    {
        private Exception? _lastException;

        public Exception? LastException => Volatile.Read(ref _lastException);

        public IDisposable? BeginScope<TState>(TState state)
            where TState : notnull
            => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            if (exception is not null)
            {
                Volatile.Write(ref _lastException, exception);
            }
        }
    }
}
