// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// The base class of a conversation task result.
    /// Please note <see cref="AnalyzeConversationTaskResult"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="ConversationalTaskResult"/>.
    /// </summary>
    public partial class AnalyzeConversationTaskResult
    {
        /// <summary> Initializes a new instance of AnalyzeConversationTaskResult. </summary>
        internal AnalyzeConversationTaskResult()
        {
        }

        /// <summary> Initializes a new instance of AnalyzeConversationTaskResult. </summary>
        /// <param name="kind"> Enumeration of supported conversational task results. </param>
        internal AnalyzeConversationTaskResult(AnalyzeConversationTaskResultsKind kind)
        {
            Kind = kind;
        }

        /// <summary> Enumeration of supported conversational task results. </summary>
        internal AnalyzeConversationTaskResultsKind Kind { get; set; }
    }
}
