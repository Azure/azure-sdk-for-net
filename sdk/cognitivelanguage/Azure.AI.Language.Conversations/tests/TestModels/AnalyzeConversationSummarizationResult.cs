// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Result for the summarization task on the conversation. </summary>
    public partial class AnalyzeConversationSummarizationResult : AnalyzeConversationJobResult
    {
        /// <summary> Initializes a new instance of AnalyzeConversationSummarizationResult. </summary>
        /// <param name="lastUpdateDateTime"> The last updated time in UTC for the task. </param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        /// <param name="results"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="results"/> is null. </exception>
        public AnalyzeConversationSummarizationResult(DateTimeOffset lastUpdateDateTime, State status, SummaryResult results) : base(lastUpdateDateTime, status)
        {
            Argument.AssertNotNull(results, nameof(results));

            Results = results;
            Kind = AnalyzeConversationResultsKind.ConversationalSummarizationResults;
        }

        /// <summary> Initializes a new instance of AnalyzeConversationSummarizationResult. </summary>
        /// <param name="lastUpdateDateTime"> The last updated time in UTC for the task. </param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        /// <param name="kind"> Enumeration of supported Conversation Analysis task results. </param>
        /// <param name="taskName"></param>
        /// <param name="results"></param>
        internal AnalyzeConversationSummarizationResult(DateTimeOffset lastUpdateDateTime, State status, AnalyzeConversationResultsKind kind, string taskName, SummaryResult results) : base(lastUpdateDateTime, status, kind, taskName)
        {
            Results = results;
            Kind = kind;
        }

        /// <summary> Gets or sets the results. </summary>
        public SummaryResult Results { get; set; }
    }
}
