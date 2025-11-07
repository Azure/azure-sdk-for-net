// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Agents;

[CodeGenType("WorkflowDefinition")]
public partial class WorkflowAgentDefinition
{
    /// <summary> Initializes a new instance of <see cref="WorkflowAgentDefinition"/>. </summary>
    internal WorkflowAgentDefinition() : base(AgentKind.Workflow)
    {
    }

    public static WorkflowAgentDefinition FromYaml(string workflowYamlDocument)
    {
        return new()
        {
            WorkflowYaml = workflowYamlDocument,
        };
    }

    [CodeGenMember("Workflow")]
    private string WorkflowYaml { get; set; }
}
