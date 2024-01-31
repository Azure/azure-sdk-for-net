// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Chat
{
    /// <summary>
    /// SendChatMessageResult
    /// </summary>
    public class SendChatMessageResult
    {
        /// <summary> Initializes a new instance of SendChatMessageResult. </summary>
        /// <param name="sendChatMessageResultInternal"> send chat message result. </param>
        internal SendChatMessageResult(SendChatMessageResultInternal sendChatMessageResultInternal)
        {
            Id = sendChatMessageResultInternal.Id;
        }

        internal SendChatMessageResult(string id)
        {
            Id = id;
        }

        /// <summary> A server-generated message id. </summary>
        public string Id { get; }
    }
}
