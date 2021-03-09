// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Communication.Chat
{
    /// <summary>
    /// Model factory that enables mocking for the Chat library.
    /// </summary>
    public static class ChatModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatMessage"/> class.
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
        /// <returns>A new <see cref="ChatMessage"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ChatMessage ChatMessage(string id, ChatMessageType type, string sequenceId, string version, ChatMessageContent content, string senderDisplayName, DateTimeOffset createdOn, string senderId, DateTimeOffset? deletedOn, DateTimeOffset? editedOn)
            => new ChatMessage(id, type, sequenceId, version, content, senderDisplayName, createdOn, senderId, deletedOn, editedOn);

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatThreadInfo"/> class.
        /// </summary>
        /// <param name="id"> Chat thread id. </param>
        /// <param name="topic"> Chat thread topic. </param>
        /// <param name="deletedOn"> The timestamp when the chat thread was deleted. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <param name="lastMessageReceivedOn"> The timestamp when the last message arrived at the server. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <returns>A new <see cref="ChatThreadInfo"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ChatThreadInfo ChatThreadInfo(string id, string topic, DateTimeOffset? deletedOn, DateTimeOffset? lastMessageReceivedOn)
            => new ChatThreadInfo(id, topic, deletedOn, lastMessageReceivedOn);

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
