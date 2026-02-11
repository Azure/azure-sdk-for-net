# Direct Preference Optimization (DPO) Fine-Tuning

This sample demonstrates how to create a Direct Preference Optimization (DPO) fine-tuning job using the Azure AI Projects SDK.

## Supported Models

Supported OpenAI models: gpt-4o, gpt-4o-mini

## Prerequisites

- Install the Azure.AI.Projects package.

- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the model deployment to use for fine-tuning.
  - `TRAINING_FILE_PATH` : the file with training data.
  - `VALIDATION_FILE_PATH` : the file with data for model validation.

## Create Clients

### Async

```C# Snippet:AI_Projects_FineTuning_DPO_CreateClientsAsync
string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/dpo_training_set.jsonl";
string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/dpo_validation_set.jsonl";
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

### Sync

```C# Snippet:AI_Projects_FineTuning_DPO_CreateClients
string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/dpo_training_set.jsonl";
string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/dpo_validation_set.jsonl";
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

```C# Snippet:AI_Projects_FineTuning_DPO_UploadFilesAsync
// Upload training file
Console.WriteLine("Uploading training file...");
using FileStream trainStream = File.OpenRead(trainingFilePath);
OpenAIFile trainFile = await fileClient.UploadFileAsync(
    trainStream,
    "dpo_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

// Upload validation file
Console.WriteLine("Uploading validation file...");
using FileStream validationStream = File.OpenRead(validationFilePath);
OpenAIFile validationFile = await fileClient.UploadFileAsync(
    validationStream,
    "dpo_validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
```

### Sync

```C# Snippet:AI_Projects_FineTuning_DPO_UploadFiles
// Upload training file
Console.WriteLine("Uploading training file...");
using FileStream trainStream = File.OpenRead(trainingFilePath);
OpenAIFile trainFile = fileClient.UploadFile(
    trainStream,
    "dpo_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

// Upload validation file
Console.WriteLine("Uploading validation file...");
using FileStream validationStream = File.OpenRead(validationFilePath);
OpenAIFile validationFile = fileClient.UploadFile(
    validationStream,
    "dpo_validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
```

## Wait for File Processing Helper

After uploading files, they need to be processed before they can be used for fine-tuning. In production, you should wait for files to complete processing before creating a fine-tuning job. The helper methods below poll the file status until it reaches `Processed` or `Error` state. This ensures your training data is ready before starting the fine-tuning job.

```C# Snippet:AI_Projects_FineTuning_WaitForFileProcessingHelper
/// <summary>
/// Wait for file to complete processing (async).
/// </summary>
public static async Task<OpenAIFile> WaitForFileProcessingAsync(
    OpenAIFileClient fileClient,
    string fileId,
    int pollIntervalSeconds = 5,
    int maxWaitSeconds = 1800)
{
    var start = DateTimeOffset.Now;
    var pollInterval = TimeSpan.FromSeconds(pollIntervalSeconds);
    var timeout = TimeSpan.FromSeconds(maxWaitSeconds);

    OpenAIFile file = await fileClient.GetFileAsync(fileId);
    Console.WriteLine($"File {fileId} initial status: {file.Status}");

    while (file.Status != FileStatus.Processed && file.Status != FileStatus.Error)
    {
        if (DateTimeOffset.Now - start > timeout)
        {
            throw new TimeoutException(
                $"File {fileId} did not finish processing after {maxWaitSeconds} seconds. Current status: {file.Status}");
        }

        await Task.Delay(pollInterval);
        file = await fileClient.GetFileAsync(fileId);
        Console.WriteLine($"File {fileId} status: {file.Status}");
    }

    if (file.Status == FileStatus.Error)
    {
        throw new InvalidOperationException(
            $"File {fileId} processing failed: {file.StatusDetails}");
    }

    Console.WriteLine($"File {fileId} processing completed successfully");
    return file;
}

/// <summary>
/// Wait for file to complete processing (sync).
/// </summary>
public static OpenAIFile WaitForFileProcessing(
    OpenAIFileClient fileClient,
    string fileId,
    int pollIntervalSeconds = 5,
    int maxWaitSeconds = 1800)
{
    var start = DateTimeOffset.Now;
    var pollInterval = TimeSpan.FromSeconds(pollIntervalSeconds);
    var timeout = TimeSpan.FromSeconds(maxWaitSeconds);

    OpenAIFile file = fileClient.GetFile(fileId);
    Console.WriteLine($"File {fileId} initial status: {file.Status}");

    while (file.Status != FileStatus.Processed && file.Status != FileStatus.Error)
    {
        if (DateTimeOffset.Now - start > timeout)
        {
            throw new TimeoutException(
                $"File {fileId} did not finish processing after {maxWaitSeconds} seconds. Current status: {file.Status}");
        }

        System.Threading.Thread.Sleep(pollInterval);
        file = fileClient.GetFile(fileId);
        Console.WriteLine($"File {fileId} status: {file.Status}");
    }

    if (file.Status == FileStatus.Error)
    {
        throw new InvalidOperationException(
            $"File {fileId} processing failed: {file.StatusDetails}");
    }

    Console.WriteLine($"File {fileId} processing completed successfully");
    return file;
}
```

## Create DPO Fine-Tuning Job

Once the files are processed, we can create a DPO fine-tuning job. DPO (Direct Preference Optimization) is a training method that learns from preference data, where each example contains a prompt with both preferred and non-preferred responses. The `FineTune` method accepts the model name, training file ID, and DPO-specific hyperparameters.

> **Note:** If you need to pass additional parameters like `trainingType` (e.g., for OSS models), use the JSON construction approach with `BinaryContent` instead of the strongly-typed API. Recommended approach is to set trainingType. See `Sample19_FineTuning_OSS.md` for an example.

### Async

```C# Snippet:AI_Projects_FineTuning_DPO_CreateJobAsync
// Create DPO fine-tuning job
Console.WriteLine("Creating DPO fine-tuning job...");
FineTuningJob fineTuningJob = fineTuningClient.FineTune(
    modelDeploymentName,
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
```

### Sync

```C# Snippet:AI_Projects_FineTuning_DPO_CreateJob
// Create DPO fine-tuning job
Console.WriteLine("Creating DPO fine-tuning job...");
FineTuningJob fineTuningJob = fineTuningClient.FineTune(
    modelDeploymentName,
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
```
