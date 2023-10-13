// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core;

namespace Azure.AI.ChatProtocol;

[CodeGenModel("ChatCompletionOptionsunknownRecord")]
public partial class ChatCompletionOptions
{
    internal bool Stream { get; } = false;

    /// <summary> Initializes a new instance of ChatCompletionOptions. </summary>
    /// <param name="messages"> placeholder. </param>
    /// <param name="sessionState"> placeholder. </param>
    /// <param name="context"> placeholder. </param>
    public  ChatCompletionOptions(IList<ChatMessage> messages, BinaryData sessionState, IDictionary<string, BinaryData> context = null)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Messages = messages;
        SessionState = sessionState;
        Context = context;
    }

    /// <summary> Initializes a new instance of ChatCompletionOptions. </summary>
    /// <param name="messages"> placeholder. </param>
    /// <param name="context"> placeholder. </param>
    public  ChatCompletionOptions(IList<ChatMessage> messages, IDictionary<string, BinaryData> context)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Messages = messages;
        Context = context;
    }
}
