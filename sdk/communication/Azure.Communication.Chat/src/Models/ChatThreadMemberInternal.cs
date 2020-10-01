// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Chat
{
    [CodeGenModel("ChatThreadMember")]
    internal partial class ChatThreadMemberInternal
    {
        internal ChatThreadMember ToChatThreadMember()
        {
            return new ChatThreadMember(this);
        }
    }
}
