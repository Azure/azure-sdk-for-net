// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE:
//   To facilitate easier use of the message object model hierarchy, we promote public visibility of Content to the
//   base type and also publicly expose Role.

public abstract partial class ChatRequestMessage
{
    /// <summary>
    /// Gets the plain text content associated with this message.
    /// </summary>
    /// <remarks>
    /// Note that the derived <see cref="ChatRequestUserMessage"/> type may specify a collection of
    /// <see cref="ChatMessageContentItem"/> instances for its content instead of this property. When doing so,
    /// <see cref="Content"/> will always be null.
    /// </remarks>
    public virtual string Content { get; protected set; }

    /// <summary>
    /// Gets the role associated with this message.
    /// </summary>
    public ChatRole Role { get; protected set; }
}
