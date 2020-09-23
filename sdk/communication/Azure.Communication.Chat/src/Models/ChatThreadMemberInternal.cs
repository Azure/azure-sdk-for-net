// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Communication;

namespace Azure.Communication.Chat
{
    [CodeGenModel("ChatThreadMember")]
    public partial class ChatThreadMemberInternal
    {
        internal ChatThreadMember ToChatThreadMember()
        {
            return new ChatThreadMember(this);
        }
    }
}
