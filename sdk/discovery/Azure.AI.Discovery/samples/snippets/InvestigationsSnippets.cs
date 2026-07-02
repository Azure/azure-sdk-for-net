// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Discovery;
using Azure.Identity;

namespace Azure.AI.Discovery.Samples.Snippets
{
    /// <summary>
    /// Snippets demonstrating how to create and manage investigations and the per-investigation Discovery Engine.
    /// </summary>
    public partial class InvestigationsSnippets
    {
        /// <summary>
        /// Create or replace an investigation, then start its Discovery Engine.
        /// </summary>
        public async Task CreateAndManageInvestigation()
        {
            #region Snippet:CreateAndManageInvestigation
            WorkspaceClient client = new WorkspaceClient(
                new Uri("https://<workspaceName>.workspace.discovery.azure.com"),
                new DefaultAzureCredential());

            DiscoveryInvestigationsClient investigations = client.GetDiscoveryInvestigationsClient();

            string projectName = "my-project";
            string investigationName = "sample-investigation";

            // Create or replace an investigation.
            DiscoveryInvestigation resource = new DiscoveryInvestigation
            {
                DisplayName = "Sample Investigation",
                Description = "Investigating anomalies in dataset X",
            };

            Response<DiscoveryInvestigation> created = await investigations.CreateOrReplaceAsync(
                projectName, investigationName, resource);

            Console.WriteLine($"Created investigation: {created.Value.Name}");

            // Start the Discovery Engine for the investigation.
            Response<DiscoveryEngine> engine = await investigations.StartDiscoveryEngineAsync(
                projectName, investigationName);

            Console.WriteLine($"Discovery Engine status: {engine.Value.DiscoveryEngineStatus}");
            #endregion
        }
    }
}
