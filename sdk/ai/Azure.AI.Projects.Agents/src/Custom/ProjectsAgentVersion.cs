// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects.Agents;

[CodeGenType("ProjectsAgentVersion")]
public partial class ProjectsAgentVersion
{
    /// <summary> The object type, which is always 'agent.version'. </summary>
    [CodeGenMember("Object")]
    internal string Object { get; } = "agent.version";

    [CodeGenMember("AgentGuid")]
    internal string AgentGuidInternal { get; }

    /// <summary> The unique GUID identifier of the agent. </summary>
    public Guid AgentGuid { get => new(AgentGuidInternal); }
}
