// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;

namespace Azure.Communication.Chat
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class CreateChatThreadOptions
    {
        public CreateChatThreadOptions(string topic)
        {
            Topic = topic;
            Metadata = new Dictionary<string, string>();
        }
        public string Topic { get; }

        public IList<ChatParticipant> Participants { get; }

        public string IdempotencyToken { get; set; }

        public IReadOnlyDictionary<string, string> Metadata { get; }
    }
}
