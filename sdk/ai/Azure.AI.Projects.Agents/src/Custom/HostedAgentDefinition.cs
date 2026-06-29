// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects.Agents;

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
        Versions = new ChangeTrackingList<ProtocolVersionRecord>();
        if (versions != null)
        {
            foreach (ProtocolVersionRecord version in versions)
            {
                Versions.Add(version);
            }
        }
    }

    private void SetContainerImageMayBe(string image)
    {
        ContainerConfiguration ??= new ContainerConfiguration();
        ContainerConfiguration.Image = image;
    }
    /// <summary> [Deprecated] The container image for the hosted agent. This property was added fo backward compatibility only. Please use ContainerConfiguration.Image instead. </summary>
    public string Image { get => ContainerConfiguration?.Image; set => SetContainerImageMayBe(value); }
    /// <summary>
    /// The property, retained for back compatibility, not used.
    /// </summary>
    public IList<ProjectsAgentTool> Tools { get; }
}
