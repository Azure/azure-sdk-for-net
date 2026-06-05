// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Projects.Agents;

[CodeGenType("AgentDefinition")]
public abstract partial class ProjectsAgentDefinition
{
    /// <summary> Configuration for Responsible AI (RAI) content filtering and safety features. </summary>
    [CodeGenMember("RaiConfig")]
    public ContentFilterConfiguration ContentFilterConfiguration { get; set; }

    /// <summary> Creates a prompt-based declarative agent definition for the specified model. </summary>
    /// <param name="model">The model deployment to use for this agent.</param>
    public static DeclarativeAgentDefinition CreatePromptAgentDefinition(string model)
        => new(model);
    /// <summary> Creates a workflow-based agent definition from a workflow YAML document. </summary>
    /// <param name="workflowYamlDocument">The workflow defined as a YAML document.</param>
    public static WorkflowAgentDefinition CreateWorkflowAgentDefinitionFromYaml(string workflowYamlDocument)
        => WorkflowAgentDefinition.FromYaml(workflowYamlDocument);
    /// <summary> Creates a hosted agent definition with the specified container configuration. </summary>
    /// <param name="containerProtocolVersions">Protocol versions supported by the hosted container.</param>
    /// <param name="cpuConfiguration">The CPU configuration string for the hosted container.</param>
    /// <param name="memoryConfiguration">The memory configuration string for the hosted container.</param>
    public static HostedAgentDefinition CreateHostedAgentDefinition(IEnumerable<ProtocolVersionRecord> containerProtocolVersions, string cpuConfiguration, string memoryConfiguration)
        => new(containerProtocolVersions, cpuConfiguration, memoryConfiguration);
}
