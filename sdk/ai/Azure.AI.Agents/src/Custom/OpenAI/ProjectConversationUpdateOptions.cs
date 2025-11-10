// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Agents;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("UpdateConversationRequest")]
public partial class ProjectConversationUpdateOptions
{
    /// <summary> Initializes a new instance of <see cref="ProjectConversationUpdateOptions"/>. </summary>
    public ProjectConversationUpdateOptions()
    {
        Metadata = new ChangeTrackingDictionary<string, string>();
    }
}
