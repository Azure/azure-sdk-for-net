// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Contains the state for the tasks being executed as part of the analyze conversation job submitted. </summary>
    public partial class ConversationTasksState
    {
        /// <summary> Initializes a new instance of ConversationTasksState. </summary>
        /// <param name="tasks"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="tasks"/> is null. </exception>
        internal ConversationTasksState(ConversationTasksStateTasks tasks)
        {
            Argument.AssertNotNull(tasks, nameof(tasks));

            Tasks = tasks;
        }

        /// <summary> Gets the tasks. </summary>
        public ConversationTasksStateTasks Tasks { get; }
    }
}
