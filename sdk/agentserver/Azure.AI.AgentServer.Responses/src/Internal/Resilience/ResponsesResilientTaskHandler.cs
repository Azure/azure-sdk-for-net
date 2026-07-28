// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// The body of the Core resilient tasks that back a response invocation. This is the single point
/// at which the Responses layer <b>composes</b> the Core resilient-task primitive: the response
/// orchestration (<see cref="ResponseOrchestrator.CreateAsync"/>) runs <i>inside</i> a Core
/// <c>@task</c> / <c>@multi_turn_task</c>, so Core owns recovery scanning, leasing, and steering —
/// the Responses layer never reimplements them. Mirrors the Python composition where the handler
/// body is invoked by the selected task primitive.
/// <para>
/// The same body serves both a fresh invocation (launched from the endpoint via
/// <c>ITaskInvoker.StartAsync/RunAsync</c>) and a crash-recovery re-invocation (dispatched by the
/// Core recovery scan with <see cref="EntryMode.Recovered"/>): recovery-vs-fresh, steered-turn, and
/// pending-input state are read from the Core <see cref="TaskContext{TInput}"/> rather than from any
/// bespoke Responses recovery/steering machinery.
/// </para>
/// </summary>
internal static class ResponsesResilientTaskHandler
{
    /// <summary>The Core task name for one-shot (non-conversation) resilient response invocations.</summary>
    public const string OneShotTaskName = "responses_resilient_one_shot";

    /// <summary>The Core task name for steerable / multi-turn conversation resilient response invocations.</summary>
    public const string MultiTurnTaskName = "responses_resilient_multi_turn";

