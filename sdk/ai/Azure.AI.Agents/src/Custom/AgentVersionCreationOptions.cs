// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents;

[CodeGenType("CreateAgentVersionRequest1")]
public partial class AgentVersionCreationOptions
{
    /// <summary> A human-readable description of the agent. </summary>
    [CodeGenMember("Description")]
    public string Description { get; set; }

    /// <summary> Initializes a new instance of <see cref="AgentVersionCreationOptions"/>. </summary>
    /// <param name="definition"> The agent definition. This can be a workflow, hosted agent, or a simple agent definition. </param>
    public AgentVersionCreationOptions(AgentDefinition definition)
    {
        Metadata = new ChangeTrackingDictionary<string, string>();
        Definition = definition;
    }
}
