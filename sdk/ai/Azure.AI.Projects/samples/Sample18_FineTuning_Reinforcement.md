# Sample using Reinforcement Fine-Tuning (RFT) in Azure.AI.Projects

This sample demonstrates how to create and manage Reinforcement Fine-Tuning (RFT) jobs using OpenAI Fine-Tuning API through the Azure AI Projects SDK. Reinforcement fine-tuning uses a reward model to optimize model behavior based on quality scores.

## Supported Models

Reinforcement fine-tuning is supported for the following models:
- o3-mini
- o4-mini

Note: Reinforcement fine-tuning also requires a grader model (typically o3-mini) to evaluate response quality.

## Prerequisites

- Install the Azure.AI.Projects package.
- Install the Azure.AI.Agents package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.

## Asynchronous Sample

```C# Snippet:AI_Projects_FineTuning_ReinforcementAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
AgentsClient agentClient = projectClient.GetAgentsClient();
OpenAIClient oaiClient = agentClient.GetOpenAIClient();
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();

// Upload training file
Console.WriteLine("Uploading training file...");
using FileStream trainStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/rft_training_set.jsonl");
OpenAIFile trainFile = await fileClient.UploadFileAsync(
    trainStream,
    "rft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

// Upload validation file
Console.WriteLine("Uploading validation file...");
using FileStream validationStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/rft_validation_set.jsonl");
OpenAIFile validationFile = await fileClient.UploadFileAsync(
    validationStream,
    "rft_validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");

// Build the JSON request manually for reinforcement learning
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

// Create reinforcement fine-tuning job
Console.WriteLine("Creating reinforcement fine-tuning job...");
string jsonString = System.Text.Json.JsonSerializer.Serialize(requestJson);
BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonString));
FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(
    content,
    waitUntilCompleted: false,
    options: null);
Console.WriteLine($"Created RFT fine-tuning job: {fineTuningJob.JobId}");
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

```C# Snippet:AI_Projects_FineTuning_Reinforcement
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
AgentsClient agentClient = projectClient.GetAgentsClient();
OpenAIClient oaiClient = agentClient.GetOpenAIClient();
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();

// Upload training file
Console.WriteLine("Uploading training file...");
using FileStream trainStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/rft_training_set.jsonl");
OpenAIFile trainFile = fileClient.UploadFile(
    trainStream,
    "rft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

// Upload validation file
Console.WriteLine("Uploading validation file...");
using FileStream validationStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/rft_validation_set.jsonl");
OpenAIFile validationFile = fileClient.UploadFile(
    validationStream,
    "rft_validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");

// Build the JSON request manually for reinforcement learning
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

// Create reinforcement fine-tuning job
Console.WriteLine("Creating reinforcement fine-tuning job...");
string jsonString = System.Text.Json.JsonSerializer.Serialize(requestJson);
BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonString));
FineTuningJob fineTuningJob = fineTuningClient.FineTune(
    content,
    waitUntilCompleted: false,
    options: null);
Console.WriteLine($"Created RFT fine-tuning job: {fineTuningJob.JobId}");
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

The training file for RFT should be in JSONL format with standard conversation messages:

```json
{"messages":[{"role":"system","content":"You are a helpful assistant."},{"role":"user","content":"Explain quantum computing in simple terms."},{"role":"assistant","content":"Quantum computing uses quantum bits (qubits) that can exist in multiple states simultaneously, unlike classical bits that are either 0 or 1. This allows quantum computers to process certain types of calculations much faster than traditional computers."}]}
{"messages":[{"role":"system","content":"You are a helpful assistant."},{"role":"user","content":"What is machine learning?"},{"role":"assistant","content":"Machine learning is a subset of artificial intelligence where computers learn from data and improve their performance over time without being explicitly programmed for every task."}]}
```

## Key Features

- **Grader Configuration**: Uses a score model (e.g., o3-mini) to evaluate response quality
- **Score Range**: Defines the scoring range (e.g., 0.0 to 10.0) for evaluating responses
- **Hyperparameters**:
  - `n_epochs`: Number of training epochs
  - `batch_size`: Training batch size
  - `learning_rate_multiplier`: Learning rate multiplier
  - `eval_interval`: Evaluation frequency during training
  - `eval_samples`: Number of samples for evaluation
  - `reasoning_effort`: Controls model reasoning depth (low, medium, high)

The reinforcement method learns to optimize responses based on the grader's quality scores.
