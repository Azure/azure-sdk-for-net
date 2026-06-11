// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Discovery;
using Azure.Identity;

namespace Azure.AI.Discovery.Samples.Snippets
{
    /// <summary>
    /// Snippets demonstrating how to create, comment on, and filter tasks within an investigation.
    /// </summary>
    public partial class TasksSnippets
    {
        /// <summary>
        /// Create a task, add a comment to it, then list tasks with a filter.
        /// </summary>
        public async Task CreateAndManageTasks()
        {
            #region Snippet:CreateAndManageTasks
            WorkspaceClient client = new WorkspaceClient(
                new Uri("https://<workspaceName>.workspace.discovery.azure.com"),
                new DefaultAzureCredential());

            DiscoveryTasksClient tasks = client.GetDiscoveryTasksClient();

            string projectName = "my-project";
            string investigationName = "sample-investigation";

            DiscoveryTask task = new DiscoveryTask
            {
                Title = "Analyze compound interactions",
                Description = "Review the interaction data for compounds A and B",
                Priority = TaskPriority.High,
                AssignedTo = new TaskAssignee("researcher-agent", ByType.Application),
                InvestigationId = $"/projects/{projectName}/investigations/{investigationName}",
            };

            Response<DiscoveryTask> created = await tasks.CreateAsync(projectName, investigationName, task);
            Console.WriteLine($"Created task: {created.Value.Title} ({created.Value.Status})");

            // Add a comment to the task.
            await tasks.AddCommentAsync(
                created.Value.Name,
                projectName,
                investigationName,
                new TaskComment("sample-user", ByType.User, "Initial analysis shows promising results."));

            // List tasks with a filter.
            await foreach (DiscoveryTask t in tasks.GetAllAsync(projectName, investigationName, filter: "status eq 'New'"))
            {
                Console.WriteLine($"{t.Name}: {t.Title}");
            }
            #endregion
        }
    }
}
