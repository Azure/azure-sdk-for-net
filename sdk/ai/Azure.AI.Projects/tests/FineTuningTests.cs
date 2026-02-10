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
using Azure.AI.Projects.OpenAI;
using Microsoft.ClientModel.TestFramework;
using Azure.ResourceManager;
using Azure.ResourceManager.CognitiveServices;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.Identity;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests;

/// <summary>
/// Recorded asynchronous tests for fine-tuning operations using test-proxy.
/// </summary>
public class FineTuningTests : ProjectsClientTestBase
{
    public FineTuningTests(bool isAsync) : base(isAsync)
    {
    }

    private async Task<(OpenAIFile TrainFile, OpenAIFile ValidationFile)> UploadTestFilesAsync(OpenAIFileClient fileClient, string jobType = "sft")
    {
        string trainingFileName = $"{jobType}_training_set.jsonl";
        string validationFileName = $"{jobType}_validation_set.jsonl";
        var trainingFilePath = GetTestFineTuningFile(trainingFileName);
        var validationFilePath = GetTestFineTuningFile(validationFileName);

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

    /// <summary>
    /// Creates a SFT or DPO fine-tuning job using raw JSON (for trainingType support).
    /// </summary>
    private async Task<FineTuningJob> CreateFineTuningJobWithRawJsonAsync(
        FineTuningClient fineTuningClient,
        string modelName,
        string trainFileId,
        string validationFileId,
        string jobType,
        string trainingType = null,
        int epochCount = 1,
        int batchSize = 4,
        double learningRate = 0.0001)
    {
        object methodObject = jobType.ToLowerInvariant() switch
        {
            "supervised" or "sft" => new
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
            },
            "dpo" => new
            {
                type = "dpo",
                dpo = new
                {
                    hyperparameters = new
                    {
                        n_epochs = epochCount,
                        batch_size = batchSize,
                        learning_rate_multiplier = learningRate
                    }
                }
            },
            _ => throw new ArgumentException($"Unknown job type: {jobType}. Use CreateRftFineTuningJobAsync for RFT jobs.", nameof(jobType))
        };

        var requestJson = new Dictionary<string, object>
        {
            ["model"] = modelName,
            ["training_file"] = trainFileId,
            ["validation_file"] = validationFileId,
            ["method"] = methodObject
        };

        if (!string.IsNullOrEmpty(trainingType))
        {
            requestJson["trainingType"] = trainingType;
        }

        string jsonString = JsonSerializer.Serialize(requestJson);
        BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonString));
        return await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);
    }

    private async Task<FineTuningJob> CreateSupervisedFineTuningJobAsync(
        FineTuningClient fineTuningClient,
        string modelName,
        string trainFileId,
        string validationFileId,
        string trainingType = null,
        int epochCount = 1,
        int batchSize = 4,
        double learningRate = 0.0001)
    {
        // Use raw JSON if trainingType is specified (required for Azure-specific field and OSS models)
        if (!string.IsNullOrEmpty(trainingType))
        {
            return await CreateFineTuningJobWithRawJsonAsync(
                fineTuningClient, modelName, trainFileId, validationFileId,
                jobType: "sft", trainingType: trainingType,
                epochCount: epochCount, batchSize: batchSize, learningRate: learningRate);
        }

        // Default: use the SDK's typed API
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
        string trainingType = null,
        int epochCount = 1,
        int batchSize = 4,
        double learningRate = 0.0001)
    {
        // Use raw JSON if trainingType is specified (required for Azure-specific field)
        if (!string.IsNullOrEmpty(trainingType))
        {
            return await CreateFineTuningJobWithRawJsonAsync(
                fineTuningClient, modelName, trainFileId, validationFileId,
                jobType: "dpo", trainingType: trainingType,
                epochCount: epochCount, batchSize: batchSize, learningRate: learningRate);
        }

        // Default: use the SDK's typed API
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

    private async Task<FineTuningJob> CreateRftFineTuningJobAsync(
        FineTuningClient fineTuningClient,
        string modelName,
        string trainFileId,
        string validationFileId,
        string trainingType = null,
        int epochCount = 1,
        int batchSize = 4,
        double learningRate = 2,
        int evalInterval = 5,
        int evalSamples = 2,
        string reasoningEffort = "medium")
    {
        // RFT uses raw JSON with its own structure (grader + RFT-specific hyperparameters)
        var methodObject = new
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
                    n_epochs = epochCount,
                    batch_size = batchSize,
                    learning_rate_multiplier = learningRate,
                    eval_interval = evalInterval,
                    eval_samples = evalSamples,
                    reasoning_effort = reasoningEffort
                }
            }
        };

        var requestJson = new Dictionary<string, object>
        {
            ["model"] = modelName,
            ["training_file"] = trainFileId,
            ["validation_file"] = validationFileId,
            ["method"] = methodObject
        };

        if (!string.IsNullOrEmpty(trainingType))
        {
            requestJson["trainingType"] = trainingType;
        }

        string jsonString = JsonSerializer.Serialize(requestJson);
        BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonString));
        return await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);
    }

    private async Task RunSftCreateJobTestAsync(string trainingType)
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
                trainingType: trainingType,
                epochCount: 1,
                batchSize: 4,
                learningRate: 0.0001);

            Console.WriteLine($"Created SFT job with {trainingType} training type: {fineTuningJob.JobId}");
            ValidateFineTuningJob(fineTuningJob);

            // Cancel the job
            await fineTuningJob.CancelAndUpdateAsync();
            Console.WriteLine($"Cancelled job: {fineTuningJob.JobId}");
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    private async Task RunDpoCreateJobTestAsync(string trainingType)
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
                trainingType: trainingType,
                epochCount: 1,
                batchSize: 4,
                learningRate: 0.0001);

            Console.WriteLine($"Created DPO job with {trainingType} training type: {fineTuningJob.JobId}");
            ValidateFineTuningJob(fineTuningJob);

            // Cancel the job
            await fineTuningJob.CancelAndUpdateAsync();
            Console.WriteLine($"Cancelled job: {fineTuningJob.JobId}");
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    private async Task RunRftCreateJobTestAsync(string trainingType)
    {
        TestTimeoutInSeconds = 120; // Increase timeout to 2 minutes for RFT job operations

        var (fileClient, fineTuningClient) = GetClients();
        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "rft");

        try
        {
            FineTuningJob fineTuningJob = await CreateRftFineTuningJobAsync(
                fineTuningClient,
                "o4-mini",
                trainFile.Id,
                validationFile.Id,
                trainingType: trainingType);

            Console.WriteLine($"Created RFT job with {trainingType} training type: {fineTuningJob.JobId}");
            ValidateFineTuningJob(fineTuningJob);

            // Cancel the job
            await fineTuningJob.CancelAndUpdateAsync();
            Console.WriteLine($"Cancelled job: {fineTuningJob.JobId}");
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
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

            // Cancel the job
            await fineTuningJob.CancelAndUpdateAsync();
            Console.WriteLine($"Cancelled job: {fineTuningJob.JobId}");
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [RecordedTest]
    public async Task Test_Sft_FineTuning_Create_Job_OpenAI_Standard()
    {
        await RunSftCreateJobTestAsync("Standard");
    }

    [RecordedTest]
    public async Task Test_Sft_FineTuning_Create_Job_OpenAI_Developer()
    {
        await RunSftCreateJobTestAsync("developerTier");
    }

    [RecordedTest]
    public async Task Test_Sft_FineTuning_Create_Job_OpenAI_GlobalStandard()
    {
        await RunSftCreateJobTestAsync("GlobalStandard");
    }

    [RecordedTest]
    public async Task Test_Sft_FineTuning_Create_Job_Oss_Model()
    {
        var (fileClient, fineTuningClient) = GetClients();
        var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "sft");

        try
        {
            FineTuningJob fineTuningJob = await CreateSupervisedFineTuningJobAsync(
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

            // Cancel the job
            await fineTuningJob.CancelAndUpdateAsync();
            Console.WriteLine($"Cancelled job: {fineTuningJob.JobId}");
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

            // Cancel the job
            await fineTuningJob.CancelAndUpdateAsync();
            Console.WriteLine($"Cancelled job: {fineTuningJob.JobId}");
        }
        finally
        {
            await CleanupTestFilesAsync(fileClient, trainFile, validationFile);
        }
    }

    [RecordedTest]
    public async Task Test_Dpo_FineTuning_Create_Job_OpenAI_Standard()
    {
        await RunDpoCreateJobTestAsync("Standard");
    }

    [RecordedTest]
    public async Task Test_Dpo_FineTuning_Create_Job_OpenAI_Developer()
    {
        await RunDpoCreateJobTestAsync("developerTier");
    }

    [RecordedTest]
    public async Task Test_Dpo_FineTuning_Create_Job_OpenAI_GlobalStandard()
    {
        await RunDpoCreateJobTestAsync("GlobalStandard");
    }

    [RecordedTest]
    public async Task Test_Rft_FineTuning_Create_Job()
    {
        await RunRftCreateJobTestAsync(null);
    }

    [RecordedTest]
    public async Task Test_Rft_FineTuning_Create_Job_OpenAI_Standard()
    {
        await RunRftCreateJobTestAsync("Standard");
    }

    [RecordedTest]
    public async Task Test_Rft_FineTuning_Create_Job_OpenAI_Developer()
    {
        await RunRftCreateJobTestAsync("developerTier");
    }

    [RecordedTest]
    public async Task Test_Rft_FineTuning_Create_Job_OpenAI_GlobalStandard()
    {
        await RunRftCreateJobTestAsync("GlobalStandard");
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
        TestTimeoutInSeconds = 120; // Increase timeout for listing jobs

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
    public async Task Test_FineTuning_Pause_Job()
    {
        // Note: This test uses a running fine-tuning job ID to test pause functionality.
        // Pause is only valid for jobs that are currently running (not queued, completed, or cancelled).
        // When re-recording this test, ensure the job is in a running state.
        var (fileClient, fineTuningClient) = GetClients();
        //var (trainFile, validationFile) = await UploadTestFilesAsync(fileClient, "dpo");
        //FineTuningJob job = await CreateDpoFineTuningJobAsync(
        //        fineTuningClient,
        //        "gpt-4.1",
        //        trainFile.Id,
        //        validationFile.Id);
        //// Retrieve the job in running state
        //while (job.Status != FineTuningStatus.Running && job.Status != FineTuningStatus.Failed)
        //{
        //    if (Mode != RecordedTestMode.Playback)
        //    {
        //        System.Threading.Thread.Sleep(1);
        //    }
        //    job = await fineTuningClient.GetJobAsync(job.JobId);
        //}
        // We cannot check that the job status is FineTuningStatus.Running instead we need to
        // check the event logs and retry pause once Training started event is emitted.
        FineTuningJob job = await fineTuningClient.GetJobAsync("ftjob-5b45a9d50470481fa8f6d91f0b07da0c");
        Assert.That(job.Status, Is.EqualTo(FineTuningStatus.Running), $"The job status is {job.Status}");

        // Pause the job
        await fineTuningClient.PauseFineTuningJobAsync(job.JobId, options: null);

        // Retrieve the job again to verify status
        FineTuningJob pausedJob = await fineTuningClient.GetJobAsync(job.JobId);
        // Verify the job is paused (status should be "paused" or similar)
        Assert.That(pausedJob, Is.Not.Null);
        HashSet<string> validStatuses = ["paused", "pausing"];
        Assert.That(validStatuses.Contains(pausedJob.Status.ToString().ToLowerInvariant()), $"The job status is {pausedJob.Status}");
        Assert.That(pausedJob.JobId, Is.EqualTo(job.JobId));
    }

    [RecordedTest]
    public async Task Test_FineTuning_Resume_Job()
    {
        // Note: This test uses a paused fine-tuning job ID to test resume functionality.
        // Resume is only valid for jobs that are currently paused.
        // When re-recording this test, ensure the job is in a paused state.
        string pausedJobId = "ftjob-ed1d6ce69401454da5eeae9002ca8166";

        var (_, fineTuningClient) = GetClients();

        // Retrieve the job first
        FineTuningJob job = await fineTuningClient.GetJobAsync(pausedJobId);
        Assert.That(job.Status, Is.EqualTo("paused"), $"The job status is {job.Status}", $"Retrieved job: {job.JobId}, Status: {job.Status}");

        // Resume the job
        Console.WriteLine($"Resuming fine-tuning job with ID: {pausedJobId}");
        await fineTuningClient.ResumeFineTuningJobAsync(pausedJobId, options: null);

        // Retrieve the job again to verify status
        FineTuningJob resumedJob = await fineTuningClient.GetJobAsync(pausedJobId);
        HashSet<string> validStatuses = ["running", "queued", "resuming"]; // Using string comparison directly since resuming status is not available in FineTuningStatus enum
        Assert.That(validStatuses.Contains(resumedJob.Status.ToString().ToLowerInvariant()), $"The job has wrong status {resumedJob.Status}");

        // Verify the job is resumed (status should be "running", "queued", or "resuming")
        Assert.That(resumedJob, Is.Not.Null);
        Assert.That(resumedJob.JobId, Is.EqualTo(pausedJobId));
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

    [RecordedTest]
    public async Task Test_FineTuning_List_Checkpoints()
    {
        // Note: This test uses a pre-completed fine-tuning job ID because checkpoints
        // are only available for jobs in terminal state and completing a job takes signicant
        // time and the test can't be halted that long. When re-recording this test, ensure the
        // job used is in terminal state.
        string preCompletedJobId = TestEnvironment.FINE_TUNING_COMPLETED_JOB;

        var (_, fineTuningClient) = GetClients();

        // Retrieve the completed job
        FineTuningJob completedJob = await fineTuningClient.GetJobAsync(preCompletedJobId);
        Console.WriteLine($"Retrieved completed job: {completedJob.JobId}, Status: {completedJob.Status}");

        // List checkpoints
        var checkpointsList = new List<FineTuningCheckpoint>();
        await foreach (FineTuningCheckpoint checkpoint in completedJob.GetCheckpointsAsync(new GetCheckpointsOptions()))
        {
            checkpointsList.Add(checkpoint);
            Console.WriteLine($"Checkpoint: {checkpoint.Id} at step {checkpoint.StepNumber}");
        }

        Console.WriteLine($"Listed {checkpointsList.Count} checkpoints for job {completedJob.JobId}");
        Assert.That(checkpointsList.Count, Is.GreaterThan(0));
        Assert.That(checkpointsList[0].Id, Is.Not.Null);
        Assert.That(checkpointsList[0].StepNumber, Is.GreaterThan(0));
    }

    [RecordedTest]
    public async Task Test_FineTuning_Inference_With_Existing_Deployment()
    {
        // Test inference with an existing fine-tuned model deployment, update this when re-recording
        // Please run the Test_FineTuning_Deploy_Model() test in the Live mode to deploy a model.
        // Deployment should look like ft-deployment-gpt-4.1-mini-2025-04-14-2025-11-25 and can be
        // found in the output of the mentioned test.
        string deploymentName = TestEnvironment.FINE_TUNING_DEPLOYMENT_ID;

        // Get project client and responses client
        AIProjectClient projectClient = GetTestProjectClient();
        // Get responses client for the specific deployment (model)
        var responsesClient = projectClient.OpenAI.GetProjectResponsesClientForModel(deploymentName);

        // Perform inference
        string prompt = "What is the capital of France?";
        Console.WriteLine($"Sending prompt: {prompt}");

        ClientResult<ResponseResult> result = await responsesClient.CreateResponseAsync(prompt);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value.OutputItems, Is.Not.Null.And.Not.Empty);

        // Get the last message item (which should be the response)
        var messageItem = result.Value.OutputItems
            .OfType<MessageResponseItem>()
            .LastOrDefault();

        Assert.That(messageItem, Is.Not.Null);
        Assert.That(messageItem.Content, Has.Count.GreaterThan(0));
        Assert.That(messageItem.Content[0].Text, Is.Not.Null.And.Not.Empty);

        Console.WriteLine($"Response: {messageItem.Content[0].Text}");
    }

    [Test]
    // Skip recording since ARM operations are not recorded via the test proxy.
    [LiveOnly]
    public async Task Test_FineTuning_Deploy_Model()
    {
        // This test demonstrates deploying a fine-tuned model using Azure Resource Manager.
        // It requires a completed fine-tuning job and takes approximately 30 minutes to complete.
        // Override the default 10 second timeout for this long-running deployment test
        TestTimeoutInSeconds = 300; // 5 minutes for deployment operations in playback mode

        // Pre-completed job ID - update this when re-recording
        string completedJobId = TestEnvironment.FINE_TUNING_COMPLETED_JOB;

        var (_, fineTuningClient) = GetClients();

        // Get the completed fine-tuning job
        FineTuningJob completedJob = await fineTuningClient.GetJobAsync(completedJobId);
        Console.WriteLine($"Retrieved completed job: {completedJob.JobId}");
        Console.WriteLine($"Status: {completedJob.Status}");
        Console.WriteLine($"Fine-tuned model: {completedJob.Value}");

        // Configure deployment
        string deploymentName = $"ft-deployment-{completedJob.BaseModel}-{DateTimeOffset.UtcNow:yyyy-MM-dd}";
        string fineTunedModelName = completedJob.Value; // The fine-tuned model identifier

        Console.WriteLine($"Deploying model '{fineTunedModelName}' as '{deploymentName}'...");

        // Create ARM client
        var credential = new DefaultAzureCredential();
        var armClient = new ArmClient(credential);

        // Get Cognitive Services account
        var resourceId = CognitiveServicesAccountResource.CreateResourceIdentifier(
            TestEnvironment.FINE_TUNING_AZURE_SUBSCRIPTION_ID,
            TestEnvironment.FINE_TUNING_AZURE_RESOURCE_GROUP,
            TestEnvironment.FINE_TUNING_AZURE_FOUNDRY_NAME);
        var accountResource = armClient.GetCognitiveServicesAccountResource(resourceId);

        // Deploy the model
        var deploymentData = new CognitiveServicesAccountDeploymentData
        {
            Properties = new CognitiveServicesAccountDeploymentProperties
            {
                Model = new CognitiveServicesAccountDeploymentModel
                {
                    Format = "OpenAI",
                    Name = fineTunedModelName,
                    Version = "1"
                }
            },
            Sku = new CognitiveServicesSku("GlobalStandard") { Capacity = 50 }
        };

        var deploymentOperation = await accountResource.GetCognitiveServicesAccountDeployments()
            .CreateOrUpdateAsync(Azure.WaitUntil.Completed, deploymentName, deploymentData);

        Console.WriteLine($"Deployment '{deploymentName}' completed successfully");
        Assert.That(deploymentOperation, Is.Not.Null);
        Assert.That(deploymentOperation.Value, Is.Not.Null);
        Assert.That(deploymentOperation.Value.Data.Name, Is.EqualTo(deploymentName));
    }
    #region Helpers
    private static string GetTestFineTuningFile(string name) => GetTestFile(Path.Combine("FineTuning", name));

    private (OpenAIFileClient FileClient, FineTuningClient FineTuningClient) GetClients()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        return (projectClient.OpenAI.GetOpenAIFileClient(), projectClient.OpenAI.GetFineTuningClient());
    }

    protected void ValidateFineTuningJob(FineTuningJob job, string expectedJobId = null, string expectedStatus = null)
    {
        Assert.That(job, Is.Not.Null);
        Assert.That(job.JobId, Is.Not.Null);
        Assert.That(job.Status, Is.Not.Null);

        if (expectedJobId != null)
        {
            Assert.That(expectedJobId, Is.EqualTo(job.JobId));
        }

        if (expectedStatus != null)
        {
            Assert.That(job.Status.ToString().ToLowerInvariant(), Is.EqualTo(expectedStatus));
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
    protected async Task<OpenAIFile> WaitForFileProcessingAsync(
        OpenAIFileClient fileClient,
        string fileId,
        int pollIntervalSeconds = 5,
        int maxWaitSeconds = 1800)
    {
        var start = DateTimeOffset.Now;
        var pollInterval = TimeSpan.FromSeconds(pollIntervalSeconds);
        var timeout = TimeSpan.FromSeconds(maxWaitSeconds);

        OpenAIFile file;
        do
        {
            file = await fileClient.GetFileAsync(fileId);
            Assert.That(DateTimeOffset.Now - start, Is.LessThan(timeout), $"File {fileId} did not finish processing after {maxWaitSeconds} seconds. Current status: {file.Status}");
            // Skip delay in Playback mode since responses are pre-recorded
            if (Mode != RecordedTestMode.Playback)
            {
                System.Threading.Thread.Sleep(pollInterval);
            }
        }
        while (file.Status != FileStatus.Processed && file.Status != FileStatus.Error);

        Assert.That(file.Status, Is.EqualTo(FileStatus.Processed), $"File {fileId} processing failed: {file.StatusDetails}");
        return file;
    }
#pragma warning restore CS0618 // Type or member is obsolete
    #endregion
}
