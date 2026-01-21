// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("UpdateConversationRequest")]
public partial class ProjectConversationUpdateOptions
{
    [CodeGenMember("Metadata")]
    private global::OpenAI.InternalMetadataContainer InternalMetadata { get; set; }

    public IDictionary<string, string> Metadata => InternalMetadata.AdditionalProperties;

    /// <summary> Initializes a new instance of <see cref="ProjectConversationUpdateOptions"/>. </summary>
    public ProjectConversationUpdateOptions()
    {
        InternalMetadata = new global::OpenAI.InternalMetadataContainer(new ChangeTrackingDictionary<string, string>(), null);
    }
}
