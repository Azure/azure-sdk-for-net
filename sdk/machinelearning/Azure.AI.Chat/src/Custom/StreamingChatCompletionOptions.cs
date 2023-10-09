// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Chat;

[CodeGenModel("StreamingChatCompletionOptionsunknownRecord")]
public partial class StreamingChatCompletionOptions
{
    internal bool Stream { get; } = true;

    /// <summary> Initializes a new instance of ChatCompletionOptions. </summary>
    /// <param name="messages"> placeholder. </param>
    /// <param name="sessionState"> placeholder. </param>
    /// <param name="extraArguments"> placeholder. </param>
    public StreamingChatCompletionOptions(IList<ChatMessage> messages, BinaryData sessionState, IDictionary<string, BinaryData> extraArguments = null)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Messages = messages;
        SessionState = sessionState;
        ExtraArguments = extraArguments;
    }

    /// <summary> Initializes a new instance of ChatCompletionOptions. </summary>
    /// <param name="messages"> placeholder. </param>
    /// <param name="extraArguments"> placeholder. </param>
    public StreamingChatCompletionOptions(IList<ChatMessage> messages, IDictionary<string, BinaryData> extraArguments)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Messages = messages;
        ExtraArguments = extraArguments;
    }
}
