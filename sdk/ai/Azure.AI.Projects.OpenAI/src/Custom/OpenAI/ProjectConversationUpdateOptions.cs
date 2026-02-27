// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("UpdateConversationBody")]
[CodeGenSuppress(nameof(ProjectConversationUpdateOptions), typeof(global::Azure.AI.Projects.OpenAI.InternalMetadataContainer))]
public partial class ProjectConversationUpdateOptions
{
    [CodeGenMember("Metadata")]
    private global::Azure.AI.Projects.OpenAI.InternalMetadataContainer InternalMetadata { get; set; }

    public IDictionary<string, string> Metadata => InternalMetadata.AdditionalProperties;

    /// <summary> Initializes a new instance of <see cref="ProjectConversationUpdateOptions"/>. </summary>
    public ProjectConversationUpdateOptions()
    {
        InternalMetadata = new global::Azure.AI.Projects.OpenAI.InternalMetadataContainer(new ChangeTrackingDictionary<string, string>(), null);
    }

    /// <summary> Initializes a new instance of <see cref="ProjectConversationUpdateOptions"/>. </summary>
    /// <param name="metadata">
    /// Set of 16 key-value pairs that can be attached to an object. This can be
    /// useful for storing additional information about the object in a structured
    /// format, and querying for objects via API or the dashboard.
    ///
    /// Keys are strings with a maximum length of 64 characters. Values are strings
    /// with a maximum length of 512 characters.
    /// </param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    internal ProjectConversationUpdateOptions(IDictionary<string, string> metadata, IDictionary<string, BinaryData> additionalBinaryDataProperties)
    {
        InternalMetadata = new global::Azure.AI.Projects.OpenAI.InternalMetadataContainer(metadata, null);
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    /// <summary> Keeps track of any properties unknown to the library. </summary>
    private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;
}
