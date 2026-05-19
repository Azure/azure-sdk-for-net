// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Agents;

[Experimental("AAIP001")]
public partial class HostedAgentDefinition
{
    /// <summary> Initializes a new instance of <see cref="HostedAgentDefinition"/>. </summary>
    /// <param name="versions"> The protocols that the agent supports for ingress communication of the containers. </param>
    /// <param name="cpu"> The CPU configuration for the hosted agent. </param>
    /// <param name="memory"> The memory configuration for the hosted agent. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="cpu"/> or <paramref name="memory"/> is null. </exception>
    public HostedAgentDefinition(IEnumerable<ProtocolVersionRecord> versions, string cpu, string memory) : base(ProjectsAgentKind.Hosted)
    {
        Argument.AssertNotNull(cpu, nameof(cpu));
        Argument.AssertNotNull(memory, nameof(memory));

        Tools = new ChangeTrackingList<ProjectsAgentTool>();
        Versions = new ChangeTrackingList<ProtocolVersionRecord>();
        Cpu = cpu;
        Memory = memory;
        EnvironmentVariables = new ChangeTrackingDictionary<string, string>();
        ProtocolVersions = new ChangeTrackingList<ProtocolVersionRecord>();
        if (versions != null)
        {
            foreach (ProtocolVersionRecord version in versions)
            {
                Versions.Add(version);
            }
        }
    }
}
