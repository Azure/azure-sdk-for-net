````markdown
# Sample using Azure OpenAI Fine-Tuning with Azure.AI.Projects

This sample demonstrates how to use Azure OpenAI fine-tuning capabilities through Azure.AI.Projects. It covers three training methods:
1. **Supervised Learning** - Traditional fine-tuning with input-output pairs
2. **Direct Preference Optimization (DPO)** - Fine-tuning with preferred/rejected response pairs
3. **Reinforcement Learning** - Fine-tuning with a grader model for reward-based training

## Prerequisites

- Install the Azure.AI.Projects and Azure.AI.OpenAI packages.
- Set the following environment variable:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
- Prepare your training data files in JSONL format.

## Training Data Format

### Supervised Learning
```jsonl
{"messages": [{"role": "system", "content": "You are a helpful assistant."}, {"role": "user", "content": "What is Azure?"}, {"role": "assistant", "content": "Azure is Microsoft's cloud platform."}]}
```

### Direct Preference Optimization (DPO)
```jsonl
{"messages": [{"role": "user", "content": "Explain quantum computing"}], "chosen": "Quantum computing uses quantum mechanics...", "rejected": "Quantum is just fast computers."}
```

### Reinforcement Learning
```jsonl
{"messages": [{"role": "user", "content": "Count down from 10"}, {"role": "assistant", "content": "10, 9, 8, 7, 6, 5, 4, 3, 2, 1"}]}
```

## Scenario 1: Supervised Learning Fine-Tuning

This is the most common fine-tuning approach, suitable for training models on task-specific data.

```C# Snippet:AI_Projects_FineTuningSupervisedAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var credential = new DefaultAzureCredential();
var projectClient = new AIProjectClient(new Uri(endpoint), credential);

// Get Azure OpenAI connection
var connection = projectClient.GetConnection(typeof(AzureOpenAIClient).FullName!);
if (!connection.TryGetLocatorAsUri(out Uri uri) || uri is null)
{
    throw new InvalidOperationException("Invalid URI from connection.");
}
uri = new Uri($"https://{uri.Host}");

// Create clients
var azureOpenAIClient = new AzureOpenAIClient(uri, credential);
var fineTuningClient = azureOpenAIClient.GetFineTuningClient();
var fileClient = azureOpenAIClient.GetOpenAIFileClient();

// Step 1: Upload training and validation files
Console.WriteLine("Uploading training file...");
OpenAIFile trainingFile = await fileClient.UploadFileAsync(
    BinaryData.FromBytes(File.ReadAllBytes("training_set.jsonl")),
    "training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"✅ Training file uploaded: {trainingFile.Id}");

Console.WriteLine("Uploading validation file...");
OpenAIFile validationFile = await fileClient.UploadFileAsync(
    BinaryData.FromBytes(File.ReadAllBytes("validation_set.jsonl")),
    "validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"✅ Validation file uploaded: {validationFile.Id}");

// Wait for file import
await Task.Delay(5000);

// Step 2: Create fine-tuning job with Supervised Learning
Console.WriteLine("Creating fine-tuning job...");
FineTuningJob createdJob = await fineTuningClient.FineTuneAsync(
    "gpt-4o-mini-2024-07-18",
    trainingFile.Id,
    waitUntilCompleted: false,
    new() 
    { 
        TrainingMethod = FineTuningTrainingMethod.CreateSupervised(
            epochCount: 3,
            batchSize: 4,
            learningRate: 0.0001),
        ValidationFile = validationFile.Id
    });
Console.WriteLine($"✅ Job created! Job ID: {createdJob.JobId}, Status: {createdJob.Status}");

// Step 3: Get the job by ID
FineTuningJob retrievedJob = await fineTuningClient.GetJobAsync(createdJob.JobId);
Console.WriteLine($"✅ Job retrieved: {retrievedJob.JobId}, Status: {retrievedJob.Status}");

// Step 4: List all jobs
Console.WriteLine("Listing all jobs...");
int jobCount = 0;
await foreach (FineTuningJob job in fineTuningClient.GetJobsAsync(options: new() { PageSize = 5 }))
{
    Console.WriteLine($"- Job ID: {job.JobId}, Status: {job.Status}");
    if (++jobCount >= 5) break;
}

// Step 5: List checkpoints (only available after job completes)
if (retrievedJob.Status == FineTuningStatus.Succeeded)
{
    Console.WriteLine("Listing checkpoints...");
    int checkpointCount = 0;
    await foreach (FineTuningCheckpoint checkpoint in retrievedJob.GetCheckpointsAsync())
    {
        Console.WriteLine($"Checkpoint {++checkpointCount}: ID={checkpoint.Id}, Step={checkpoint.StepNumber}");
        if (checkpointCount >= 5) break;
    }
}

// Step 6: List events
Console.WriteLine("Listing events...");
int eventCount = 0;
await foreach (FineTuningEvent evt in retrievedJob.GetEventsAsync(new GetEventsOptions() { PageSize = 10 }))
{
    Console.WriteLine($"Event {++eventCount}: {evt.Level} - {evt.Message}");
    if (eventCount >= 5) break;
}

// Step 7: Cancel the job (if needed)
Console.WriteLine("Cancelling job...");
FineTuningJob jobToCancel = await fineTuningClient.GetJobAsync(createdJob.JobId);
await jobToCancel.CancelAndUpdateAsync();
Console.WriteLine($"✅ Job cancelled! Status: {jobToCancel.Status}");
```

