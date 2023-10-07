// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core;

namespace Azure.AI.Chat;

public partial class ChatCompletionOptions
{
    internal bool Stream { get; } = false;

    /// <summary> Initializes a new instance of ChatCompletionOptions. </summary>
    /// <param name="messages"> placeholder. </param>
    /// <param name="sessionState"> placeholder. </param>
    /// <param name="extraArguments"> placeholder. </param>
    public  ChatCompletionOptions(IList<ChatMessage> messages, BinaryData sessionState, IDictionary<string, BinaryData> extraArguments = null)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Messages = messages;
        SessionState = sessionState;
        ExtraArguments = extraArguments;
    }

    /// <summary> Initializes a new instance of ChatCompletionOptions. </summary>
    /// <param name="messages"> placeholder. </param>
    /// <param name="extraArguments"> placeholder. </param>
    public  ChatCompletionOptions(IList<ChatMessage> messages, IDictionary<string, BinaryData> extraArguments)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Messages = messages;
        ExtraArguments = extraArguments;
    }
}
