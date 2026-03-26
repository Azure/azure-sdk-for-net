// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

public partial class ProjectsAgentsModelFactory
{
    public static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default)
    {
        return new ProjectsAgentRecord("agent", id, name, default, additionalBinaryDataProperties: null);
    }

    internal static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default, AgentObjectVersions versions = default)
    {
        return new ProjectsAgentRecord("agent", id, name, versions, additionalBinaryDataProperties: null);
    }
}
