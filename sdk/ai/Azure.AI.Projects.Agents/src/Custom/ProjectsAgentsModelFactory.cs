// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

public partial class ProjectsAgentsModelFactory
{
    public static AgentRecord AgentRecord(string id = default, string name = default)
    {
        return new AgentRecord("agent", id, name, default, additionalBinaryDataProperties: null);
    }

    internal static AgentRecord AgentRecord(string id = default, string name = default, AgentObjectVersions versions = default)
    {
        return new AgentRecord("agent", id, name, versions, additionalBinaryDataProperties: null);
    }
}
