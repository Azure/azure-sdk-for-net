// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Agents;

[CodeGenType("WorkflowAgentDefinition")]
public partial class WorkflowAgentDefinition
{
    /// <summary> Initializes a new instance of <see cref="WorkflowAgentDefinition"/>. </summary>
    internal WorkflowAgentDefinition() : base(ProjectsAgentKind.Workflow)
    {
    }

    /// <summary>
    /// Creates a new <see cref="WorkflowAgentDefinition"/> from a workflow YAML document.
    /// </summary>
    /// <param name="workflowYamlDocument">The workflow defined as a YAML document.</param>
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
