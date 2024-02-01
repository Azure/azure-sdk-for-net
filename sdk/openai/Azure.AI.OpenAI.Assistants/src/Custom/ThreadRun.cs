// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI.Assistants;

public partial class ThreadRun
{
    /*
     * CUSTOM CODE DESCRIPTION:
     *
     * "Required but nullable" utcDateTime doesn't emit the appropriate deserialization logic by default.
     *
     */

    /// <summary> The Unix timestamp, in seconds, representing when this item was started. </summary>
    [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(DeserializeNullableDateTimeOffset))]
    public DateTimeOffset? StartedAt { get; }
    /// <summary> The Unix timestamp, in seconds, representing when this item expires. </summary>
    [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(DeserializeNullableDateTimeOffset))]
    public DateTimeOffset? ExpiresAt { get; }
    /// <summary> The Unix timestamp, in seconds, representing when this completed. </summary>
    [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(DeserializeNullableDateTimeOffset))]
    public DateTimeOffset? CompletedAt { get; }
    /// <summary> The Unix timestamp, in seconds, representing when this was cancelled. </summary>
    [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(DeserializeNullableDateTimeOffset))]
    public DateTimeOffset? CancelledAt { get; }
    /// <summary> The Unix timestamp, in seconds, representing when this failed. </summary>
    [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(DeserializeNullableDateTimeOffset))]
    public DateTimeOffset? FailedAt { get; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void DeserializeNullableDateTimeOffset(
        JsonProperty property,
        ref DateTimeOffset? targetDateTimeOffset)
        => CustomSerializationHelpers.DeserializeNullableDateTimeOffset(property, ref targetDateTimeOffset);
}
