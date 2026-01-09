# Sample using Supervised Fine-Tuning (SFT) in Azure.AI.Projects

This sample demonstrates how to create and manage supervised fine-tuning jobs using OpenAI Fine-Tuning API through the Azure AI Projects SDK. The file operations are accessed via the ProjectOpenAIClient `GetFineTuningClient` method. Supervised fine-tuning allows you to customize models for specific tasks using labeled training data.

## Supported Models
Supported OpenAI models: gpt-4o, gpt-4o-mini, gpt-4.1, gpt-4.1-mini

## Prerequisites

- Install the Azure.AI.Projects package.
- For deployment samples, also install:
  - `Azure.ResourceManager.CognitiveServices` - For model deployment via Azure Resource Manager

- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the model deployment to use for fine-tuning.
  - `TRAINING_FILE_PATH` : the file with training data.
  - `VALIDATION_FILE_PATH` : the file with data for model validation.

## Create Clients

To work with fine-tuning, we need to create several clients. The `AIProjectClient` is the main entry point, which provides access to `ProjectOpenAIClient`. From there, we obtain `OpenAIFileClient` for file operations and `FineTuningClient` for managing fine-tuning jobs.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_CreateClientsAsync
string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/sft_validation_set.jsonl";
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_CreateClients
string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/sft_validation_set.jsonl";
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

## Upload Files

To fine-tune a model, we need to upload training and validation datasets. In the code below, we use the `UploadFile` method of `OpenAIFileClient`. This method returns an `OpenAIFile` object containing the file ID and `Status`, which indicates whether the file was successfully uploaded to the cloud. We use these to monitor the upload process in the `WaitForFileProcessing` and `WaitForFileProcessingAsync` helper methods.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_UploadFilesAsync
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

### Synchronous

```C# Snippet:AI_Projects_FineTuning_UploadFiles
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

## Create Fine-Tuning Job

Once the files are processed, we can create a fine-tuning job. The `FineTune` method accepts the model name, training file ID, and optional parameters like hyperparameters and validation file. Setting `waitUntilCompleted: false` returns immediately after job creation, allowing you to monitor progress asynchronously.

> **Note:** If you need to pass additional parameters like `trainingType` (e.g., for OSS models), use the JSON construction approach with `BinaryContent` instead of the strongly-typed API. Recommended approach is to set trainingType. See `Sample19_FineTuning_OSS.md` for an example.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_CreateJobAsync
// Create supervised fine-tuning job
Console.WriteLine("Creating supervised fine-tuning job...");
FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(
    modelDeploymentName,
    trainFile.Id,
    waitUntilCompleted: false,
    new()
    {
        TrainingMethod = FineTuningTrainingMethod.CreateSupervised(
            epochCount: 3,
            batchSize: 1,
            learningRate: 1.0),
        ValidationFile = validationFile.Id
    });
Console.WriteLine($"Created fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_CreateJob
// Create supervised fine-tuning job
Console.WriteLine("Creating supervised fine-tuning job...");
FineTuningJob fineTuningJob = fineTuningClient.FineTune(
    modelDeploymentName,
    trainFile.Id,
    waitUntilCompleted: false,
    new()
    {
        TrainingMethod = FineTuningTrainingMethod.CreateSupervised(
            epochCount: 3,
            batchSize: 1,
            learningRate: 1.0),
        ValidationFile = validationFile.Id
    });
Console.WriteLine($"Created fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
```

## Retrieve Job

