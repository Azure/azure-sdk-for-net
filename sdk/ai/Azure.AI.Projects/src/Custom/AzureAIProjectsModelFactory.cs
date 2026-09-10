// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.Projects.Evaluation;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Projects
{
    [CodeGenType("ProjectsModelFactory")]
    public partial class AzureAIProjectsModelFactory
    {
        /// <summary> Represents a target specifying an Azure AI agent. </summary>
        /// <param name="name"> The unique identifier of the Azure AI agent. </param>
        /// <param name="version"> The version of the Azure AI agent. </param>
        /// <param name="toolDescriptions"> The parameters used to control the sampling behavior of the agent during text generation. </param>
        /// <returns> A new <see cref="Evaluation.AzureAIAgentTarget"/> instance for mocking. </returns>
        public static AzureAIAgentTarget AzureAIAgentTarget(string name = default, string version = default, IEnumerable<ToolDescription> toolDescriptions = default)
        {
            toolDescriptions ??= new ChangeTrackingList<ToolDescription>();

            return new AzureAIAgentTarget("azure_ai_agent", additionalBinaryDataProperties: null, name, version, [.. toolDescriptions], []);
        }
    }
}
