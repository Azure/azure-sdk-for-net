// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// Recovery-drop precondition e2e (US1 / FR-016). Before dispatching a recovery, the scan reads the
/// durable record. A <em>definitive</em> not-found (<see cref="ResourceNotFoundException"/>) means the
/// response was never durably created (or was deleted) and the entry MUST be dropped without dispatch.
/// A <em>transient</em> read error MUST NOT be swallowed: the entry is retained (not dropped, not
/// dispatched) so it is retried in a later lifetime.
/// </summary>
[NonParallelizable]
public sealed class TestRecoveryDropPreconditionTests : CrashRecoveryE2ETestBase
{
    [Test]
    public async Task DefinitiveNotFound_DropsEntry_WithoutDispatch()
    {
        // No durable record is seeded — only the recovery task exists. GET returns a definitive
        // not-found, so the scan must drop the entry and never touch the handler.
        await SeedInterruptedTaskAsync(new ResponseRecoveryPayload(
            responseId: IdGenerator.NewResponseId(),
            disposition: ResponseRecoveryPayload.DispositionReinvoke,
            request: new CreateResponse { Model = "test-model", Background = true, Store = true }));

        var handler = new TestHandler();
        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        for (var i = 0; i < 40 && RecoveryEntryCount() > 0; i++)
        {
            await Task.Delay(25);
        }

        Assert.That(RecoveryEntryCount(), Is.EqualTo(0), "definitive not-found must drop the recovery entry");
        Assert.That(handler.CallCount, Is.EqualTo(0), "a dropped entry must never dispatch the handler");
    }

    [Test]
    public async Task TransientReadError_RetainsEntry_WithoutDispatch()
    {
        // Seed a durable record, but wrap the DI provider so GET throws a transient error during the
        // scan. The entry must be retained (retried later), and the handler must not be dispatched.
        var responseId = IdGenerator.NewResponseId();
        await SeedInterruptedResponseAsync(responseId, ResponseRecoveryPayload.DispositionReinvoke, stream: false);

        var handler = new TestHandler();
        using var factory = new TestWebApplicationFactory(
            handler,
            configureOptions: o => o.ResilientBackground = true,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(
                    new TransientFailingResponsesProvider(new FileResponsesProvider(ResponsesDir)));
                TestEventStreams.UseFileBacked(services, ResponsesDir);
                services.AddSingleton(CoreTaskRecoveryTestHelpers.CreateTaskStore(TasksDir));
            });
        using var client = factory.CreateClient();

        // Give the startup scan time to run and (correctly) fail transiently.
        await Task.Delay(500);

        Assert.That(RecoveryEntryCount(), Is.EqualTo(1),
            "a transient read error must NOT drop the recovery entry — it is retried next lifetime");
        Assert.That(handler.CallCount, Is.EqualTo(0),
            "a transient precondition failure must not dispatch the handler");
    }

    /// <summary>
    /// A <see cref="ResponsesProvider"/> wrapper that throws a transient (non-not-found) error on
    /// <see cref="GetResponseAsync"/> and delegates everything else to an inner provider.
    /// </summary>
    private sealed class TransientFailingResponsesProvider : ResponsesProvider
    {
        private readonly ResponsesProvider _inner;

        public TransientFailingResponsesProvider(ResponsesProvider inner) => _inner = inner;

        public override Task<ResponseObject> GetResponseAsync(
            string responseId, PlatformContext context, CancellationToken cancellationToken = default)
            => throw new IOException("Simulated transient store read failure.");

        public override Task CreateResponseAsync(
            CreateResponseRequest request, PlatformContext context, CancellationToken cancellationToken = default)
            => _inner.CreateResponseAsync(request, context, cancellationToken);

        public override Task UpdateResponseAsync(
            ResponseObject response, PlatformContext context, CancellationToken cancellationToken = default)
            => _inner.UpdateResponseAsync(response, context, cancellationToken);

        public override Task DeleteResponseAsync(
            string responseId, PlatformContext context, CancellationToken cancellationToken = default)
            => _inner.DeleteResponseAsync(responseId, context, cancellationToken);

        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(
            string responseId, PlatformContext context, int limit = 20, bool ascending = false,
            string? after = null, string? before = null, CancellationToken cancellationToken = default)
            => _inner.GetInputItemsAsync(responseId, context, limit, ascending, after, before, cancellationToken);

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(
            IEnumerable<string> itemIds, PlatformContext context, CancellationToken cancellationToken = default)
            => _inner.GetItemsAsync(itemIds, context, cancellationToken);

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(
            string? previousResponseId, string? conversationId, int limit, PlatformContext context,
            CancellationToken cancellationToken = default)
            => _inner.GetHistoryItemIdsAsync(previousResponseId, conversationId, limit, context, cancellationToken);
    }
}
