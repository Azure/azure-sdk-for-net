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
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests;

/// <summary>
/// Synchronous live tests for fine-tuning operations.
/// </summary>
public class FineTuningTests : FineTuningTestsBase
{
    public FineTuningTests(bool isAsync) : base(isAsync)
    {
    }

    private (OpenAIFile TrainFile, OpenAIFile ValidationFile) UploadTestFiles(OpenAIFileClient fileClient, string jobType = "sft")
    {
        var dataDirectory = GetDataDirectory();
        string trainingFileName = $"{jobType}_training_set.jsonl";
        string validationFileName = $"{jobType}_validation_set.jsonl";
        var trainingFilePath = Path.Combine(dataDirectory, trainingFileName);
        var validationFilePath = Path.Combine(dataDirectory, validationFileName);

        Console.WriteLine($"Uploading training file: {trainingFileName}...");
        OpenAIFile trainFile = fileClient.UploadFile(
            BinaryData.FromBytes(File.ReadAllBytes(trainingFilePath)),
            trainingFileName,
            FileUploadPurpose.FineTune);
        Assert.IsNotNull(trainFile);
        Assert.IsNotNull(trainFile.Id);
        Console.WriteLine($"Uploaded training file: {trainFile.Id}");

        Console.WriteLine($"Uploading validation file: {validationFileName}...");
        OpenAIFile validationFile = fileClient.UploadFile(
            BinaryData.FromBytes(File.ReadAllBytes(validationFilePath)),
            validationFileName,
            FileUploadPurpose.FineTune);
        Assert.IsNotNull(validationFile);
        Assert.IsNotNull(validationFile.Id);
        Console.WriteLine($"Uploaded validation file: {validationFile.Id}");

        Console.WriteLine("Waiting 10 seconds for files to complete processing...");
        System.Threading.Thread.Sleep(10000);

        return (trainFile, validationFile);
    }

    private void CleanupTestFiles(OpenAIFileClient fileClient, OpenAIFile trainFile, OpenAIFile validationFile)
    {
        if (trainFile != null)
        {
            try
            {
                ClientResult<FileDeletionResult> result = fileClient.DeleteFile(trainFile.Id);
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
                ClientResult<FileDeletionResult> result = fileClient.DeleteFile(validationFile.Id);
                Console.WriteLine($"Deleted validation file: {validationFile.Id} (deleted: {result.Value.Deleted})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete validation file {validationFile.Id}: {ex.Message}");
            }
        }
    }

