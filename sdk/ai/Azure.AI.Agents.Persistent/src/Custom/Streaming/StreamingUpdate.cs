// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.ServerSentEvents;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// Represents a single item of streamed Agents API data.
/// </summary>
/// <remarks>
/// Please note that this is the abstract base type. To access data, downcast an instance of this type to an
/// appropriate, derived update type:
/// <para>
/// For messages: <see cref="MessageStatusUpdate"/>, <see cref="MessageContentUpdate"/>
/// </para>
/// <para>
/// For runs and run steps: <see cref="RunUpdate"/>, <see cref="RunStepUpdate"/>, <see cref="RunStepDetailsUpdate"/>,
/// <see cref="RequiredActionUpdate"/>
/// </para>
/// <para>
/// For threads: <see cref="ThreadUpdate"/>
/// </para>
/// </remarks>
public abstract partial class StreamingUpdate
{
    /// <summary>
    /// A value indicating what type of event this update represents.
    /// </summary>
    /// <remarks>
    /// Many events share the same response type. For example, <see cref="StreamingUpdateReason.RunCreated"/> and
    /// <see cref="StreamingUpdateReason.RunCompleted"/> are both associated with a <see cref="ThreadRun"/> instance.
    /// You can use the value of <see cref="UpdateKind"/> to differentiate between these events when the type is not
    /// sufficient to do so.
    /// </remarks>
    public StreamingUpdateReason UpdateKind { get; }

    internal StreamingUpdate(StreamingUpdateReason updateKind)
    {
        UpdateKind = updateKind;
    }

    internal static IEnumerable<StreamingUpdate> FromEvent(SseItem<byte[]> sseItem)
    {
        StreamingUpdateReason updateKind = StreamingUpdateReasonExtensions.FromSseEventLabel(sseItem.EventType);
        using JsonDocument dataDocument = JsonDocument.Parse(sseItem.Data);
        JsonElement e = dataDocument.RootElement;

        return updateKind switch
        {
            StreamingUpdateReason.ThreadCreated => ThreadUpdate.DeserializeThreadCreationUpdates(e, updateKind),
            StreamingUpdateReason.RunCreated
            or StreamingUpdateReason.RunQueued
            or StreamingUpdateReason.RunInProgress
            or StreamingUpdateReason.RunCompleted
            or StreamingUpdateReason.RunIncomplete
            or StreamingUpdateReason.RunFailed
            or StreamingUpdateReason.RunCancelling
            or StreamingUpdateReason.RunCancelled
            or StreamingUpdateReason.RunExpired => RunUpdate.DeserializeRunUpdates(e, updateKind),
            StreamingUpdateReason.RunRequiresAction => DeserializeRequiredActionUpdate(e),
            StreamingUpdateReason.RunStepCreated
            or StreamingUpdateReason.RunStepInProgress
            or StreamingUpdateReason.RunStepCompleted
            or StreamingUpdateReason.RunStepFailed
            or StreamingUpdateReason.RunStepCancelled
            or StreamingUpdateReason.RunStepExpired => RunStepUpdate.DeserializeRunStepUpdates(e, updateKind),
            StreamingUpdateReason.MessageCreated
            or StreamingUpdateReason.MessageInProgress
            or StreamingUpdateReason.MessageCompleted
            or StreamingUpdateReason.MessageFailed => MessageStatusUpdate.DeserializeMessageStatusUpdates(e, updateKind),
            StreamingUpdateReason.RunStepUpdated => RunStepDetailsUpdate.DeserializeRunStepDetailsUpdates(e, updateKind),
            StreamingUpdateReason.MessageUpdated => MessageContentUpdate.DeserializeMessageContentUpdates(e, updateKind),
            _ => null,
        };
    }

    internal static IEnumerable<StreamingUpdate> DeserializeRequiredActionUpdate(JsonElement e)
    {
        IEnumerable<StreamingUpdate> updates = RequiredActionUpdate.DeserializeRequiredActionUpdates(e);
        if (updates.Any())
        {
            return updates;
        }
        return SubmitToolApprovalUpdate.DeserializeSubmitToolApprovalUpdates(e);
    }
}

/// <summary>
/// Represents a single item of streamed data that encapsulates an underlying response value type.
/// </summary>
/// <typeparam name="T"> The response value type of the "delta" payload. </typeparam>
public partial class StreamingUpdate<T> : StreamingUpdate
    where T : class
{
    /// <summary>
    /// The underlying response value received with the streaming event.
    /// </summary>
    public T Value { get; }

    internal StreamingUpdate(T value, StreamingUpdateReason updateKind)
        : base(updateKind)
    {
        Value = value;
    }

    /// <summary>
    /// Implicit operator that allows the underlying value type of the <see cref="StreamingUpdate{T}"/> to be used
    /// directly.
    /// </summary>
    /// <param name="update"></param>
    public static implicit operator T(StreamingUpdate<T> update) => update.Value;
}
