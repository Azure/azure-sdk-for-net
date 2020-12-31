// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Chat
{
    [CodeGenModel("ReadReceipt")]
    public partial class ReadReceipt
    {
        internal ReadReceipt(string senderId, string chatMessageId, DateTimeOffset? readOn)
        {
            SenderId = senderId;
            Sender = new CommunicationUserIdentifier(senderId);
            ChatMessageId = chatMessageId;
            ReadOn = readOn;
        }

        /// <summary>
        /// The <see cref="CommunicationUserIdentifier" /> for the message.
        /// </summary>
        public CommunicationUserIdentifier Sender { get; }
        internal string SenderId { get; }
    }
}
