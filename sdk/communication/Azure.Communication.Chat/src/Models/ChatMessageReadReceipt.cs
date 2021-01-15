// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Chat
{
    [CodeGenModel("ChatMessageReadReceipt")]
    public partial class ChatMessageReadReceipt
    {
        internal ChatMessageReadReceipt(CommunicationIdentifierModel sender, string chatMessageId, DateTimeOffset readOn)
        {
            RawSender = sender;
            Sender = CommunicationIdentifierSerializer.Deserialize(sender);
            ChatMessageId = chatMessageId;
            ReadOn = readOn;
        }

        /// <summary>
        /// The <see cref="CommunicationIdentifier" /> for the message.
        /// </summary>
        public CommunicationIdentifier Sender { get; }

        [CodeGenMember("Sender")]
        internal CommunicationIdentifierModel RawSender { get; }
    }
}
