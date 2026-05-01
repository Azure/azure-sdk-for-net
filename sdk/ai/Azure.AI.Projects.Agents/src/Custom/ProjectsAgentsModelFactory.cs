// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

[CodeGenSuppress("ProjectsAgentRecord", typeof(string), typeof(string), typeof(AgentObjectVersions), typeof(AgentEndpointConfig), typeof(AgentIdentity), typeof(AgentIdentity), typeof(AgentBlueprintReference), typeof(AgentCard))]
public partial class ProjectsAgentsModelFactory
{
    public static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default)
    {
        return new ProjectsAgentRecord("agent", id, name, default, default, default, default, default, default, null);
    }

    internal static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default, AgentObjectVersions versions = default, AgentEndpointConfig agentEndpoint = default, AgentIdentity instanceIdentity = default, AgentIdentity blueprint = default, AgentBlueprintReference blueprintReference = default, AgentCard agentCard = default)
    {
        return new ProjectsAgentRecord("agent", id, name, versions, agentEndpoint, instanceIdentity, blueprint, blueprintReference, agentCard, additionalBinaryDataProperties: null);
    }
}
