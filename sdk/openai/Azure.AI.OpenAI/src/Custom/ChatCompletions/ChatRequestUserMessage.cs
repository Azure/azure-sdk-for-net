// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE:
//   Depending on the model being used, "Content" may either be a plain string or an array of content items.
//   We choose to represent this union type as two parallel properties in the user request message class and
//   conditionally serialize based on which instantiation was used.

[CodeGenSuppress("ChatRequestUserMessage", typeof(BinaryData))]
[CodeGenSerialization(nameof(Content), SerializationValueHook = nameof(SerializeContent))]
public partial class ChatRequestUserMessage : ChatRequestMessage
{
    /// <summary>
    /// Gets the plain text content associated with this message. Null if the message was instantiated using a
    /// multimodal content item collection.
    /// </summary>
    /// <remarks>
    /// <see cref="ChatRequestUserMessage"/> may use either plain text content, which is represented by this property,
    /// or a collection of content items instead represented by <see cref="MultimodalContentItems"/>.
    /// </remarks>
    public string Content { get; protected set; }

    /// <summary>
    /// Gets the multimodal content item content associated with this message. Null if the message was instantiated
    /// using a plain text content.
    /// </summary>
    /// <remarks>
    /// <see cref="ChatRequestUserMessage"/> may use either plain text content, which is represented by
    /// <see cref="Content"/>, or a collection of content items instead represented by this property.
    /// </remarks>
    public IList<ChatMessageContentItem> MultimodalContentItems { get; }

    /// <summary>
    /// Creates a new instance of ChatRequestUserMessage using plain text content.
    /// </summary>
    /// <param name="content"> The plain text content associated with the message. </param>
    /// <exception cref="ArgumentException">
    /// <paramref name="content"/> is null or empty.
    /// </exception>
    public ChatRequestUserMessage(string content)
    {
        if (content == null)
        {
            throw new ArgumentNullException(nameof(content));
        }
        if (content.Length == 0)
        {
            throw new ArgumentException("Value cannot be an empty string.", nameof(content));
        }
        Role = ChatRole.User;
        Content = content;
    }

    /// <summary>
    /// Creates a new instance of ChatRequestUserMessage using a collection of structured content.
    /// </summary>
    /// <param name="content"> The collection of structured content associated with the message. </param>
    /// <exception cref="ArgumentException">
    /// <paramref name="content"/> is null or empty.
    /// </exception>
    public ChatRequestUserMessage(IEnumerable<ChatMessageContentItem> content)
    {
        if (content == null)
        {
            throw new ArgumentNullException(nameof(content));
        }
        // .NET Framework's Enumerable.Any() always allocates an enumerator, so we optimize for collections here.
        if (content is ICollection<ChatMessageContentItem> collectionOfT && collectionOfT.Count == 0)
        {
            throw new ArgumentException("Value cannot be an empty collection.", nameof(content));
        }
        if (content is ICollection collection && collection.Count == 0)
        {
            throw new ArgumentException("Value cannot be an empty collection.", nameof(content));
        }
        using IEnumerator<ChatMessageContentItem> e = content.GetEnumerator();
        if (!e.MoveNext())
        {
            throw new ArgumentException("Value cannot be an empty collection.", nameof(content));
        }
        Role = ChatRole.User;
        MultimodalContentItems = content.ToList();
    }

    /// <summary>
    /// Creates a new instance of ChatRequestUserMessage using a collection of structured content.
    /// </summary>
    /// <param name="content"> The collection of structured content associated with the message. </param>
    /// <exception cref="ArgumentException">
    /// <paramref name="content"/> is null or empty.
    /// </exception>
    public ChatRequestUserMessage(params ChatMessageContentItem[] content)
    {
        if (content == null)
        {
            throw new ArgumentNullException(nameof(content));
        }
        if (content.Length == 0)
        {
            throw new ArgumentException("Value cannot be an empty collection.", nameof(content));
        }
        Role = ChatRole.User;
        MultimodalContentItems = content.ToList();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void SerializeContent(Utf8JsonWriter writer)
    {
        if (MultimodalContentItems != null)
        {
            writer.WriteStartArray();
            foreach (ChatMessageContentItem item in MultimodalContentItems)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
        }
        else if (!string.IsNullOrEmpty(Content))
        {
            writer.WriteStringValue(Content);
        }
    }
}
