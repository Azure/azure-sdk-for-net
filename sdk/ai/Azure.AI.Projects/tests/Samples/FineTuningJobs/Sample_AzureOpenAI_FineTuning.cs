// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests;

public class Sample_AzureOpenAI_FineTuning_Consolidated : SamplesBase<AIProjectsTestEnvironment>
{
    private string GetDataDirectory()
    {
        var testDirectory = Path.GetDirectoryName(typeof(Sample_AzureOpenAI_FineTuning_Consolidated).Assembly.Location);
        while (testDirectory != null && !Directory.Exists(Path.Combine(testDirectory, "sdk")))
        {
            testDirectory = Path.GetDirectoryName(testDirectory);
        }
        return Path.Combine(testDirectory!, "sdk", "ai", "Azure.AI.Projects", "tests", "Samples", "FineTuningJobs", "data");
    }

    private async Task<(FineTuningClient, OpenAIFileClient, AzureOpenAIClient)> GetClientsAsync(string endpoint)
    {
        Console.WriteLine("Creating AI Project client...");
        var credential = new DefaultAzureCredential();
        var projectClient = new AIProjectClient(new Uri(endpoint), credential);

        Console.WriteLine("Getting Azure OpenAI connection...");
        var connection = projectClient.GetConnection(typeof(AzureOpenAIClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI from connection.");
        }
        uri = new Uri($"https://{uri.Host}");

        Console.WriteLine("Creating Azure OpenAI client...");
        AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(uri, credential);
        return (azureOpenAIClient.GetFineTuningClient(), azureOpenAIClient.GetOpenAIFileClient(), azureOpenAIClient);
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuning_SupervisedLearningAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var dataDirectory = GetDataDirectory();
        var trainingFilePath = Path.Combine(dataDirectory, "training_set.jsonl");
        var validationFilePath = Path.Combine(dataDirectory, "validation_set.jsonl");

        var (fineTuningClient, fileClient, _) = await GetClientsAsync(endpoint);

        // Step 1: Upload training and validation files
        Console.WriteLine("\n=== Step 1: Uploading Files ===");
        Console.WriteLine("Uploading training file...");
        OpenAIFile trainingFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(trainingFilePath)),
            "training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"✅ Training file uploaded: {trainingFile.Id}");
        
        Console.WriteLine("Uploading validation file...");
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(validationFilePath)),
            "validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"✅ Validation file uploaded: {validationFile.Id}");
        Console.WriteLine("Waiting for file import...");
        await Task.Delay(5000);

        // Step 2: Create fine-tuning job with Supervised Learning
        Console.WriteLine("\n=== Step 2: Creating Fine-Tuning Job ===");
        FineTuningJob createdJob = await fineTuningClient.FineTuneAsync(
            "gpt-4o-mini-2024-07-18",
            trainingFile.Id,
            waitUntilCompleted: false,
            new() 
            { 
                TrainingMethod = FineTuningTrainingMethod.CreateSupervised(
                    epochCount: 3,
                    batchSize: 4,
                    learningRate: 0.0001),
                ValidationFile = validationFile.Id
            });
        Console.WriteLine($"✅ Job created! Job ID: {createdJob.JobId}, Status: {createdJob.Status}");

        // Step 3: Get the job by ID
        Console.WriteLine("\n=== Step 3: Getting Job by ID ===");
        FineTuningJob retrievedJob = await fineTuningClient.GetJobAsync(createdJob.JobId);
        Console.WriteLine($"✅ Job retrieved: {retrievedJob.JobId}, Status: {retrievedJob.Status}");

        // Step 4: List all jobs
        Console.WriteLine("\n=== Step 4: Listing All Jobs ===");
        int jobCount = 0;
        await foreach (FineTuningJob job in fineTuningClient.GetJobsAsync(options: new() { PageSize = 5 }))
        {
            Console.WriteLine($"- Job ID: {job.JobId}, Status: {job.Status}");
            if (++jobCount >= 5) break;
        }
        Console.WriteLine($"✅ Listed {jobCount} job(s)");

