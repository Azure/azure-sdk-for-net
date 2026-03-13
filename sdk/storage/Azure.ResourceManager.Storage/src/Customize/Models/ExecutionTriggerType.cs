// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Hand-authored enum replacing generated string-backed extensible type
// to preserve the prior GA strongly-typed enum API surface.

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
