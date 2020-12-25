// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Chat
{
    [CodeGenModel("ChatMessage")]
    public partial class ChatMessage
    {
        internal ChatMessage(string id, string type, ChatMessagePriority? priority, string version, string content, string senderDisplayName, DateTimeOffset? createdOn, string senderId, DateTimeOffset? deletedOn, DateTimeOffset? editedOn)
        {
            Id = id;
            Type = type;
            Priority = priority;
            Version = version;
            Content = content;
            SenderDisplayName = senderDisplayName;
            CreatedOn = createdOn;
            SenderId = senderId;
            DeletedOn = deletedOn;
            EditedOn = editedOn;
            Sender = new CommunicationUser(senderId);
        }

        /// <summary>
        /// The <see cref="CommunicationUser" /> for the message.
        /// </summary>
        public CommunicationUser Sender { get; }
        internal string SenderId { get; }
    }
}
