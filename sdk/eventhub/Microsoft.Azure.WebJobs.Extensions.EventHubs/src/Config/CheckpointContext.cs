// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.EventHubs
{
    /// <summary>
    /// Represents the state of an Event Hub partition's checkpointing strategy and its relative state.
    /// </summary>
    public class CheckpointContext
    {
        /// <summary>
        /// Determines whether this checkpoint will partition after this invocation succeeds.
        /// </summary>
        public bool IsCheckpointingAfterInvocation { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckpointContext"/> class.
        /// </summary>
        /// <param name="isCheckpointingAfterInvocation">Determines whether this checkpoint will partition after this invocation succeeds.</param>
        public CheckpointContext(bool isCheckpointingAfterInvocation)
        {
            IsCheckpointingAfterInvocation = isCheckpointingAfterInvocation;
        }
    }
}
