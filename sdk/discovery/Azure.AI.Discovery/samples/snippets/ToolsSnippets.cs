// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Discovery;
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.Discovery.Samples.Snippets
{
    /// <summary>
    /// Snippets demonstrating how to run tools on supercomputer node pools.
    /// </summary>
    public partial class ToolsSnippets
    {
        /// <summary>
        /// Submit a tool run as a long-running operation and wait for completion.
        /// </summary>
        public async Task RunToolOnCompute()
        {
            #region Snippet:RunToolOnCompute
            WorkspaceClient client = new WorkspaceClient(
                new Uri("https://<workspaceName>.workspace.discovery.azure.com"),
                new DefaultAzureCredential());

            DiscoveryToolsClient tools = client.GetDiscoveryToolsClient();

            Operation<RunResult> run = await tools.RunAsync(
                WaitUntil.Completed,
                projectName: "my-project",
                toolId: new ResourceIdentifier("/subscriptions/.../tools/my-tool"),
                nodePoolIds: new[] { new ResourceIdentifier("/subscriptions/.../nodePools/my-pool") },
                command: "echo \"Hello from Discovery\"");

            Console.WriteLine($"Run completed: {run.Value.Status}");
            #endregion
        }
    }
}
