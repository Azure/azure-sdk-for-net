// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("WorkflowAgentDefinition")]
[Experimental("AAIP001")]
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
