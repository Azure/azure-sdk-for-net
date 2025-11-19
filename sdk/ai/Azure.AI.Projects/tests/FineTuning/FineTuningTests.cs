// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests;

/// <summary>
/// Recorded asynchronous tests for fine-tuning operations using test-proxy.
/// </summary>
public class FineTuningTests : FineTuningTestsBase
{
    public FineTuningTests(bool isAsync) : base(isAsync)
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
        Assert.That(trainFile, Is.Not.Null);
        Assert.That(trainFile.Id, Is.Not.Null);
        Console.WriteLine($"Uploaded training file: {trainFile.Id}");

        Console.WriteLine($"Uploading validation file: {validationFileName}...");
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(validationFilePath)),
            validationFileName,
            FileUploadPurpose.FineTune);
        Assert.That(validationFile, Is.Not.Null);
        Assert.That(validationFile.Id, Is.Not.Null);
        Console.WriteLine($"Uploaded validation file: {validationFile.Id}");

        Console.WriteLine("Waiting for files to complete processing...");
        await WaitForFileProcessingAsync(fileClient, trainFile.Id, pollIntervalSeconds: 2);
        await WaitForFileProcessingAsync(fileClient, validationFile.Id, pollIntervalSeconds: 2);

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

    private async Task<FineTuningJob> CreateSupervisedFineTuningJobForOssModelAsync(
        FineTuningClient fineTuningClient,
        string modelName,
        string trainFileId,
        string validationFileId,
        string trainingType,
        int epochCount = 1,
        int batchSize = 4,
        double learningRate = 0.0001)
    {
        var requestJson = new
        {
            model = modelName,
            training_file = trainFileId,
            validation_file = validationFileId,
            trainingType = trainingType,
            method = new
            {
                type = "supervised",
                supervised = new
                {
                    hyperparameters = new
                    {
                        n_epochs = epochCount,
                        batch_size = batchSize,
                        learning_rate_multiplier = learningRate
                    }
                }
            }
        };

        string jsonString = JsonSerializer.Serialize(requestJson);
        BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonString));
        return await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);
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

    [RecordedTest]
    public async Task Test_Sft_FineTuning_Create_Job()
    {
        var (fileClient, fineTuningClient) = GetClients();
        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "sft");

        try
        {
            FineTuningJob fineTuningJob = await CreateSupervisedFineTuningJobAsync(
                fineTuningClient,
                "gpt-4.1",
                trainFile.Id,
                validationFile.Id,
                epochCount: 1,
                batchSize: 4,
                learningRate: 0.0001);

            Console.WriteLine($"Created SFT job: {fineTuningJob.JobId}");
            ValidateFineTuningJob(fineTuningJob);
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [RecordedTest]
    public async Task Test_Sft_FineTuning_Create_Job_Oss_Model()
    {
        var (fileClient, fineTuningClient) = GetClients();
        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "sft");

        try
        {
            FineTuningJob fineTuningJob = await CreateSupervisedFineTuningJobForOssModelAsync(
                fineTuningClient,
                "Ministral-3B",
                trainFile.Id,
                validationFile.Id,
                trainingType: "GlobalStandard",
                epochCount: 1,
                batchSize: 4,
                learningRate: 0.0001);

            Console.WriteLine($"Created SFT OSS job: {fineTuningJob.JobId}");
            ValidateFineTuningJob(fineTuningJob);
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [RecordedTest]
    public async Task Test_Dpo_FineTuning_Create_Job()
    {
        var (fileClient, fineTuningClient) = GetClients();
        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "dpo");

        try
        {
            FineTuningJob fineTuningJob = await CreateDpoFineTuningJobAsync(
                fineTuningClient,
                "gpt-4o-mini",
                trainFile.Id,
                validationFile.Id,
                epochCount: 1,
                batchSize: 4,
                learningRate: 0.0001);

            Console.WriteLine($"Created DPO job: {fineTuningJob.JobId}");
            ValidateFineTuningJob(fineTuningJob);
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [RecordedTest]
    public async Task Test_Rft_FineTuning_Create_Job()
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
            string jsonString = JsonSerializer.Serialize(requestJson);
            BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonString));
            FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);

            Console.WriteLine($"Created RFT job: {fineTuningJob.JobId}");
            ValidateFineTuningJob(fineTuningJob);
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [RecordedTest]
    public async Task Test_FineTuning_Retrieve_Job()
    {
        var (fileClient, fineTuningClient) = GetClients();
        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "sft");

        try
        {
            // Create a job first
            FineTuningJob createdJob = await CreateSupervisedFineTuningJobAsync(
                fineTuningClient,
                "gpt-4.1",
                trainFile.Id,
                validationFile.Id);

            // Retrieve the job
            FineTuningJob retrievedJob = await fineTuningClient.GetJobAsync(createdJob.JobId);
            Console.WriteLine($"Retrieved job: {retrievedJob.JobId}");
            ValidateFineTuningJob(retrievedJob, expectedJobId: createdJob.JobId);

            // Cancel the job
            await retrievedJob.CancelAndUpdateAsync();
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [RecordedTest]
    public async Task Test_FineTuning_List_Jobs()
    {
        var (fileClient, fineTuningClient) = GetClients();
        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "sft");

        try
        {
            // Create a job first
            FineTuningJob createdJob = await CreateSupervisedFineTuningJobAsync(
                fineTuningClient,
                "gpt-4.1",
                trainFile.Id,
                validationFile.Id);

            // List jobs and verify our job is in the list
            var jobsList = new List<FineTuningJob>();
            await foreach (FineTuningJob job in fineTuningClient.GetJobsAsync())
            {
                jobsList.Add(job);
            }
            Console.WriteLine($"Listed {jobsList.Count} jobs");
            Assert.That(jobsList.Count, Is.GreaterThan(0));
            Assert.That(jobsList.Select(j => j.JobId), Does.Contain(createdJob.JobId));

            // Cancel the job
            await createdJob.CancelAndUpdateAsync();
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [RecordedTest]
    public async Task Test_FineTuning_Cancel_Job()
    {
        var (fileClient, fineTuningClient) = GetClients();
        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "sft");

        try
        {
            // Create a job
            FineTuningJob createdJob = await CreateSupervisedFineTuningJobAsync(
                fineTuningClient,
                "gpt-4.1",
                trainFile.Id,
                validationFile.Id);

            Console.WriteLine($"Created job: {createdJob.JobId}");

            // Cancel the job
            await createdJob.CancelAndUpdateAsync();
            Console.WriteLine($"Cancelled job: {createdJob.JobId}, Status: {createdJob.Status}");
            Assert.That(createdJob.Status.ToString().ToLowerInvariant(), Is.EqualTo("cancelled"));
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [RecordedTest]
    public async Task Test_FineTuning_List_Events()
    {
        var (fileClient, fineTuningClient) = GetClients();
        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "sft");

        try
        {
            // Create a job
            FineTuningJob createdJob = await CreateSupervisedFineTuningJobAsync(
                fineTuningClient,
                "gpt-4.1",
                trainFile.Id,
                validationFile.Id);

            // List events
            var eventsList = new List<FineTuningEvent>();
            await foreach (FineTuningEvent evt in createdJob.GetEventsAsync(new GetEventsOptions()))
            {
                eventsList.Add(evt);
            }
            Console.WriteLine($"Listed {eventsList.Count} events for job {createdJob.JobId}");
            Assert.That(eventsList.Count, Is.GreaterThan(0));

            // Cancel the job
            await createdJob.CancelAndUpdateAsync();
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }
}