        // Step 5: List checkpoints (only available after job reaches terminal state)
        Console.WriteLine("\n=== Step 5: Listing Checkpoints ===");
        if (retrievedJob.Status == FineTuningStatus.Succeeded || 
            retrievedJob.Status == FineTuningStatus.Failed ||
            retrievedJob.Status == FineTuningStatus.Cancelled)
        {
            int checkpointCount = 0;
            await foreach (FineTuningCheckpoint checkpoint in retrievedJob.GetCheckpointsAsync())
            {
                Console.WriteLine($"Checkpoint {++checkpointCount}: ID={checkpoint.Id}, Step={checkpoint.StepNumber}");
                if (checkpointCount >= 5) break;
            }
            Console.WriteLine($"✅ Listed {checkpointCount} checkpoint(s)");
        }
        else
        {
            Console.WriteLine($"⚠️  Job is in '{retrievedJob.Status}' state. Checkpoints only available after job completes.");
        }

        // Step 6: List events
        Console.WriteLine("\n=== Step 6: Listing Events ===");
        int eventCount = 0;
        await foreach (FineTuningEvent evt in retrievedJob.GetEventsAsync(new GetEventsOptions() { PageSize = 10 }))
        {
            Console.WriteLine($"Event {++eventCount}: {evt.Level} - {evt.Message}");
            if (eventCount >= 5) break;
        }
        Console.WriteLine($"✅ Listed {eventCount} event(s)");

        // Step 7: Cancel the job
        Console.WriteLine("\n=== Step 7: Cancelling Job ===");
        FineTuningJob jobToCancel = await fineTuningClient.GetJobAsync(createdJob.JobId);
        await jobToCancel.CancelAndUpdateAsync();
        Console.WriteLine($"✅ Job cancelled! Status: {jobToCancel.Status}");

        // Step 8: Delete the job
        Console.WriteLine("\n=== Step 8: Deleting Job ===");
        FineTuningJob jobToDelete = await fineTuningClient.GetJobAsync(createdJob.JobId);
        var azureJob = (Azure.AI.OpenAI.FineTuning.AzureFineTuningJob)jobToDelete;
        
#pragma warning disable AOAI001
        await azureJob.DeleteJobAsync(jobToDelete.JobId, options: null);
#pragma warning restore AOAI001
        
        Console.WriteLine($"✅ Job deleted successfully");
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuning_DirectPreferenceOptimizationAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var dataDirectory = GetDataDirectory();
        var trainingFilePath = Path.Combine(dataDirectory, "dpo_training_set.jsonl");
        var validationFilePath = Path.Combine(dataDirectory, "dpo_validation_set.jsonl");

        var (fineTuningClient, fileClient, _) = await GetClientsAsync(endpoint);

