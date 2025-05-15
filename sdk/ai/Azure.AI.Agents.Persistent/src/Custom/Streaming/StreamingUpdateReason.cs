// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// The collection of values associated with the event names of streaming update payloads. These correspond to the
/// expected downcast data type of the <see cref="StreamingUpdate"/> as well as to the expected data present in the
/// payload.
/// </summary>
public enum StreamingUpdateReason
{
    /// <summary>
    /// Indicates that there is no known reason associated with the streaming update.
    /// </summary>
    Unknown,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.created</c> event.
    /// </summary>
    /// <remarks> This reason is typically only associated with calls to
    /// <see cref="PersistentAgentsAdministrationClient.CreateThreadAndRun(string, PersistentAgentThreadCreationOptions, string, string, System.Collections.Generic.IEnumerable{ToolDefinition}, ToolResources, bool?, float?, float?, int?, int?, Truncation, System.BinaryData, System.BinaryData, bool?, System.Collections.Generic.IReadOnlyDictionary{string, string}, System.Threading.CancellationToken)"/>,
    /// as other run-related methods operate on a thread that has previously been created.
    /// </remarks>
    ThreadCreated,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.created</c> event.
    /// </summary>
    RunCreated,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.queued</c> event.
    /// </summary>
    RunQueued,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.in_progress</c> event.
    /// </summary>
    RunInProgress,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.requires_action</c> event.
    /// </summary>
    /// <remarks>
    /// Note that, if multiple actions occur within a single event, as can be the case with the parallel tool calling,
    /// distinct <see cref="RequiredActionUpdate"/> instances will be generated for each
    /// <see cref="RequiredAction"/>.
    /// </remarks>
    RunRequiresAction,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.completed</c> event.
    /// </summary>
    RunCompleted,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.incomplete</c> event.
    /// </summary>
    RunIncomplete,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.failed</c> event.
    /// </summary>
    RunFailed,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.cancelling</c> event.
    /// </summary>
    RunCancelling,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.cancelled</c> event.
    /// </summary>
    RunCancelled,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.expired</c> event.
    /// </summary>
    RunExpired,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.step.created</c> event.
    /// </summary>
    RunStepCreated,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.step.in_progress</c> event.
    /// </summary>
    RunStepInProgress,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.step.delta</c> event.
    /// </summary>
    RunStepUpdated,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.step.completed</c> event.
    /// </summary>
    RunStepCompleted,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.step.failed</c> event.
    /// </summary>
    RunStepFailed,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.step.cancelled</c> event.
    /// </summary>
    RunStepCancelled,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.run.step.expired</c> event.
    /// </summary>
    RunStepExpired,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.message.created</c> event.
    /// </summary>
    MessageCreated,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.message.in_progress</c> event.
    /// </summary>
    MessageInProgress,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.message.delta</c> event.
    /// </summary>
    /// <remarks>
    /// Distinct <see cref="MessageContentUpdate"/> instances will be created per each content update and/or content
    /// annotation present on the event.
    /// </remarks>
    MessageUpdated,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.message.completed</c> event.
    /// </summary>
    MessageCompleted,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.message.failed</c> event.
    /// </summary>
    MessageFailed,
    /// <summary>
    /// Indicates that an update was generated as part of a <c>thread.message.error</c> event.
    /// </summary>
    Error,
    /// <summary>
    /// Indicates the end of streaming update events. This value should never be typically observed.
    /// </summary>
    Done,
}
