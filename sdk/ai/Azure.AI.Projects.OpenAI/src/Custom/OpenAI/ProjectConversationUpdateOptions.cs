// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("UpdateConversationRequest")]
public partial class ProjectConversationUpdateOptions
{
    [CodeGenMember("Metadata")]
    private global::Azure.AI.Projects.OpenAI.InternalMetadataContainer InternalMetadata { get; set; }
        = new global::Azure.AI.Projects.OpenAI.InternalMetadataContainer(new ChangeTrackingDictionary<string, string>(), null);

    public IDictionary<string, string> Metadata => InternalMetadata.AdditionalProperties;
}
