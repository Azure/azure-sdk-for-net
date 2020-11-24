// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Chat.Models
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
        /// <param name="priority"> The chat message priority. </param>
        /// <param name="version"> Version of the chat message. </param>
        /// <param name="content"> Content of the chat message. </param>
        /// <param name="senderDisplayName"> The display name of the chat message sender. </param>
        /// <param name="createdOn"> The timestamp when the chat message arrived at the server. </param>
        /// <param name="senderId"> The id of the chat message sender. </param>
        /// <param name="deletedOn"> The timestamp when the chat message was deleted. </param>
        /// <param name="editedOn"> The timestamp when the chat message was edited. </param>
        /// <returns>A new <see cref="ChatMessage"/> instance for mocking.</returns>
        public static ChatMessage ChatMessage(string id, string type, ChatMessagePriority? priority, string version, string content, string senderDisplayName, DateTimeOffset? createdOn, string senderId, DateTimeOffset? deletedOn, DateTimeOffset? editedOn)
            => new ChatMessage(id, type, priority, version, content, senderDisplayName, createdOn, senderId, deletedOn, editedOn);

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatThreadInfo"/> class.
        /// </summary>
        /// <param name="id"> Chat thread id. </param>
        /// <param name="topic"> Chat thread topic. </param>
        /// <param name="isDeleted"> Flag if a chat thread is soft deleted. </param>
        /// <param name="lastMessageReceivedOn"> The timestamp when the last message arrived at the server. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <returns>A new <see cref="ChatThreadInfo"/> instance for mocking.</returns>
        public static ChatThreadInfo ChatThreadInfo(string id, string topic, bool? isDeleted, DateTimeOffset? lastMessageReceivedOn)
            => new ChatThreadInfo(id, topic, isDeleted, lastMessageReceivedOn);

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadReceipt"/> class.
        /// </summary>
        /// <param name="senderId"> Id of the of message sender. </param>
        /// <param name="chatMessageId"> Id for the chat message that has been read. </param>
        /// <param name="readOn"> Read receipt timestamp. </param>
        /// <returns>A new <see cref="ReadReceipt"/> instance for mocking.</returns>
        public static ReadReceipt ReadReceipt(string senderId, string chatMessageId, DateTimeOffset? readOn)
            => new ReadReceipt(senderId, chatMessageId, readOn);

        /// <summary>
        /// Initializes a new instance of the <see cref="SendChatMessageResult"/> class.
        /// </summary>
        /// <param name="id"> A server-generated message id. </param>
        /// <returns>A new <see cref="SendChatMessageResult"/> instance for mocking.</returns>
        public static SendChatMessageResult SendChatMessageResult(string id)
            => new SendChatMessageResult(id);
    }
}
