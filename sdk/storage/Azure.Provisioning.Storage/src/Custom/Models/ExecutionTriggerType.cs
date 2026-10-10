// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Storage;

// TypeSpec generates TaskExecutionTriggerType instead; retain this shipped enum for obsolete TriggerType compatibility.
/// <summary> The trigger type of the storage task assignment execution. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is obsoleted and will be removed in a future version. Please use TaskExecutionTriggerType instead.")]
public enum ExecutionTriggerType
{
    /// <summary>
    /// RunOnce.
    /// </summary>
    RunOnce = 0,

    /// <summary>
    /// OnSchedule.
    /// </summary>
    OnSchedule = 1,
}
