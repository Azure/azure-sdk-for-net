// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// Source-generated, allocation-free log definitions and the <see cref="ActivitySource"/>
/// for the resilient-tasks engine. All events are emitted under the logger category
/// <c>Azure.AI.AgentServer.Tasks</c>. Sensitive values (e.g. <c>Authorization</c>
/// headers) and task payload/PII are never logged (FR-044).
/// </summary>
internal static partial class TaskTelemetry
{
    /// <summary>The logger category for all resilient-task events.</summary>
    public const string Category = "Azure.AI.AgentServer.Tasks";

    /// <summary>The <see cref="ActivitySource"/> name for resilient-task spans.</summary>
    public const string ActivitySourceName = "Azure.AI.AgentServer.Tasks";

    /// <summary>The shared <see cref="ActivitySource"/> for key task operations.</summary>
    public static readonly ActivitySource ActivitySource = new(ActivitySourceName);

    [LoggerMessage(
        EventId = 1,
        EventName = "resilient_task_handler_failure",
        Level = LogLevel.Warning,
        Message = "Resilient task handler failed for task {TaskId} (attempt {Attempt}): {ErrorType}.")]
    public static partial void HandlerFailure(this ILogger logger, string taskId, int attempt, string errorType);

    [LoggerMessage(
        EventId = 2,
        EventName = "resilient_task_lease_acquired",
        Level = LogLevel.Debug,
        Message = "Acquired lease for task {TaskId} (generation {Generation}).")]
    public static partial void LeaseAcquired(this ILogger logger, string taskId, long generation);

    [LoggerMessage(
        EventId = 3,
        EventName = "resilient_task_lease_renewed",
        Level = LogLevel.Trace,
        Message = "Renewed lease for task {TaskId}.")]
    public static partial void LeaseRenewed(this ILogger logger, string taskId);

    [LoggerMessage(
        EventId = 4,
        EventName = "resilient_task_lease_lost",
        Level = LogLevel.Information,
        Message = "Lease lost for task {TaskId}; execution will be abandoned.")]
    public static partial void LeaseLost(this ILogger logger, string taskId);

    [LoggerMessage(
        EventId = 5,
        EventName = "resilient_task_recovered",
        Level = LogLevel.Information,
        Message = "Recovered task {TaskId} (recovery #{RecoveryCount}).")]
    public static partial void TaskRecovered(this ILogger logger, string taskId, int recoveryCount);

    [LoggerMessage(
        EventId = 6,
        EventName = "resilient_task_retry",
        Level = LogLevel.Information,
        Message = "Retrying task {TaskId} (attempt {Attempt} of {MaxAttempts}) after {DelayMs} ms.")]
    public static partial void TaskRetry(this ILogger logger, string taskId, int attempt, int maxAttempts, double delayMs);

    [LoggerMessage(
        EventId = 7,
        EventName = "resilient_task_flush",
        Level = LogLevel.Trace,
        Message = "Flushed metadata for task {TaskId}.")]
    public static partial void MetadataFlushed(this ILogger logger, string taskId);

    [LoggerMessage(
        EventId = 8,
        EventName = "resilient_task_write_abandoned",
        Level = LogLevel.Debug,
        Message = "Abandoned serialized write for task {TaskId} (intent {Intent}); race lost.")]
    public static partial void WriteAbandoned(this ILogger logger, string taskId, string intent);

    [LoggerMessage(
        EventId = 9,
        EventName = "resilient_task_recovery_scan_failed",
        Level = LogLevel.Warning,
        Message = "Background recovery scan failed (error {ErrorType}); retrying next interval.")]
    public static partial void RecoveryScanFailed(this ILogger logger, string errorType);

    [LoggerMessage(
        EventId = 10,
        EventName = "resilient_task_lease_force_expire_failed",
        Level = LogLevel.Warning,
        Message = "Failed to force-expire lease for task {TaskId} during shutdown (error {ErrorType}); lease will lapse on TTL.")]
    public static partial void LeaseForceExpireFailed(this ILogger logger, string taskId, string errorType);

    [LoggerMessage(
        EventId = 11,
        EventName = "resilient_task_manager_starting",
        Level = LogLevel.Information,
        Message = "TaskManager starting (owner={Owner}, instance={Instance}, hosted={Hosted}).")]
    public static partial void TaskManagerStarting(this ILogger logger, string owner, string instance, bool hosted);

    [LoggerMessage(
        EventId = 12,
        EventName = "resilient_task_reclaimed_stale",
        Level = LogLevel.Information,
        Message = "Reclaimed stale task {TaskId} (generation will increment).")]
    public static partial void StaleTaskReclaimed(this ILogger logger, string taskId);

    /// <summary>Starts an activity for a key task operation, or returns <see langword="null"/> when no listener is attached.</summary>
    /// <param name="operationName">The operation name (becomes the span name).</param>
    /// <param name="taskId">The task id, attached as a tag.</param>
    /// <returns>The started activity, or <see langword="null"/>.</returns>
    public static Activity? StartOperation(string operationName, string taskId)
    {
        Activity? activity = ActivitySource.StartActivity(operationName, ActivityKind.Internal);
        activity?.SetTag("task.id", taskId);
        return activity;
    }
}
