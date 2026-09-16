// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// Forms lease identity and drives lease acquisition, renewal (heartbeat), and
/// reclamation through the write serializer. The lease trio (<c>owner</c>,
/// <c>instance_id</c>, <c>duration</c>) is piggybacked on every mutating PATCH
/// (SOT §25.4); the store performs the lease arithmetic and bumps the generation
/// on a different-instance reacquire.
/// </summary>
internal sealed class LeaseManager
{
    private readonly TaskWriteSerializer _serializer;

    /// <summary>Initializes a new instance of the <see cref="LeaseManager"/> class.</summary>
    /// <param name="serializer">The write serializer used to apply lease PATCHes.</param>
    /// <param name="instanceId">An optional fixed instance id; a fresh one is generated when omitted.</param>
    public LeaseManager(TaskWriteSerializer serializer, string? instanceId = null)
    {
        _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        InstanceId = instanceId ?? NewInstanceId();
    }

    /// <summary>The instance id identifying this worker for lease ownership.</summary>
    public string InstanceId { get; }

    /// <summary>Forms the lease owner string as <c>&lt;agentName&gt;|session:&lt;sessionId&gt;</c>.</summary>
    /// <param name="agentName">The agent name.</param>
    /// <param name="sessionId">The session id.</param>
    /// <returns>The composed owner string.</returns>
    public static string FormatOwner(string agentName, string sessionId)
        => $"{agentName}|session:{sessionId}";

    /// <summary>
    /// Generates a fresh instance id of the form
    /// <c>worker-&lt;pid&gt;-&lt;rand8hex&gt;-&lt;unixSeconds&gt;</c>.
    /// </summary>
    /// <returns>A new instance id.</returns>
    public static string NewInstanceId()
    {
        int pid = Environment.ProcessId;
        Span<byte> rnd = stackalloc byte[4];
        RandomNumberGenerator.Fill(rnd);
        string rand8 = Convert.ToHexString(rnd).ToLowerInvariant();
        long unixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return string.Create(
            CultureInfo.InvariantCulture,
            $"worker-{pid}-{rand8}-{unixSeconds}");
    }

    /// <summary>
    /// Acquires or renews the lease on a task, transitioning it to <c>in_progress</c>.
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="owner">The lease owner string.</param>
    /// <param name="durationSeconds">The lease duration in seconds.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The updated record holding the acquired/renewed lease.</returns>
    public Task<TaskRecord> AcquireAsync(
        string taskId, string owner, int durationSeconds, CancellationToken cancellationToken = default)
        => _serializer.UpdateAsync(
            taskId,
            _ => new TaskPatchRequest
            {
                Status = TaskWireKeys.StatusInProgress,
                LeaseOwner = owner,
                LeaseInstanceId = InstanceId,
                LeaseDurationSeconds = durationSeconds,
            },
            WriteIntent.LeaseHeartbeat,
            cancellationToken);

    /// <summary>
    /// Sends a heartbeat (lease renewal). Lease renewal requires the record be (or
    /// transition to) <c>in_progress</c> in the same PATCH (SOT §25.4).
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="owner">The lease owner string.</param>
    /// <param name="durationSeconds">The lease duration in seconds.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The updated record.</returns>
    public Task<TaskRecord> HeartbeatAsync(
        string taskId, string owner, int durationSeconds, CancellationToken cancellationToken = default)
        => AcquireAsync(taskId, owner, durationSeconds, cancellationToken);

    /// <summary>
    /// Force-expires the lease (duration 0) while keeping the record <c>in_progress</c>,
    /// so another worker can immediately reclaim it. Used by exit-for-recovery.
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="owner">The lease owner string.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The updated record.</returns>
    public Task<TaskRecord> ReleaseAsync(
        string taskId, string owner, CancellationToken cancellationToken = default)
        => _serializer.UpdateAsync(
            taskId,
            _ => new TaskPatchRequest
            {
                Status = TaskWireKeys.StatusInProgress,
                LeaseOwner = owner,
                LeaseInstanceId = InstanceId,
                LeaseDurationSeconds = 0,
            },
            WriteIntent.LeaseHeartbeat,
            cancellationToken);

    /// <summary>
    /// Reclaims an expired lease. A precondition failure during reclaim is treated as
    /// the race-loss signal and abandons quietly (SOT §25.3).
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="owner">The lease owner string.</param>
    /// <param name="durationSeconds">The lease duration in seconds.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The updated record on a successful reclaim.</returns>
    public Task<TaskRecord> ReclaimAsync(
        string taskId, string owner, int durationSeconds, CancellationToken cancellationToken = default)
        => _serializer.UpdateAsync(
            taskId,
            _ => new TaskPatchRequest
            {
                Status = TaskWireKeys.StatusInProgress,
                LeaseOwner = owner,
                LeaseInstanceId = InstanceId,
                LeaseDurationSeconds = durationSeconds,
            },
            WriteIntent.Reclaim,
            cancellationToken);
}
