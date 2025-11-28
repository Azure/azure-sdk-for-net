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
string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/sft_validation_set.jsonl";
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

### Sync

```C# Snippet:AI_Projects_FineTuning_OSS_CreateClients
string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/sft_validation_set.jsonl";
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

## Upload Training and Validation Files

To fine-tune a model, we need to upload training and validation datasets. In the code below, we use the `UploadFile` method of `OpenAIFileClient`. This method returns an `OpenAIFile` object containing the file ID and `Status`, which indicates whether the file was successfully uploaded to the cloud. We use these to monitor the upload process in the `WaitForFileProcessing` and `WaitForFileProcessingAsync` helper methods.

### Async

```C# Snippet:AI_Projects_FineTuning_OSS_UploadFilesAsync
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
```

### Sync

```C# Snippet:AI_Projects_FineTuning_OSS_UploadFiles
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
```

## Wait for File Processing

In production, you should wait for files to complete processing before creating a fine-tuning job. See the helper methods in `Sample16_FineTuning_Supervised.md` for `WaitForFileProcessingAsync` and `WaitForFileProcessing` implementations.

## Create OSS Fine-Tuning Job

Once the files are processed, we can create a fine-tuning job for open source models. We use JSON construction with `BinaryContent` to include the trainingType parameter in the request.

### Async

```C# Snippet:AI_Projects_FineTuning_OSS_CreateJobAsync
// Create OSS fine-tuning job with GlobalStandard training type
Console.WriteLine("Creating OSS fine-tuning job...");

var requestJson = new
{
    model = modelDeploymentName,
    training_file = trainFile.Id,
    validation_file = validationFile.Id,
    trainingType = "GlobalStandard",
    method = new
    {
        type = "supervised",
        hyperparameters = new
        {
            n_epochs = 1,
            batch_size = 4,
            learning_rate_multiplier = 0.0001
        }
    }
};

string jsonBody = JsonSerializer.Serialize(requestJson);

BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);

Console.WriteLine($"Created OSS fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
```

### Sync

```C# Snippet:AI_Projects_FineTuning_OSS_CreateJob
// Create OSS fine-tuning job with GlobalStandard training type
Console.WriteLine("Creating OSS fine-tuning job...");

var requestJson = new
{
    model = modelDeploymentName,
    training_file = trainFile.Id,
    validation_file = validationFile.Id,
    trainingType = "GlobalStandard",
    method = new
    {
        type = "supervised",
        hyperparameters = new
        {
            n_epochs = 1,
            batch_size = 4,
            learning_rate_multiplier = 0.0001
        }
    }
};

string jsonBody = JsonSerializer.Serialize(requestJson);

BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
FineTuningJob fineTuningJob = fineTuningClient.FineTune(content, waitUntilCompleted: false, options: null);

Console.WriteLine($"Created OSS fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
```