## Scenario 2: Direct Preference Optimization (DPO)

DPO is useful for training models to prefer certain responses over others, particularly for alignment and safety.

```C# Snippet:AI_Projects_FineTuningDPOAsync
// Assuming trainingFile and validationFile are already uploaded
// and fineTuningClient is already created (see Scenario 1)

// Create fine-tuning job with DPO
Console.WriteLine("Creating DPO fine-tuning job...");
FineTuningJob createdJob = await fineTuningClient.FineTuneAsync(
    "gpt-4o-2024-08-06",
    trainingFile.Id,
    waitUntilCompleted: false,
    new() 
    { 
        TrainingMethod = FineTuningTrainingMethod.CreateDirectPreferenceOptimization(
            epochCount: 3,
            batchSize: 4,
            learningRate: 0.0001),
        ValidationFile = validationFile.Id
    });
Console.WriteLine($"✅ DPO job created! Job ID: {createdJob.JobId}, Status: {createdJob.Status}");

// Monitor job status
FineTuningJob retrievedJob = await fineTuningClient.GetJobAsync(createdJob.JobId);
Console.WriteLine($"✅ Job retrieved: {retrievedJob.JobId}, Status: {retrievedJob.Status}");

// List events to track progress
await foreach (FineTuningEvent evt in retrievedJob.GetEventsAsync(new GetEventsOptions() { PageSize = 10 }))
{
    Console.WriteLine($"{evt.Level}: {evt.Message}");
}
```

## Scenario 3: Reinforcement Learning Fine-Tuning

Reinforcement Learning uses a grader model to evaluate responses and provide rewards for training. This is an advanced technique for optimizing models based on quality metrics.

```C# Snippet:AI_Projects_FineTuningRLAsync
// Assuming trainingFile and validationFile are already uploaded
// and fineTuningClient is already created (see Scenario 1)

// Build RL configuration using protocol method
var requestJson = new
{
    model = "o4-mini",
    training_file = trainingFile.Id,
    validation_file = validationFile.Id,
    method = new
    {
        type = "reinforcement",
        reinforcement = new
        {
            grader = new
            {
                type = "score_model",
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

// Serialize and create job
string jsonString = JsonSerializer.Serialize(requestJson);
BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonString));

Console.WriteLine("Creating RL fine-tuning job...");
FineTuningJob createdJob = await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);
Console.WriteLine($"✅ RL job created! Job ID: {createdJob.JobId}, Status: {createdJob.Status}");

// Monitor the job
FineTuningJob retrievedJob = await fineTuningClient.GetJobAsync(createdJob.JobId);
Console.WriteLine($"Job Status: {retrievedJob.Status}");

// List events
await foreach (FineTuningEvent evt in retrievedJob.GetEventsAsync(new GetEventsOptions() { PageSize = 10 }))
{
    Console.WriteLine($"{evt.Level}: {evt.Message}");
}
```

