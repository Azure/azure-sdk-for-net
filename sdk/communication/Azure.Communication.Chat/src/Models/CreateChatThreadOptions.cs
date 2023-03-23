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
        public string Topic { get; set; }

        public IEnumerable<ChatParticipant> Participants { get; set; }

        public string IdempotencyToken { get; set; }

        public RetentionPolicy RetentionPolicy { get; set; }
    }
}
