// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.AI.Projects.Agents;

public static partial class ProjectsAgentsModelFactory
{
    /// <summary> Creates a hosted definition using the 2.0 model-factory contract. </summary>
    /// <param name="contentFilterConfiguration"> The content filter configuration. </param>
    /// <param name="tools"> The legacy tools. </param>
    /// <param name="versions"> Supported protocols. </param>
    /// <param name="cpu"> The CPU configuration. </param>
    /// <param name="memory"> The memory configuration. </param>
    /// <param name="environmentVariables"> The environment variables. </param>
    /// <param name="image"> The container image. </param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static HostedAgentDefinition HostedAgentDefinition(
        ContentFilterConfiguration contentFilterConfiguration,
        IEnumerable<ProjectsAgentTool> tools,
        IEnumerable<ProtocolVersionRecord> versions,
        string cpu,
        string memory,
        IDictionary<string, string> environmentVariables,
        string image)
    {
        HostedAgentDefinition result = HostedAgentDefinition(
            contentFilterConfiguration: contentFilterConfiguration,
            cpu: cpu,
            memory: memory,
            environmentVariables: environmentVariables,
            containerConfiguration: image == null ? null : new ContainerConfiguration { Image = image },
            versions: versions);
        if (tools != null)
        {
            foreach (ProjectsAgentTool tool in tools)
            {
                result.Tools.Add(tool);
            }
        }
        return result;
    }
}
