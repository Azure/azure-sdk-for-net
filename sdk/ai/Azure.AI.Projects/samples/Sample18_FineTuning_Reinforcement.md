# Reinforcement Fine-Tuning

This sample demonstrates how to create a reinforcement fine-tuning job with grader configuration using the Azure AI Projects SDK.

## Supported Models

Supported OpenAI models: o1, o3, o4 (with grader models: o1-mini, o3-mini)

## Prerequisites

- Install the Azure.AI.Projects package.

- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the model deployment to use for fine-tuning.

## Create Clients

### Async

```C# Snippet:AI_Projects_FineTuning_Reinforcement_CreateClientsAsync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

### Sync

```C# Snippet:AI_Projects_FineTuning_Reinforcement_CreateClients
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

## Upload Training and Validation Files

### Async

```C# Snippet:AI_Projects_FineTuning_Reinforcement_UploadFilesAsync
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

// Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
// See Sample16_FineTuning_Supervised.md for a WaitForFileProcessingAsync helper method.
```

### Sync

```C# Snippet:AI_Projects_FineTuning_Reinforcement_UploadFiles
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

// Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
// See Sample16_FineTuning_Supervised.md for a WaitForFileProcessing helper method.
```

## Create Reinforcement Fine-Tuning Job

### Async

```C# Snippet:AI_Projects_FineTuning_Reinforcement_CreateJobAsync
// Create reinforcement fine-tuning job with grader configuration
// Note: Currently, reinforcement fine-tuning requires manual JSON construction
Console.WriteLine("Creating reinforcement fine-tuning job...");

string jsonBody = JsonSerializer.Serialize(new Dictionary<string, object>
{
    ["model"] = modelDeploymentName,
    ["training_file"] = trainFile.Id,
    ["validation_file"] = validationFile.Id,
    ["method"] = new Dictionary<string, object>
    {
        ["type"] = "reinforcement",
        ["reinforcement"] = new Dictionary<string, object>
        {
            ["grader"] = new Dictionary<string, object>
            {
                ["type"] = "score_model",
                ["model"] = "o3-mini"
            }
        },
        ["hyperparameters"] = new Dictionary<string, object>
        {
            ["reasoning_effort"] = "medium",
            ["eval_interval"] = 10,
            ["eval_samples"] = 5
        }
    }
});

BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);

Console.WriteLine($"Created reinforcement fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
```

### Sync

```C# Snippet:AI_Projects_FineTuning_Reinforcement_CreateJob
// Create reinforcement fine-tuning job with grader configuration
Console.WriteLine("Creating reinforcement fine-tuning job...");

string jsonBody = JsonSerializer.Serialize(new Dictionary<string, object>
{
    ["model"] = modelDeploymentName,
    ["training_file"] = trainFile.Id,
    ["validation_file"] = validationFile.Id,
    ["method"] = new Dictionary<string, object>
    {
        ["type"] = "reinforcement",
        ["reinforcement"] = new Dictionary<string, object>
        {
            ["grader"] = new Dictionary<string, object>
            {
                ["type"] = "score_model",
                ["model"] = "o3-mini"
            }
        },
        ["hyperparameters"] = new Dictionary<string, object>
        {
            ["reasoning_effort"] = "medium",
            ["eval_interval"] = 10,
            ["eval_samples"] = 5
        }
    }
});

BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
FineTuningJob fineTuningJob = fineTuningClient.FineTune(content, waitUntilCompleted: false, options: null);

Console.WriteLine($"Created reinforcement fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
```
