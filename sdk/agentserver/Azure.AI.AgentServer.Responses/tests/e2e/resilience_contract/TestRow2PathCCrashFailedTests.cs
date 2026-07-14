// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// Row 2, Path C crash-failed e2e (US1). Row 2 = an interrupted background response whose recovery
/// disposition is <c>mark-failed</c> (the non-resilient default policy for the entry). After the
/// sandbox restarts, the startup recovery scan must transition the response to <c>failed</c> WITHOUT
/// re-invoking the handler, and clear the recovery entry. Parameterized over non-streaming and
/// streaming acceptance.
/// </summary>
[NonParallelizable]
public sealed class TestRow2PathCCrashFailedTests : CrashRecoveryE2ETestBase
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task Row2PathC_MarksInterruptedResponseFailed_WithoutReInvoke(bool stream)
    {
        var responseId = IdGenerator.NewResponseId();
        await SeedInterruptedResponseAsync(responseId, ResponseRecoveryPayload.DispositionMarkFailed, stream);

        var handler = new TestHandler();
        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        await WaitForStatusAsync(client, responseId, "failed");

        var get = await client.GetAsync($"/responses/{responseId}");
        using (var doc = System.Text.Json.JsonDocument.Parse(await get.Content.ReadAsStringAsync()))
        {
            Assert.That(doc.RootElement.GetProperty("error").GetProperty("code").GetString(),
                Is.EqualTo("server_error"), "Path C mark-failed must use code=server_error");
            Assert.That(doc.RootElement.GetProperty("error").GetProperty("shutdown_reason").GetString(),
                Is.EqualTo("crash_recovery"),
                "Path C (next-lifetime recovery) mark-failed must carry shutdown_reason=crash_recovery");
        }

        Assert.That(handler.CallCount, Is.EqualTo(0), "mark-failed must not re-invoke the handler");
        Assert.That(RecoveryEntryCount(), Is.EqualTo(0), "recovery entry should be cleared after mark-failed");
    }

    [Test]
    public async Task Row2PathC_MarkFailed_PreservesAccumulatedOutput()
    {
        var responseId = IdGenerator.NewResponseId();

        // The response durably checkpointed 2 output items before the crash. mark-failed recovery
        // must overlay the failed terminal WITHOUT discarding that accumulated output — a failed
        // response's output "may be partial" (Python responses-resilience §7.2/§7.3 overlay contract).
        await SeedInterruptedResponseWithOutputAsync(
            responseId, ResponseRecoveryPayload.DispositionMarkFailed, outputItems: 2);

        var handler = new TestHandler();
        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        await WaitForStatusAsync(client, responseId, "failed");

        var get = await client.GetAsync($"/responses/{responseId}");
        using (var doc = System.Text.Json.JsonDocument.Parse(await get.Content.ReadAsStringAsync()))
        {
            Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"));
            Assert.That(doc.RootElement.GetProperty("error").GetProperty("code").GetString(),
                Is.EqualTo("server_error"));
            Assert.That(doc.RootElement.GetProperty("output").GetArrayLength(), Is.EqualTo(2),
                "mark-failed must preserve the accumulated (partial) output rather than clearing it");
        }

        Assert.That(handler.CallCount, Is.EqualTo(0), "mark-failed must not re-invoke the handler");
    }
}
