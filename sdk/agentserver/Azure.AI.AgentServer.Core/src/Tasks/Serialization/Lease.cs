// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Core.Tasks.Serialization;

/// <summary>
/// The lease portion of a task record — the optimistic ownership token that
/// grants a single worker instance the right to execute a task for a bounded
/// duration.
/// </summary>
internal sealed class Lease
{
    /// <summary>The lease owner, formatted <c>&lt;agentName&gt;|session:&lt;sessionId&gt;</c>.</summary>
    public string Owner { get; set; } = string.Empty;

    /// <summary>The owning worker instance id, <c>worker-&lt;pid&gt;-&lt;rand8hex&gt;-&lt;unixSeconds&gt;</c>.</summary>
    public string InstanceId { get; set; } = string.Empty;

    /// <summary>Incremented whenever a different instance reacquires the lease.</summary>
    public long Generation { get; set; }

    /// <summary>ISO-8601 UTC instant after which the lease is considered expired.</summary>
    public string ExpiresAt { get; set; } = string.Empty;

    /// <summary>Provider-written count of how many times this lease was taken over after expiry.</summary>
    public long ExpiryCount { get; set; }

    /// <summary>Provider-written ISO-8601 UTC of the last heartbeat; the framework never writes this.</summary>
    public string? HeartbeatAt { get; set; }

    /// <summary>Reconstructs a <see cref="Lease"/> from its JSON object form, or <see langword="null"/>.</summary>
    /// <param name="node">The JSON node holding the lease, or <see langword="null"/>.</param>
    /// <returns>The parsed lease, or <see langword="null"/> when the node is absent/null.</returns>
    public static Lease? FromJson(JsonNode? node)
    {
        if (node is not JsonObject obj)
        {
            return null;
        }

        return new Lease
        {
            Owner = WireValue.AsStringOrEmpty(obj[TaskWireKeys.LeaseOwner]),
            InstanceId = WireValue.AsStringOrEmpty(obj[TaskWireKeys.LeaseInstanceId]),
            Generation = (long?)obj[TaskWireKeys.LeaseGeneration] ?? 0,
            ExpiresAt = WireValue.AsStringOrEmpty(obj[TaskWireKeys.LeaseExpiresAt]),
            ExpiryCount = (long?)obj[TaskWireKeys.LeaseExpiryCount] ?? 0,
            HeartbeatAt = WireValue.AsString(obj[TaskWireKeys.LeaseHeartbeatAt]),
        };
    }

    /// <summary>Projects this lease to its JSON object form using the canonical wire keys.</summary>
    /// <returns>A <see cref="JsonObject"/> with the lease fields.</returns>
    public JsonObject ToJson()
    {
        var obj = new JsonObject
        {
            [TaskWireKeys.LeaseOwner] = Owner,
            [TaskWireKeys.LeaseInstanceId] = InstanceId,
            [TaskWireKeys.LeaseGeneration] = Generation,
            [TaskWireKeys.LeaseExpiresAt] = ExpiresAt,
            [TaskWireKeys.LeaseExpiryCount] = ExpiryCount,
        };

        if (HeartbeatAt is not null)
        {
            obj[TaskWireKeys.LeaseHeartbeatAt] = HeartbeatAt;
        }

        return obj;
    }
}
