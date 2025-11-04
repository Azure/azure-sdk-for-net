// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Agents;

/// <summary> The AgentReference. </summary>
public partial class AgentReference
{
    public static implicit operator AgentReference(AgentRecord agent) => agent is null ? null : new(agent.Name) { Version = agent.Versions.Latest.Version };
    public static implicit operator AgentReference(AgentVersion agent) => agent is null ? null : new(agent.Name) { Version = agent.Version };
    public static implicit operator AgentReference(string agentName) => new(agentName);
}
