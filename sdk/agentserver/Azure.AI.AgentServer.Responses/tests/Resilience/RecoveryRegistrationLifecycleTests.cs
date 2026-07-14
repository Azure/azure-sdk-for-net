// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Resilience;

/// <summary>
/// Integration tests for acceptance-time resilient registration (T013). Drives a real background
/// response through the full HTTP → endpoint → Core task → orchestrator pipeline with durable
/// file-backed stores and asserts the Core task lifecycle: a task record is written when the
/// background response is accepted (so a crashed sandbox can re-invoke it), and removed once the response
/// reaches a terminal state (so the next lifetime does not re-run finished work).
/// </summary>
[NonParallelizable]
public sealed class RecoveryRegistrationLifecycleTests : IDisposable
{
    private readonly string _root;
    private readonly string _responsesDir;
    private readonly string _tasksDir;

    public RecoveryRegistrationLifecycleTests()
    {
        _root = Path.Combine(Path.GetTempPath(), "reg-lifecycle-" + Guid.NewGuid().ToString("N"));
        _responsesDir = Path.Combine(_root, "responses");
        _tasksDir = Path.Combine(_root, "tasks");
        Directory.CreateDirectory(_responsesDir);
        Directory.CreateDirectory(_tasksDir);
    }

    public void Dispose()
    {
        try
        {
            if (Directory.Exists(_root))
            {
                Directory.Delete(_root, recursive: true);
            }
        }
        catch (IOException) { }
    }

    private TestWebApplicationFactory NewResilientFactory(TestHandler handler)
        => new(
            handler,
            configureOptions: o => o.ResilientBackground = true,
            configureTestServices: services =>
            {
                // Hermetic durable composition rooted in a temp directory (no env mutation).
                services.AddSingleton<ResponsesProvider>(new FileResponsesProvider(_responsesDir));
                services.AddSingleton(CoreTaskRecoveryTestHelpers.CreateTaskStore(_tasksDir));
                TestEventStreams.UseFileBacked(services, _responsesDir);
            });

    private int RecoveryEntryCount()
        => CoreTaskRecoveryTestHelpers.TaskRecordCount(_tasksDir);

    [Test]
    public async Task BackgroundResponse_RegistersRecoveryEntry_ThenRemovesAtTerminal()
    {
        var gate = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => GatedLifecycle(ctx, gate, ct),
        };

        using var factory = NewResilientFactory(handler);
        using var client = factory.CreateClient();

        var body = JsonSerializer.Serialize(new { model = "test", background = true });
        var post = await client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.That(post.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var created = JsonDocument.Parse(await post.Content.ReadAsStringAsync());
        var responseId = created.RootElement.GetProperty("id").GetString();
        Assert.That(responseId, Is.Not.Null.And.Not.Empty);

        // In-flight: recovery entry must exist so a crash can re-invoke this response.
        Assert.That(RecoveryEntryCount(), Is.EqualTo(1),
            "Core task record should be written before the handler completes");
        var payload = await CoreTaskRecoveryTestHelpers.ReadTaskPayloadAsync(_tasksDir, responseId!);
        Assert.That(payload.ResponseId, Is.EqualTo(responseId));
        Assert.That(payload.Disposition, Is.EqualTo(ResponseRecoveryPayload.DispositionReinvoke));

        // Let the handler finish and wait for terminal finalization.
        gate.SetResult();
        await WaitForTerminalAsync(client, responseId!);

        Assert.That(RecoveryEntryCount(), Is.EqualTo(0),
            "Core task record should be removed once the response reaches a terminal state");
    }

    [Test]
    public async Task NonBackgroundResponse_WritesNoRecoveryEntry()
    {
        using var factory = NewResilientFactory(new TestHandler());
        using var client = factory.CreateClient();

        var body = JsonSerializer.Serialize(new { model = "test" });
        var post = await client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.That(post.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        Assert.That(RecoveryEntryCount(), Is.EqualTo(0),
            "non-background responses are synchronous and must not create Core task records");
    }

    private static async Task WaitForTerminalAsync(HttpClient client, string responseId)
    {
        for (var i = 0; i < 100; i++)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            if (get.StatusCode == HttpStatusCode.OK)
            {
                using var doc = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
                var status = doc.RootElement.GetProperty("status").GetString();
                if (status is "completed" or "failed" or "cancelled" or "incomplete")
                {
                    return;
                }
            }

            await Task.Delay(25);
        }

        Assert.Fail($"Response {responseId} did not reach a terminal state in time.");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> GatedLifecycle(
        ResponseContext ctx,
        TaskCompletionSource gate,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
        yield return new ResponseCreatedEvent(0, response);

        await gate.Task.WaitAsync(ct);

        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }
}