    /// <summary>
    /// Runs the response orchestration for one task turn. Resolves a request scope, reconstructs the
    /// <see cref="ResponseContextImpl"/> from the persisted task input and the live Core
    /// <see cref="TaskContext{TInput}"/>, and drives <see cref="ResponseOrchestrator.CreateAsync"/>.
    /// </summary>
    public static async Task<ResponseTaskOutput> RunTurnAsync(
        IServiceProvider rootProvider,
        TaskContext<ResponseTaskInput> ctx,
        CancellationToken cancellationToken)
    {
        Argument.AssertNotNull(rootProvider, nameof(rootProvider));
        Argument.AssertNotNull(ctx, nameof(ctx));

        ResponseRecoveryPayload payload = ctx.Input.Payload;
        CreateResponse request = payload.Request;
        string responseId = payload.ResponseId;

        bool isBackground = request.Background == true;
        bool isStreaming = request.Stream == true;
        bool store = request.Store != false;
        bool isRecovery = ctx.EntryMode == EntryMode.Recovered;

        using IServiceScope scope = rootProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        IServiceProvider sp = scope.ServiceProvider;

        var orchestrator = sp.GetRequiredService<ResponseOrchestrator>();
        var provider = sp.GetRequiredService<ResponsesProvider>();
        var cancellationProvider = sp.GetRequiredService<ResponsesCancellationSignalProvider>();
        var tracker = sp.GetRequiredService<ResponseExecutionTracker>();
        var options = sp.GetRequiredService<IOptions<ResponsesServerOptions>>();
        var logger = sp.GetRequiredService<ILogger<ResponseOrchestrator>>();

        var platformContext = new PlatformContext(payload.UserIdKey, payload.CallId);

        // On a recovery re-invocation the durable snapshot from the prior lifetime is the handler's
        // resumption seed. A definitively-absent record means the original POST connection closed
        // without returning a response id (no client can fetch it) — drop the execution rather than
        // re-invoke (recovery precondition; see the resilience contract).
        ResponseObject? persisted = null;
        if (isRecovery)
        {
            try
            {
                persisted = await provider.GetResponseAsync(responseId, platformContext, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (ResourceNotFoundException)
            {
                logger.LogInformation(
                    "Recovery for {ResponseId} dropped: durable record definitively absent.", responseId);
                return ResponseTaskOutput.Dropped(responseId);
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex,
                    "Recovery for {ResponseId} could not read the durable record; retaining task for a later recovery.",
                    responseId);
                await ExitCoreTaskForRecoveryAsync(ctx, new ResponseContext(responseId), cancellationToken)
                    .ConfigureAwait(false);
                throw;
            }

            if (persisted is not null && ResponseOrchestrator.IsTerminalStatus(persisted.Status))
            {
                logger.LogInformation(
                    "Recovery for {ResponseId} dropped: durable record already terminal ({Status}).",
                    responseId, persisted.Status);
                return ResponseTaskOutput.Completed(responseId, persisted.Status);
            }

            if (string.Equals(payload.Disposition, ResponseRecoveryPayload.DispositionMarkFailed, StringComparison.Ordinal))
            {
                logger.LogInformation(
                    "Recovery for {ResponseId} marking failed: disposition=mark-failed.", responseId);

                // Overlay the failed terminal onto the durable snapshot: set status + attach the
                // server_error, but PRESERVE the handler-owned fields (agent_reference, model,
                // metadata, and the output accumulated + durably checkpointed before the crash).
                // A failed response's output "may be partial" and is kept, matching the Python
                // crash-failed overlay contract (responses-resilience-spec §7.2/§7.3). The prior
                // snapshot is the authoritative record of what was durably accomplished; the
                // failure is layered on top rather than discarding it.
                persisted!.SetFailed(
                    ResponseErrorCode.ServerError,
                    "The response was interrupted and is not eligible for recovery.",
                    shutdownReason: "crash_recovery");
                await provider.UpdateResponseAsync(persisted!, platformContext, cancellationToken)
                    .ConfigureAwait(false);
                return ResponseTaskOutput.Dropped(responseId);
            }
        }

        // Build the steering-aware ResponseContext from the live Core TaskContext. This is the single
        // source of truth for IsSteeredTurn / PendingInputCount (Core owns steering), so it is built
        // here — even when the endpoint pre-created the execution for the response.created bridge and
        // left Context unset (the multi-turn / steering dispatch path).
        ResponseContextImpl BuildContext() => new(
            responseId,
            provider,
            request,
            options,
            rawBody: null,
            clientHeaders: payload.ClientHeaders,
            queryParameters: ToStringValues(payload.QueryParameters),
            platformContext: platformContext,
            isRecovery: isRecovery,
            persistedResponse: persisted,
            isSteeredTurn: ctx.IsSteeredTurn,
            pendingInputCountProvider: () => ctx.PendingInputCount,
            conversationChainMetadata: new DurableConversationChainMetadata(ctx.Metadata));

        if (!isRecovery
            && tracker.TryGet(responseId, out ResponseExecution? existing)
            && existing is not null)
        {
            // The endpoint pre-created this execution to bridge response.created back to the caller.
            // Reuse its Context when present (one-shot); otherwise build the steering-aware context
            // now (multi-turn dispatch leaves Context unset so Core's ctx drives steering state).
            // Either way the context must carry the durable, Core-backed chain-metadata facade so
            // ConversationChainMetadata.FlushAsync persists into the task record: the endpoint's
            // pre-created context was built with a plain (non-durable) facade, so attach the durable
            // one here before the handler runs.
            ResponseContext reuseContext = existing.Context ?? BuildContext();
            if (reuseContext is ResponseContextImpl reuseImpl)
            {
                reuseImpl.AttachDurableConversationChainMetadata(ctx.Metadata);
            }

            existing.Context = reuseContext;

            await RunWithExecutionAsync(
                orchestrator,
                cancellationProvider,
                request,
                existing,
                reuseContext,
                ctx,
                cancellationToken).ConfigureAwait(false);

            return ResponseTaskOutput.Completed(responseId, existing.Response?.Status);
        }

        var execution = tracker.Create(responseId, isBackground, isStreaming, store);
        execution.AgentSessionId = payload.AgentSessionId;
        execution.UserIdKey = payload.UserIdKey;
        if (persisted is not null)
        {
            execution.RecoveredOutputWatermark = persisted.Output?.Count ?? 0;
        }

        ResponseContextImpl context = BuildContext();
        execution.Context = context;

        try
        {
            await RunWithExecutionAsync(
                orchestrator,
                cancellationProvider,
                request,
                execution,
                context,
                ctx,
                cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            tracker.TryEvict(responseId);
        }

        return ResponseTaskOutput.Completed(responseId, execution.Response?.Status);
    }

    private static async Task RunWithExecutionAsync(
        ResponseOrchestrator orchestrator,
        ResponsesCancellationSignalProvider cancellationProvider,
        CreateResponse request,
        ResponseExecution execution,
        ResponseContext context,
        TaskContext<ResponseTaskInput> ctx,
        CancellationToken cancellationToken)
    {
        using CancellationTokenRegistration shutdownRegistration = ctx.Shutdown.Register(() =>
        {
            execution.ShutdownRequested = true;
            context.IsShutdownRequested = true;
        });

        CancellationToken providerCt =
            await cancellationProvider.GetResponseCancellationTokenAsync(execution.ResponseId)
                .ConfigureAwait(false);

        using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
            cancellationToken,
            execution.CancellationTokenSource.Token,
            providerCt);

        OrchestratorResult result = await orchestrator.CreateAsync(
            request, execution, context, linkedCts.Token).ConfigureAwait(false);

        if (result.Events is not null)
        {
            await foreach (var _ in result.Events.WithCancellation(linkedCts.Token).ConfigureAwait(false))
            {
            }
        }

        if (execution.DeferredForRecovery)
        {
            await ExitCoreTaskForRecoveryAsync(ctx, context, cancellationToken).ConfigureAwait(false);
        }
    }

    private static async Task ExitCoreTaskForRecoveryAsync(
        TaskContext<ResponseTaskInput> ctx,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        if (!ctx.Shutdown.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(Timeout.InfiniteTimeSpan, ctx.Shutdown).WaitAsync(cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (ctx.Shutdown.IsCancellationRequested)
            {
                // Expected: Core has now signaled the only point at which ExitForRecovery is valid.
            }
        }

        context.IsShutdownRequested = true;
        await ctx.ExitForRecoveryAsync(cancellationToken).ConfigureAwait(false);
    }

    private static IReadOnlyDictionary<string, StringValues> ToStringValues(
        IReadOnlyDictionary<string, string> source)
    {
        var map = new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase);
        foreach (var pair in source)
        {
            map[pair.Key] = pair.Value;
        }

        return map;
    }
}
