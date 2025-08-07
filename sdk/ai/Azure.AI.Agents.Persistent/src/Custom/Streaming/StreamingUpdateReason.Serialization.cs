// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents.Persistent;

internal static class StreamingUpdateReasonExtensions
{
    internal static string ToSseEventLabel(this StreamingUpdateReason value) => value switch
    {
        StreamingUpdateReason.ThreadCreated => "thread.created",
        StreamingUpdateReason.RunCreated => "thread.run.created",
        StreamingUpdateReason.RunQueued => "thread.run.queued",
        StreamingUpdateReason.RunInProgress => "thread.run.in_progress",
        StreamingUpdateReason.RunRequiresAction => "thread.run.requires_action",
        StreamingUpdateReason.RunCompleted => "thread.run.completed",
        StreamingUpdateReason.RunFailed => "thread.run.failed",
        StreamingUpdateReason.RunCancelling => "thread.run.cancelling",
        StreamingUpdateReason.RunCancelled => "thread.run.cancelled",
        StreamingUpdateReason.RunExpired => "thread.run.expired",
        StreamingUpdateReason.RunStepCreated => "thread.run.step.created",
        StreamingUpdateReason.RunStepInProgress => "thread.run.step.in_progress",
        StreamingUpdateReason.RunStepUpdated => "thread.run.step.delta",
        StreamingUpdateReason.RunStepCompleted => "thread.run.step.completed",
        StreamingUpdateReason.RunStepFailed => "thread.run.step.failed",
        StreamingUpdateReason.RunStepCancelled => "thread.run.step.cancelled",
        StreamingUpdateReason.RunStepExpired => "thread.run.step.expired",
        StreamingUpdateReason.MessageCreated => "thread.message.created",
        StreamingUpdateReason.MessageInProgress => "thread.message.in_progress",
        StreamingUpdateReason.MessageUpdated => "thread.message.delta",
        StreamingUpdateReason.MessageCompleted => "thread.message.completed",
        StreamingUpdateReason.MessageFailed => "thread.message.incomplete",
        StreamingUpdateReason.Error => "error",
        StreamingUpdateReason.Done => "done",
        _ => string.Empty
    };

    internal static StreamingUpdateReason FromSseEventLabel(string label) => label switch
    {
        "thread.created" => StreamingUpdateReason.ThreadCreated,
        "thread.run.created" => StreamingUpdateReason.RunCreated,
        "thread.run.queued" => StreamingUpdateReason.RunQueued,
        "thread.run.in_progress" => StreamingUpdateReason.RunInProgress,
        "thread.run.requires_action" => StreamingUpdateReason.RunRequiresAction,
        "thread.run.completed" => StreamingUpdateReason.RunCompleted,
        "thread.run.incomplete" => StreamingUpdateReason.RunIncomplete,
        "thread.run.failed" => StreamingUpdateReason.RunFailed,
        "thread.run.cancelling" => StreamingUpdateReason.RunCancelling,
        "thread.run.cancelled" => StreamingUpdateReason.RunCancelled,
        "thread.run.expired" => StreamingUpdateReason.RunExpired,
        "thread.run.step.created" => StreamingUpdateReason.RunStepCreated,
        "thread.run.step.in_progress" => StreamingUpdateReason.RunStepInProgress,
        "thread.run.step.delta" => StreamingUpdateReason.RunStepUpdated,
        "thread.run.step.completed" => StreamingUpdateReason.RunStepCompleted,
        "thread.run.step.failed" => StreamingUpdateReason.RunStepFailed,
        "thread.run.step.cancelled" => StreamingUpdateReason.RunStepCancelled,
        "thread.run.step.expired" => StreamingUpdateReason.RunStepExpired,
        "thread.message.created" => StreamingUpdateReason.MessageCreated,
        "thread.message.in_progress" => StreamingUpdateReason.MessageInProgress,
        "thread.message.delta" => StreamingUpdateReason.MessageUpdated,
        "thread.message.completed" => StreamingUpdateReason.MessageCompleted,
        "thread.message.incomplete" => StreamingUpdateReason.MessageFailed,
        "error" => StreamingUpdateReason.Error,
        "done" => StreamingUpdateReason.Done,
        _ => StreamingUpdateReason.Unknown,
    };
}
