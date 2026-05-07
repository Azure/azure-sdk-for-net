// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-parallel-node-tasks.md.

using System.Threading.Tasks;
using Azure;
using Azure.Compute.Batch;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace BatchDocSamples;

internal static class ParallelNodeTasks
{
    private static readonly BatchClient batchClient = Stubs.BatchClient;

    public static async Task CreatePoolWithTaskSlotsAsync()
    {
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();

        #region Snippet:parallel_pool_create
        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = "standard_d1_v2",
            DeploymentConfiguration = new BatchDeploymentConfiguration()
            {
                VmConfiguration = new BatchVmConfiguration(
                    imageReference: new BatchImageReference()
                    {
                        Publisher = "MicrosoftWindowsServer",
                        Offer = "WindowsServer",
                        Sku = "2019-datacenter-core",
                        Version = "latest"
                    },
                    nodeAgentSkuId: "batch.node.windows amd64")
            },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = 4 }
            },
            TaskSlotsPerNode = 4,
            TaskSchedulingPolicy = new Azure.ResourceManager.Batch.Models.BatchTaskSchedulingPolicy(
                Azure.ResourceManager.Batch.Models.BatchNodeFillType.Pack)
        };

        await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, "mypool", poolData);
        #endregion
    }

    public static BatchTaskCreateOptions CreateMultiSlotTask(string taskId, string taskCommandLine)
    {
        #region Snippet:parallel_task_required_slots
        BatchTaskCreateOptions task = new BatchTaskCreateOptions(taskId, taskCommandLine)
        {
            RequiredSlots = 2
        };
        #endregion
        return task;
    }

    public static async Task ListNodesWithSlotsAsync(string poolId)
    {
        #region Snippet:parallel_list_nodes
        await foreach (BatchNode node in batchClient.GetNodesAsync(
            poolId,
            select: new[] { "id", "runningTasksCount", "runningTaskSlotsCount" }))
        {
            System.Console.WriteLine(node.Id + " :");
            System.Console.WriteLine($"RunningTasks = {node.RunningTasksCount}, RunningTaskSlots = {node.RunningTaskSlotsCount}");
        }
        #endregion
    }

    public static async Task ReadJobTaskCountsAsync(string jobId)
    {
        #region Snippet:parallel_job_task_counts
        BatchTaskCountsResult result = await batchClient.GetJobTaskCountsAsync(jobId);

        System.Console.WriteLine("\t\tActive\tRunning\tCompleted");
        System.Console.WriteLine($"TaskCounts:\t{result.TaskCounts.Active}\t{result.TaskCounts.Running}\t{result.TaskCounts.Completed}");
        System.Console.WriteLine($"TaskSlotCounts:\t{result.TaskSlotCounts.Active}\t{result.TaskSlotCounts.Running}\t{result.TaskSlotCounts.Completed}");
        #endregion
    }
}
