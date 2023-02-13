// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// Container for results for all tasks in the conversation job.
    /// Please note <see cref="AnalyzeConversationJobResult"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AnalyzeConversationPIIResult"/>, <see cref="AnalyzeConversationSentimentResult"/> and <see cref="AnalyzeConversationSummarizationResult"/>.
    /// </summary>
    public partial class AnalyzeConversationJobResult : TaskState
    {
        /// <summary> Initializes a new instance of AnalyzeConversationJobResult. </summary>
        /// <param name="lastUpdateDateTime"> The last updated time in UTC for the task. </param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        public AnalyzeConversationJobResult(DateTimeOffset lastUpdateDateTime, State status) : base(lastUpdateDateTime, status)
        {
        }

        /// <summary> Initializes a new instance of AnalyzeConversationJobResult. </summary>
        /// <param name="lastUpdateDateTime"> The last updated time in UTC for the task. </param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        /// <param name="kind"> Enumeration of supported Conversation Analysis task results. </param>
        /// <param name="taskName"></param>
        internal AnalyzeConversationJobResult(DateTimeOffset lastUpdateDateTime, State status, AnalyzeConversationResultsKind kind, string taskName) : base(lastUpdateDateTime, status)
        {
            Kind = kind;
            TaskName = taskName;
        }

        /// <summary> Enumeration of supported Conversation Analysis task results. </summary>
        internal AnalyzeConversationResultsKind Kind { get; set; }
        /// <summary> Gets or sets the task name. </summary>
        public string TaskName { get; set; }
    }
}
