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

    public static DeclarativeAgentDefinition CreatePromptAgentDefinition(string model)
        => new(model);
    public static WorkflowAgentDefinition CreateWorkflowAgentDefinitionFromYaml(string workflowYamlDocument)
        => WorkflowAgentDefinition.FromYaml(workflowYamlDocument);
    public static HostedAgentDefinition CreateHostedAgentDefinition(IEnumerable<ProtocolVersionRecord> containerProtocolVersions, string cpuConfiguration, string memoryConfiguration)
        => new(containerProtocolVersions, cpuConfiguration, memoryConfiguration);
}
