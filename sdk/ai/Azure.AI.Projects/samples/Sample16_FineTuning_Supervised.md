# Sample using Supervised Fine-Tuning (SFT) in Azure.AI.Projects

This sample demonstrates how to create and manage supervised fine-tuning jobs using OpenAI Fine-Tuning API through the Azure AI Projects SDK. Supervised fine-tuning allows you to customize models for specific tasks using labeled training data.

## Supported Models

Supervised fine-tuning is supported for the following models:
- gpt-4.1
- gpt-4.1-mini
- gpt-4o-mini-2024-07-18
- gpt-4o-2024-08-06

## Prerequisites

- Install the Azure.AI.Projects package.
- Install the Azure.AI.Agents package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.

## Asynchronous Sample

```C# Snippet:AI_Projects_FineTuning_SupervisedAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
AgentsClient agentClient = projectClient.GetAgentsClient();
OpenAIClient oaiClient = agentClient.GetOpenAIClient();
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();

// Upload training file
Console.WriteLine("Uploading training file...");
using FileStream trainStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/sft_training_set.jsonl");
OpenAIFile trainFile = await fileClient.UploadFileAsync(
    trainStream,
    "sft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

// Upload validation file
Console.WriteLine("Uploading validation file...");
using FileStream validationStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/sft_validation_set.jsonl");
OpenAIFile validationFile = await fileClient.UploadFileAsync(
    validationStream,
    "sft_validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");

// Create supervised fine-tuning job
Console.WriteLine("Creating supervised fine-tuning job...");
FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(
    "gpt-4.1",
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
Console.WriteLine($"Model: {fineTuningJob.Model}");

// Retrieve job details
Console.WriteLine($"Getting fine-tuning job with ID: {fineTuningJob.JobId}");
FineTuningJob retrievedJob = await fineTuningClient.GetJobAsync(fineTuningJob.JobId);
Console.WriteLine($"Retrieved job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");

// List all fine-tuning jobs
Console.WriteLine("Listing all fine-tuning jobs:");
await foreach (FineTuningJob job in fineTuningClient.GetJobsAsync())
{
    Console.WriteLine($"Job: {job.JobId}, Model: {job.Model}, Status: {job.Status}");
}

// Pause the fine-tuning job
Console.WriteLine($"Pausing fine-tuning job with ID: {fineTuningJob.JobId}");
await fineTuningClient.PauseFineTuningJobAsync(fineTuningJob.JobId, options: null);
FineTuningJob pausedJob = await fineTuningClient.GetJobAsync(fineTuningJob.JobId);
Console.WriteLine($"Paused job: {pausedJob.JobId}, Status: {pausedJob.Status}");

// Resume the fine-tuning job
Console.WriteLine($"Resuming fine-tuning job with ID: {fineTuningJob.JobId}");
await fineTuningClient.ResumeFineTuningJobAsync(fineTuningJob.JobId, options: null);
FineTuningJob resumedJob = await fineTuningClient.GetJobAsync(fineTuningJob.JobId);
Console.WriteLine($"Resumed job: {resumedJob.JobId}, Status: {resumedJob.Status}");

// List events for the job
Console.WriteLine($"Listing events of fine-tuning job: {fineTuningJob.JobId}");
await foreach (FineTuningEvent evt in retrievedJob.GetEventsAsync(new GetEventsOptions()))
{
    Console.WriteLine($"Event: {evt.Level} - {evt.Message} at {evt.CreatedAt}");
}

// List checkpoints (job needs to be in terminal state)
Console.WriteLine($"Listing checkpoints of fine-tuning job: {fineTuningJob.JobId}");
await foreach (FineTuningCheckpoint checkpoint in retrievedJob.GetCheckpointsAsync(new GetCheckpointsOptions()))
{
    Console.WriteLine($"Checkpoint: {checkpoint.Id} at step {checkpoint.StepNumber}");
}

// Cancel the fine-tuning job
Console.WriteLine($"Cancelling fine-tuning job with ID: {retrievedJob.JobId}");
await retrievedJob.CancelAndUpdateAsync();
Console.WriteLine($"Successfully cancelled fine-tuning job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");

// Clean up files
ClientResult<FileDeletionResult> trainDeleteResult = await fileClient.DeleteFileAsync(trainFile.Id);
Console.WriteLine($"Deleted training file: {trainFile.Id} (deleted: {trainDeleteResult.Value.Deleted})");

ClientResult<FileDeletionResult> validationDeleteResult = await fileClient.DeleteFileAsync(validationFile.Id);
Console.WriteLine($"Deleted validation file: {validationFile.Id} (deleted: {validationDeleteResult.Value.Deleted})");
```

