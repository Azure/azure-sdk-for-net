// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.AI.Projects.Agents;

namespace Azure.AI.Projects.Evaluation;

[CodeGenType("AzureAIAgentTarget")]
public partial class AzureAIAgentTarget
{
    /// <summary> Gets the Tools. </summary>
    [CodeGenMember("Tools")]
    internal IList<InternalTool> InternalTools { get; }

    /// <summary> Gets the Tools. </summary>
    public IList<ProjectsAgentTool> Tools { get => [.. InternalTools.Select(x => ProjectsAgentTool.AsProjectTool(x))]; }
}
