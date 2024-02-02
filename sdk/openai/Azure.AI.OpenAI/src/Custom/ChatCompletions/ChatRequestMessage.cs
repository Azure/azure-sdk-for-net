// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE: here to promote the visibility of Role to public despite it being used as the JSON object discriminator.

public partial class ChatRequestMessage
{
    /// <summary> The chat role associated with this message. </summary>
    public ChatRole Role { get; set; }
}