## Synchronous Sample

```C# Snippet:AI_Projects_FineTuning_Supervised
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
AgentsClient agentClient = projectClient.GetAgentsClient();
OpenAIClient oaiClient = agentClient.GetOpenAIClient();
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();

// Upload training file
Console.WriteLine("Uploading training file...");
using FileStream trainStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/sft_training_set.jsonl");
OpenAIFile trainFile = fileClient.UploadFile(
    trainStream,
    "sft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

// Upload validation file
Console.WriteLine("Uploading validation file...");
using FileStream validationStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/sft_validation_set.jsonl");
OpenAIFile validationFile = fileClient.UploadFile(
    validationStream,
    "sft_validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");

// Create supervised fine-tuning job
Console.WriteLine("Creating supervised fine-tuning job...");
FineTuningJob fineTuningJob = fineTuningClient.FineTune(
    "gpt-4.1",
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
Console.WriteLine($"Model: {fineTuningJob.Model}");

// Retrieve job details
Console.WriteLine($"Getting fine-tuning job with ID: {fineTuningJob.JobId}");
FineTuningJob retrievedJob = fineTuningClient.GetJob(fineTuningJob.JobId);
Console.WriteLine($"Retrieved job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");

// List all fine-tuning jobs
Console.WriteLine("Listing all fine-tuning jobs:");
foreach (FineTuningJob job in fineTuningClient.GetJobs())
{
    Console.WriteLine($"Job: {job.JobId}, Model: {job.Model}, Status: {job.Status}");
}

// Pause the fine-tuning job
Console.WriteLine($"Pausing fine-tuning job with ID: {fineTuningJob.JobId}");
fineTuningClient.PauseFineTuningJob(fineTuningJob.JobId, options: null);
FineTuningJob pausedJob = fineTuningClient.GetJob(fineTuningJob.JobId);
Console.WriteLine($"Paused job: {pausedJob.JobId}, Status: {pausedJob.Status}");

// Resume the fine-tuning job
Console.WriteLine($"Resuming fine-tuning job with ID: {fineTuningJob.JobId}");
fineTuningClient.ResumeFineTuningJob(fineTuningJob.JobId, options: null);
FineTuningJob resumedJob = fineTuningClient.GetJob(fineTuningJob.JobId);
Console.WriteLine($"Resumed job: {resumedJob.JobId}, Status: {resumedJob.Status}");

// List events for the job
Console.WriteLine($"Listing events of fine-tuning job: {fineTuningJob.JobId}");
foreach (FineTuningEvent evt in retrievedJob.GetEvents(new GetEventsOptions()))
{
    Console.WriteLine($"Event: {evt.Level} - {evt.Message} at {evt.CreatedAt}");
}

// List checkpoints (job needs to be in terminal state)
Console.WriteLine($"Listing checkpoints of fine-tuning job: {fineTuningJob.JobId}");
foreach (FineTuningCheckpoint checkpoint in retrievedJob.GetCheckpoints(new GetCheckpointsOptions()))
{
    Console.WriteLine($"Checkpoint: {checkpoint.Id} at step {checkpoint.StepNumber}");
}

// Cancel the fine-tuning job
Console.WriteLine($"Cancelling fine-tuning job with ID: {retrievedJob.JobId}");
retrievedJob.CancelAndUpdate();
Console.WriteLine($"Successfully cancelled fine-tuning job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");

// Clean up files
ClientResult<FileDeletionResult> trainDeleteResult = fileClient.DeleteFile(trainFile.Id);
Console.WriteLine($"Deleted training file: {trainFile.Id} (deleted: {trainDeleteResult.Value.Deleted})");

ClientResult<FileDeletionResult> validationDeleteResult = fileClient.DeleteFile(validationFile.Id);
Console.WriteLine($"Deleted validation file: {validationFile.Id} (deleted: {validationDeleteResult.Value.Deleted})");
```

## Training Data Format

The training file should be in JSONL format with the following structure:

```json
{"messages":[{"role":"system","content":"You are a helpful assistant."},{"role":"user","content":"What's the capital of France?"},{"role":"assistant","content":"The capital of France is Paris."}]}
{"messages":[{"role":"system","content":"You are a helpful assistant."},{"role":"user","content":"What is 2+2?"},{"role":"assistant","content":"2+2 equals 4."}]}
```

Each line is a complete conversation with system, user, and assistant messages.
