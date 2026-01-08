// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Execution trigger update for storage task assignment. </summary>
    public partial class ExecutionTriggerUpdate
    {
        /// <summary> The trigger type of the storage task assignment execution. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public ExecutionTriggerType? TriggerType
        {
            get => TaskExecutionTriggerType.ToString().ToExecutionTriggerType();
            set => TaskExecutionTriggerType = value.ToString();
        }
    }
}
