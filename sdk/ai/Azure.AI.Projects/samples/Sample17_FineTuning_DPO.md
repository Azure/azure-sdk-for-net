# Sample using Direct Preference Optimization (DPO) Fine-Tuning in Azure.AI.Projects

This sample demonstrates how to create and manage Direct Preference Optimization (DPO) fine-tuning jobs using OpenAI Fine-Tuning API through the Azure AI Projects SDK. DPO is a technique that directly optimizes model preferences by learning from paired examples of preferred and non-preferred outputs.

## Supported Models

Direct Preference Optimization (DPO) fine-tuning is supported for the following models:
- gpt-4o-mini-2024-07-18
- gpt-4o-2024-08-06

## Prerequisites

- Install the Azure.AI.Projects package.
- Install the Azure.AI.Agents package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.

## Asynchronous Sample

```C# Snippet:AI_Projects_FineTuning_DPOAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
AgentsClient agentClient = projectClient.GetAgentsClient();
OpenAIClient oaiClient = agentClient.GetOpenAIClient();
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();

// Upload training file
Console.WriteLine("Uploading training file...");
using FileStream trainStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/dpo_training_set.jsonl");
OpenAIFile trainFile = await fileClient.UploadFileAsync(
    trainStream,
    "dpo_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

// Upload validation file
Console.WriteLine("Uploading validation file...");
using FileStream validationStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/dpo_validation_set.jsonl");
OpenAIFile validationFile = await fileClient.UploadFileAsync(
    validationStream,
    "dpo_validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");

// Create DPO fine-tuning job
Console.WriteLine("Creating DPO fine-tuning job...");
FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(
    "gpt-4o-mini-2024-07-18",
    trainFile.Id,
    waitUntilCompleted: false,
    new()
    {
        TrainingMethod = FineTuningTrainingMethod.CreateDirectPreferenceOptimization(
            epochCount: 1,
            batchSize: 4,
            learningRate: 0.0001),
        ValidationFile = validationFile.Id
    });
Console.WriteLine($"Created DPO fine-tuning job: {fineTuningJob.JobId}");
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

```C# Snippet:AI_Projects_FineTuning_DPO
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
AgentsClient agentClient = projectClient.GetAgentsClient();
OpenAIClient oaiClient = agentClient.GetOpenAIClient();
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();

// Upload training file
Console.WriteLine("Uploading training file...");
using FileStream trainStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/dpo_training_set.jsonl");
OpenAIFile trainFile = fileClient.UploadFile(
    trainStream,
    "dpo_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

// Upload validation file
Console.WriteLine("Uploading validation file...");
using FileStream validationStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/dpo_validation_set.jsonl");
OpenAIFile validationFile = fileClient.UploadFile(
    validationStream,
    "dpo_validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");

// Create DPO fine-tuning job
Console.WriteLine("Creating DPO fine-tuning job...");
FineTuningJob fineTuningJob = fineTuningClient.FineTune(
    "gpt-4o-mini-2024-07-18",
    trainFile.Id,
    waitUntilCompleted: false,
    new()
    {
        TrainingMethod = FineTuningTrainingMethod.CreateDirectPreferenceOptimization(
            epochCount: 1,
            batchSize: 4,
            learningRate: 0.0001),
        ValidationFile = validationFile.Id
    });
Console.WriteLine($"Created DPO fine-tuning job: {fineTuningJob.JobId}");
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

The training file for DPO should be in JSONL format with input, preferred_output, and non_preferred_output fields:

```json
{"input":{"messages":[{"role":"system","content":"You are a helpful assistant."},{"role":"user","content":"What's the capital of France?"}]},"preferred_output":[{"role":"assistant","content":"The capital of France is Paris."}],"non_preferred_output":[{"role":"assistant","content":"I think it's London."}]}
{"input":{"messages":[{"role":"system","content":"You are a helpful assistant."},{"role":"user","content":"What is 2+2?"}]},"preferred_output":[{"role":"assistant","content":"2+2 equals 4."}],"non_preferred_output":[{"role":"assistant","content":"2+2 equals 5."}]}
```

Each line contains:
- `input`: The conversation context with system and user messages
- `preferred_output`: The desired assistant response
- `non_preferred_output`: The less desirable assistant response

The model learns to prefer the preferred_output over the non_preferred_output.
