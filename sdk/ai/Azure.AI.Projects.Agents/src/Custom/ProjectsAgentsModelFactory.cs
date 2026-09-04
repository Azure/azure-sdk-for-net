// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

[CodeGenSuppress("ProjectsAgentRecord", typeof(string), typeof(string), typeof(AgentState), typeof(AgentStateSource?), typeof(AgentObjectVersions), typeof(AgentEndpointConfiguration), typeof(DigitalWorkerType?), typeof(AgentIdentity), typeof(AgentIdentity), typeof(AgentBlueprintReference), typeof(AgentCard))]
public partial class ProjectsAgentsModelFactory
{
    /// <summary> Creates a new instance of <see cref="Agents.ProjectsAgentRecord"/> for mocking. </summary>
    /// <param name="id">The agent identifier.</param>
    /// <param name="name">The agent name.</param>
    /// <param name="state">The agent state.</param>
    /// <param name="digitalWorkerType">(Preview) The type of digital worker (previously known as `autopilot`). If omitted, it is not a digital worker.</param>
    public static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default, AgentState state = default, DigitalWorkerType? digitalWorkerType = default)
    {
        return new ProjectsAgentRecord("agent", id, name, state, default, new AgentObjectVersions(), default, digitalWorkerType, default, default, default, default, null);
    }

    internal static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default, AgentState state = default, AgentStateSource? stateSource = default, AgentObjectVersions versions = default, AgentEndpointConfiguration agentEndpoint = default, DigitalWorkerType? digitalWorkerType = default, AgentIdentity instanceIdentity = default, AgentIdentity blueprint = default, AgentBlueprintReference blueprintReference = default, AgentCard agentCard = default)
    {
        return new ProjectsAgentRecord("agent", id, name, state, stateSource, versions, agentEndpoint, digitalWorkerType, instanceIdentity, blueprint, blueprintReference, agentCard, additionalBinaryDataProperties: null);
    }
}
