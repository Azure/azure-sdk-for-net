# Sample using Reinforcement Fine-Tuning (RFT) in Azure.AI.Projects

This sample demonstrates how to create and manage Reinforcement Fine-Tuning (RFT) jobs using OpenAI Fine-Tuning API through the Azure AI Projects SDK. Reinforcement fine-tuning uses a reward model to optimize model behavior based on quality scores.

## Supported Models
Supported OpenAI models: o4-mini

Note: Reinforcement fine-tuning also requires a grader model (typically o3-mini) to evaluate response quality.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.

## Asynchronous Sample

```C# Snippet:AI_Projects_FineTuning_ReinforcementAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
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

// Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
// See Sample16_FineTuning_Supervised.md for a WaitForFileProcessingAsync helper method.

// Build the JSON request manually for reinforcement learning
var requestJson = new
{
    model = "o4-mini",
    training_file = trainFile.Id,
    validation_file = validationFile.Id,
    // trainingType = "Standard", Pass trainingType here, default is Standard
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
```

## Synchronous Sample

```C# Snippet:AI_Projects_FineTuning_Reinforcement
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
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

// Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
// See Sample16_FineTuning_Supervised.md for a WaitForFileProcessing helper method.

// Build the JSON request manually for reinforcement learning
var requestJson = new
{
    model = "o4-mini",
    training_file = trainFile.Id,
    validation_file = validationFile.Id,
    // trainingType = "Standard", Pass trainingType here, default is Standard
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
```