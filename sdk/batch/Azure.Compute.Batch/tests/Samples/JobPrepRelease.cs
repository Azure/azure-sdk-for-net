// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-job-prep-release.md
// Each method corresponds to a ```csharp fenced code block in the doc.

using System.Threading.Tasks;
using Azure;
using Azure.Compute.Batch;

namespace BatchDocSamples;

internal static class JobPrepRelease
{
    private static readonly BatchClient myBatchClient = Stubs.BatchClient;

    // Block 1: Create job with prep + release tasks.
    public static async Task CreateJobWithPrepAndReleaseAsync()
    {
        #region Snippet:job_prep_release_create
        // Specify the command lines for the job preparation and release tasks
        string jobPrepCmdLine =
            "cmd /c echo %AZ_BATCH_NODE_ID% > %AZ_BATCH_NODE_SHARED_DIR%\\shared_file.txt";
        string jobReleaseCmdLine =
            "cmd /c del %AZ_BATCH_NODE_SHARED_DIR%\\shared_file.txt";

        // Build the job create content for BatchPool "myPool" with preparation and
        // release tasks attached.
        BatchJobCreateOptions jobContent = new BatchJobCreateOptions(
            "JobPrepReleaseSampleJob",
            new BatchPoolInfo { PoolId = "myPool" })
        {
            JobPreparationTask = new BatchJobPreparationTask(jobPrepCmdLine),
            JobReleaseTask = new BatchJobReleaseTask(jobReleaseCmdLine)
        };

        await myBatchClient.CreateJobAsync(jobContent);
        #endregion
    }

    // Block 2: Terminate the job.
    public static async Task TerminateJobAsync()
    {
        #region Snippet:job_prep_release_terminate
        // Terminate the job to mark it as completed. Terminate initiates the
        // job release task on any node that ran job tasks. Note that the
        // job release task also runs when a job is deleted, so you don't
        // have to call Terminate if you delete jobs after task completion.

        await myBatchClient.TerminateJobAsync(WaitUntil.Completed, "JobPrepReleaseSampleJob");
        #endregion
    }
}
