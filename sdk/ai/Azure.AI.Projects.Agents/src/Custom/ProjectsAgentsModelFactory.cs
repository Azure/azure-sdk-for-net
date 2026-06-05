// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

public partial class ProjectsAgentsModelFactory
{
    /// <summary> Creates a new instance of <see cref="Agents.ProjectsAgentRecord"/> for mocking. </summary>
    /// <param name="id">The agent identifier.</param>
    /// <param name="name">The agent name.</param>
    public static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default)
    {
        return new ProjectsAgentRecord("agent", id, name, new AgentObjectVersions(), default, default, default, default, default, null);
    }

    internal static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default, AgentObjectVersions versions = default, AgentEndpointConfiguration agentEndpoint = default, AgentIdentity instanceIdentity = default, AgentIdentity blueprint = default, AgentBlueprintReference blueprintReference = default, AgentCard agentCard = default)
    {
        return new ProjectsAgentRecord("agent", id, name, versions, agentEndpoint, instanceIdentity, blueprint, blueprintReference, agentCard, additionalBinaryDataProperties: null);
    }
}
