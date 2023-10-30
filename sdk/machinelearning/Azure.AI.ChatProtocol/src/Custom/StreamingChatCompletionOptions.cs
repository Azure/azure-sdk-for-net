// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.ChatProtocol;

#pragma warning disable AZC0030 // Disabling error about renaming type to Options
[CodeGenModel("StreamingChatCompletionOptionsunknownRecord")]
public partial class StreamingChatCompletionOptions
{
    internal bool Stream { get; } = true;

    /// <summary> Initializes a new instance of ChatCompletionOptions. </summary>
    /// <param name="messages"> The collection of context messages associated with this completion request. </param>
    /// <param name="sessionState"> Backend-specific information for the tracking of a session. </param>
    /// <param name="context"> Backend-specific context or arguments. </param>
    public StreamingChatCompletionOptions(IList<ChatMessage> messages, BinaryData sessionState, IDictionary<string, BinaryData> context = null)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Messages = messages;
        SessionState = sessionState;
        Context = context;
    }

    /// <summary> Initializes a new instance of ChatCompletionOptions. </summary>
    /// <param name="messages"> The collection of context messages associated with this completion request. </param>
    /// <param name="context"> Backend-specific context or arguments. </param>
    public StreamingChatCompletionOptions(IList<ChatMessage> messages, IDictionary<string, BinaryData> context)
    {
        Argument.AssertNotNull(messages, nameof(messages));
        Messages = messages;
        Context = context;
    }
}
#pragma warning restore AZC0030
