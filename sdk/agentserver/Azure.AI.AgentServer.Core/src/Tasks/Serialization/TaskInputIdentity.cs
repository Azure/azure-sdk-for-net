// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Core.Tasks.Serialization;

internal static class TaskInputIdentity
{
    public static string Active(TaskRecord record, string fallback)
        => (string?)record.Payload[TaskWireKeys.PayloadActiveInputId]
            ?? (string?)record.Payload[TaskWireKeys.PayloadLastInputId]
            ?? fallback;

    public static string? Accepted(TaskRecord record)
    {
        string? head = (string?)record.Payload[TaskWireKeys.PayloadLastInputId];
        if (record.Payload[TaskWireKeys.PayloadActiveInputId] is null
            && record.Payload[TaskWireKeys.PayloadSteering] is JsonObject steering
            && steering[TaskWireKeys.SteeringPendingInputs] is JsonArray pending
            && steering[TaskWireKeys.SteeringPendingInputIds] is JsonArray ids
            && pending.Count > 0 && ids.Count == pending.Count
            && ids[ids.Count - 1] is JsonValue tail
            && tail.TryGetValue(out string? inputId)
            && !string.IsNullOrEmpty(inputId))
        {
            // Older .NET records used last_input_id for the executing turn. Their aligned
            // queue IDs preserve the last still-recorded acceptance separately.
            return inputId;
        }
        return head;
    }

    public static bool NeedsMigration(TaskRecord record)
        => record.Payload[TaskWireKeys.PayloadActiveInputId] is null
            && !string.Equals(Accepted(record), (string?)record.Payload[TaskWireKeys.PayloadLastInputId], StringComparison.Ordinal);

    public static void PreserveLegacy(TaskRecord record, JsonObject patch, string fallback)
    {
        if (record.Payload[TaskWireKeys.PayloadActiveInputId] is null)
        {
            patch[TaskWireKeys.PayloadActiveInputId] = Active(record, fallback);
            patch[TaskWireKeys.PayloadLastInputId] = Accepted(record);
        }
    }
}
