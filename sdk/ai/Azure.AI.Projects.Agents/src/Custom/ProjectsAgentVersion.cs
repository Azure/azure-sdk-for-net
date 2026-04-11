// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

[CodeGenType("ProjectsAgentVersion")]
public partial class ProjectsAgentVersion
{
    /// <summary> The object type, which is always 'agent.version'. </summary>
    [CodeGenMember("Object")]
    internal string Object { get; } = "agent.version";

    public string GetStatus()
    {
        if (_additionalBinaryDataProperties.TryGetValue("status", out System.BinaryData status))
        {
            return status.ToString();
        }
        return null;
    }
}
