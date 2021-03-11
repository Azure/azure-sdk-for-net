// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Chat
{
    /// <summary>The ChatThread.</summary>
    public class ChatThread
    {
        internal ChatThread(ChatThreadInternal chatThreadInternal)
        {
            Id = chatThreadInternal.Id;
            Topic = chatThreadInternal.Topic;
            CreatedOn = chatThreadInternal.CreatedOn;
            CreatedBy = CommunicationIdentifierSerializer.Deserialize(chatThreadInternal.CreatedByCommunicationIdentifier);
            DeletedOn = chatThreadInternal.DeletedOn;
        }

        /// <summary> Chat thread id. </summary>
        public string Id { get; }
        /// <summary> Chat thread topic. </summary>
        public string Topic { get; }
        /// <summary> The timestamp when the chat thread was created. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset CreatedOn { get; }
        /// <summary> Identifier of the chat thread owner. </summary>
        public CommunicationIdentifier CreatedBy { get; }
        /// <summary>The timestamp when the chat thread was deleted. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? DeletedOn { get; }
    }
}
