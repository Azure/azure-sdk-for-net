// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The option to set to call a Conversation project. </summary>
    public partial class ConversationCallingOptions
    {
        /// <summary> Initializes a new instance of ConversationCallingOptions. </summary>
        public ConversationCallingOptions()
        {
        }

        /// <summary> The language of the query in BCP 47 language representation.. </summary>
        public string Language { get; set; }
        /// <summary> If true, the service will return more detailed information. </summary>
        public bool? Verbose { get; set; }
        /// <summary> If true, the query will be saved for customers to further review in authoring, to improve the model quality. </summary>
        public bool? IsLoggingEnabled { get; set; }
    }
}
