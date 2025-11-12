// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents;

[CodeGenType("AgentDefinition")]
public abstract partial class AgentDefinition
{
    /// <summary> Configuration for Responsible AI (RAI) content filtering and safety features. </summary>
    [CodeGenMember("RaiConfig")]
    public ContentFilterConfiguration ContentFilterConfiguration { get; set; }

    public static PromptAgentDefinition CreatePromptAgentDefinition(string model)
        => new PromptAgentDefinition(model);
    public static WorkflowAgentDefinition CreateWorkflowAgentDefinitionFromYaml(string workflowYamlDocument)
        => WorkflowAgentDefinition.FromYaml(workflowYamlDocument);
    public static ContainerAppAgentDefinition CreateContainerAppAgentDefinition(IEnumerable<ProtocolVersionRecord> containerProtocolVersions, string containerAppResourceId, string ingressSubdomainSuffix)
        => new ContainerAppAgentDefinition(containerProtocolVersions, containerAppResourceId, ingressSubdomainSuffix);
    public static HostedAgentDefinition CreateHostedAgentDefinition(IEnumerable<ProtocolVersionRecord> containerProtocolVersions, string cpuConfiguration, string memoryConfiguration)
        => new HostedAgentDefinition(containerProtocolVersions, cpuConfiguration, memoryConfiguration);
}
