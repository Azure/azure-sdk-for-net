# Sample using Direct Preference Optimization (DPO) Fine-Tuning in Azure.AI.Projects

This sample demonstrates how to create and manage Direct Preference Optimization (DPO) fine-tuning jobs using OpenAI Fine-Tuning API through the Azure AI Projects SDK. DPO is a technique that directly optimizes model preferences by learning from paired examples of preferred and non-preferred outputs.

## Supported Models
Supported OpenAI models: GPT-4o, GPT-4.1, GPT-4.1-mini, GPT-4.1-nano, and GPT-4o-mini.


## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.

## Asynchronous Sample

```C# Snippet:AI_Projects_FineTuning_DPOAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
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

// Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
// See Sample16_FineTuning_Supervised.md for a WaitForFileProcessingAsync helper method.

// Create DPO fine-tuning job
// Note: The default training type passed here is "Standard".
// If you need to pass training type explicitly (e.g., "GlobalStandard"),
// see Sample19_FineTuning_OSS.md for the manual JSON construction approach.
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
```

## Synchronous Sample

```C# Snippet:AI_Projects_FineTuning_DPO
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
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

// Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
// See Sample16_FineTuning_Supervised.md for a WaitForFileProcessing helper method.

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
```
