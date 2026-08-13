// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// Shared harness for in-process crash-recovery e2e tests (US1). A crash is simulated by seeding
/// the durable store with an interrupted <c>in_progress</c> background response plus its
/// acceptance-time recovery entry, then starting a fresh host over the same state directories so
/// that the Core recovery scan (<c>TaskDurabilityService</c> cold-start, wired by <c>AddResilientTasks</c>)
/// runs on startup. This mirrors the single-process
/// / single-sandbox recovery model (the sandbox auto-recovers on crash; the fresh process re-invokes
/// or fails interrupted work). Real SIGKILL of a child process is not used because recovery is a
/// single-process concern verified deterministically here.
/// </summary>
public abstract class CrashRecoveryE2ETestBase : IDisposable
{
    private protected readonly string Root;
    private protected readonly string ResponsesDir;
    private protected readonly string TasksDir;

    protected CrashRecoveryE2ETestBase()
    {
        Root = Path.Combine(Path.GetTempPath(), "crash-e2e-" + Guid.NewGuid().ToString("N"));
        ResponsesDir = Path.Combine(Root, "responses");
        TasksDir = Path.Combine(Root, "tasks");
        Directory.CreateDirectory(ResponsesDir);
        Directory.CreateDirectory(TasksDir);
    }

    public void Dispose()
    {
        try
        {
            if (Directory.Exists(Root))
            {
                Directory.Delete(Root, recursive: true);
            }
        }
        catch (IOException) { }

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Seeds the durable store to mimic a prior (crashed) lifetime: an <c>in_progress</c> background
    /// response was durably created and its acceptance-time recovery entry was written, but the
    /// response never reached a terminal state before the process died.
    /// </summary>
    private protected async Task SeedInterruptedResponseAsync(
        string responseId,
        string disposition,
        bool stream,
        IDictionary<string, string>? clientHeaders = null,
        IDictionary<string, string>? queryParameters = null)
    {
        var provider = new FileResponsesProvider(ResponsesDir);
        var envelope = new ResponseObject(responseId, "test-model") { Status = ResponseStatus.InProgress };
        envelope.Background = true;
        await provider.CreateResponseAsync(new CreateResponseRequest(envelope, null, null), PlatformContext.Empty);

        var query = new Dictionary<string, string>(StringComparer.Ordinal);
        if (queryParameters is not null)
        {
            foreach (var kvp in queryParameters)
            {
                query[kvp.Key] = kvp.Value;
            }
        }

        var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        if (clientHeaders is not null)
        {
            foreach (var kvp in clientHeaders)
            {
                headers[kvp.Key] = kvp.Value;
            }
        }

        await SeedInterruptedTaskAsync(new ResponseRecoveryPayload(
            responseId: responseId,
            disposition: disposition,
            request: new CreateResponse { Model = "test-model", Background = true, Store = true, Stream = stream },
            clientHeaders: headers,
            queryParameters: query));
    }

    /// <summary>Seeds an interrupted background response that had already accumulated
    /// <paramref name="outputItems"/> durably-checkpointed output items before the crash, plus its
    /// recovery entry. Used to verify the crash-failed overlay preserves partial output.</summary>
    private protected async Task SeedInterruptedResponseWithOutputAsync(
        string responseId,
        string disposition,
        int outputItems)
    {
        var provider = new FileResponsesProvider(ResponsesDir);
        var envelope = new ResponseObject(responseId, "test-model") { Status = ResponseStatus.InProgress };
        envelope.Background = true;
        for (var i = 0; i < outputItems; i++)
        {
            envelope.Output.Add(NewOutputMessage($"msg_seed_{i}", $"phase-{i}"));
        }

        await provider.CreateResponseAsync(new CreateResponseRequest(envelope, null, null), PlatformContext.Empty);

        await SeedInterruptedTaskAsync(new ResponseRecoveryPayload(
            responseId: responseId,
            disposition: disposition,
            request: new CreateResponse { Model = "test-model", Background = true, Store = true, Stream = false },
            clientHeaders: new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase),
            queryParameters: new Dictionary<string, string>(StringComparer.Ordinal)));
    }

    /// <summary>Seeds only the durable in-progress envelope (no recovery entry), for tests that
    /// register a custom recovery payload themselves.</summary>
    private protected async Task SeedDurableEnvelopeAsync(string responseId)
    {
        var provider = new FileResponsesProvider(ResponsesDir);
        var envelope = new ResponseObject(responseId, "test-model") { Status = ResponseStatus.InProgress };
        envelope.Background = true;
        await provider.CreateResponseAsync(new CreateResponseRequest(envelope, null, null), PlatformContext.Empty);
    }

    /// <summary>Seeds a durable in-progress envelope carrying <paramref name="outputItems"/> already-emitted
    /// output message items (mimicking a crash after some output was checkpointed). No recovery entry.</summary>
    private protected async Task SeedDurableEnvelopeWithOutputAsync(string responseId, int outputItems)
    {
        var provider = new FileResponsesProvider(ResponsesDir);
        var envelope = new ResponseObject(responseId, "test-model") { Status = ResponseStatus.InProgress };
        envelope.Background = true;
        for (var i = 0; i < outputItems; i++)
        {
            envelope.Output.Add(NewOutputMessage($"msg_seed_{i}", $"phase-{i}"));
        }

        await provider.CreateResponseAsync(new CreateResponseRequest(envelope, null, null), PlatformContext.Empty);
    }

