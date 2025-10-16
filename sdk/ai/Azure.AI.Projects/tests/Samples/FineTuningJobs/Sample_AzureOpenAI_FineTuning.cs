// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests;

public class Sample_AzureOpenAI_FineTuning_Refactored : SamplesBase<AIProjectsTestEnvironment>
{
    private string GetDataDirectory()
    {
        var testDirectory = Path.GetDirectoryName(typeof(Sample_AzureOpenAI_FineTuning_Refactored).Assembly.Location);
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

    private async Task<FineTuningJob> GetJobByIdAsync(FineTuningClient client, string jobId)
    {
        await foreach (FineTuningJob job in client.GetJobsAsync())
        {
            if (job.JobId == jobId)
            {
                return job;
            }
        }
        throw new InvalidOperationException($"Job {jobId} not found");
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuningUploadFileAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var dataDirectory = GetDataDirectory();
        var trainingFilePath = Path.Combine(dataDirectory, "training_set.jsonl");

        var (_, fileClient, _) = await GetClientsAsync(endpoint);

        Console.WriteLine($"\nUploading file: training_set.jsonl");
        OpenAIFile uploadedFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(trainingFilePath)),
            "training_set.jsonl",
            FileUploadPurpose.FineTune);

        Console.WriteLine($"✅ Upload successful! File ID: {uploadedFile.Id}");
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuningListJobsAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var (fineTuningClient, _, _) = await GetClientsAsync(endpoint);

        Console.WriteLine("\nListing fine-tuning jobs:");
        int count = 0;
        await foreach (FineTuningJob job in fineTuningClient.GetJobsAsync(options: new() { PageSize = 10 }))
        {
            Console.WriteLine($"- Job ID: {job.JobId}, Status: {job.Status}");
            if (++count >= 5) break;
        }
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuningCreateJobAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var dataDirectory = GetDataDirectory();
        var trainingFilePath = Path.Combine(dataDirectory, "training_set.jsonl");
        var validationFilePath = Path.Combine(dataDirectory, "validation_set.jsonl");

        var (fineTuningClient, fileClient, _) = await GetClientsAsync(endpoint);

        Console.WriteLine("\nUploading training file...");
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

        Console.WriteLine("\nCreating fine-tuning job...");
        FineTuningJob createdJob = await fineTuningClient.FineTuneAsync(
            "gpt-4o-mini-2024-07-18",
            trainingFile.Id,
            waitUntilCompleted: false,
            new() 
            { 
                TrainingMethod = FineTuningTrainingMethod.CreateSupervised(),
                ValidationFile = validationFile.Id
            });

        Console.WriteLine($"✅ Job created! Job ID: {createdJob.JobId}, Status: {createdJob.Status}");
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuningCreateJobWithReinforcementLearningAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var dataDirectory = GetDataDirectory();
        var trainingFilePath = Path.Combine(dataDirectory, "countdown_train_100.jsonl");
        var validationFilePath = Path.Combine(dataDirectory, "countdown_valid_50.jsonl");
    
        var (fineTuningClient, fileClient, _) = await GetClientsAsync(endpoint);
    
        Console.WriteLine("\nUploading training file for reinforcement learning...");
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

        Console.WriteLine("\nCreating fine-tuning job with Reinforcement Learning...");
        
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
        
        Console.WriteLine($"✅ Job created with RL! Job ID: {createdJob.JobId}, Status: {createdJob.Status}");
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuningCreateJobWithDpoAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var dataDirectory = GetDataDirectory();
        var trainingFilePath = Path.Combine(dataDirectory, "dpo_training_set.jsonl");
        var validationFilePath = Path.Combine(dataDirectory, "dpo_validation_set.jsonl");

        var (fineTuningClient, fileClient, _) = await GetClientsAsync(endpoint);
        
