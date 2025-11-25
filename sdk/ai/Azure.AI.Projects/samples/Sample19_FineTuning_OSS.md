# Open Source Model (OSS) Fine-Tuning

This sample demonstrates how to create a fine-tuning job for open source models with GlobalStandard training type using the Azure AI Projects SDK.

## Supported Models

Supported models: Ministral-3B

## Prerequisites

- Install the Azure.AI.Projects package.

- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the model deployment to use for fine-tuning.

## Create Clients

### Async

```C# Snippet:AI_Projects_FineTuning_OSS_CreateClientsAsync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

### Sync

```C# Snippet:AI_Projects_FineTuning_OSS_CreateClients
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

## Upload Training and Validation Files

### Async

```C# Snippet:AI_Projects_FineTuning_OSS_UploadFilesAsync
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

// Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
// See Sample16_FineTuning_Supervised.md for a WaitForFileProcessingAsync helper method.
```

### Sync

```C# Snippet:AI_Projects_FineTuning_OSS_UploadFiles
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

// Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
// See Sample16_FineTuning_Supervised.md for a WaitForFileProcessing helper method.
```

## Create OSS Fine-Tuning Job

### Async

```C# Snippet:AI_Projects_FineTuning_OSS_CreateJobAsync
// Create OSS fine-tuning job with GlobalStandard training type
// Note: OSS models like Ministral-3B require explicit trainingType="GlobalStandard" parameter
// which is not supported by the standard FineTuningClient API, so we use manual JSON construction
Console.WriteLine("Creating OSS fine-tuning job...");

string jsonBody = JsonSerializer.Serialize(new Dictionary<string, object>
{
    ["model"] = modelDeploymentName,
    ["training_file"] = trainFile.Id,
    ["validation_file"] = validationFile.Id,
    ["trainingType"] = "GlobalStandard",
    ["method"] = new Dictionary<string, object>
    {
        ["type"] = "supervised",
        ["hyperparameters"] = new Dictionary<string, object>
        {
            ["n_epochs"] = 1,
            ["batch_size"] = 4,
            ["learning_rate_multiplier"] = 0.0001
        }
    }
});

BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);

Console.WriteLine($"Created OSS fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
```

### Sync

```C# Snippet:AI_Projects_FineTuning_OSS_CreateJob
// Create OSS fine-tuning job with GlobalStandard training type
Console.WriteLine("Creating OSS fine-tuning job...");

string jsonBody = JsonSerializer.Serialize(new Dictionary<string, object>
{
    ["model"] = modelDeploymentName,
    ["training_file"] = trainFile.Id,
    ["validation_file"] = validationFile.Id,
    ["trainingType"] = "GlobalStandard",
    ["method"] = new Dictionary<string, object>
    {
        ["type"] = "supervised",
        ["hyperparameters"] = new Dictionary<string, object>
        {
            ["n_epochs"] = 1,
            ["batch_size"] = 4,
            ["learning_rate_multiplier"] = 0.0001
        }
    }
});

BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
FineTuningJob fineTuningJob = fineTuningClient.FineTune(content, waitUntilCompleted: false, options: null);

Console.WriteLine($"Created OSS fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
```
