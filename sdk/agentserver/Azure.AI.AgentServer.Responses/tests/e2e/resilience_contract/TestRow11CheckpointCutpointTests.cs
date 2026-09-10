// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// Row 11 checkpoint-cutpoint crash e2e tests (FR-032 C1 / FR-033 C3). A prior lifetime emitted
/// phase output items and, at cutpoint C1, successfully checkpointed the snapshot before the crash;
/// at cutpoint C3 the crash happened before the checkpoint landed. On re-invocation a checkpoint-aware
/// handler re-seeds its stream from <see cref="ResponseContext.PersistedResponse"/> and resumes past
/// the checkpointed phases (C1) or re-runs the un-checkpointed phase (C3), driven by the durable
/// output watermark rather than restarting from scratch.
/// </summary>
public class TestRow11CheckpointCutpointTests : CrashRecoveryE2ETestBase
{
    private const int TotalPhases = 2;

    [Test]
    public async Task C1_CheckpointedPhase_ResumesPastIt()
    {
        // C1: the prior lifetime checkpointed after phase 1, so the durable snapshot holds 1 item.
        var responseId = IdGenerator.NewResponseId();
        await SeedCheckpointedResponseAsync(responseId, checkpointedPhaseCount: 1);

        var newPhaseCount = 0;
        var completed = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) =>
            {
                Assert.That(ctx.IsRecovery, Is.True);
                Assert.That(ctx.PersistedResponse, Is.Not.Null);
                Assert.That(ctx.PersistedResponse!.Output, Has.Count.EqualTo(1),
                    "the durable snapshot must expose the checkpointed phase");
                return ResumingLifecycle(ctx, req, () => Interlocked.Increment(ref newPhaseCount), completed, ct);
            },
        };

        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        await completed.Task.WaitAsync(TimeSpan.FromSeconds(10));
        await WaitForStatusAsync(client, responseId, "completed");

        // Only phase 2 re-ran; phase 1 was resumed-past (not re-emitted).
        Assert.That(newPhaseCount, Is.EqualTo(TotalPhases - 1));
        await AssertFinalOutputCountAsync(client, responseId, TotalPhases);
    }

    [Test]
    public async Task C3_UncheckpointedPhase_ReRuns()
    {
        // C3: the crash happened before the checkpoint landed, so the durable snapshot holds 0 items.
        var responseId = IdGenerator.NewResponseId();
        await SeedCheckpointedResponseAsync(responseId, checkpointedPhaseCount: 0);

        var newPhaseCount = 0;
        var completed = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) =>
            {
                Assert.That(ctx.IsRecovery, Is.True);
                Assert.That(ctx.PersistedResponse!.Output, Has.Count.EqualTo(0),
                    "the un-checkpointed phase must not appear in the durable snapshot");
                return ResumingLifecycle(ctx, req, () => Interlocked.Increment(ref newPhaseCount), completed, ct);
            },
        };

        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        await completed.Task.WaitAsync(TimeSpan.FromSeconds(10));
        await WaitForStatusAsync(client, responseId, "completed");

        // Both phases re-ran because none was checkpointed before the crash.
        Assert.That(newPhaseCount, Is.EqualTo(TotalPhases));
        await AssertFinalOutputCountAsync(client, responseId, TotalPhases);
    }

    // ── Helpers ──────────────────────────────────────────────

    /// <summary>
    /// Seeds a prior-lifetime durable snapshot holding <paramref name="checkpointedPhaseCount"/>
    /// output items (the phases that were checkpointed before the crash) plus a re-invoke recovery
    /// entry.
    /// </summary>
    private async Task SeedCheckpointedResponseAsync(string responseId, int checkpointedPhaseCount)
    {
        var provider = new FileResponsesProvider(ResponsesDir);
        var envelope = new ResponseObject(responseId, "test-model") { Status = ResponseStatus.InProgress };
        envelope.Background = true;
        for (var i = 0; i < checkpointedPhaseCount; i++)
        {
            envelope.Output.Add(CreateOutputMessage($"msg_seed_{i}", $"phase-{i}-original"));
        }

        await provider.CreateResponseAsync(new CreateResponseRequest(envelope, null, null), PlatformContext.Empty);

        await SeedInterruptedTaskAsync(new ResponseRecoveryPayload(
            responseId: responseId,
            disposition: ResponseRecoveryPayload.DispositionReinvoke,
            request: new CreateResponse { Model = "test-model", Background = true, Store = true }));
    }

    /// <summary>
    /// A checkpoint-aware recovery handler: re-seeds the stream from the durable snapshot, resumes at
    /// the next un-checkpointed phase, checkpoints after each phase, then completes.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> ResumingLifecycle(
        ResponseContext ctx,
        CreateResponse request,
        Action onPhaseEmitted,
        TaskCompletionSource completed,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, ctx.PersistedResponse!);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var start = stream.Response.Output.Count; // durable watermark: phases already checkpointed
        for (var phase = start; phase < TotalPhases; phase++)
        {
            var message = stream.AddOutputItemMessage();
            yield return message.EmitAdded();
            var text = message.AddTextContent();
            yield return text.EmitAdded();
            yield return text.EmitDelta($"phase-{phase}-rerun");
            yield return text.EmitTextDone($"phase-{phase}-rerun");
            yield return text.EmitDone();
            yield return message.EmitDone();
            onPhaseEmitted();

            // Checkpoint the phase so a subsequent crash would resume past it (C1 semantics).
            yield return stream.Checkpoint();
        }

        await Task.Yield();
        yield return stream.EmitCompleted();
        completed.TrySetResult();
    }

    private static async Task AssertFinalOutputCountAsync(HttpClient client, string responseId, int expected)
    {
        var get = await client.GetAsync($"/responses/{responseId}");
        get.EnsureSuccessStatusCode();
        var body = await get.Content.ReadAsStringAsync();
        using var doc = System.Text.Json.JsonDocument.Parse(body);
        var output = doc.RootElement.GetProperty("output");
        Assert.That(output.GetArrayLength(), Is.EqualTo(expected));
    }

    private static OutputItemMessage CreateOutputMessage(string id, string text)
    {
        var content = new MessageContentOutputTextContent(
            text: text,
            annotations: Array.Empty<Annotation>(),
            logprobs: Array.Empty<LogProb>());
        return new OutputItemMessage(
            id: id,
            content: new List<MessageContent> { content },
            status: MessageStatus.Completed);
    }
}
