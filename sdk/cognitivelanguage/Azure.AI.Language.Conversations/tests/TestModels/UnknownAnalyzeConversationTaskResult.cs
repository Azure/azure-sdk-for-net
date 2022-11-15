// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The UnknownAnalyzeConversationTaskResult. </summary>
    internal partial class UnknownAnalyzeConversationTaskResult : AnalyzeConversationTaskResult
    {
        /// <summary> Initializes a new instance of UnknownAnalyzeConversationTaskResult. </summary>
        /// <param name="kind"> Enumeration of supported conversational task results. </param>
        internal UnknownAnalyzeConversationTaskResult(AnalyzeConversationTaskResultsKind kind) : base(kind)
        {
            Kind = kind;
        }
    }
}
