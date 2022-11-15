// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Result from the sentiment analysis operation performed on a list of conversations. </summary>
    public partial class AnalyzeConversationSentimentResult : AnalyzeConversationJobResult
    {
        /// <summary> Initializes a new instance of AnalyzeConversationSentimentResult. </summary>
        /// <param name="lastUpdateDateTime"> The last updated time in UTC for the task. </param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        /// <param name="results"> The result from sentiment analysis operation for each conversation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="results"/> is null. </exception>
        public AnalyzeConversationSentimentResult(DateTimeOffset lastUpdateDateTime, State status, ConversationSentimentResults results) : base(lastUpdateDateTime, status)
        {
            Argument.AssertNotNull(results, nameof(results));

            Results = results;
            Kind = AnalyzeConversationResultsKind.ConversationalSentimentResults;
        }

        /// <summary> Initializes a new instance of AnalyzeConversationSentimentResult. </summary>
        /// <param name="lastUpdateDateTime"> The last updated time in UTC for the task. </param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        /// <param name="kind"> Enumeration of supported Conversation Analysis task results. </param>
        /// <param name="taskName"></param>
        /// <param name="results"> The result from sentiment analysis operation for each conversation. </param>
        internal AnalyzeConversationSentimentResult(DateTimeOffset lastUpdateDateTime, State status, AnalyzeConversationResultsKind kind, string taskName, ConversationSentimentResults results) : base(lastUpdateDateTime, status, kind, taskName)
        {
            Results = results;
            Kind = kind;
        }

        /// <summary> The result from sentiment analysis operation for each conversation. </summary>
        public ConversationSentimentResults Results { get; set; }
    }
}