        Console.WriteLine("\nUploading training file for DPO...");
        OpenAIFile trainingFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(trainingFilePath)),
            "dpo_training_set.jsonl",
            FileUploadPurpose.FineTune);
        
        Console.WriteLine($"✅ Training file uploaded: {trainingFile.Id}");
        
        Console.WriteLine("Uploading validation file for DPO...");
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(validationFilePath)),
            "dpo_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        
        Console.WriteLine($"✅ Validation file uploaded: {validationFile.Id}");
        Console.WriteLine("Waiting for file import...");
        await Task.Delay(5000);

        Console.WriteLine("\nCreating fine-tuning job with Direct Preference Optimization...");
        
        // DPO is only supported by gpt-4o (not gpt-4o-mini)
        FineTuningJob createdJob = await fineTuningClient.FineTuneAsync(
            "gpt-4o-2024-08-06",
            trainingFile.Id,
            waitUntilCompleted: false,
            new() 
            { 
                TrainingMethod = FineTuningTrainingMethod.CreateDirectPreferenceOptimization(),
                ValidationFile = validationFile.Id
            });

        Console.WriteLine($"✅ Job created with DPO! Job ID: {createdJob.JobId}, Status: {createdJob.Status}");
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuningGetJobAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var jobId = "ftjob-da72c7361831470d93de08ffe8c46296";
        
        var (fineTuningClient, _, _) = await GetClientsAsync(endpoint);
        
        // NOTE: GetJobAsync(jobId) returns 404 on Azure - base class uses wrong URL format
        Console.WriteLine($"\nRetrieving job: {jobId}");
        FineTuningJob job = await fineTuningClient.GetJobAsync(jobId);
        Console.WriteLine($"✅ Job ID: {job.JobId}, Status: {job.Status}");
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuningCancelJobAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var dataDirectory = GetDataDirectory();
        var trainingFilePath = Path.Combine(dataDirectory, "training_set.jsonl");
        var validationFilePath = Path.Combine(dataDirectory, "validation_set.jsonl");

        var (fineTuningClient, fileClient, _) = await GetClientsAsync(endpoint);
        
        Console.WriteLine("\nUploading training file...");
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
        await Task.Delay(5000);
        
        Console.WriteLine("\nCreating job to cancel...");
        FineTuningJob createdJob = await fineTuningClient.FineTuneAsync(
            "gpt-4o-mini-2024-07-18",
            trainingFile.Id,
            waitUntilCompleted: false,
            new() 
            { 
                TrainingMethod = FineTuningTrainingMethod.CreateSupervised(),
                ValidationFile = validationFile.Id
            });
        
        Console.WriteLine($"✅ Job created: {createdJob.JobId}");
        Console.WriteLine($"\nCancelling job...");
        
        FineTuningJob jobToCancel = await GetJobByIdAsync(fineTuningClient, createdJob.JobId);
        await jobToCancel.CancelAndUpdateAsync();
        
        Console.WriteLine($"✅ Job cancelled! Status: {jobToCancel.Status}");
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuningDeleteJobAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var jobId = "ftjob-68d43662c2be4fc1b0bd07ebf1c8e067";
        
        var (fineTuningClient, _, _) = await GetClientsAsync(endpoint);
        
        Console.WriteLine($"\nDeleting job: {jobId}");
        FineTuningJob jobToDelete = await GetJobByIdAsync(fineTuningClient, jobId);
        
#pragma warning disable AOAI001
        await ((Azure.AI.OpenAI.FineTuning.AzureFineTuningJob)jobToDelete).DeleteJobAsync(jobId, null);
#pragma warning restore AOAI001
        
        Console.WriteLine($"✅ Job deleted: {jobId}");
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuningListCheckpointsAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var jobId = "ftjob-2730abd7e1574603bde2161a96d6645d";
        
        var (fineTuningClient, _, _) = await GetClientsAsync(endpoint);
        
        Console.WriteLine($"\nListing checkpoints for job: {jobId}");
        FineTuningJob job = await GetJobByIdAsync(fineTuningClient, jobId);

        int count = 0;
        await foreach (FineTuningCheckpoint checkpoint in job.GetCheckpointsAsync())
        {
            Console.WriteLine($"Checkpoint {++count}: ID={checkpoint.Id}, Step={checkpoint.StepNumber}");
            if (count >= 5) break;
        }
        Console.WriteLine($"✅ Listed {count} checkpoint(s)");
    }

    [Test]
    [AsyncOnly]
    public async Task FineTuningListEventsAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var jobId = "ftjob-2730abd7e1574603bde2161a96d6645d";
        
        var (fineTuningClient, _, _) = await GetClientsAsync(endpoint);
        
        Console.WriteLine($"\nListing events for job: {jobId}");
        FineTuningJob job = await GetJobByIdAsync(fineTuningClient, jobId);

        int count = 0;
        await foreach (FineTuningEvent evt in job.GetEventsAsync(new GetEventsOptions() { PageSize = 10 }))
        {
            Console.WriteLine($"Event {++count}: {evt.Level} - {evt.Message}");
            if (count >= 5) break;
        }
        Console.WriteLine($"✅ Listed {count} event(s)");
    }
}
