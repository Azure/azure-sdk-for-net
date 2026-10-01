// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Sample_LegacyAgentModels_Imports
using Azure.AI.Projects.Agents;
using Azure.AI.Extensions.OpenAI;
#endregion
using NUnit.Framework;

#pragma warning disable AAIP002

namespace Samples;

public class Sample_LegacyModels
{
    [Test]
    public void FullyQualifiedModels()
    {
        #region Snippet:Sample_LegacyAgentModels_QualifiedNames
        // Both namespaces contain AzureAISearchTool and AzureAISearchToolOptions.
        // EditorBrowsable(Never) does not remove the legacy names from compilation.
        var legacyTool = new Azure.AI.Projects.Agents.AzureAISearchTool(
            new Azure.AI.Projects.Agents.AzureAISearchToolOptions(
            [
                new Azure.AI.Projects.Agents.AzureAISearchToolIndex
                {
                    ProjectConnectionId = "search-connection",
                    IndexName = "documents"
                }
            ]));

        var sharedTool = new Azure.AI.Extensions.OpenAI.AzureAISearchTool(
            new Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions(
            [
                new Azure.AI.Extensions.OpenAI.AzureAISearchToolIndex
                {
                    ProjectConnectionId = "search-connection",
                    IndexName = "documents"
                }
            ]));

        // Existing code can keep using the legacy model and its implicit conversion.
        var legacyDefinition = new DeclarativeAgentDefinition("model-deployment")
        {
            Tools = { legacyTool }
        };

        // New code can use the shared model directly.
        var sharedDefinition = new DeclarativeAgentDefinition("model-deployment")
        {
            Tools = { sharedTool }
        };
        #endregion
        Assert.That(legacyDefinition.Tools[0], Is.TypeOf<Azure.AI.Extensions.OpenAI.AzureAISearchTool>());
        Assert.That(sharedDefinition.Tools[0], Is.SameAs(sharedTool));
    }
}
