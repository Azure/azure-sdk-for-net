// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/large-number-tasks.md.
// The original used BatchClientParallelOptions + JobOperations.AddTaskAsync collection.
// Azure.Compute.Batch's equivalent is BatchClient.CreateTasksAsync(jobId, IEnumerable<BatchTaskCreateOptions>, CreateTasksOptions).

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Compute.Batch;

namespace BatchDocSamples;

internal static class LargeNumberTasks
{
    private static readonly BatchClient batchClient = Stubs.BatchClient;

    public static async Task AddManyTasksAsync(string jobId)
    {
        #region Snippet:large_tasks_parallel_options
        CreateTasksOptions parallelOptions = new CreateTasksOptions()
        {
            MaxDegreeOfParallelism = 15
        };
        #endregion

        #region Snippet:large_tasks_add_collection
        // Add a list of tasks as a collection
        List<BatchTaskCreateOptions> tasksToAdd = new List<BatchTaskCreateOptions>(); // Populate with your tasks
        // ...
        await batchClient.CreateTasksAsync(jobId, tasksToAdd, parallelOptions);
        #endregion
    }
}
