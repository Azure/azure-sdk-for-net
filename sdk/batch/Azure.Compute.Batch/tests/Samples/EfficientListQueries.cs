// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-efficient-list-queries.md

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Compute.Batch;

namespace BatchDocSamples;

internal static class EfficientListQueries
{
    private static readonly BatchClient batchClient = Stubs.BatchClient;
    private static readonly BatchClient myBatchClient = Stubs.BatchClient;

    // Block 1: List all tasks in a job, all properties.
    public static void ListAllTasks()
    {
        #region Snippet:list_queries_all_tasks
        // Get a collection of all of the tasks and all of their properties for job-001
        AsyncPageable<BatchTask> allTasks = batchClient.GetTasksAsync("job-001");
        #endregion
        _ = allTasks;
    }

    // Block 2: Filtered + selected list.
    public static void ListCompletedTasks()
    {
        #region Snippet:list_queries_filter_select
        // Specify filter and select strings to return only a subset of tasks and their properties.
        AsyncPageable<BatchTask> completedTasks = batchClient.GetTasksAsync(
            jobId: "job-001",
            filter: "state eq 'completed'",
            select: new[] { "id", "commandLine", "nodeInfo" });
        #endregion
        _ = completedTasks;
    }

    // Block 3: GetPoolsAsync with filter/select/expand.
    public static async Task ListTestPoolsAsync()
    {
        #region Snippet:list_queries_pools_expand
        // Pull only the "test" pools, and limit the data crossing the wire by selecting only
        // the Id and Statistics properties. Use expand="stats" so the .NET API pulls the
        // statistics for the BatchPools in a single underlying REST API call. Note that we
        // use the pool's REST API element name "stats" here as opposed to "Statistics" as it
        // appears in the .NET API (BatchPool.Statistics).
        List<BatchPool> testPools = new List<BatchPool>();
        await foreach (BatchPool pool in myBatchClient.GetPoolsAsync(
            filter: "startswith(id, 'test')",
            select: new[] { "id", "stats" },
            expand: new[] { "stats" }))
        {
            testPools.Add(pool);
        }
        #endregion
    }

    // Block 4: OnlyChangedAfter helper from the BatchMetrics sample.
    internal static (string Filter, IEnumerable<string> Select) OnlyChangedAfter(DateTime time)
    {
        #region Snippet:list_queries_only_changed_after
        return (
            Filter: string.Format("stateTransitionTime gt DateTime'{0:o}'", time),
            Select: new[] { "id", "state" });
        #endregion
    }
}
