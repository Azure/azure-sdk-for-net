// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Communication.Chat
{
    /// <summary>
    /// Model factory that enables mocking for the Chat library.
    /// </summary>
    [CodeGenType("CommunicationChatModelFactory")]
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
        public static ChatThreadItem ChatThreadItem(string id, string topic, DateTimeOffset? deletedOn, DateTimeOffset? lastMessageReceivedOn)
            => new ChatThreadItem(id, topic, deletedOn, lastMessageReceivedOn);

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatMessageReadReceipt"/> class.
        /// </summary>
        /// <param name="sender">CommunicationIdentifier of the of message sender. </param>
        /// <param name="chatMessageId"> Id for the chat message that has been read. </param>
        /// <param name="readOn"> Read receipt timestamp. </param>
        /// <returns>A new <see cref="ChatMessageReadReceipt"/> instance for mocking.</returns>
        public static ChatMessageReadReceipt ChatMessageReadReceipt(CommunicationIdentifier sender, string chatMessageId, DateTimeOffset readOn)
            => new ChatMessageReadReceipt(sender, chatMessageId, readOn);

        /// <summary>
        /// Initializes a new instance of the <see cref="Chat.ChatMessageContent"/> class.
        /// </summary>
        /// <param name="message"> Chat message. </param>
        /// <param name="topic"> Topic of the message content. </param>
        /// <param name="communicationUserIdentifier"> Communication user identifier.</param>
        /// <param name="participants"> List of chat participants. </param>
        /// <returns>A new <see cref="Chat.ChatMessageContent"/> instance for mocking.</returns>
        public static ChatMessageContent ChatMessageContent(string message, string topic, CommunicationUserIdentifier communicationUserIdentifier, IEnumerable<ChatParticipant> participants) => new ChatMessageContent(message, topic, communicationUserIdentifier, participants);

        /// <summary>
        /// Initializes a new instance of the <see cref="Chat.ChatMessageContent"/> class.
        /// </summary>
        /// <param name="message"> Chat message. </param>
        /// <param name="topic"> Topic of the message content. </param>
        /// <param name="communicationUserIdentifier"> Communication user identifier.</param>
        /// <param name="participants"> List of chat participants. </param>
        /// <param name="attachments"> List of chat attachments. </param>
        /// <returns>A new <see cref="Chat.ChatMessageContent"/> instance for mocking.</returns>
        public static ChatMessageContent ChatMessageContent(string message, string topic, CommunicationUserIdentifier communicationUserIdentifier, IEnumerable<ChatParticipant> participants, IEnumerable<ChatAttachment> attachments = null) => new ChatMessageContent(message, topic, communicationUserIdentifier, participants, attachments);

        /// <summary>
        /// Initializes a new instance of the <see cref="Chat.ChatThreadProperties"/> class.
        /// </summary>
        /// <param name="id"> Chat message ID. </param>
        /// <param name="topic"> Topic of the message content. </param>
        /// <param name="createdOn"> Created on date time </param>
        /// <param name="createdBy"> Created by </param>
        /// <param name="deletedOn"> Deleted on date time </param>
        /// <returns>A new <see cref="Chat.ChatThreadProperties"/> instance for mocking.</returns>
        public static ChatThreadProperties ChatThreadProperties(string id, string topic, DateTimeOffset createdOn, CommunicationIdentifier createdBy, DateTimeOffset deletedOn) => new ChatThreadProperties(id, topic, createdOn, createdBy, deletedOn);

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateChatThreadResult"/> class.
        /// </summary>
        /// <param name="chatThread"> Thread properties </param>
        /// <param name="invalidParticipants"> List of invalid participants</param>
        /// <returns>A new <see cref="CreateChatThreadResult"/> instance for mocking.</returns>
        public static CreateChatThreadResult CreateChatThreadResult(ChatThreadProperties chatThread, IEnumerable<ChatError> invalidParticipants) => new CreateChatThreadResult(chatThread, invalidParticipants);

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatAttachment"/> class.
        /// </summary>
        /// <param name="id"> Id of the attachment. </param>
        /// <param name="attachmentType"> The type of attachment. </param>
        /// <param name="name"> The name of the attachment content. </param>
        /// <param name="uri"> The URI where the attachment can be downloaded. </param>
        /// <param name="previewUri"> The URI where the preview of attachment can be downloaded. </param>
        /// <returns>A new <see cref="ChatAttachment"/> instance for mocking.</returns>
        public static ChatAttachment ChatAttachment(string id, ChatAttachmentType attachmentType, string name, Uri uri, Uri previewUri) => new ChatAttachment(id, attachmentType, name, uri, previewUri);

        /// <summary>
        /// Initializes a new instance of the <see cref="Chat.ChatParticipant"/> class.
        /// </summary>
        /// <param name="user"> User </param>
        /// <param name="displayName">Display name for the chat thread member.</param>
        /// <param name="shareHistoryTime"> Time from which the chat history is shared with the member. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`.</param>
        /// <returns>A new <see cref="Chat.ChatParticipant"/> instance for mocking.</returns>
        public static ChatParticipant ChatParticipant(CommunicationIdentifier user, string displayName, DateTimeOffset? shareHistoryTime) => new ChatParticipant(user, displayName, shareHistoryTime);

        /// <summary>
        /// Initializes a new instance of the <see cref="Chat.ChatParticipant"/> class.
        /// </summary>
        /// <param name="user"> User </param>
        /// <param name="displayName">Display name for the chat thread member.</param>
        /// <param name="shareHistoryTime"> Time from which the chat history is shared with the member. The timestamp is in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`.</param>
        /// <param name="metadata"> Property bag of participant metadata key - value pairs. </param>
        /// <returns>A new <see cref="Chat.ChatParticipant"/> instance for mocking.</returns>
        public static ChatParticipant ChatParticipant(CommunicationIdentifier user, string displayName, DateTimeOffset? shareHistoryTime, IDictionary<string, string> metadata) => new ChatParticipant(user, displayName, shareHistoryTime, metadata);

        /// <summary>
        /// Initializes a new instance of the <see cref="SendChatMessageResult"/> class.
        /// </summary>
        /// <param name="id"> A server-generated message id. </param>
        /// <returns>A new <see cref="SendChatMessageResult"/> instance for mocking.</returns>
        public static SendChatMessageResult SendChatMessageResult(string id) => new SendChatMessageResult(id);
    }
}
