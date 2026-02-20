// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.CognitiveServices;
using Azure.ResourceManager.CognitiveServices.Models;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests.Samples;

public partial class Sample16_FineTuning_Supervised : SamplesBase
{
    [Test]
    public async Task SupervisedFineTuningAsync()
    {
        #region Snippet:AI_Projects_FineTuning_CreateClientsAsync
#if SNIPPET
        string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
        string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/sft_validation_set.jsonl";
#else
        string trainingFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "sft_training_set.jsonl");
        string validationFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "sft_validation_set.jsonl");
#endif
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
        #endregion

        #region Snippet:AI_Projects_FineTuning_UploadFilesAsync
        // Upload training file
        Console.WriteLine("Uploading training file...");
        using FileStream trainStream = File.OpenRead(trainingFilePath);
        OpenAIFile trainFile = await fileClient.UploadFileAsync(
            trainStream,
            "sft_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead(validationFilePath);
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            validationStream,
            "sft_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
        #endregion

        // Wait for files to complete processing
        Console.WriteLine("Waiting for files to complete processing...");
        await FineTuningHelpers.WaitForFileProcessingAsync(fileClient, trainFile.Id, pollIntervalSeconds: 2);
        await FineTuningHelpers.WaitForFileProcessingAsync(fileClient, validationFile.Id, pollIntervalSeconds: 2);

        #region Snippet:AI_Projects_FineTuning_CreateJobAsync
        // Create supervised fine-tuning job
        Console.WriteLine("Creating supervised fine-tuning job...");
        FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(
            modelDeploymentName,
            trainFile.Id,
            waitUntilCompleted: false,
            new()
            {
                TrainingMethod = FineTuningTrainingMethod.CreateSupervised(
                    epochCount: 3,
                    batchSize: 1,
                    learningRate: 1.0),
                ValidationFile = validationFile.Id
            });
        Console.WriteLine($"Created fine-tuning job: {fineTuningJob.JobId}");
        Console.WriteLine($"Status: {fineTuningJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_RetrieveJobAsync
        // Retrieve job details
        Console.WriteLine($"Getting fine-tuning job with ID: {fineTuningJob.JobId}");
        FineTuningJob retrievedJob = await fineTuningClient.GetJobAsync(fineTuningJob.JobId);
        Console.WriteLine($"Retrieved job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_ListJobsAsync
        // List all fine-tuning jobs
        Console.WriteLine("Listing all fine-tuning jobs:");
        await foreach (FineTuningJob job in fineTuningClient.GetJobsAsync())
        {
            Console.WriteLine($"Job: {job.JobId}, Status: {job.Status}");
        }
        #endregion

        #region Snippet:AI_Projects_FineTuning_PauseJobAsync
        // Pause the fine-tuning job
        Console.WriteLine($"Pausing fine-tuning job with ID: {fineTuningJob.JobId}");
        await fineTuningClient.PauseFineTuningJobAsync(fineTuningJob.JobId, options: null);
        FineTuningJob pausedJob = await fineTuningClient.GetJobAsync(fineTuningJob.JobId);
        Console.WriteLine($"Paused job: {pausedJob.JobId}, Status: {pausedJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_ResumeJobAsync
        // Resume the fine-tuning job
        Console.WriteLine($"Resuming fine-tuning job with ID: {fineTuningJob.JobId}");
        await fineTuningClient.ResumeFineTuningJobAsync(fineTuningJob.JobId, options: null);
        FineTuningJob resumedJob = await fineTuningClient.GetJobAsync(fineTuningJob.JobId);
        Console.WriteLine($"Resumed job: {resumedJob.JobId}, Status: {resumedJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_ListEventsAsync
        // List events for the job
        Console.WriteLine($"Listing events of fine-tuning job: {fineTuningJob.JobId}");
        await foreach (FineTuningEvent evt in retrievedJob.GetEventsAsync(new GetEventsOptions()))
        {
            Console.WriteLine($"Event: {evt.Level} - {evt.Message} at {evt.CreatedAt}");
        }
        #endregion

        #region Snippet:AI_Projects_FineTuning_WaitForTerminalStateAsync
        // Wait for job to reach terminal state (succeeded, failed, or cancelled)
        Console.WriteLine($"Waiting for job {fineTuningJob.JobId} to reach terminal state...");
        FineTuningJob finalJob = await FineTuningHelpers.WaitForJobTerminalStateAsync(fineTuningClient, fineTuningJob.JobId);
        Console.WriteLine($"Job reached terminal state: {finalJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_ListCheckpointsAsync
        // List checkpoints (job needs to be in terminal state)
        Console.WriteLine($"Listing checkpoints of fine-tuning job: {fineTuningJob.JobId}");
        await foreach (FineTuningCheckpoint checkpoint in finalJob.GetCheckpointsAsync(new GetCheckpointsOptions()))
        {
            Console.WriteLine($"Checkpoint: {checkpoint.Id} at step {checkpoint.StepNumber}");
        }
        #endregion

        #region Snippet:AI_Projects_FineTuning_CancelJobAsync
        // Cancel the fine-tuning job
        Console.WriteLine($"Cancelling fine-tuning job with ID: {retrievedJob.JobId}");
        await retrievedJob.CancelAndUpdateAsync();
        Console.WriteLine($"Successfully cancelled fine-tuning job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_CleanupFilesAsync
        // Clean up files
        ClientResult<FileDeletionResult> trainDeleteResult = await fileClient.DeleteFileAsync(trainFile.Id);
        Console.WriteLine($"Deleted training file: {trainFile.Id} (deleted: {trainDeleteResult.Value.Deleted})");

        ClientResult<FileDeletionResult> validationDeleteResult = await fileClient.DeleteFileAsync(validationFile.Id);
        Console.WriteLine($"Deleted validation file: {validationFile.Id} (deleted: {validationDeleteResult.Value.Deleted})");
        #endregion
    }

    [Test]
    public void SupervisedFineTuningSync()
    {
        #region Snippet:AI_Projects_FineTuning_CreateClients
#if SNIPPET
        string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
        string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/sft_validation_set.jsonl";
#else
        string trainingFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "sft_training_set.jsonl");
        string validationFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "sft_validation_set.jsonl");
#endif
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
        #endregion

        #region Snippet:AI_Projects_FineTuning_UploadFiles
        // Upload training file
        Console.WriteLine("Uploading training file...");
        using FileStream trainStream = File.OpenRead(trainingFilePath);
        OpenAIFile trainFile = fileClient.UploadFile(
            trainStream,
            "sft_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead(validationFilePath);
        OpenAIFile validationFile = fileClient.UploadFile(
            validationStream,
            "sft_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
        #endregion

        // Wait for files to complete processing
        Console.WriteLine("Waiting for files to complete processing...");
        FineTuningHelpers.WaitForFileProcessing(fileClient, trainFile.Id, pollIntervalSeconds: 2);
        FineTuningHelpers.WaitForFileProcessing(fileClient, validationFile.Id, pollIntervalSeconds: 2);

        #region Snippet:AI_Projects_FineTuning_CreateJob
        // Create supervised fine-tuning job
        Console.WriteLine("Creating supervised fine-tuning job...");
        FineTuningJob fineTuningJob = fineTuningClient.FineTune(
            modelDeploymentName,
            trainFile.Id,
            waitUntilCompleted: false,
            new()
            {
                TrainingMethod = FineTuningTrainingMethod.CreateSupervised(
                    epochCount: 3,
                    batchSize: 1,
                    learningRate: 1.0),
                ValidationFile = validationFile.Id
            });
        Console.WriteLine($"Created fine-tuning job: {fineTuningJob.JobId}");
        Console.WriteLine($"Status: {fineTuningJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_RetrieveJob
        // Retrieve job details
        Console.WriteLine($"Getting fine-tuning job with ID: {fineTuningJob.JobId}");
        FineTuningJob retrievedJob = fineTuningClient.GetJob(fineTuningJob.JobId);
        Console.WriteLine($"Retrieved job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_ListJobs
        // List all fine-tuning jobs
        Console.WriteLine("Listing all fine-tuning jobs:");
        foreach (FineTuningJob job in fineTuningClient.GetJobs())
        {
            Console.WriteLine($"Job: {job.JobId}, Status: {job.Status}");
        }
        #endregion

        #region Snippet:AI_Projects_FineTuning_PauseJob
        // Pause the fine-tuning job
        Console.WriteLine($"Pausing fine-tuning job with ID: {fineTuningJob.JobId}");
        fineTuningClient.PauseFineTuningJob(fineTuningJob.JobId, options: null);
        FineTuningJob pausedJob = fineTuningClient.GetJob(fineTuningJob.JobId);
        Console.WriteLine($"Paused job: {pausedJob.JobId}, Status: {pausedJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_ResumeJob
        // Resume the fine-tuning job
        Console.WriteLine($"Resuming fine-tuning job with ID: {fineTuningJob.JobId}");
        fineTuningClient.ResumeFineTuningJob(fineTuningJob.JobId, options: null);
        FineTuningJob resumedJob = fineTuningClient.GetJob(fineTuningJob.JobId);
        Console.WriteLine($"Resumed job: {resumedJob.JobId}, Status: {resumedJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_ListEvents
        // List events for the job
        Console.WriteLine($"Listing events of fine-tuning job: {fineTuningJob.JobId}");
        foreach (FineTuningEvent evt in retrievedJob.GetEvents(new GetEventsOptions()))
        {
            Console.WriteLine($"Event: {evt.Level} - {evt.Message} at {evt.CreatedAt}");
        }
        #endregion

        #region Snippet:AI_Projects_FineTuning_WaitForTerminalState
        // Wait for job to reach terminal state (succeeded, failed, or cancelled)
        Console.WriteLine($"Waiting for job {fineTuningJob.JobId} to reach terminal state...");
        FineTuningJob finalJob = FineTuningHelpers.WaitForJobTerminalState(fineTuningClient, fineTuningJob.JobId);
        Console.WriteLine($"Job reached terminal state: {finalJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_ListCheckpoints
        // List checkpoints (job needs to be in terminal state)
        Console.WriteLine($"Listing checkpoints of fine-tuning job: {fineTuningJob.JobId}");
        foreach (FineTuningCheckpoint checkpoint in finalJob.GetCheckpoints(new GetCheckpointsOptions()))
        {
            Console.WriteLine($"Checkpoint: {checkpoint.Id} at step {checkpoint.StepNumber}");
        }
        #endregion

        #region Snippet:AI_Projects_FineTuning_CancelJob
        // Cancel the fine-tuning job
        Console.WriteLine($"Cancelling fine-tuning job with ID: {retrievedJob.JobId}");
        retrievedJob.CancelAndUpdate();
        Console.WriteLine($"Successfully cancelled fine-tuning job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");
        #endregion

        #region Snippet:AI_Projects_FineTuning_CleanupFiles
        // Clean up files
        ClientResult<FileDeletionResult> trainDeleteResult = fileClient.DeleteFile(trainFile.Id);
        Console.WriteLine($"Deleted training file: {trainFile.Id} (deleted: {trainDeleteResult.Value.Deleted})");

        ClientResult<FileDeletionResult> validationDeleteResult = fileClient.DeleteFile(validationFile.Id);
        Console.WriteLine($"Deleted validation file: {validationFile.Id} (deleted: {validationDeleteResult.Value.Deleted})");
        #endregion
    }

    [Test]
    public async Task DeployFineTunedModelAsync()
    {
        #region Snippet:AI_Projects_FineTuning_DeployModelAsync
        // Get the completed fine-tuning job
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        FineTuningClient fineTuningClient = projectClient.OpenAI.GetFineTuningClient();

        FineTuningJob completedJob = await fineTuningClient.GetJobAsync("your-completed-job-id");

        // Configure deployment
        string deploymentName = $"ft-deployment-{completedJob.BaseModel}-{DateTimeOffset.UtcNow:yyyy-MM-dd}";
        string fineTunedModelName = completedJob.Value; // The fine-tuned model identifier

        Console.WriteLine($"Deploying model '{fineTunedModelName}' as '{deploymentName}'...");

        // Create ARM client
        var credential = new DefaultAzureCredential();
        var armClient = new ArmClient(credential);

        // Get Cognitive Services account
        string subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");
        string resourceGroupName = Environment.GetEnvironmentVariable("AZURE_RESOURCE_GROUP");
        string accountName = Environment.GetEnvironmentVariable("AZURE_ACCOUNT_NAME");

        var resourceId = CognitiveServicesAccountResource.CreateResourceIdentifier(
            subscriptionId,
            resourceGroupName,
            accountName);
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
        #endregion
    }

    [Test]
    public void DeployFineTunedModelSync()
    {
        #region Snippet:AI_Projects_FineTuning_DeployModel
        // Get the completed fine-tuning job
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        FineTuningClient fineTuningClient = projectClient.OpenAI.GetFineTuningClient();

        FineTuningJob completedJob = fineTuningClient.GetJob("your-completed-job-id");

        // Configure deployment
        string deploymentName = $"ft-deployment-{completedJob.BaseModel}-{DateTimeOffset.UtcNow:yyyy-MM-dd}";
        string fineTunedModelName = completedJob.Value; // The fine-tuned model identifier

        Console.WriteLine($"Deploying model '{fineTunedModelName}' as '{deploymentName}'...");

        // Create ARM client
        var credential = new DefaultAzureCredential();
        var armClient = new ArmClient(credential);

        // Get Cognitive Services account
        string subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");
        string resourceGroupName = Environment.GetEnvironmentVariable("AZURE_RESOURCE_GROUP");
        string accountName = Environment.GetEnvironmentVariable("AZURE_ACCOUNT_NAME");

        var resourceId = CognitiveServicesAccountResource.CreateResourceIdentifier(
            subscriptionId,
            resourceGroupName,
            accountName);
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

        var deploymentOperation = accountResource.GetCognitiveServicesAccountDeployments()
            .CreateOrUpdate(Azure.WaitUntil.Completed, deploymentName, deploymentData);

        Console.WriteLine($"Deployment '{deploymentName}' completed successfully");
        #endregion
    }

    [Test]
    public async Task InferenceWithFineTunedModelAsync()
    {
        #region Snippet:AI_Projects_FineTuning_InferenceAsync
        // Get the deployed fine-tuned model
        string deploymentName = "your-deployment-name";

        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

        // Get responses client for the specific deployment
        var responsesClient = projectClient.OpenAI.GetProjectResponsesClientForModel(deploymentName);

        // Perform inference
        string prompt = "What is the capital of France?";
        Console.WriteLine($"Sending prompt: {prompt}");

        ClientResult<ResponseResult> result = await responsesClient.CreateResponseAsync(prompt);

        // Get the response message
        var messageItem = result.Value.OutputItems
            .OfType<MessageResponseItem>()
            .LastOrDefault();

        Console.WriteLine($"Response: {messageItem.Content[0].Text}");
        #endregion
    }

    [Test]
    public void InferenceWithFineTunedModelSync()
    {
        #region Snippet:AI_Projects_FineTuning_Inference
        // Get the deployed fine-tuned model
        string deploymentName = "your-deployment-name";

        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

        // Get responses client for the specific deployment
        var responsesClient = projectClient.OpenAI.GetProjectResponsesClientForModel(deploymentName);

        // Perform inference
        string prompt = "What is the capital of France?";
        Console.WriteLine($"Sending prompt: {prompt}");

        ClientResult<ResponseResult> result = responsesClient.CreateResponse(prompt);

        // Get the response message
        var messageItem = result.Value.OutputItems
            .OfType<MessageResponseItem>()
            .LastOrDefault();

        Console.WriteLine($"Response: {messageItem.Content[0].Text}");
        #endregion
    }

    public Sample16_FineTuning_Supervised(bool isAsync) : base(isAsync) { }
}
