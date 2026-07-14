// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Resilience;

/// <summary>
/// In-process crash-recovery integration tests (US1 / T021). Simulate a sandbox crash by seeding
/// the durable store with an interrupted <c>in_progress</c> background response plus its
/// Core durable task record, then start a fresh host over the same state directories. The
/// Core startup recovery scan must re-invoke the handler (disposition=re-invoke)
/// so the response completes, or mark it failed (disposition=mark-failed), and remove the entry.
/// </summary>
[NonParallelizable]
public sealed class CrashRecoveryReinvokeTests : IDisposable
{
    private readonly string _root;
    private readonly string _responsesDir;
    private readonly string _tasksDir;

    public CrashRecoveryReinvokeTests()
    {
        _root = Path.Combine(Path.GetTempPath(), "crash-recovery-" + Guid.NewGuid().ToString("N"));
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

    private async Task SeedInterruptedResponseAsync(string responseId, string disposition)
    {
        // Simulate the prior (crashed) lifetime: an in_progress background response was durably
        // created, and its Core durable task record was written, but the response never
        // reached a terminal state before the process died.
        var provider = new FileResponsesProvider(_responsesDir);
        var envelope = new Models.ResponseObject(responseId, "test-model") { Status = ResponseStatus.InProgress };
        envelope.Background = true;
        await provider.CreateResponseAsync(new CreateResponseRequest(envelope, null, null), PlatformContext.Empty);

        await CoreTaskRecoveryTestHelpers.SeedInterruptedTaskAsync(_tasksDir, new ResponseRecoveryPayload(
            responseId: responseId,
            disposition: disposition,
            request: new CreateResponse { Model = "test-model", Background = true, Store = true }));
    }

    private TestWebApplicationFactory NewRecoveringHost(TestHandler handler)
        => new(
            handler,
            configureOptions: o => o.ResilientBackground = true,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(new FileResponsesProvider(_responsesDir));
                services.AddSingleton(CoreTaskRecoveryTestHelpers.CreateTaskStore(_tasksDir));
                TestEventStreams.UseFileBacked(services, _responsesDir);
            });

    private int RecoveryEntryCount()
        => CoreTaskRecoveryTestHelpers.TaskRecordCount(_tasksDir);

    [Test]
    public async Task Reinvoke_CompletesInterruptedResponse_AndClearsEntry()
    {
        var responseId = IdGenerator.NewResponseId();
        await SeedInterruptedResponseAsync(responseId, ResponseRecoveryPayload.DispositionReinvoke);

        var reinvoked = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) =>
            {
                Assert.That(ctx.IsRecovery, Is.True, "recovered handler must observe IsRecovery == true");
                Assert.That(ctx.PersistedResponse, Is.Not.Null, "recovered handler must see the prior snapshot");
                return CompletingLifecycle(ctx, reinvoked);
            },
        };

        // Starting the host runs Core's task recovery scan → re-invoke.
        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        await reinvoked.Task.WaitAsync(TimeSpan.FromSeconds(10));
        await WaitForStatusAsync(client, responseId, "completed");

        Assert.That(handler.CallCount, Is.EqualTo(1), "handler should have been re-invoked exactly once");
        Assert.That(RecoveryEntryCount(), Is.EqualTo(0), "recovery entry should be cleared after completion");
    }

    [Test]
    public async Task MarkFailed_TransitionsInterruptedResponse_AndClearsEntry()
    {
        var responseId = IdGenerator.NewResponseId();
        await SeedInterruptedResponseAsync(responseId, ResponseRecoveryPayload.DispositionMarkFailed);

        var handler = new TestHandler();
        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        await WaitForStatusAsync(client, responseId, "failed");

        Assert.That(handler.CallCount, Is.EqualTo(0), "mark-failed must not re-invoke the handler");
        Assert.That(RecoveryEntryCount(), Is.EqualTo(0), "recovery entry should be cleared after mark-failed");
    }

    [Test]
    public async Task RecoveryScan_DropsEntry_WhenDurableRecordMissing()
    {
        // Register a Core task whose durable response record does NOT exist — a definitive
        // not-found. The scan must drop the entry (FR-016) and not re-invoke anything.
        await CoreTaskRecoveryTestHelpers.SeedInterruptedTaskAsync(_tasksDir, new ResponseRecoveryPayload(
            responseId: IdGenerator.NewResponseId(),
            disposition: ResponseRecoveryPayload.DispositionReinvoke,
            request: new CreateResponse { Model = "test-model", Background = true, Store = true }));

        var handler = new TestHandler();
        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        // Give the startup scan a moment to run.
        for (var i = 0; i < 40 && RecoveryEntryCount() > 0; i++)
        {
            await Task.Delay(25);
        }

        Assert.That(RecoveryEntryCount(), Is.EqualTo(0), "entry for a missing durable record should be dropped");
        Assert.That(handler.CallCount, Is.EqualTo(0), "no handler should be invoked for a dropped entry");
    }

    private static async Task WaitForStatusAsync(HttpClient client, string responseId, string expected)
    {
        string last = "(none)";
        for (var i = 0; i < 200; i++)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            var body = await get.Content.ReadAsStringAsync();
            last = $"{(int)get.StatusCode} {body}";
            if (get.StatusCode == HttpStatusCode.OK)
            {
                using var doc = JsonDocument.Parse(body);
                var status = doc.RootElement.GetProperty("status").GetString();
                if (status == expected)
                {
                    return;
                }
            }

            await Task.Delay(25);
        }

        Assert.Fail($"Response {responseId} did not reach status '{expected}' in time. Last GET: {last}");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CompletingLifecycle(
        ResponseContext ctx,
        TaskCompletionSource signal,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
        yield return new ResponseCreatedEvent(0, response);
        await Task.Yield();
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
        signal.TrySetResult();
    }
}
