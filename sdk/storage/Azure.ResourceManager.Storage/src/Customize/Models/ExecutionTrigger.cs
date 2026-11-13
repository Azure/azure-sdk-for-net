// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Execution trigger for storage task assignment. </summary>
    public partial class ExecutionTrigger
    {
        /// <summary> Initializes a new instance of <see cref="ExecutionTrigger"/>. </summary>
        /// <param name="triggerType"> The trigger type of the storage task assignment execution. </param>
        /// <param name="parameters"> The trigger parameters of the storage task assignment execution. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ExecutionTrigger(ExecutionTriggerType triggerType, ExecutionTriggerParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            TaskExecutionTriggerType = triggerType.ToString();
            Parameters = parameters;
        }

        /// <summary> The trigger type of the storage task assignment execution. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public ExecutionTriggerType TriggerType
        {
            get => TaskExecutionTriggerType.ToString().ToExecutionTriggerType();
            set => TaskExecutionTriggerType = value.ToString();
        }
    }
}
