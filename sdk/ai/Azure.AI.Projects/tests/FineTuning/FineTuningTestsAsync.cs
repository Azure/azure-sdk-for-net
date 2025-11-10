// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.Agents;
using Azure.AI.OpenAI;
using Azure.AI.Projects.Tests.Utils;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests;

/// <summary>
/// Asynchronous live tests for fine-tuning operations.
/// </summary>
public class FineTuningTestsAsync : FineTuningTestsBase
{
    public FineTuningTestsAsync(bool isAsync) : base(isAsync)
    {
    }

    private async Task<(OpenAIFile TrainFile, OpenAIFile ValidationFile)> UploadTestFilesAsync(OpenAIFileClient fileClient, string jobType = "sft")
    {
        var dataDirectory = GetDataDirectory();
        string trainingFileName = $"{jobType}_training_set.jsonl";
        string validationFileName = $"{jobType}_validation_set.jsonl";
        var trainingFilePath = Path.Combine(dataDirectory, trainingFileName);
        var validationFilePath = Path.Combine(dataDirectory, validationFileName);

        Console.WriteLine($"Uploading training file: {trainingFileName}...");
        OpenAIFile trainFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(trainingFilePath)),
            trainingFileName,
            FileUploadPurpose.FineTune);
        Assert.IsNotNull(trainFile);
        Assert.IsNotNull(trainFile.Id);
        Console.WriteLine($"Uploaded training file: {trainFile.Id}");

        Console.WriteLine($"Uploading validation file: {validationFileName}...");
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(validationFilePath)),
            validationFileName,
            FileUploadPurpose.FineTune);
        Assert.IsNotNull(validationFile);
        Assert.IsNotNull(validationFile.Id);
        Console.WriteLine($"Uploaded validation file: {validationFile.Id}");

        Console.WriteLine("Waiting 10 seconds for files to complete processing...");
        await Task.Delay(10000);

        return (trainFile, validationFile);
    }

    private async Task CleanupTestFilesAsync(OpenAIFileClient fileClient, OpenAIFile trainFile, OpenAIFile validationFile)
    {
        if (trainFile != null)
        {
            try
            {
                ClientResult<FileDeletionResult> result = await fileClient.DeleteFileAsync(trainFile.Id);
                Console.WriteLine($"Deleted training file: {trainFile.Id} (deleted: {result.Value.Deleted})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete training file {trainFile.Id}: {ex.Message}");
            }
        }

        if (validationFile != null)
        {
            try
            {
                ClientResult<FileDeletionResult> result = await fileClient.DeleteFileAsync(validationFile.Id);
                Console.WriteLine($"Deleted validation file: {validationFile.Id} (deleted: {result.Value.Deleted})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete validation file {validationFile.Id}: {ex.Message}");
            }
        }
    }

    private async Task<FineTuningJob> CreateSupervisedFineTuningJobAsync(
        FineTuningClient fineTuningClient,
        string modelName,
        string trainFileId,
        string validationFileId,
        int epochCount = 1,
        int batchSize = 4,
        double learningRate = 0.0001)
    {
        return await fineTuningClient.FineTuneAsync(
            modelName,
            trainFileId,
            waitUntilCompleted: false,
            new()
            {
                TrainingMethod = FineTuningTrainingMethod.CreateSupervised(
                    epochCount: epochCount,
                    batchSize: batchSize,
                    learningRate: learningRate),
                ValidationFile = validationFileId
            });
    }

    private async Task<FineTuningJob> CreateDpoFineTuningJobAsync(
        FineTuningClient fineTuningClient,
        string modelName,
        string trainFileId,
        string validationFileId,
        int epochCount = 1,
        int batchSize = 4,
        double learningRate = 0.0001)
    {
        return await fineTuningClient.FineTuneAsync(
            modelName,
            trainFileId,
            waitUntilCompleted: false,
            new()
            {
                TrainingMethod = FineTuningTrainingMethod.CreateDirectPreferenceOptimization(
                    epochCount: epochCount,
                    batchSize: batchSize,
                    learningRate: learningRate),
                ValidationFile = validationFileId
            });
    }

    private async Task RunFineTuningLifecycleTestAsync(
        FineTuningClient fineTuningClient,
        FineTuningJob fineTuningJob,
        string testName)
    {
        Console.WriteLine($"[{testName}] Created job: {fineTuningJob.JobId}");
        ValidateFineTuningJob(fineTuningJob);

        // Retrieve job
        FineTuningJob retrievedJob = await fineTuningClient.GetJobAsync(fineTuningJob.JobId);
        Console.WriteLine($"[{testName}] Retrieved job: {retrievedJob.JobId}");
        ValidateFineTuningJob(retrievedJob, expectedJobId: fineTuningJob.JobId);

        // List jobs and verify our job is in the list
        var jobsList = new List<FineTuningJob>();
        await foreach (FineTuningJob job in fineTuningClient.GetJobsAsync())
        {
            jobsList.Add(job);
        }
        Console.WriteLine($"[{testName}] Listed {jobsList.Count} jobs");
        Assert.That(jobsList.Select(j => j.JobId), Does.Contain(fineTuningJob.JobId));

        // Pause job
        // Console.WriteLine($"[{testName}] Pausing job: {retrievedJob.JobId}");
        // await fineTuningClient.PauseFineTuningJobAsync(retrievedJob.JobId, options: null);
        // FineTuningJob pausedJob = await fineTuningClient.GetJobAsync(retrievedJob.JobId);
        // Console.WriteLine($"[{testName}] Paused job: {pausedJob.JobId}, Status: {pausedJob.Status}");

        // // Resume job
        // Console.WriteLine($"[{testName}] Resuming job: {pausedJob.JobId}");
        // await fineTuningClient.ResumeFineTuningJobAsync(pausedJob.JobId, options: null);
        // FineTuningJob resumedJob = await fineTuningClient.GetJobAsync(pausedJob.JobId);
        // Console.WriteLine($"[{testName}] Resumed job: {resumedJob.JobId}, Status: {resumedJob.Status}");

        // List events
        var eventsList = new List<FineTuningEvent>();
        await foreach (FineTuningEvent evt in retrievedJob.GetEventsAsync(new GetEventsOptions()))
        {
            eventsList.Add(evt);
        }
        Console.WriteLine($"[{testName}] Listed {eventsList.Count} events");
        Assert.That(eventsList.Count, Is.GreaterThan(0));

        // Cancel job
        await retrievedJob.CancelAndUpdateAsync();
        Console.WriteLine($"[{testName}] Cancelled job: {retrievedJob.JobId}");
        Assert.AreEqual("cancelled", retrievedJob.Status.ToString().ToLowerInvariant());
    }

    [Test]
    [AsyncOnly]
    public async Task SftFineTuning_FullLifecycle()
    {
        var (fileClient, fineTuningClient) = GetClients();

        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "sft");

        try
        {
            // Create job
            FineTuningJob fineTuningJob = await CreateSupervisedFineTuningJobAsync(
                fineTuningClient,
                "gpt-4.1",
                trainFile.Id,
                validationFile.Id,
                epochCount: 1,
                batchSize: 4,
                learningRate: 0.0001);

            // Run lifecycle test
            await RunFineTuningLifecycleTestAsync(fineTuningClient, fineTuningJob, "sft_lifecycle");
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [Test]
    [AsyncOnly]
    public async Task SftOssFineTuning_FullLifecycle()
    {
        var (fileClient, fineTuningClient) = GetClients();

        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "sft");

        try
        {
            // Create job with OSS model
            FineTuningJob fineTuningJob = await CreateSupervisedFineTuningJobAsync(
                fineTuningClient,
                "Ministral-3B",
                trainFile.Id,
                validationFile.Id,
                epochCount: 1,
                batchSize: 4,
                learningRate: 0.0001);

            // Run lifecycle test
            await RunFineTuningLifecycleTestAsync(fineTuningClient, fineTuningJob, "sft_oss_lifecycle");
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [Test]
    [AsyncOnly]
    public async Task DpoFineTuning_FullLifecycle()
    {
        var (fileClient, fineTuningClient) = GetClients();

        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "dpo");

        try
        {
            // Create job
            FineTuningJob fineTuningJob = await CreateDpoFineTuningJobAsync(
                fineTuningClient,
                "gpt-4o-mini",
                trainFile.Id,
                validationFile.Id,
                epochCount: 1,
                batchSize: 4,
                learningRate: 0.0001);

            // Run lifecycle test
            await RunFineTuningLifecycleTestAsync(fineTuningClient, fineTuningJob, "dpo_lifecycle");
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [Test]
    [AsyncOnly]
    public async Task RftFineTuning_FullLifecycle()
    {
        var (fileClient, fineTuningClient) = GetClients();

        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "rft");

        // Build the JSON request manually since RL APIs are internal
        var requestJson = new
        {
            model = "o4-mini",
            training_file = trainFile.Id,
            validation_file = validationFile.Id,
            method = new
            {
                type = "reinforcement",
                reinforcement = new
                {
                    grader = new
                    {
                        type = "score_model",
                        name = "o3-mini",
                        model = "o3-mini",
                        input = new[]
                        {
                            new
                            {
                                role = "user",
                                content = "Evaluate the model's response based on correctness and quality. Rate from 0 to 10."
                            }
                        },
                        range = new[] { 0.0, 10.0 }
                    },
                    hyperparameters = new
                    {
                        n_epochs = 1,
                        batch_size = 4,
                        learning_rate_multiplier = 2,
                        eval_interval = 5,
                        eval_samples = 2,
                        reasoning_effort = "medium"
                    }
                }
            }
        };

        try
        {
            // Create job
            string jsonString = JsonSerializer.Serialize(requestJson);
            BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonString));
            FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);

            // Run lifecycle test
            await RunFineTuningLifecycleTestAsync(fineTuningClient, fineTuningJob, "rft_lifecycle");
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }
}
