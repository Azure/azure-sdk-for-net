// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;

namespace Azure.Communication.Chat
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UpdateChatThreadPropertiesOptions
    {
        public UpdateChatThreadPropertiesOptions()
        {
            Metadata = new Dictionary<string, string>();
        }
        public string Topic { get; set; }

        public IDictionary<string, string> Metadata { get; }
    }
}
