// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Returns the current state of the task. </summary>
    public partial class TaskState
    {
        /// <summary> Initializes a new instance of TaskState. </summary>
        /// <param name="lastUpdateDateTime"> The last updated time in UTC for the task. </param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        public TaskState(DateTimeOffset lastUpdateDateTime, State status)
        {
            LastUpdateDateTime = lastUpdateDateTime;
            Status = status;
        }

        /// <summary> The last updated time in UTC for the task. </summary>
        public DateTimeOffset LastUpdateDateTime { get; set; }
        /// <summary> The status of the task at the mentioned last update time. </summary>
        public State Status { get; set; }
    }
}
