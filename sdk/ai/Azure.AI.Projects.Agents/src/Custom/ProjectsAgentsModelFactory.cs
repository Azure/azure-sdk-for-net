// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

public partial class ProjectsAgentsModelFactory
{
    public static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default)
    {
        return new ProjectsAgentRecord("agent", id, name, new AgentObjectVersions(), default, default, default, default, default, null);
    }

    internal static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default, AgentObjectVersions versions = default, AgentEndpoint agentEndpoint = default, AgentIdentity instanceIdentity = default, AgentIdentity blueprint = default, AgentBlueprintReference blueprintReference = default, AgentCard agentCard = default)
    {
        return new ProjectsAgentRecord("agent", id, name, versions, agentEndpoint, instanceIdentity, blueprint, blueprintReference, agentCard, additionalBinaryDataProperties: null);
    }
}
