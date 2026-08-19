// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Represents a conversation associated with a Microsoft Foundry project. </summary>
public partial class ProjectConversation
{
    private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

    internal ProjectConversation()
    {
    }

    internal ProjectConversation(
        string id,
        string @object,
        IDictionary<string, string> metadata,
        DateTimeOffset createdAt,
        IDictionary<string, BinaryData> additionalBinaryDataProperties)
    {
        Id = id;
        Object = @object;
        Metadata = metadata;
        CreatedAt = createdAt;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    private string Object { get; } = "conversation";

    /// <summary> The unique ID of the conversation. </summary>
    public string Id { get; }

    /// <summary> Gets the metadata attached to the conversation. </summary>
    public IDictionary<string, string> Metadata { get; }

    /// <summary> The time at which the conversation was created. </summary>
    public DateTimeOffset CreatedAt { get; }

    /// <summary> Converts a raw client result into a project conversation. </summary>
    /// <param name="result"> The result to convert. </param>
    public static explicit operator ProjectConversation(ClientResult result)
    {
        using JsonDocument document = JsonDocument.Parse(result.GetRawResponse().Content);
        return DeserializeProjectConversation(document.RootElement, ModelSerializationExtensions.WireOptions);
    }

    /// <summary> Converts a project conversation into its conversation ID. </summary>
    /// <param name="conversation"> The project conversation to convert. </param>
    /// <returns> The conversation ID. </returns>
    public static implicit operator string(ProjectConversation conversation) => conversation.Id;
}
