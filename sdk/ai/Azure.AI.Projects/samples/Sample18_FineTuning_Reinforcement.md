# Reinforcement Fine-Tuning

This sample demonstrates how to create a reinforcement fine-tuning job with grader configuration using the Azure AI Projects SDK.

## Supported Models

Supported OpenAI models: o1, o3, o4 (with grader models: o1-mini, o3-mini)

## Prerequisites

- Install the Azure.AI.Projects package.

- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the model deployment to use for fine-tuning.
  - `GRADER_MODEL_DEPLOYMENT_NAME`: The name of the grader model deployment (e.g., o3-mini).

## Create Clients

### Async

```C# Snippet:AI_Projects_FineTuning_Reinforcement_CreateClientsAsync
string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/rft_training_set.jsonl";
string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/rft_validation_set.jsonl";
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var graderModelDeploymentName = Environment.GetEnvironmentVariable("GRADER_MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

### Sync

```C# Snippet:AI_Projects_FineTuning_Reinforcement_CreateClients
string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/rft_training_set.jsonl";
string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/rft_validation_set.jsonl";
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var graderModelDeploymentName = Environment.GetEnvironmentVariable("GRADER_MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

## Upload Training and Validation Files

To fine-tune a model, we need to upload training and validation datasets. In the code below, we use the `UploadFile` method of `OpenAIFileClient`. This method returns an `OpenAIFile` object containing the file ID and `Status`, which indicates whether the file was successfully uploaded to the cloud. We use these to monitor the upload process in the `WaitForFileProcessing` and `WaitForFileProcessingAsync` helper methods.

### Async

```C# Snippet:AI_Projects_FineTuning_Reinforcement_UploadFilesAsync
// Upload training file
Console.WriteLine("Uploading training file...");
using FileStream trainStream = File.OpenRead(trainingFilePath);
OpenAIFile trainFile = await fileClient.UploadFileAsync(
    trainStream,
    "rft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

// Upload validation file
Console.WriteLine("Uploading validation file...");
using FileStream validationStream = File.OpenRead(validationFilePath);
OpenAIFile validationFile = await fileClient.UploadFileAsync(
    validationStream,
    "rft_validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
```

### Sync

```C# Snippet:AI_Projects_FineTuning_Reinforcement_UploadFiles
// Upload training file
Console.WriteLine("Uploading training file...");
using FileStream trainStream = File.OpenRead(trainingFilePath);
OpenAIFile trainFile = fileClient.UploadFile(
    trainStream,
    "rft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

// Upload validation file
Console.WriteLine("Uploading validation file...");
using FileStream validationStream = File.OpenRead(validationFilePath);
OpenAIFile validationFile = fileClient.UploadFile(
    validationStream,
    "rft_validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
```

## Wait for File Processing

In production, you should wait for files to complete processing before creating a fine-tuning job. See the helper methods in `Sample16_FineTuning_Supervised.md` for `WaitForFileProcessingAsync` and `WaitForFileProcessing` implementations.

## Create Reinforcement Fine-Tuning Job

Once the files are processed, we can create a reinforcement fine-tuning job. Reinforcement fine-tuning uses a grader model to evaluate and score the model's responses, enabling the model to learn from feedback. The request includes grader configuration with input prompts, scoring range, and hyperparameters like reasoning effort. Since reinforcement fine-tuning requires additional parameters not available in the strongly-typed API, we use JSON construction with `BinaryContent`.

### Async

```C# Snippet:AI_Projects_FineTuning_Reinforcement_CreateJobAsync
// Create reinforcement fine-tuning job with grader configuration
Console.WriteLine("Creating reinforcement fine-tuning job...");

var requestJson = new
{
    model = modelDeploymentName,
    training_file = trainFile.Id,
    validation_file = validationFile.Id,
    trainingType = "Standard",
    method = new
    {
        type = "reinforcement",
        reinforcement = new
        {
            grader = new
            {
                type = "score_model",
                name = graderModelDeploymentName,
                model = graderModelDeploymentName,
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

string jsonBody = JsonSerializer.Serialize(requestJson);

BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);

Console.WriteLine($"Created reinforcement fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
```

### Sync

```C# Snippet:AI_Projects_FineTuning_Reinforcement_CreateJob
// Create reinforcement fine-tuning job with grader configuration
Console.WriteLine("Creating reinforcement fine-tuning job...");

var requestJson = new
{
    model = modelDeploymentName,
    training_file = trainFile.Id,
    validation_file = validationFile.Id,
    trainingType = "Standard",
    method = new
    {
        type = "reinforcement",
        reinforcement = new
        {
            grader = new
            {
                type = "score_model",
                name = graderModelDeploymentName,
                model = graderModelDeploymentName,
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

string jsonBody = JsonSerializer.Serialize(requestJson);

BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
FineTuningJob fineTuningJob = fineTuningClient.FineTune(content, waitUntilCompleted: false, options: null);

Console.WriteLine($"Created reinforcement fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
```