After creating a fine-tuning job, you can retrieve its current status and details using the `GetJob` method. This returns a `FineTuningJob` object with information about the job's progress, including status, base model, training file, and timestamps.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_RetrieveJobAsync
// Retrieve job details
Console.WriteLine($"Getting fine-tuning job with ID: {fineTuningJob.JobId}");
FineTuningJob retrievedJob = await fineTuningClient.GetJobAsync(fineTuningJob.JobId);
Console.WriteLine($"Retrieved job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_RetrieveJob
// Retrieve job details
Console.WriteLine($"Getting fine-tuning job with ID: {fineTuningJob.JobId}");
FineTuningJob retrievedJob = fineTuningClient.GetJob(fineTuningJob.JobId);
Console.WriteLine($"Retrieved job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");
```

## List Jobs

The `GetJobs` method returns a paginated list of all fine-tuning jobs in your project. This is useful for monitoring multiple jobs or finding a specific job by its properties.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_ListJobsAsync
// List all fine-tuning jobs
Console.WriteLine("Listing all fine-tuning jobs:");
await foreach (FineTuningJob job in fineTuningClient.GetJobsAsync())
{
    Console.WriteLine($"Job: {job.JobId}, Status: {job.Status}");
}
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_ListJobs
// List all fine-tuning jobs
Console.WriteLine("Listing all fine-tuning jobs:");
foreach (FineTuningJob job in fineTuningClient.GetJobs())
{
    Console.WriteLine($"Job: {job.JobId}, Status: {job.Status}");
}
```

## Pause Job

You can pause a running fine-tuning job using `PauseFineTuningJob`. This temporarily stops the training process while preserving progress. Pausing is useful when you need to manage compute resources or review intermediate results before continuing.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_PauseJobAsync
// Pause the fine-tuning job
Console.WriteLine($"Pausing fine-tuning job with ID: {fineTuningJob.JobId}");
await fineTuningClient.PauseFineTuningJobAsync(fineTuningJob.JobId, options: null);
FineTuningJob pausedJob = await fineTuningClient.GetJobAsync(fineTuningJob.JobId);
Console.WriteLine($"Paused job: {pausedJob.JobId}, Status: {pausedJob.Status}");
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_PauseJob
// Pause the fine-tuning job
Console.WriteLine($"Pausing fine-tuning job with ID: {fineTuningJob.JobId}");
fineTuningClient.PauseFineTuningJob(fineTuningJob.JobId, options: null);
FineTuningJob pausedJob = fineTuningClient.GetJob(fineTuningJob.JobId);
Console.WriteLine($"Paused job: {pausedJob.JobId}, Status: {pausedJob.Status}");
```

## Resume Job

After pausing a job, you can resume it using `ResumeFineTuningJob`. The training will continue from where it left off, preserving all previous progress and checkpoints.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_ResumeJobAsync
// Resume the fine-tuning job
Console.WriteLine($"Resuming fine-tuning job with ID: {fineTuningJob.JobId}");
await fineTuningClient.ResumeFineTuningJobAsync(fineTuningJob.JobId, options: null);
FineTuningJob resumedJob = await fineTuningClient.GetJobAsync(fineTuningJob.JobId);
Console.WriteLine($"Resumed job: {resumedJob.JobId}, Status: {resumedJob.Status}");
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_ResumeJob
// Resume the fine-tuning job
Console.WriteLine($"Resuming fine-tuning job with ID: {fineTuningJob.JobId}");
fineTuningClient.ResumeFineTuningJob(fineTuningJob.JobId, options: null);
FineTuningJob resumedJob = fineTuningClient.GetJob(fineTuningJob.JobId);
Console.WriteLine($"Resumed job: {resumedJob.JobId}, Status: {resumedJob.Status}");
```

## List Events

The `GetEvents` method returns a stream of events for a fine-tuning job. Events include training progress updates, validation metrics, and any errors or warnings. This is useful for monitoring job progress and debugging issues.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_ListEventsAsync
// List events for the job
Console.WriteLine($"Listing events of fine-tuning job: {fineTuningJob.JobId}");
await foreach (FineTuningEvent evt in retrievedJob.GetEventsAsync(new GetEventsOptions()))
{
    Console.WriteLine($"Event: {evt.Level} - {evt.Message} at {evt.CreatedAt}");
}
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_ListEvents
// List events for the job
Console.WriteLine($"Listing events of fine-tuning job: {fineTuningJob.JobId}");
foreach (FineTuningEvent evt in retrievedJob.GetEvents(new GetEventsOptions()))
{
    Console.WriteLine($"Event: {evt.Level} - {evt.Message} at {evt.CreatedAt}");
}
```

## Wait for Terminal State

Fine-tuning jobs run asynchronously and may take significant time to complete. The helper methods below poll the job status until it reaches a terminal state: `succeeded`, `failed`, or `cancelled`. This is essential for automation workflows that need to wait for job completion before proceeding.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_WaitForTerminalStateAsync
// Wait for job to reach terminal state (succeeded, failed, or cancelled)
Console.WriteLine($"Waiting for job {fineTuningJob.JobId} to reach terminal state...");
FineTuningJob finalJob = await FineTuningHelpers.WaitForJobTerminalStateAsync(fineTuningClient, fineTuningJob.JobId);
Console.WriteLine($"Job reached terminal state: {finalJob.Status}");
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_WaitForTerminalState
// Wait for job to reach terminal state (succeeded, failed, or cancelled)
Console.WriteLine($"Waiting for job {fineTuningJob.JobId} to reach terminal state...");
FineTuningJob finalJob = FineTuningHelpers.WaitForJobTerminalState(fineTuningClient, fineTuningJob.JobId);
Console.WriteLine($"Job reached terminal state: {finalJob.Status}");
```

### Wait for Terminal State Helper

Here's a helper method you can use to wait for a fine-tuning job to reach a terminal state:

```C# Snippet:AI_Projects_FineTuning_WaitForTerminalStateHelper
/// <summary>
/// Wait for job to reach terminal state (async).
/// </summary>
public static async Task<FineTuningJob> WaitForJobTerminalStateAsync(
    FineTuningClient fineTuningClient,
    string jobId,
    int pollIntervalSeconds = 10,
    int maxWaitSeconds = 3600)
{
    var start = DateTimeOffset.Now;
    var pollInterval = TimeSpan.FromSeconds(pollIntervalSeconds);
    var timeout = TimeSpan.FromSeconds(maxWaitSeconds);

    FineTuningJob job = await fineTuningClient.GetJobAsync(jobId);
    Console.WriteLine($"Job {jobId} initial status: {job.Status}");

    while (!IsTerminalState(job.Status))
    {
        if (DateTimeOffset.Now - start > timeout)
        {
            throw new TimeoutException(
                $"Job {jobId} did not reach terminal state after {maxWaitSeconds} seconds. Current status: {job.Status}");
        }

        await Task.Delay(pollInterval);
        job = await fineTuningClient.GetJobAsync(jobId);
        Console.WriteLine($"Job {jobId} status: {job.Status}");
    }

    Console.WriteLine($"Job {jobId} reached terminal state: {job.Status}");
    return job;
}

/// <summary>
/// Wait for job to reach terminal state (sync).
/// </summary>
public static FineTuningJob WaitForJobTerminalState(
    FineTuningClient fineTuningClient,
    string jobId,
    int pollIntervalSeconds = 10,
    int maxWaitSeconds = 3600)
{
    var start = DateTimeOffset.Now;
    var pollInterval = TimeSpan.FromSeconds(pollIntervalSeconds);
    var timeout = TimeSpan.FromSeconds(maxWaitSeconds);

    FineTuningJob job = fineTuningClient.GetJob(jobId);
    Console.WriteLine($"Job {jobId} initial status: {job.Status}");

    while (!IsTerminalState(job.Status))
    {
        if (DateTimeOffset.Now - start > timeout)
        {
            throw new TimeoutException(
                $"Job {jobId} did not reach terminal state after {maxWaitSeconds} seconds. Current status: {job.Status}");
        }

        System.Threading.Thread.Sleep(pollInterval);
        job = fineTuningClient.GetJob(jobId);
        Console.WriteLine($"Job {jobId} status: {job.Status}");
    }

    Console.WriteLine($"Job {jobId} reached terminal state: {job.Status}");
    return job;
}

/// <summary>
/// Check if job status is terminal.
/// </summary>
public static bool IsTerminalState(FineTuningStatus status)
{
    return status.ToString().ToLowerInvariant() switch
    {
        "succeeded" => true,
        "failed" => true,
        "cancelled" => true,
        _ => false
    };
}
```

## List Checkpoints

During training, the fine-tuning process saves checkpoints at regular intervals. The `GetCheckpoints` method returns these checkpoints, which can be used for model selection or rollback. Each checkpoint includes training metrics and the step number at which it was saved.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_ListCheckpointsAsync
// List checkpoints (job needs to be in terminal state)
Console.WriteLine($"Listing checkpoints of fine-tuning job: {fineTuningJob.JobId}");
await foreach (FineTuningCheckpoint checkpoint in finalJob.GetCheckpointsAsync(new GetCheckpointsOptions()))
{
    Console.WriteLine($"Checkpoint: {checkpoint.Id} at step {checkpoint.StepNumber}");
}
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_ListCheckpoints
// List checkpoints (job needs to be in terminal state)
Console.WriteLine($"Listing checkpoints of fine-tuning job: {fineTuningJob.JobId}");
foreach (FineTuningCheckpoint checkpoint in finalJob.GetCheckpoints(new GetCheckpointsOptions()))
{
    Console.WriteLine($"Checkpoint: {checkpoint.Id} at step {checkpoint.StepNumber}");
}
```

## Cancel Job

The `CancelAndUpdate` method cancels a running or paused fine-tuning job. Once cancelled, the job cannot be resumed. Any checkpoints created before cancellation are still available for use.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_CancelJobAsync
// Cancel the fine-tuning job
Console.WriteLine($"Cancelling fine-tuning job with ID: {retrievedJob.JobId}");
await retrievedJob.CancelAndUpdateAsync();
Console.WriteLine($"Successfully cancelled fine-tuning job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_CancelJob
// Cancel the fine-tuning job
Console.WriteLine($"Cancelling fine-tuning job with ID: {retrievedJob.JobId}");
retrievedJob.CancelAndUpdate();
Console.WriteLine($"Successfully cancelled fine-tuning job: {retrievedJob.JobId}, Status: {retrievedJob.Status}");
```

## Cleanup Files

After fine-tuning is complete, you can delete the training and validation files using `DeleteFile`. This helps manage storage costs and keeps your file list organized. Note that deleting files does not affect any fine-tuned models that were created using those files.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_CleanupFilesAsync
// Clean up files
ClientResult<FileDeletionResult> trainDeleteResult = await fileClient.DeleteFileAsync(trainFile.Id);
Console.WriteLine($"Deleted training file: {trainFile.Id} (deleted: {trainDeleteResult.Value.Deleted})");

ClientResult<FileDeletionResult> validationDeleteResult = await fileClient.DeleteFileAsync(validationFile.Id);
Console.WriteLine($"Deleted validation file: {validationFile.Id} (deleted: {validationDeleteResult.Value.Deleted})");
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_CleanupFiles
// Clean up files
ClientResult<FileDeletionResult> trainDeleteResult = fileClient.DeleteFile(trainFile.Id);
Console.WriteLine($"Deleted training file: {trainFile.Id} (deleted: {trainDeleteResult.Value.Deleted})");

ClientResult<FileDeletionResult> validationDeleteResult = fileClient.DeleteFile(validationFile.Id);
Console.WriteLine($"Deleted validation file: {validationFile.Id} (deleted: {validationDeleteResult.Value.Deleted})");
```

## Deploy Model

Once a fine-tuning job succeeds, you need to deploy the resulting model before it can be used for inference. Deployment is done through Azure Resource Manager using the `Azure.ResourceManager.CognitiveServices` package. The deployment creates an endpoint where you can send inference requests to your fine-tuned model.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_DeployModelAsync
// Get the completed fine-tuning job
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
FineTuningClient fineTuningClient = projectClient.OpenAI.GetFineTuningClient();

FineTuningJob completedJob = await fineTuningClient.GetJobAsync("your-completed-job-id");

// Configure deployment
string deploymentName = $"ft-deployment-{completedJob.BaseModel}-{DateTimeOffset.UtcNow:yyyy-MM-dd}";
string fineTunedModelName = completedJob.Value; // The fine-tuned model identifier

Console.WriteLine($"Deploying model '{fineTunedModelName}' as '{deploymentName}'...");

// Create ARM client
var credential = new DefaultAzureCredential();
var armClient = new ArmClient(credential);

// Get Cognitive Services account
string subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");
string resourceGroupName = Environment.GetEnvironmentVariable("AZURE_RESOURCE_GROUP");
string accountName = Environment.GetEnvironmentVariable("AZURE_ACCOUNT_NAME");

var resourceId = CognitiveServicesAccountResource.CreateResourceIdentifier(
    subscriptionId,
    resourceGroupName,
    accountName);
var accountResource = armClient.GetCognitiveServicesAccountResource(resourceId);

// Deploy the model
var deploymentData = new CognitiveServicesAccountDeploymentData
{
    Properties = new CognitiveServicesAccountDeploymentProperties
    {
        Model = new CognitiveServicesAccountDeploymentModel
        {
            Format = "OpenAI",
            Name = fineTunedModelName,
            Version = "1"
        }
    },
    Sku = new CognitiveServicesSku("GlobalStandard") { Capacity = 50 }
};

var deploymentOperation = await accountResource.GetCognitiveServicesAccountDeployments()
    .CreateOrUpdateAsync(Azure.WaitUntil.Completed, deploymentName, deploymentData);

Console.WriteLine($"Deployment '{deploymentName}' completed successfully");
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_DeployModel
// Get the completed fine-tuning job
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
FineTuningClient fineTuningClient = projectClient.OpenAI.GetFineTuningClient();

FineTuningJob completedJob = fineTuningClient.GetJob("your-completed-job-id");

// Configure deployment
string deploymentName = $"ft-deployment-{completedJob.BaseModel}-{DateTimeOffset.UtcNow:yyyy-MM-dd}";
string fineTunedModelName = completedJob.Value; // The fine-tuned model identifier

Console.WriteLine($"Deploying model '{fineTunedModelName}' as '{deploymentName}'...");

// Create ARM client
var credential = new DefaultAzureCredential();
var armClient = new ArmClient(credential);

// Get Cognitive Services account
string subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");
string resourceGroupName = Environment.GetEnvironmentVariable("AZURE_RESOURCE_GROUP");
string accountName = Environment.GetEnvironmentVariable("AZURE_ACCOUNT_NAME");

var resourceId = CognitiveServicesAccountResource.CreateResourceIdentifier(
    subscriptionId,
    resourceGroupName,
    accountName);
var accountResource = armClient.GetCognitiveServicesAccountResource(resourceId);

// Deploy the model
var deploymentData = new CognitiveServicesAccountDeploymentData
{
    Properties = new CognitiveServicesAccountDeploymentProperties
    {
        Model = new CognitiveServicesAccountDeploymentModel
        {
            Format = "OpenAI",
            Name = fineTunedModelName,
            Version = "1"
        }
    },
    Sku = new CognitiveServicesSku("GlobalStandard") { Capacity = 50 }
};

var deploymentOperation = accountResource.GetCognitiveServicesAccountDeployments()
    .CreateOrUpdate(Azure.WaitUntil.Completed, deploymentName, deploymentData);

Console.WriteLine($"Deployment '{deploymentName}' completed successfully");
```

## Inference with Fine-Tuned Model

After deploying your fine-tuned model, you can use it for inference. The `GetProjectResponsesClientForModel` method creates a client configured for your specific deployment. You can then send prompts and receive responses from your customized model, which should reflect the patterns learned from your training data.

### Asynchronous

```C# Snippet:AI_Projects_FineTuning_InferenceAsync
// Get the deployed fine-tuned model
string deploymentName = "your-deployment-name";

var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

// Get responses client for the specific deployment
var responsesClient = projectClient.OpenAI.GetProjectResponsesClientForModel(deploymentName);

// Perform inference
string prompt = "What is the capital of France?";
Console.WriteLine($"Sending prompt: {prompt}");

ClientResult<ResponseResult> result = await responsesClient.CreateResponseAsync(prompt);

// Get the response message
var messageItem = result.Value.OutputItems
    .OfType<MessageResponseItem>()
    .LastOrDefault();

Console.WriteLine($"Response: {messageItem.Content[0].Text}");
```

### Synchronous

```C# Snippet:AI_Projects_FineTuning_Inference
// Get the deployed fine-tuned model
string deploymentName = "your-deployment-name";

var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

// Get responses client for the specific deployment
var responsesClient = projectClient.OpenAI.GetProjectResponsesClientForModel(deploymentName);

// Perform inference
string prompt = "What is the capital of France?";
Console.WriteLine($"Sending prompt: {prompt}");

ClientResult<ResponseResult> result = responsesClient.CreateResponse(prompt);

// Get the response message
var messageItem = result.Value.OutputItems
    .OfType<MessageResponseItem>()
    .LastOrDefault();

Console.WriteLine($"Response: {messageItem.Content[0].Text}");
```
