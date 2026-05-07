// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippet extracted from articles/batch/batch-container-isolation-task.md.

using System.Threading.Tasks;
using Azure;
using Azure.Compute.Batch;

namespace BatchDocSamples;

internal static class ContainerIsolation
{
    public static async Task CreateExampleContainerIsolationTaskAsync(BatchClient client, string jobId)
    {
        #region Snippet:container_isolation_task
        BatchTaskCreateOptions containerIsolationTask = new BatchTaskCreateOptions(
            "test-container-isolation", "printenv")
        {
            ContainerSettings = new BatchTaskContainerSettings("docker.io/ubuntu:22.04")
            {
                ContainerHostBatchBindMounts =
                {
                    new ContainerHostBatchBindMountEntry()
                    {
                        Source = ContainerHostDataPath.Task
                    }
                }
            }
        };
        await client.CreateTaskAsync(jobId, containerIsolationTask);
        #endregion
    }
}
