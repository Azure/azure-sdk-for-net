// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Communication.Chat
{
    /// <summary>
    /// Model factory that enables mocking for the Chat library.
    /// </summary>
    public static partial class ChatModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Chat.ChatMessage"/> class.
        /// </summary>
        /// <param name="id"> The id of the chat message. </param>
        /// <param name="type"> The chat message priority. </param>
        /// <param name="sequenceId"> The sequenceId of the chat message. </param>
        /// <param name="version"> Version of the chat message. </param>
        /// <param name="content"> Content of the chat message. </param>
        /// <param name="senderDisplayName"> The display name of the chat message sender. </param>
        /// <param name="createdOn"> The timestamp when the chat message arrived at the server. </param>
        /// <param name="senderId"> The id of the chat message sender. </param>
        /// <param name="deletedOn"> The timestamp when the chat message was deleted. </param>
        /// <param name="editedOn"> The timestamp when the chat message was edited. </param>
        /// <param name="metadata"> Property bag of message metadata key - value pairs. </param>
        /// <returns>A new <see cref="Chat.ChatMessage"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ChatMessage ChatMessage(string id, ChatMessageType type, string sequenceId, string version, ChatMessageContent content, string senderDisplayName, DateTimeOffset createdOn, string senderId, DateTimeOffset? deletedOn, DateTimeOffset? editedOn, IReadOnlyDictionary<string, string> metadata)
            => new ChatMessage(id, type, sequenceId, version, content, senderDisplayName, createdOn, senderId, deletedOn, editedOn, metadata);

        /// <summary>
        /// Initializes a new instance of the <see cref="Chat.ChatMessage"/> class.
        /// </summary>
        /// <param name="id"> The id of the chat message. </param>
        /// <param name="type"> The chat message priority. </param>
        /// <param name="sequenceId"> The sequenceId of the chat message. </param>
        /// <param name="version"> Version of the chat message. </param>
        /// <param name="content"> Content of the chat message. </param>
        /// <param name="senderDisplayName"> The display name of the chat message sender. </param>
        /// <param name="createdOn"> The timestamp when the chat message arrived at the server. </param>
        /// <param name="senderId"> The id of the chat message sender. </param>
        /// <param name="deletedOn"> The timestamp when the chat message was deleted. </param>
        /// <param name="editedOn"> The timestamp when the chat message was edited. </param>
        /// <returns>A new <see cref="Chat.ChatMessage"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ChatMessage ChatMessage(string id, ChatMessageType type, string sequenceId, string version, ChatMessageContent content, string senderDisplayName, DateTimeOffset createdOn, string senderId, DateTimeOffset? deletedOn, DateTimeOffset? editedOn)
            => ChatMessage(id, type, sequenceId, version, content, senderDisplayName, createdOn, senderId, deletedOn, editedOn, null);

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatMessageReadReceipt"/> class.
        /// </summary>
        /// <param name="sender">CommunicationIdentifier of the of message sender. </param>
        /// <param name="chatMessageId"> Id for the chat message that has been read. </param>
        /// <param name="readOn"> Read receipt timestamp. </param>
        /// <returns>A new <see cref="ChatMessageReadReceipt"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ChatMessageReadReceipt ChatMessageReadReceipt(CommunicationIdentifier sender, string chatMessageId, DateTimeOffset readOn)
            => new ChatMessageReadReceipt(sender, chatMessageId, readOn);
    }
}
