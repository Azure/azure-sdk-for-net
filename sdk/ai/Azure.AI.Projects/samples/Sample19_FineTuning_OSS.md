# Sample using OSS Models Supervised Fine-Tuning in Azure.AI.Projects

This sample demonstrates how to create and manage supervised fine-tuning jobs for Open Source Software (OSS) models using OpenAI Fine-Tuning API through the Azure AI Projects SDK. This allows you to fine-tune open-source models like Mistral deployed in Azure AI.

## Supported Models
Supported open-source models with SFT: Ministral-3b

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.

## Asynchronous Sample

```C# Snippet:AI_Projects_FineTuning_OSSAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
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

// Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
// See Sample16_FineTuning_Supervised.md for a WaitForFileProcessingAsync helper method.

// Create supervised fine-tuning job for OSS model
// Note: OSS models require GlobalStandard training type. We use manual JSON construction to pass "GlobalStandard".
string ossModelName = "Ministral-3B";
Console.WriteLine($"Creating OSS supervised fine-tuning job for model: {ossModelName}");

var requestJson = new
{
    model = ossModelName,
    training_file = trainFile.Id,
    validation_file = validationFile.Id,
    trainingType = "GlobalStandard",
    method = new
    {
        type = "supervised",
        supervised = new
        {
            hyperparameters = new
            {
                n_epochs = 3,
                batch_size = 2,
                learning_rate_multiplier = 0.00002
            }
        }
    }
};

string jsonString = System.Text.Json.JsonSerializer.Serialize(requestJson);
BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonString));
FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(
    content,
    waitUntilCompleted: false,
    options: null);
Console.WriteLine($"Created OSS fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
Console.WriteLine($"Model: {fineTuningJob.Model}");
```

## Synchronous Sample

```C# Snippet:AI_Projects_FineTuning_OSS
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
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

// Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
// See Sample16_FineTuning_Supervised.md for a WaitForFileProcessing helper method.

// Create supervised fine-tuning job for OSS model
// Note: OSS models require explicit training type. We use manual JSON construction to pass "GlobalStandard".
string ossModelName = "Ministral-3B";
Console.WriteLine($"Creating OSS supervised fine-tuning job for model: {ossModelName}");

var requestJson = new
{
    model = ossModelName,
    training_file = trainFile.Id,
    validation_file = validationFile.Id,
    trainingType = "GlobalStandard",
    method = new
    {
        type = "supervised",
        supervised = new
        {
            hyperparameters = new
            {
                n_epochs = 3,
                batch_size = 2,
                learning_rate_multiplier = 0.00002
            }
        }
    }
};

string jsonString = System.Text.Json.JsonSerializer.Serialize(requestJson);
BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonString));
FineTuningJob fineTuningJob = fineTuningClient.FineTune(
    content,
    waitUntilCompleted: false,
    options: null);
Console.WriteLine($"Created OSS fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
Console.WriteLine($"Model: {fineTuningJob.Model}");
```