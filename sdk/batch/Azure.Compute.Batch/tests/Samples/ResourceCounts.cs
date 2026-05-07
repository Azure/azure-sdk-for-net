// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-get-resource-counts.md.

using System;
using System.Threading.Tasks;
using Azure.Compute.Batch;

namespace BatchDocSamples;

internal static class ResourceCounts
{
    private static readonly BatchClient batchClient = Stubs.BatchClient;

    public static async Task GetJobTaskCountsAsync()
    {
        #region Snippet:resource_counts_job_tasks
        BatchTaskCountsResult taskCounts = await batchClient.GetJobTaskCountsAsync("job-1");

        Console.WriteLine("Task count in active state: {0}", taskCounts.TaskCounts.Active);
        Console.WriteLine("Task count in preparing or running state: {0}", taskCounts.TaskCounts.Running);
        Console.WriteLine("Task count in completed state: {0}", taskCounts.TaskCounts.Completed);
        Console.WriteLine("Succeeded task count: {0}", taskCounts.TaskCounts.Succeeded);
        Console.WriteLine("Failed task count: {0}", taskCounts.TaskCounts.Failed);
        #endregion
    }

    public static async Task ListPoolNodeCountsAsync()
    {
        #region Snippet:resource_counts_pool_nodes
        await foreach (BatchPoolNodeCounts nodeCounts in batchClient.GetPoolNodeCountsAsync())
        {
            Console.WriteLine("Pool Id: {0}", nodeCounts.PoolId);

            Console.WriteLine("Total dedicated node count: {0}", nodeCounts.Dedicated.Total);

            // Get dedicated node counts in Idle and Offline states; you can get additional states.
            Console.WriteLine("Dedicated node count in Idle state: {0}", nodeCounts.Dedicated.Idle);
            Console.WriteLine("Dedicated node count in Offline state: {0}", nodeCounts.Dedicated.Offline);

            Console.WriteLine("Total Spot node count: {0}", nodeCounts.LowPriority.Total);

            // Get Spot node counts in Running and Preempted states; you can get additional states.
            Console.WriteLine("Spot node count in Running state: {0}", nodeCounts.LowPriority.Running);
            Console.WriteLine("Spot node count in Preempted state: {0}", nodeCounts.LowPriority.Preempted);
        }
        #endregion
    }

    public static async Task ListPoolNodeCountsFilteredAsync()
    {
        #region Snippet:resource_counts_pool_nodes_filter
        await foreach (BatchPoolNodeCounts nodeCounts in batchClient.GetPoolNodeCountsAsync(
            filter: "poolId eq 'testpool'"))
        {
            Console.WriteLine("Pool Id: {0}", nodeCounts.PoolId);

            Console.WriteLine("Total dedicated node count: {0}", nodeCounts.Dedicated.Total);

            // Get dedicated node counts in Idle and Offline states; you can get additional states.
            Console.WriteLine("Dedicated node count in Idle state: {0}", nodeCounts.Dedicated.Idle);
            Console.WriteLine("Dedicated node count in Offline state: {0}", nodeCounts.Dedicated.Offline);

            Console.WriteLine("Total Spot node count: {0}", nodeCounts.LowPriority.Total);

            // Get Spot node counts in Running and Preempted states; you can get additional states.
            Console.WriteLine("Spot node count in Running state: {0}", nodeCounts.LowPriority.Running);
            Console.WriteLine("Spot node count in Preempted state: {0}", nodeCounts.LowPriority.Preempted);
        }
        #endregion
    }
}
