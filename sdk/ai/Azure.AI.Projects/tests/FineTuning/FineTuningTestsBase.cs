// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using Azure.AI.Projects.OpenAI;
using Azure.AI.Projects.Tests.Utils;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests;

/// <summary>
/// Base class for fine-tuning tests containing common functionality.
/// </summary>
public abstract class FineTuningTestsBase : ProjectsClientTestBase
{
    protected FineTuningTestsBase(bool isAsync) : base(isAsync)
    {
    }

    protected string GetDataDirectory()
    {
        var testDirectory = Path.GetDirectoryName(typeof(FineTuningTestsBase).Assembly.Location);
        while (testDirectory != null && !Directory.Exists(Path.Combine(testDirectory, "sdk")))
        {
            testDirectory = Path.GetDirectoryName(testDirectory);
        }
        return Path.Combine(testDirectory!, "sdk", "ai", "Azure.AI.Projects", "tests", "FineTuning", "data");
    }

    /// <summary>
    /// Gets OpenAIFileClient and FineTuningClient with recording support and HTTP logging enabled.
    /// </summary>
    /// <returns>A tuple containing OpenAIFileClient and FineTuningClient.</returns>
    protected (OpenAIFileClient FileClient, FineTuningClient FineTuningClient) GetClients()
    {
        AIProjectClient projectClient = GetTestClient();

        ProjectOpenAIClient oaiClient = projectClient.OpenAI;

        return (oaiClient.GetOpenAIFileClient(), oaiClient.GetFineTuningClient());
    }

    protected void ValidateFineTuningJob(FineTuningJob job, string expectedJobId = null, string expectedStatus = null)
    {
        Assert.IsNotNull(job);
        Assert.IsNotNull(job.JobId);
        Assert.IsNotNull(job.Status);

        if (expectedJobId != null)
        {
            Assert.AreEqual(expectedJobId, job.JobId);
        }

        if (expectedStatus != null)
        {
            Assert.AreEqual(expectedStatus, job.Status.ToString().ToLowerInvariant());
        }
    }

    /// <summary>
    /// Waits for a file to finish processing by polling its status.
    /// </summary>
    /// <param name="fileClient">The OpenAI file client.</param>
    /// <param name="fileId">The ID of the file to wait for.</param>
    /// <param name="pollIntervalSeconds">Polling interval in seconds (default: 5).</param>
    /// <param name="maxWaitSeconds">Maximum wait time in seconds (default: 1800 = 30 minutes).</param>
    /// <returns>The processed file.</returns>
#pragma warning disable CS0618 // Type or member is obsolete
    protected OpenAIFile WaitForFileProcessing(
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
#pragma warning restore CS0618 // Type or member is obsolete

    /// <summary>
    /// Asynchronously waits for a file to finish processing by polling its status.
    /// </summary>
    /// <param name="fileClient">The OpenAI file client.</param>
    /// <param name="fileId">The ID of the file to wait for.</param>
    /// <param name="pollIntervalSeconds">Polling interval in seconds (default: 5).</param>
    /// <param name="maxWaitSeconds">Maximum wait time in seconds (default: 1800 = 30 minutes).</param>
    /// <returns>The processed file.</returns>
#pragma warning disable CS0618 // Type or member is obsolete
    protected async System.Threading.Tasks.Task<OpenAIFile> WaitForFileProcessingAsync(
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

            await System.Threading.Tasks.Task.Delay(pollInterval);
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
#pragma warning restore CS0618 // Type or member is obsolete
}
