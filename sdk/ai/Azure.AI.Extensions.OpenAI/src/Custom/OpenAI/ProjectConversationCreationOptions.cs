// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Represents options for creating a project conversation. </summary>
public partial class ProjectConversationCreationOptions
{
    private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

    /// <summary>
    /// Gets the initial items to include in the conversation context.
    /// You may add up to 20 items at a time.
    /// </summary>
    public IList<ResponseItem> Items { get; }

    /// <summary> Gets the metadata attached to the conversation. </summary>
    public IDictionary<string, string> Metadata { get; }

    /// <summary> Initializes a new instance of <see cref="ProjectConversationCreationOptions"/>. </summary>
    public ProjectConversationCreationOptions()
    {
        Metadata = new ChangeTrackingDictionary<string, string>();
        Items = new ChangeTrackingList<ResponseItem>();
    }

    internal ProjectConversationCreationOptions(
        IDictionary<string, string> metadata,
        IList<ResponseItem> items,
        IDictionary<string, BinaryData> additionalBinaryDataProperties)
    {
        Metadata = metadata;
        Items = items;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    /// <summary> Converts project conversation creation options into binary content. </summary>
    /// <param name="projectConversationCreationOptions"> The <see cref="ProjectConversationCreationOptions"/> to serialize into <see cref="BinaryContent"/>. </param>
    /// <returns> The binary content representation of the project conversation creation options. </returns>
    public static implicit operator BinaryContent(ProjectConversationCreationOptions projectConversationCreationOptions)
    {
        if (projectConversationCreationOptions == null)
        {
            return null;
        }
        return BinaryContent.Create(projectConversationCreationOptions, ModelSerializationExtensions.WireOptions);
    }
}
