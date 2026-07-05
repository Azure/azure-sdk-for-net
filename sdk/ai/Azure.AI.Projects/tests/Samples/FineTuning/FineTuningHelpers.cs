// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only
#pragma warning disable CS0618 // Type or member is obsolete

using System;
using System.IO;
using System.Threading.Tasks;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests.Samples;

/// <summary>
/// Helper methods for fine-tuning operations.
/// </summary>
public static class FineTuningHelpers
{
    /// <summary>
    /// Gets the path to the samples data directory.
    /// </summary>
    public static string GetSamplesDataDirectory()
    {
        var testDirectory = Path.GetDirectoryName(typeof(FineTuningHelpers).Assembly.Location);
        while (testDirectory != null && !Directory.Exists(Path.Combine(testDirectory, "sdk")))
        {
            testDirectory = Path.GetDirectoryName(testDirectory);
        }
        return Path.Combine(testDirectory!, "sdk", "ai", "Azure.AI.Projects", "tests", "Samples", "FineTuning", "data");
    }

    #region Snippet:AI_Projects_FineTuning_WaitForFileProcessingHelper
    /// <summary>
    /// Wait for file to complete processing (async).
    /// </summary>
    public static async Task<OpenAIFile> WaitForFileProcessingAsync(
        OpenAIFileClient fileClient,
        string fileId,
        int pollIntervalSeconds = 5,
        int maxWaitSeconds = 1800)
    {
        var start = DateTimeOffset.Now;
        var pollInterval = TimeSpan.FromSeconds(pollIntervalSeconds);
        var timeout = TimeSpan.FromSeconds(maxWaitSeconds);

        OpenAIFile file = await fileClient.GetFileAsync(fileId);
        Console.WriteLine($"File {fileId} initial status: {file.Status}");

        while (file.Status != FileStatus.Processed && file.Status != FileStatus.Error)
        {
            if (DateTimeOffset.Now - start > timeout)
            {
                throw new TimeoutException(
                    $"File {fileId} did not finish processing after {maxWaitSeconds} seconds. Current status: {file.Status}");
            }

            await Task.Delay(pollInterval);
            file = await fileClient.GetFileAsync(fileId);
            Console.WriteLine($"File {fileId} status: {file.Status}");
        }

        if (file.Status == FileStatus.Error)
        {
            throw new InvalidOperationException(
                $"File {fileId} processing failed: {file.StatusDetails}");
        }

        Console.WriteLine($"File {fileId} processing completed successfully");
        return file;
    }

    /// <summary>
    /// Wait for file to complete processing (sync).
    /// </summary>
    public static OpenAIFile WaitForFileProcessing(
        OpenAIFileClient fileClient,
        string fileId,
        int pollIntervalSeconds = 5,
        int maxWaitSeconds = 1800)
    {
        var start = DateTimeOffset.Now;
        var pollInterval = TimeSpan.FromSeconds(pollIntervalSeconds);
        var timeout = TimeSpan.FromSeconds(maxWaitSeconds);

        OpenAIFile file = fileClient.GetFile(fileId);
        Console.WriteLine($"File {fileId} initial status: {file.Status}");

        while (file.Status != FileStatus.Processed && file.Status != FileStatus.Error)
        {
            if (DateTimeOffset.Now - start > timeout)
            {
                throw new TimeoutException(
                    $"File {fileId} did not finish processing after {maxWaitSeconds} seconds. Current status: {file.Status}");
            }

            System.Threading.Thread.Sleep(pollInterval);
            file = fileClient.GetFile(fileId);
            Console.WriteLine($"File {fileId} status: {file.Status}");
        }

        if (file.Status == FileStatus.Error)
        {
            throw new InvalidOperationException(
                $"File {fileId} processing failed: {file.StatusDetails}");
        }

        Console.WriteLine($"File {fileId} processing completed successfully");
        return file;
    }
    #endregion

    #region Snippet:AI_Projects_FineTuning_WaitForTerminalStateHelper
    /// <summary>
    /// Wait for job to reach terminal state (async).
    /// </summary>
    public static async Task<FineTuningJob> WaitForJobTerminalStateAsync(
        FineTuningClient fineTuningClient,
        string jobId,
        int pollIntervalSeconds = 10,
        int maxWaitSeconds = 3600)
    {
        var start = DateTimeOffset.Now;
        var pollInterval = TimeSpan.FromSeconds(pollIntervalSeconds);
        var timeout = TimeSpan.FromSeconds(maxWaitSeconds);

        FineTuningJob job = await fineTuningClient.GetJobAsync(jobId);
        Console.WriteLine($"Job {jobId} initial status: {job.Status}");

        while (!IsTerminalState(job.Status))
        {
            if (DateTimeOffset.Now - start > timeout)
            {
                throw new TimeoutException(
                    $"Job {jobId} did not reach terminal state after {maxWaitSeconds} seconds. Current status: {job.Status}");
            }

            await Task.Delay(pollInterval);
            job = await fineTuningClient.GetJobAsync(jobId);
            Console.WriteLine($"Job {jobId} status: {job.Status}");
        }

        Console.WriteLine($"Job {jobId} reached terminal state: {job.Status}");
        return job;
    }

    /// <summary>
    /// Wait for job to reach terminal state (sync).
    /// </summary>
    public static FineTuningJob WaitForJobTerminalState(
        FineTuningClient fineTuningClient,
        string jobId,
        int pollIntervalSeconds = 10,
        int maxWaitSeconds = 3600)
    {
        var start = DateTimeOffset.Now;
        var pollInterval = TimeSpan.FromSeconds(pollIntervalSeconds);
        var timeout = TimeSpan.FromSeconds(maxWaitSeconds);

        FineTuningJob job = fineTuningClient.GetJob(jobId);
        Console.WriteLine($"Job {jobId} initial status: {job.Status}");

        while (!IsTerminalState(job.Status))
        {
            if (DateTimeOffset.Now - start > timeout)
            {
                throw new TimeoutException(
                    $"Job {jobId} did not reach terminal state after {maxWaitSeconds} seconds. Current status: {job.Status}");
            }

            System.Threading.Thread.Sleep(pollInterval);
            job = fineTuningClient.GetJob(jobId);
            Console.WriteLine($"Job {jobId} status: {job.Status}");
        }

        Console.WriteLine($"Job {jobId} reached terminal state: {job.Status}");
        return job;
    }

    /// <summary>
    /// Check if job status is terminal.
    /// </summary>
    public static bool IsTerminalState(FineTuningStatus status)
    {
        return status.ToString().ToLowerInvariant() switch
        {
            "succeeded" => true,
            "failed" => true,
            "cancelled" => true,
            _ => false
        };
    }
    #endregion
}
