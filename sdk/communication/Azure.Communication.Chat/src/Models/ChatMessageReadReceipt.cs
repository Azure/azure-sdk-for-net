// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Chat
{
    [CodeGenModel("ChatMessageReadReceipt")]
    public partial class ChatMessageReadReceipt
    {
        internal ChatMessageReadReceipt(string senderId, string chatMessageId, DateTimeOffset readOn)
        {
            SenderId = senderId;
            Sender = new CommunicationUserIdentifier(senderId);
            ChatMessageId = chatMessageId;
            ReadOn = readOn;
        }

        /// <summary>
        /// The <see cref="CommunicationUserIdentifier" /> for the message.
        /// </summary>
        public CommunicationIdentifier Sender { get; }
        internal string SenderId { get; }
    }
}
