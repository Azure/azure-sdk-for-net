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
        /// Initializes a new instance of the <see cref="ChatThreadItem"/> class.
        /// </summary>
        /// <param name="id"> Chat thread id. </param>
        /// <param name="topic"> Chat thread topic. </param>
        /// <param name="deletedOn"> The timestamp when the chat thread was deleted. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <param name="lastMessageReceivedOn"> The timestamp when the last message arrived at the server. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <returns>A new <see cref="ChatThreadItem"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ChatThreadItem ChatThreadItem(string id, string topic, DateTimeOffset? deletedOn, DateTimeOffset? lastMessageReceivedOn)
            => new ChatThreadItem(id, topic, deletedOn, lastMessageReceivedOn);

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

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatMessageContent"/> class.
        /// </summary>
        /// <param name="message"> Chat message. </param>
        /// <param name="topic"> Topic of the message content. </param>
        /// <param name="communicationUserIdentifier"> Communication user identifier.</param>
        /// <param name="participants"> List of chat participants </param>
        /// <returns>A new <see cref="ChatMessageContent"/> instance for mocking.</returns>
        public static ChatMessageContent ChatMessageContent(string message, string topic, CommunicationUserIdentifier communicationUserIdentifier, IReadOnlyList<ChatParticipant> participants) => new ChatMessageContent(message, topic, communicationUserIdentifier, participants);

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatThreadProperties"/> class.
        /// </summary>
        /// <param name="id"> Chat message. </param>
        /// <param name="topic"> Topic of the message content. </param>
        /// <param name="createdOn"> Created on date time </param>
        /// <param name="createdBy"> Created by </param>
        /// <param name="deletedOn"> Deleted on date time </param>
        /// <returns>A new <see cref="ChatThreadProperties"/> instance for mocking.</returns>
        public static ChatThreadProperties ChatThreadProperties(string id, string topic, DateTimeOffset createdOn, CommunicationIdentifier createdBy, DateTimeOffset deletedOn) => new ChatThreadProperties(id,topic,createdOn, createdBy, deletedOn);

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateChatThreadResult"/> class.
        /// </summary>
        /// <param name="chatThread"> Thread properties </param>
        /// <param name="invalidParticipants"> List of invalid participants</param>
        /// <returns>A new <see cref="CreateChatThreadResult"/> instance for mocking.</returns>
        public static CreateChatThreadResult CreateChatThreadResult(ChatThreadProperties chatThread, IReadOnlyList<ChatError> invalidParticipants) => new CreateChatThreadResult(chatThread, invalidParticipants);

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatParticipant"/> class.
        /// </summary>
        /// <param name="user"> User </param>
        /// <param name="displayName">Display name for the chat thread member.</param>
        /// <param name="shareHistoryTime"> Time from which the chat history is shared with the member. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`.</param>
        /// <returns>A new <see cref="ChatParticipant"/> instance for mocking.</returns>
        public static ChatParticipant ChatParticipant(CommunicationIdentifier user, string displayName, DateTimeOffset? shareHistoryTime) => new ChatParticipant(user, displayName, shareHistoryTime);

        ///// <summary>
        ///// Initializes a new instance of the <see cref="SendChatMessageOptions"/> class.
        ///// </summary>
        ///// <param name="content"> Content for the message </param>
        ///// <param name="messageType">The message type.</param>
        ///// <param name="senderDisplayName"> Time from which the chat history is shared with the member. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`.</param>
        ///// <param name="metadata"> Properties bag for custom attributes to the message in the form of key-value pair. </param>        /// <returns>A new <see cref="SendChatMessageOptions"/> instance for mocking.</returns>
        //public static SendChatMessageOptions SendChatMessageOptions(string content, ChatMessageType messageType, string senderDisplayName, IDictionary<string, string> metadata) => new SendChatMessageOptions(content, messageType, senderDisplayName, metadata);

        /// <summary>
        /// Initializes a new instance of the <see cref="SendChatMessageResult"/> class.
        /// </summary>
        /// <param name="id"> A server-generated message id. </param>
        /// <returns>A new <see cref="SendChatMessageResult"/> instance for mocking.</returns>
        public static SendChatMessageResult SendChatMessageResult(string id) => new SendChatMessageResult(id);

        ///// <summary>
        ///// Initializes a new instance of the <see cref="TypingNotificationOptions"/> class.
        ///// </summary>
        ///// <param name="senderDisplayName"> The display name of the message sender. This property is used to populate sender name for push notifications. </param>
        ///// <returns>A new <see cref="TypingNotificationOptions"/> instance for mocking.</returns>
        //public static TypingNotificationOptions TypingNotificationOptions(string senderDisplayName) => new TypingNotificationOptions { };

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="UpdateChatMessageOptions"/> class.
    //    /// </summary>
    //    /// <param name="messageId">The id of the chat message.</param>
    //    /// <param name="content">Content of a chat message. </param>
    //    /// <param name="metadata">Properties bag for custom attributes to the message in the form of key-value pair. </param>
    //    /// <returns>A new <see cref="UpdateChatMessageOptions"/> instance for mocking.</returns>
    //    public static UpdateChatMessageOptions UpdateChatMessageOptions(string messageId, string content, IDictionary<string, string> metadata) => new UpdateChatMessageOptions(messageId,content,metadata);
    }
}
