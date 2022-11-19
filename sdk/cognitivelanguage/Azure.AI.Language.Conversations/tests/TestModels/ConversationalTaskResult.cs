// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The results of a Conversation task. </summary>
    public partial class ConversationalTaskResult : AnalyzeConversationTaskResult
    {
        /// <summary> Initializes a new instance of ConversationalTaskResult. </summary>
        /// <param name="result"> Represents a conversation analysis response. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="result"/> is null. </exception>
        internal ConversationalTaskResult(AnalyzeConversationResult result)
        {
            Argument.AssertNotNull(result, nameof(result));

            Result = result;
            Kind = AnalyzeConversationTaskResultsKind.ConversationResult;
        }

        /// <summary> Initializes a new instance of ConversationalTaskResult. </summary>
        /// <param name="kind"> Enumeration of supported conversational task results. </param>
        /// <param name="result"> Represents a conversation analysis response. </param>
        internal ConversationalTaskResult(AnalyzeConversationTaskResultsKind kind, AnalyzeConversationResult result) : base(kind)
        {
            Result = result;
            Kind = kind;
        }

        /// <summary> Represents a conversation analysis response. </summary>
        public AnalyzeConversationResult Result { get; }
    }
}
