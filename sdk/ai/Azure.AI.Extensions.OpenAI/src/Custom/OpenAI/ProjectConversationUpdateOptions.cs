// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Represents options for updating a project conversation. </summary>
public partial class ProjectConversationUpdateOptions
{
    private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

    /// <summary> Gets the metadata to update on the conversation. </summary>
    public IDictionary<string, string> Metadata { get; }

    /// <summary> Initializes a new instance of <see cref="ProjectConversationUpdateOptions"/>. </summary>
    public ProjectConversationUpdateOptions()
    {
        Metadata = new ChangeTrackingDictionary<string, string>();
    }

    internal ProjectConversationUpdateOptions(IDictionary<string, string> metadata, IDictionary<string, BinaryData> additionalBinaryDataProperties)
    {
        Metadata = metadata;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    /// <summary> Converts project conversation update options into binary content. </summary>
    /// <param name="ProjectConversationUpdateOptions"> The options to serialize. </param>
    /// <returns> The binary content representation of the options. </returns>
    public static implicit operator BinaryContent(ProjectConversationUpdateOptions ProjectConversationUpdateOptions)
    {
        if (ProjectConversationUpdateOptions == null)
        {
            return null;
        }
        return BinaryContent.Create(ProjectConversationUpdateOptions, ModelSerializationExtensions.WireOptions);
    }
}
