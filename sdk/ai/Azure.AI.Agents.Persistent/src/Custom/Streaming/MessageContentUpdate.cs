// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// Represents a streaming update to <see cref="PersistentThreadMessage"/> content as part of the Agents API.
/// </summary>
/// <remarks>
/// Distinct <see cref="MessageContentUpdate"/> instances will be generated for each <see cref="MessageContent"/> part
/// and each content subcomponent, such as <see cref="TextAnnotationUpdate"/> instances, even if this information
/// arrived in the same response chunk.
/// </remarks>
public partial class MessageContentUpdate : StreamingUpdate
{
    /// <summary> Gets the identifier of the message being updated. </summary>
    public string MessageId => _delta.Id;

    /// <inheritdoc cref="MessageDeltaContent.Index"/>
    public int MessageIndex => _textContent?.Index
        ?? _imageFileContent?.Index
        ?? TextAnnotation?.ContentIndex
        ?? 0;

    /// <summary> Gets the role of the message author, if available. </summary>
    public MessageRole? Role => _delta.Delta?.Role;

    /// <summary> Gets the file identifier for an image file content part, if applicable. </summary>
    public string ImageFileId => _imageFileContent?.ImageFile?.FileId;

    /// <summary> Gets the text value of the content part, if applicable. </summary>
    public string Text => _textContent?.Text?.Value;

    /// <summary>
    /// An update to an annotation associated with a specific content item in the message's content items collection.
    /// </summary>
    public TextAnnotationUpdate TextAnnotation { get; }

    private readonly MessageDeltaImageFileContent _imageFileContent;
    private readonly MessageDeltaTextContent _textContent;
    private readonly MessageDeltaChunk _delta;

    internal MessageContentUpdate(MessageDeltaChunk delta, MessageDeltaContent content)
        : base(StreamingUpdateReason.MessageUpdated)
    {
        _delta = delta;
        _textContent = content as MessageDeltaTextContent;
        _imageFileContent = content as MessageDeltaImageFileContent;
    }

    internal MessageContentUpdate(MessageDeltaChunk delta, TextAnnotationUpdate annotation)
        : base(StreamingUpdateReason.MessageUpdated)
    {
        _delta = delta;
        TextAnnotation = annotation;
    }

    internal static IEnumerable<MessageContentUpdate> DeserializeMessageContentUpdates(
        JsonElement element,
        StreamingUpdateReason _,
        ModelReaderWriterOptions options = null)
    {
        MessageDeltaChunk deltaObject = MessageDeltaChunk.DeserializeMessageDeltaChunk(element, options ?? ModelSerializationExtensions.WireOptions);
        List<MessageContentUpdate> updates = [];
        foreach (MessageDeltaContent deltaContent in deltaObject.Delta.Content ?? [])
        {
            updates.Add(new(deltaObject, deltaContent));
            if (deltaContent is MessageDeltaTextContent textContent)
            {
                foreach (MessageDeltaTextAnnotation internalAnnotation in textContent.Text.Annotations)
                {
                    TextAnnotationUpdate annotation = new(internalAnnotation);
                    updates.Add(new(deltaObject, annotation));
                }
            }
        }
        return updates;
    }
}
