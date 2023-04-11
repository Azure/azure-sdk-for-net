// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Azure.Communication.Chat
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class CreateChatThreadOptions
    {
        public CreateChatThreadOptions(string topic)
        {
            Topic = topic;
        }
        public string Topic { get; }

        public IList<ChatParticipant> Participants { get; }

        public string IdempotencyToken { get; set; }

        public ChatRetentionPolicy RetentionPolicy { get; set; }
    }
}
