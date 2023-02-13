// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// The base class of a conversation input task.
    /// Please note <see cref="AnalyzeConversationTask"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="ConversationalTask"/>.
    /// </summary>
    public partial class AnalyzeConversationTask
    {
        /// <summary> Initializes a new instance of AnalyzeConversationTask. </summary>
        public AnalyzeConversationTask()
        {
        }

        /// <summary> Enumeration of supported Conversation tasks. </summary>
        internal AnalyzeConversationTaskKind Kind { get; set; }
    }
}