    private FineTuningJob CreateSupervisedFineTuningJob(
        FineTuningClient fineTuningClient,
        string modelName,
        string trainFileId,
        string validationFileId,
        int epochCount = 1,
        int batchSize = 4,
        double learningRate = 0.0001)
    {
        return fineTuningClient.FineTune(
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

    private FineTuningJob CreateDpoFineTuningJob(
        FineTuningClient fineTuningClient,
        string modelName,
        string trainFileId,
        string validationFileId,
        int epochCount = 1,
        int batchSize = 4,
        double learningRate = 0.0001)
    {
        return fineTuningClient.FineTune(
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

    private void RunFineTuningLifecycleTest(
        FineTuningClient fineTuningClient,
        FineTuningJob fineTuningJob,
        string testName)
    {
        Console.WriteLine($"[{testName}] Created job: {fineTuningJob.JobId}");
        ValidateFineTuningJob(fineTuningJob);

        // Retrieve job
        FineTuningJob retrievedJob = fineTuningClient.GetJob(fineTuningJob.JobId);
        Console.WriteLine($"[{testName}] Retrieved job: {retrievedJob.JobId}");
        ValidateFineTuningJob(retrievedJob, expectedJobId: fineTuningJob.JobId);

        // List jobs and verify our job is in the list
        var jobsList = new List<FineTuningJob>();
        foreach (FineTuningJob job in fineTuningClient.GetJobs())
        {
            jobsList.Add(job);
        }
        Console.WriteLine($"[{testName}] Listed {jobsList.Count} jobs");
        Assert.That(jobsList.Select(j => j.JobId), Does.Contain(fineTuningJob.JobId));

        // Pause job
        // Console.WriteLine($"[{testName}] Pausing job: {retrievedJob.JobId}");
        // fineTuningClient.PauseFineTuningJob(retrievedJob.JobId, options: null);
        // FineTuningJob pausedJob = fineTuningClient.GetJob(retrievedJob.JobId);
        // Console.WriteLine($"[{testName}] Paused job: {pausedJob.JobId}, Status: {pausedJob.Status}");

        // // Resume job
        // Console.WriteLine($"[{testName}] Resuming job: {pausedJob.JobId}");
        // fineTuningClient.ResumeFineTuningJob(pausedJob.JobId, options: null);
        // FineTuningJob resumedJob = fineTuningClient.GetJob(pausedJob.JobId);
        // Console.WriteLine($"[{testName}] Resumed job: {resumedJob.JobId}, Status: {resumedJob.Status}");

        // List events
        var eventsList = new List<FineTuningEvent>();
        foreach (FineTuningEvent evt in retrievedJob.GetEvents(new GetEventsOptions()))
        {
            eventsList.Add(evt);
        }
        Console.WriteLine($"[{testName}] Listed {eventsList.Count} events");
        Assert.That(eventsList.Count, Is.GreaterThan(0));

        // Cancel job
        retrievedJob.CancelAndUpdate();
        Console.WriteLine($"[{testName}] Cancelled job: {retrievedJob.JobId}");
        Assert.AreEqual("cancelled", retrievedJob.Status.ToString().ToLowerInvariant());
    }

    [Test]
    [SyncOnly]
    public void SftFineTuning_FullLifecycleSync()
    {
        var (fileClient, fineTuningClient) = GetClients();

        var (trainFile, validationFile) = UploadTestFiles(fileClient, "sft");

        try
        {
            // Create job
            FineTuningJob fineTuningJob = CreateSupervisedFineTuningJob(
                fineTuningClient,
                "gpt-4.1",
                trainFile.Id,
                validationFile.Id,
                epochCount: 1,
                batchSize: 4,
                learningRate: 0.0001);

            // Run lifecycle test
            RunFineTuningLifecycleTest(fineTuningClient, fineTuningJob, "sft_lifecycle_sync");
        }
        finally
        {
            CleanupTestFiles(fileClient, trainFile, validationFile);
        }
    }

    [Test]
    [SyncOnly]
    public void SftOssFineTuning_FullLifecycleSync()
    {
        var (fileClient, fineTuningClient) = GetClients();

        var (trainFile, validationFile) = UploadTestFiles(fileClient, "sft");

        try
        {
            // Create job with OSS model
            FineTuningJob fineTuningJob = CreateSupervisedFineTuningJob(
                fineTuningClient,
                "Ministral-3B",
                trainFile.Id,
                validationFile.Id,
                epochCount: 1,
                batchSize: 4,
                learningRate: 0.0001);

            // Run lifecycle test
            RunFineTuningLifecycleTest(fineTuningClient, fineTuningJob, "sft_oss_lifecycle_sync");
        }
        finally
        {
            CleanupTestFiles(fileClient, trainFile, validationFile);
        }
    }

    [Test]
    [SyncOnly]
    public void DpoFineTuning_FullLifecycleSync()
    {
        var (fileClient, fineTuningClient) = GetClients();

        var (trainFile, validationFile) = UploadTestFiles(fileClient, "dpo");

        try
        {
            // Create job
            FineTuningJob fineTuningJob = CreateDpoFineTuningJob(
                fineTuningClient,
                "gpt-4o-mini",
                trainFile.Id,
                validationFile.Id,
                epochCount: 1,
                batchSize: 4,
                learningRate: 0.0001);

            // Run lifecycle test
            RunFineTuningLifecycleTest(fineTuningClient, fineTuningJob, "dpo_lifecycle_sync");
        }
        finally
        {
            CleanupTestFiles(fileClient, trainFile, validationFile);
        }
    }

    [Test]
    [SyncOnly]
    public void RftFineTuning_FullLifecycleSync()
    {
        var (fileClient, fineTuningClient) = GetClients();

        var (trainFile, validationFile) = UploadTestFiles(fileClient, "rft");

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
            FineTuningJob fineTuningJob = fineTuningClient.FineTune(content, waitUntilCompleted: false, options: null);

            // Run lifecycle test
            RunFineTuningLifecycleTest(fineTuningClient, fineTuningJob, "rft_lifecycle_sync");
        }
        finally
        {
            CleanupTestFiles(fileClient, trainFile, validationFile);
        }
    }
}
