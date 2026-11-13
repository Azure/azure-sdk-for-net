// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The trigger type of the storage task assignment execution. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ExecutionTriggerType
    {
        /// <summary> RunOnce. </summary>
        RunOnce,
        /// <summary> OnSchedule. </summary>
        OnSchedule
    }
}