## Job Management Operations

### Wait for Job Completion

```C# Snippet:AI_Projects_FineTuningWaitForCompletion
// Poll until job completes
FineTuningJob job = await fineTuningClient.GetJobAsync(jobId);
while (job.Status == FineTuningStatus.Running || 
       job.Status == FineTuningStatus.Pending ||
       job.Status == FineTuningStatus.Validating)
{
    await Task.Delay(TimeSpan.FromSeconds(30));
    job = await fineTuningClient.GetJobAsync(jobId);
    Console.WriteLine($"Job Status: {job.Status}");
}

if (job.Status == FineTuningStatus.Succeeded)
{
    Console.WriteLine($"✅ Fine-tuning completed! Fine-tuned model: {job.FineTunedModel}");
}
else if (job.Status == FineTuningStatus.Failed)
{
    Console.WriteLine($"❌ Fine-tuning failed: {job.Error?.Message}");
}
```

### Cancel a Running Job

```C# Snippet:AI_Projects_FineTuningCancelJob
// Cancel a job if needed
FineTuningJob jobToCancel = await fineTuningClient.GetJobAsync(jobId);
await jobToCancel.CancelAndUpdateAsync();
Console.WriteLine($"Job cancelled. New status: {jobToCancel.Status}");
```

### List All Fine-Tuning Jobs

```C# Snippet:AI_Projects_FineTuningListJobs
// List all fine-tuning jobs with pagination
Console.WriteLine("All Fine-Tuning Jobs:");
await foreach (FineTuningJob job in fineTuningClient.GetJobsAsync(options: new() { PageSize = 10 }))
{
    Console.WriteLine($"- Job ID: {job.JobId}");
    Console.WriteLine($"  Model: {job.Model}");
    Console.WriteLine($"  Status: {job.Status}");
    Console.WriteLine($"  Created: {job.CreatedAt}");
    if (job.FineTunedModel != null)
    {
        Console.WriteLine($"  Fine-tuned Model: {job.FineTunedModel}");
    }
    Console.WriteLine();
}
```

### Monitor Job Events

```C# Snippet:AI_Projects_FineTuningMonitorEvents
// Stream job events for detailed progress
FineTuningJob job = await fineTuningClient.GetJobAsync(jobId);
Console.WriteLine("Job Events:");
await foreach (FineTuningEvent evt in job.GetEventsAsync())
{
    Console.WriteLine($"[{evt.CreatedAt}] {evt.Level}: {evt.Message}");
}
```

### Access Checkpoints

```C# Snippet:AI_Projects_FineTuningListCheckpoints
// List checkpoints after job completion
FineTuningJob completedJob = await fineTuningClient.GetJobAsync(jobId);
if (completedJob.Status == FineTuningStatus.Succeeded)
{
    Console.WriteLine("Checkpoints:");
    await foreach (FineTuningCheckpoint checkpoint in completedJob.GetCheckpointsAsync())
    {
        Console.WriteLine($"- Checkpoint ID: {checkpoint.Id}");
        Console.WriteLine($"  Step Number: {checkpoint.StepNumber}");
        Console.WriteLine($"  Metrics: {checkpoint.Metrics}");
        Console.WriteLine($"  Fine-tuned Model: {checkpoint.FineTunedModelCheckpoint}");
    }
}
```

````
