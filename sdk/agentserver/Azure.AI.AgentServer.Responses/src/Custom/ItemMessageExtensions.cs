// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Extension methods for <see cref="ItemMessage"/> that provide typed access
/// to the <see cref="ItemMessage.Content"/> BinaryData property.
/// </summary>
public static class ItemMessageExtensions
{
    /// <summary>
    /// Expands the <see cref="ItemMessage.Content"/> BinaryData into a typed list of
    /// <see cref="MessageContent"/> objects. A plain JSON string is wrapped as an
    /// input text content part. A JSON array is deserialized
    /// element-by-element via <see cref="MessageContent"/> polymorphic deserialization.
    /// </summary>
    /// <param name="message">The item message to expand content from.</param>
    /// <returns>
    /// A list of deserialized content parts, or an empty list if content is <c>null</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception>
    /// <exception cref="FormatException">
    /// The content BinaryData contains a JSON value that is neither a string nor an array.
    /// Message: <c>"Expected JSON array or string for item content"</c>.
    /// </exception>
    public static List<MessageContent> GetContentExpanded(this ItemMessage message)
    {
        Argument.AssertNotNull(message, nameof(message));
        if (RawMessageContentRegistry.TryGetContent(message, out BinaryData? rawContent))
        {
            return BinaryDataExpansionHelpers.ExpandContent(rawContent);
        }

        try
        {
            return message.Content.Select(ToMessageContent).ToList();
        }
        catch (Exception ex) when (ex is JsonException or InvalidOperationException)
        {
            throw new FormatException("Expected JSON array, object, or string for item content", ex);
        }
    }

    internal static class RawMessageContentRegistry
    {
        private static readonly ConditionalWeakTable<ItemMessage, BinaryDataHolder> s_content = new();

        internal static void Register(ItemMessage message, BinaryData content)
        {
            s_content.Remove(message);
            s_content.Add(message, new BinaryDataHolder(content));
        }

        internal static bool TryGetContent(ItemMessage message, out BinaryData? content)
        {
            if (s_content.TryGetValue(message, out BinaryDataHolder? holder))
            {
                content = holder.Content;
                return true;
            }

            content = null;
            return false;
        }

        private sealed class BinaryDataHolder
        {
            internal BinaryDataHolder(BinaryData content)
            {
                Content = content;
            }

            internal BinaryData Content { get; }
        }
    }

    private static MessageContent ToMessageContent(ResponseContentPart part)
    {
        return part.Kind switch
        {
            ResponseContentPartKind.InputText => ResponseContentPart.CreateInputTextPart(part.Text ?? string.Empty),
            ResponseContentPartKind.OutputText => ResponseContentPart.CreateOutputTextPart(
                part.Text ?? string.Empty,
                part.OutputTextAnnotations),
            ResponseContentPartKind.Refusal => ResponseContentPart.CreateRefusalPart(part.Refusal ?? string.Empty),
            ResponseContentPartKind.InputImage when part.InputImageUri is not null => ResponseContentPart.CreateInputImagePart(
                new Uri(part.InputImageUri, UriKind.RelativeOrAbsolute),
                part.InputImageDetailLevel),
            ResponseContentPartKind.InputImage => ResponseContentPart.CreateInputImagePart(
                part.InputImageFileId,
                part.InputImageDetailLevel),
            ResponseContentPartKind.InputFile when part.InputFileBytes is not null => ResponseContentPart.CreateInputFilePart(
                part.InputFileBytes,
                part.InputFileBytesMediaType,
                part.InputFilename),
            ResponseContentPartKind.InputFile when part.InputFileUri is not null => ResponseContentPart.CreateInputFilePart(part.InputFileUri),
            ResponseContentPartKind.InputFile => ResponseContentPart.CreateInputFilePart(part.InputFileId),
            _ => throw new FormatException($"Unsupported message content part kind '{part.Kind}'."),
        };
    }

    private static ImageDetail ToImageDetail(string? detail)
    {
        return Enum.TryParse<ImageDetail>(detail, ignoreCase: true, out var parsed)
            ? parsed
            : ImageDetail.Auto;
    }

    private static string ToFileData(BinaryData? fileBytes)
    {
        if (fileBytes is null)
        {
            return string.Empty;
        }

        string value = fileBytes.ToString();
        return value.StartsWith("data:", StringComparison.OrdinalIgnoreCase)
            ? value
            : $"data:application/octet-stream;base64,{Convert.ToBase64String(fileBytes.ToArray())}";
    }
}
