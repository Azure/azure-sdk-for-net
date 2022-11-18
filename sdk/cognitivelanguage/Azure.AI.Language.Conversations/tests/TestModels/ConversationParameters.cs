// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> This is a set of request parameters for Customized Conversation projects. </summary>
    public partial class ConversationParameters : AnalysisParameters
    {
        /// <summary> Initializes a new instance of ConversationParameters. </summary>
        public ConversationParameters()
        {
            TargetProjectKind = TargetProjectKind.Conversation;
        }

        /// <summary> The option to set to call a Conversation project. </summary>
        public ConversationCallingOptions CallingOptions { get; set; }
    }
}
