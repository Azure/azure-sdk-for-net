// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenType("AzureChatMessageContext")]
[Experimental("AOAI001")]
public partial class ChatMessageContext
{
    /// <summary> Summary information about documents retrieved by the data retrieval operation. </summary>
    [CodeGenMember("AllRetrievedDocuments")]
    public ChatRetrievedDocument RetrievedDocuments { get; }
}
