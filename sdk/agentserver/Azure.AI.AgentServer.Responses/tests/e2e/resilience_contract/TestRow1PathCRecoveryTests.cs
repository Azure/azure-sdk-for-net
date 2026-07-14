// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// Row 1, Path C crash-recovery e2e (US1). Row 1 = <c>store=true</c>, <c>background=true</c> with
/// <c>ResilientBackground=true</c>. Path C = the handler was interrupted mid-flight by a crash. After
/// the sandbox restarts, the startup recovery scan must re-invoke the handler with the recovered
/// context (<see cref="ResponseContext.IsRecovery"/> == true) and drive the response to
/// <c>completed</c>, then clear the recovery entry. Parameterized over non-streaming and streaming
/// acceptance so both paths repopulate their durable artifacts.
/// </summary>
[NonParallelizable]
public sealed class TestRow1PathCRecoveryTests : CrashRecoveryE2ETestBase
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task Row1PathC_ReInvokesInterruptedResponse_AndCompletes(bool stream)
    {
        var responseId = IdGenerator.NewResponseId();
        await SeedInterruptedResponseAsync(responseId, ResponseRecoveryPayload.DispositionReinvoke, stream);

        var reinvoked = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) =>
            {
                Assert.That(ctx.IsRecovery, Is.True, "recovered handler must observe IsRecovery == true");
                Assert.That(ctx.PersistedResponse, Is.Not.Null, "recovered handler must see the prior snapshot");
                return CompletingLifecycle(ctx, reinvoked, ct);
            },
        };

        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        await reinvoked.Task.WaitAsync(TimeSpan.FromSeconds(10));
        await WaitForStatusAsync(client, responseId, "completed");

        Assert.That(handler.CallCount, Is.EqualTo(1), "handler should have been re-invoked exactly once");
        Assert.That(RecoveryEntryCount(), Is.EqualTo(0), "recovery entry should be cleared after completion");

        if (stream)
        {
            // The re-invoked streaming handler must repopulate the durable stream so a reconnecting
            // client can replay the terminal event.
            var sse = await ReadSseReplayAsync(client, responseId);
            Assert.That(sse, Does.Contain("event: response.completed"),
                "streaming recovery must repopulate the durable stream with the terminal event");
        }
    }
}
