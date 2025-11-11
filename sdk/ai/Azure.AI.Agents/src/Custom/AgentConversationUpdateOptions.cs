// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents;

[CodeGenType("UpdateConversationRequest1")]
public partial class AgentConversationUpdateOptions
{
    /// <summary> Initializes a new instance of <see cref="AgentConversationUpdateOptions"/>. </summary>
    public AgentConversationUpdateOptions()
    {
        Metadata = new ChangeTrackingDictionary<string, string>();
    }
}