        // Step 1: Upload training and validation files
        Console.WriteLine("\n=== Step 1: Uploading Files for DPO ===");
        Console.WriteLine("Uploading training file...");
        OpenAIFile trainingFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(trainingFilePath)),
            "dpo_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"✅ Training file uploaded: {trainingFile.Id}");
        
        Console.WriteLine("Uploading validation file...");
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(validationFilePath)),
            "dpo_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"✅ Validation file uploaded: {validationFile.Id}");
        Console.WriteLine("Waiting for file import...");
        await Task.Delay(5000);

        // Step 2: Create fine-tuning job with DPO
        Console.WriteLine("\n=== Step 2: Creating Fine-Tuning Job with DPO ===");
        FineTuningJob createdJob = await fineTuningClient.FineTuneAsync(
            "gpt-4o-2024-08-06",
            trainingFile.Id,
            waitUntilCompleted: false,
            new() 
            { 
                TrainingMethod = FineTuningTrainingMethod.CreateDirectPreferenceOptimization(
                    epochCount: 3,
                    batchSize: 4,
                    learningRate: 0.0001),
                ValidationFile = validationFile.Id
            });
        Console.WriteLine($"✅ Job created! Job ID: {createdJob.JobId}, Status: {createdJob.Status}");

        // Step 3: Get the job by ID
        Console.WriteLine("\n=== Step 3: Getting Job by ID ===");
        FineTuningJob retrievedJob = await fineTuningClient.GetJobAsync(createdJob.JobId);
        Console.WriteLine($"✅ Job retrieved: {retrievedJob.JobId}, Status: {retrievedJob.Status}");

        // Step 4: List all jobs
        Console.WriteLine("\n=== Step 4: Listing All Jobs ===");
        int jobCount = 0;
        await foreach (FineTuningJob job in fineTuningClient.GetJobsAsync(options: new() { PageSize = 5 }))
        {
            Console.WriteLine($"- Job ID: {job.JobId}, Status: {job.Status}");
            if (++jobCount >= 5) break;
        }
        Console.WriteLine($"✅ Listed {jobCount} job(s)");

        // Step 5: List checkpoints (only available after job reaches terminal state)
        Console.WriteLine("\n=== Step 5: Listing Checkpoints ===");
        if (retrievedJob.Status == FineTuningStatus.Succeeded || 
            retrievedJob.Status == FineTuningStatus.Failed ||
            retrievedJob.Status == FineTuningStatus.Cancelled)
        {
            int checkpointCount = 0;
            await foreach (FineTuningCheckpoint checkpoint in retrievedJob.GetCheckpointsAsync())
            {
                Console.WriteLine($"Checkpoint {++checkpointCount}: ID={checkpoint.Id}, Step={checkpoint.StepNumber}");
                if (checkpointCount >= 5) break;
            }
            Console.WriteLine($"✅ Listed {checkpointCount} checkpoint(s)");
        }
        else
        {
            Console.WriteLine($"⚠️  Job is in '{retrievedJob.Status}' state. Checkpoints only available after job completes.");
        }

        // Step 6: List events
        Console.WriteLine("\n=== Step 6: Listing Events ===");
        int eventCount = 0;
        await foreach (FineTuningEvent evt in retrievedJob.GetEventsAsync(new GetEventsOptions() { PageSize = 10 }))
        {
            Console.WriteLine($"Event {++eventCount}: {evt.Level} - {evt.Message}");
            if (eventCount >= 5) break;
        }
        Console.WriteLine($"✅ Listed {eventCount} event(s)");

        // Step 7: Cancel the job
        Console.WriteLine("\n=== Step 7: Cancelling Job ===");
        FineTuningJob jobToCancel = await fineTuningClient.GetJobAsync(createdJob.JobId);
        await jobToCancel.CancelAndUpdateAsync();
        Console.WriteLine($"✅ Job cancelled! Status: {jobToCancel.Status}");

        // Step 8: Delete the job
        Console.WriteLine("\n=== Step 8: Deleting Job ===");
        FineTuningJob jobToDelete = await fineTuningClient.GetJobAsync(createdJob.JobId);
        var azureJob = (Azure.AI.OpenAI.FineTuning.AzureFineTuningJob)jobToDelete;
        
#pragma warning disable AOAI001
        await azureJob.DeleteJobAsync(jobToDelete.JobId, options: null);
