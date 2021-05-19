// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Chat
{
    /// <summary> Chat message. </summary>
    public class ChatMessage
    {
        internal ChatMessage(ChatMessageInternal chatMessageInternal)
        {
            Id = chatMessageInternal.Id;
            Type = chatMessageInternal.Type;
            SequenceId = chatMessageInternal.SequenceId;
            Version = chatMessageInternal.Version;
            Content = new ChatMessageContent(chatMessageInternal.Content);
            SenderDisplayName = chatMessageInternal.SenderDisplayName;
            CreatedOn = chatMessageInternal.CreatedOn;
            if (chatMessageInternal.SenderCommunicationIdentifier != null)
            {
                Sender = CommunicationIdentifierSerializer.Deserialize(chatMessageInternal.SenderCommunicationIdentifier);
            }
            DeletedOn = chatMessageInternal.DeletedOn;
            EditedOn = chatMessageInternal.EditedOn;
        }

        internal ChatMessage(string id, ChatMessageType type, string sequenceId, string version, ChatMessageContent content, string senderDisplayName, DateTimeOffset createdOn, string senderId, DateTimeOffset? deletedOn, DateTimeOffset? editedOn)
        {
            Id = id;
            Type = type;
            SequenceId = sequenceId;
            Version = version;
            Content = content;
            SenderDisplayName = senderDisplayName;
            CreatedOn = createdOn;
            Sender = new CommunicationUserIdentifier(senderId);
            DeletedOn = deletedOn;
            EditedOn = editedOn;
        }

        /// <summary> The id of the chat message. This id is server generated. </summary>
        public string Id { get; }
        /// <summary> The chat message type. </summary>
        public ChatMessageType Type { get; }
        /// <summary> Sequence of the chat message in the conversation. </summary>
        public string SequenceId { get; }
        /// <summary> Version of the chat message. </summary>
        public string Version { get; }
        /// <summary> Content of a chat message. </summary>
        public ChatMessageContent Content { get; }
        /// <summary> The display name of the chat message sender. This property is used to populate sender name for push notifications. </summary>
        public string SenderDisplayName { get; }
        /// <summary> The timestamp when the chat message arrived at the server. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset CreatedOn { get; }
        /// <summary> The identifier of the chat message sender. </summary>
        public CommunicationIdentifier Sender { get; }
        /// <summary> The timestamp (if applicable) when the message was deleted. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? DeletedOn { get; }
        /// <summary> The last timestamp (if applicable) when the message was edited. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? EditedOn { get; }
    }
}
