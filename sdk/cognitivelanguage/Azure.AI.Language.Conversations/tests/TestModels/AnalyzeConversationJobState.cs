// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Contains the status of the analyze conversations job submitted along with related statistics. </summary>
    public partial class AnalyzeConversationJobState : JobState
    {
        /// <summary> Initializes a new instance of AnalyzeConversationJobState. </summary>
        /// <param name="createdDateTime"></param>
        /// <param name="jobId"></param>
        /// <param name="lastUpdatedDateTime"></param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        /// <param name="tasks"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="tasks"/> is null. </exception>
        internal AnalyzeConversationJobState(DateTimeOffset createdDateTime, string jobId, DateTimeOffset lastUpdatedDateTime, State status, ConversationTasksStateTasks tasks) : base(createdDateTime, jobId, lastUpdatedDateTime, status)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));
            Argument.AssertNotNull(tasks, nameof(tasks));

            Tasks = tasks;
        }

        /// <summary> Initializes a new instance of AnalyzeConversationJobState. </summary>
        /// <param name="displayName"></param>
        /// <param name="createdDateTime"></param>
        /// <param name="expirationDateTime"></param>
        /// <param name="jobId"></param>
        /// <param name="lastUpdatedDateTime"></param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        /// <param name="errors"></param>
        /// <param name="nextLink"></param>
        /// <param name="tasks"></param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        internal AnalyzeConversationJobState(string displayName, DateTimeOffset createdDateTime, DateTimeOffset? expirationDateTime, string jobId, DateTimeOffset lastUpdatedDateTime, State status, IReadOnlyList<Error> errors, string nextLink, ConversationTasksStateTasks tasks, ConversationRequestStatistics statistics) : base(displayName, createdDateTime, expirationDateTime, jobId, lastUpdatedDateTime, status, errors, nextLink)
        {
            Tasks = tasks;
            Statistics = statistics;
        }

        /// <summary> Gets the tasks. </summary>
        public ConversationTasksStateTasks Tasks { get; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the request payload. </summary>
        public ConversationRequestStatistics Statistics { get; }
    }
}
