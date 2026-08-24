// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Storage;

// TypeSpec emits TaskExecutionTriggerType for the current schema. Preserve the previously
// shipped enum and its ordinal order because ExecutionTrigger.TriggerType still exposes it.
/// <summary>
/// The trigger type of the storage task assignment execution.
/// </summary>
public enum ExecutionTriggerType
{
    /// <summary>
    /// RunOnce.
    /// </summary>
    RunOnce,

    /// <summary>
    /// OnSchedule.
    /// </summary>
    OnSchedule,
}