#pragma warning restore AOAI001
        
        Console.WriteLine($"✅ Job deleted successfully");
        Console.WriteLine("\n=== DPO Full Lifecycle Complete ===");
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuning_ReinforcementLearningAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var dataDirectory = GetDataDirectory();
        var trainingFilePath = Path.Combine(dataDirectory, "countdown_train_100.jsonl");
        var validationFilePath = Path.Combine(dataDirectory, "countdown_valid_50.jsonl");

        var (fineTuningClient, fileClient, _) = await GetClientsAsync(endpoint);

        // Step 1: Upload training and validation files
        Console.WriteLine("\n=== Step 1: Uploading Files for Reinforcement Learning ===");
        Console.WriteLine("Uploading training file...");
        OpenAIFile trainingFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(trainingFilePath)),
            "countdown_train_100.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"✅ Training file uploaded: {trainingFile.Id}");
        
        Console.WriteLine("Uploading validation file...");
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(validationFilePath)),
            "countdown_valid_50.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"✅ Validation file uploaded: {validationFile.Id}");
        Console.WriteLine("Waiting for file import...");
        await Task.Delay(5000);

        // Step 2: Create fine-tuning job with Reinforcement Learning
        Console.WriteLine("\n=== Step 2: Creating Fine-Tuning Job with Reinforcement Learning ===");
        
        // Build the JSON request manually since RL APIs are internal
        var requestJson = new
        {
            model = "o4-mini",
            training_file = trainingFile.Id,
            validation_file = validationFile.Id,
            method = new
            {
                type = "reinforcement",
                reinforcement = new
                {
                    grader = new
                    {
                        type = "score_model",
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
        
        // Serialize and call protocol method
        string jsonString = JsonSerializer.Serialize(requestJson);
        BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonString));
        
        FineTuningJob createdJob = await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);
        Console.WriteLine($"✅ Job created! Job ID: {createdJob.JobId}, Status: {createdJob.Status}");

        // Step 3: Get the job by ID
        Console.WriteLine("\n=== Step 3: Getting Job by ID ===");
        FineTuningJob retrievedJob = await fineTuningClient.GetJobAsync(createdJob.JobId);
        Console.WriteLine($"✅ Job retrieved: {retrievedJob.JobId}, Status: {retrievedJob.Status}");

        // Step 4: List all jobs
        Console.WriteLine("\n=== Step 4: Listing All Jobs ===");
        int jobCount = 0;
        await foreach (FineTuningJob job in fineTuningClient.GetJobsAsync(options: new() { PageSize = 5 }))
        {
            Console.WriteLine($"- Job ID: {job.JobId}, Status: {job.Status}");
            if (++jobCount >= 5) break;
        }
        Console.WriteLine($"✅ Listed {jobCount} job(s)");

        // Step 5: List checkpoints (only available after job reaches terminal state)
        Console.WriteLine("\n=== Step 5: Listing Checkpoints ===");
        if (retrievedJob.Status == FineTuningStatus.Succeeded || 
            retrievedJob.Status == FineTuningStatus.Failed ||
            retrievedJob.Status == FineTuningStatus.Cancelled)
        {
            int checkpointCount = 0;
            await foreach (FineTuningCheckpoint checkpoint in retrievedJob.GetCheckpointsAsync())
            {
                Console.WriteLine($"Checkpoint {++checkpointCount}: ID={checkpoint.Id}, Step={checkpoint.StepNumber}");
                if (checkpointCount >= 5) break;
            }
            Console.WriteLine($"✅ Listed {checkpointCount} checkpoint(s)");
        }
        else
        {
            Console.WriteLine($"⚠️  Job is in '{retrievedJob.Status}' state. Checkpoints only available after job completes.");
        }

        // Step 6: List events
        Console.WriteLine("\n=== Step 6: Listing Events ===");
        int eventCount = 0;
        await foreach (FineTuningEvent evt in retrievedJob.GetEventsAsync(new GetEventsOptions() { PageSize = 10 }))
        {
            Console.WriteLine($"Event {++eventCount}: {evt.Level} - {evt.Message}");
            if (eventCount >= 5) break;
        }
        Console.WriteLine($"✅ Listed {eventCount} event(s)");

        // Step 7: Cancel the job
        Console.WriteLine("\n=== Step 7: Cancelling Job ===");
        FineTuningJob jobToCancel = await fineTuningClient.GetJobAsync(createdJob.JobId);
        await jobToCancel.CancelAndUpdateAsync();
        Console.WriteLine($"✅ Job cancelled! Status: {jobToCancel.Status}");

        // Step 8: Delete the job
        Console.WriteLine("\n=== Step 8: Deleting Job ===");
        FineTuningJob jobToDelete = await fineTuningClient.GetJobAsync(createdJob.JobId);
        var azureJob = (Azure.AI.OpenAI.FineTuning.AzureFineTuningJob)jobToDelete;
        
#pragma warning disable AOAI001
        await azureJob.DeleteJobAsync(jobToDelete.JobId, options: null);
#pragma warning restore AOAI001
        
        Console.WriteLine($"✅ Job deleted successfully");
        Console.WriteLine("\n=== Reinforcement Learning Full Lifecycle Complete ===");
    }
}
