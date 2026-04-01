// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Custom partial extending the generated <see cref="ItemMessage"/> with a
/// strongly-typed constructor that accepts typed content parts.
/// </summary>
public partial class ItemMessage
{
    /// <summary>
    /// Creates an <see cref="ItemMessage"/> with the specified role and strongly-typed content.
    /// The content list is serialized to BinaryData.
    /// </summary>
    /// <param name="role">The message role.</param>
    /// <param name="content">The typed content parts.</param>
    /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
    public ItemMessage(MessageRole role, IList<MessageContent> content)
        : base(ItemType.Message)
    {
        Argument.AssertNotNull(content, nameof(content));

        Role = role;

        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteStartArray();
            foreach (var item in content)
            {
                ((IJsonModel<MessageContent>)item).Write(writer, ModelReaderWriterOptions.Json);
            }
            writer.WriteEndArray();
        }

        Content = BinaryData.FromBytes(stream.ToArray());
    }

    /// <summary> The content of the message. </summary>
    public BinaryData Content { get; set; }
}
