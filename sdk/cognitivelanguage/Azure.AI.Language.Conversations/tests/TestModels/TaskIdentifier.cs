// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Base task object. </summary>
    public partial class TaskIdentifier
    {
        /// <summary> Initializes a new instance of TaskIdentifier. </summary>
        public TaskIdentifier()
        {
        }

        /// <summary> Initializes a new instance of TaskIdentifier. </summary>
        /// <param name="taskName"></param>
        internal TaskIdentifier(string taskName)
        {
            TaskName = taskName;
        }

        /// <summary> Gets or sets the task name. </summary>
        public string TaskName { get; set; }
    }
}