    /// <summary>Publishes a pre-crash durable SSE stream: created(0) + one output-item added(1)/done(2) per
    /// seeded item, with no completion sentinel (the process died mid-stream).</summary>
    private protected async Task SeedInterruptedStreamAsync(string responseId, int outputItems = 1)
    {
        var streamRegistry = TestEventStreams.CreateFileBackedRegistry(ResponsesDir);
        var stream = await streamRegistry.GetOrCreateAsync(responseId);
        var publisher = await EventStreamObserver.CreateAsync(stream);
        var response = new ResponseObject(responseId, "test-model") { Status = ResponseStatus.InProgress };
        long seq = 0;
        await publisher.OnNextAsync(new ResponseCreatedEvent(seq++, response));
        for (var i = 0; i < outputItems; i++)
        {
            var item = NewOutputMessage($"msg_seed_{i}", $"phase-{i}");
            await publisher.OnNextAsync(new ResponseOutputItemAddedEvent(seq++, outputIndex: i, item: item));
            await publisher.OnNextAsync(new ResponseOutputItemDoneEvent(seq++, outputIndex: i, item: item));
        }

        // Simulate a crash: release the durable stream's exclusive writer lock WITHOUT writing a
        // terminal sentinel (the process died mid-stream). Disposing the Core file-backed stream
        // frees the lock file so the recovering host's registry can re-open and continue the stream.
        if (stream is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }

    /// <summary>Writes a Core task record for a recoverable response.</summary>
    private protected Task SeedInterruptedTaskAsync(ResponseRecoveryPayload payload)
        => CoreTaskRecoveryTestHelpers.SeedInterruptedTaskAsync(TasksDir, payload);

    /// <summary>Writes a reinvoke Core task record for a background streaming response.</summary>
    private protected Task RegisterStreamingReinvokeAsync(string responseId)
        => SeedInterruptedTaskAsync(new ResponseRecoveryPayload(
            responseId: responseId,
            disposition: ResponseRecoveryPayload.DispositionReinvoke,
            request: new CreateResponse { Model = "test-model", Background = true, Store = true, Stream = true }));

    /// <summary>Builds a completed output message item with a single text content.</summary>
    private protected static OutputItemMessage NewOutputMessage(string id, string text)
        => new(
            id: id,
            content: new List<MessageContent>
            {
                new MessageContentOutputTextContent(text, Array.Empty<Annotation>(), Array.Empty<LogProb>()),
            },
            status: MessageStatus.Completed);

    /// <summary>Builds a fresh host over the same durable directories, enabling resilient background.</summary>
    private protected TestWebApplicationFactory NewRecoveringHost(TestHandler handler)
        => new(
            handler,
            configureOptions: o => o.ResilientBackground = true,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(new FileResponsesProvider(ResponsesDir));
                services.AddSingleton(CoreTaskRecoveryTestHelpers.CreateTaskStore(TasksDir));
                TestEventStreams.UseFileBacked(services, ResponsesDir);
            });

    private protected int RecoveryEntryCount()
        => CoreTaskRecoveryTestHelpers.TaskRecordCount(TasksDir);

    /// <summary>
    /// Waits (bounded) for the Core task-record count to reach <paramref name="expected"/>. A
    /// non-resilient background response (Row 2) is now tracked by a Core one-shot task while it runs,
    /// so on a graceful shutdown the record is removed by the engine as the task finalizes — which
    /// happens asynchronously relative to the host's StopAsync returning. This polls for the terminal
    /// steady state (the record cleared) rather than asserting instantaneous consistency.
    /// </summary>
    private protected async Task WaitForRecoveryEntryCountAsync(int expected, string message)
    {
        int last = -1;
        for (var i = 0; i < 200; i++)
        {
            last = RecoveryEntryCount();
            if (last == expected)
            {
                return;
            }

            await Task.Delay(25);
        }

        Assert.That(last, Is.EqualTo(expected), message);
    }

    private protected static async Task WaitForStatusAsync(HttpClient client, string responseId, string expected)
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
                if (doc.RootElement.GetProperty("status").GetString() == expected)
                {
                    return;
                }
            }

            await Task.Delay(25);
        }

        Assert.Fail($"Response {responseId} did not reach status '{expected}' in time. Last GET: {last}");
    }

    /// <summary>Reads the SSE replay body for a completed/failed durable response.</summary>
    private protected static async Task<string> ReadSseReplayAsync(HttpClient client, string responseId)
    {
        var get = await client.GetAsync($"/responses/{responseId}?stream=true");
        return await get.Content.ReadAsStringAsync();
    }

    /// <summary>A minimal handler lifecycle that yields created → completed and signals when done.</summary>
    private protected static async IAsyncEnumerable<ResponseStreamEvent> CompletingLifecycle(
        ResponseContext ctx,
        TaskCompletionSource signal,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new ResponseObject(ctx.ResponseId, "test-model");
        yield return new ResponseCreatedEvent(0, response);
        await Task.Yield();
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
        signal.TrySetResult();
    }
}
