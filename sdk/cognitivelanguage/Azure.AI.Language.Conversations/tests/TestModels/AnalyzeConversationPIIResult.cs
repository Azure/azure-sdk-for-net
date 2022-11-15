// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Result from the personally identifiable information detection and redaction operation performed on a list of conversations. </summary>
    public partial class AnalyzeConversationPIIResult : AnalyzeConversationJobResult
    {
        /// <summary> Initializes a new instance of AnalyzeConversationPIIResult. </summary>
        /// <param name="lastUpdateDateTime"> The last updated time in UTC for the task. </param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        /// <param name="results"> The result from PII detection and redaction operation for each conversation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="results"/> is null. </exception>
        public AnalyzeConversationPIIResult(DateTimeOffset lastUpdateDateTime, State status, ConversationPIIResults results) : base(lastUpdateDateTime, status)
        {
            Argument.AssertNotNull(results, nameof(results));

            Results = results;
            Kind = AnalyzeConversationResultsKind.ConversationalPIIResults;
        }

        /// <summary> Initializes a new instance of AnalyzeConversationPIIResult. </summary>
        /// <param name="lastUpdateDateTime"> The last updated time in UTC for the task. </param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        /// <param name="kind"> Enumeration of supported Conversation Analysis task results. </param>
        /// <param name="taskName"></param>
        /// <param name="results"> The result from PII detection and redaction operation for each conversation. </param>
        internal AnalyzeConversationPIIResult(DateTimeOffset lastUpdateDateTime, State status, AnalyzeConversationResultsKind kind, string taskName, ConversationPIIResults results) : base(lastUpdateDateTime, status, kind, taskName)
        {
            Results = results;
            Kind = kind;
        }

        /// <summary> The result from PII detection and redaction operation for each conversation. </summary>
        public ConversationPIIResults Results { get; set; }
    }
}
