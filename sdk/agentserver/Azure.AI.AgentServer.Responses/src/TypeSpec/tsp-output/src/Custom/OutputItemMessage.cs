// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Custom partial extending <see cref="OutputItemMessage"/> with a convenience
/// constructor that defaults the role to <see cref="MessageRole.Assistant"/>.
/// All server output messages are assistant messages, so callers should not need
/// to specify the role explicitly.
/// </summary>
public partial class OutputItemMessage
{
    /// <summary>
    /// Creates an <see cref="OutputItemMessage"/> with the role defaulted to
    /// <see cref="MessageRole.Assistant"/>.
    /// </summary>
    /// <param name="id">The unique ID of the message.</param>
    /// <param name="status">The status of the message.</param>
    /// <param name="content">The content parts of the message.</param>
    public OutputItemMessage(string id, MessageStatus status, IEnumerable<MessageContent> content)
        : this(id, status, MessageRole.Assistant, content)
    {
    }
}
