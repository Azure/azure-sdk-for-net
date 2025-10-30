// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents;

[CodeGenType("UpdateAgentRequest1")]
[CodeGenSuppress(nameof(AgentUpdateOptions), typeof(AgentDefinition))]
public partial class AgentUpdateOptions
{
    /// <summary> A human-readable description of the agent. </summary>
    [CodeGenMember("Description")]
    public string Description { get; set; }

    public AgentUpdateOptions(AgentDefinition definition)
        : this(description: default, metadata: default, definition: definition, additionalBinaryDataProperties: default)
    {
        Metadata = new ChangeTrackingDictionary<string, string>();
    }
}
