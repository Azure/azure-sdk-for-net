// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.Chat
{
    /// <summary> Options for the chat message. </summary>
    public class UpdateChatMessageOptions
    {
        /// <summary> The id of the chat message. </summary>
        public string MessageId { get; set; }
        /// <summary> Content of a chat message. </summary>
        public string Content { get; set; }
        /// <summary> Properties bag for custom attributes to the message in the form of key-value pair. </summary>
        public IDictionary<string, string> Metadata { get; } = new Dictionary<string, string>();
    }
}
