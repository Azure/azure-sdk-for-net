# Sample for data generation in Azure.AI.Projects.

In this example we will demonstrate how the data can be generated using `DataGenerationJobs` client in `Azure.AI.Projects`.

1. First, we need to create clients and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClients_DataGenerationJob
string endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
```

2. In our scenario, we will generate 16 questions and answer pairs based on the provided prompt and will save them into the data set named "dataset-generation-eval-sample".

```C# Snippet:Sample_UploadFile_DataGenerationJob
DataGenerationJobOutputOptions outputOptions = new()
{
    Name = "dataset-generation-eval-sample",
    Description = "QnA pairs generated from the Contoso refund policy prompt.",
};
outputOptions.Tags["sample"] = "dataset-generation-with-evaluation";
DataGenerationJob job = new()
{
    Inputs = new DataGenerationJobInputs(
        name: "sampleGeneration",
        sources: [new PromptDataGenerationJobSource(prompt: "Contoso offers a full refund within 30 days of purchase for any product " +
                "returned in its original condition. After 30 days, store credit may be " +
                "issued at the discretion of customer support. Digital goods are " +
                "non-refundable once downloaded."){
            Description = "Contoso refund policy"
        }],
        options: new SimpleQnADataGenerationJobOptions(maxSamples: 16)
        {
            ModelOptions = new(modelDeploymentName)
        },
        scenario: DataGenerationJobScenario.Evaluation
    )
    {
        OutputOptions = outputOptions
    },
};
```

3. Start the data generation job.

Synchronous sample:
```C# Snippet:Sample_CreateJob_DataGenerationJob_Sync
DataGenerationJob runningJob = projectClient.DataGenerationJobs.CreateGenerationJob(job);
Console.WriteLine($"Created job ID: {runningJob.Id}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateJob_DataGenerationJob_Async
DataGenerationJob runningJob = await projectClient.DataGenerationJobs.CreateGenerationJobAsync(job);
Console.WriteLine($"Created job ID: {runningJob.Id}");
```

4. Wait for the job to arrive at a final state and print out data set ID and version.

Synchronous sample:
```C# Snippet:Sample_GetJob_DataGenerationJob_Sync
while (runningJob.Status != JobStatus.Failed && runningJob.Status != JobStatus.Succeeded)
{
    Thread.Sleep(500);
    Console.WriteLine($"Waiting for job ID: {runningJob.Id}...");
    runningJob = projectClient.DataGenerationJobs.GetGenerationJob(jobId: runningJob.Id);
}
if (runningJob.Status == JobStatus.Failed)
{
    throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
}
Console.WriteLine($"The job ID: {runningJob.Id} completed");
if (runningJob.Result.Outputs[0] is DatasetDataGenerationJobOutput dataOutput)
{
    Console.WriteLine($"Created the dataset {dataOutput.Name}, v. {dataOutput.Version}");
}
```

Asynchronous sample:
```C# Snippet:Sample_GetJob_DataGenerationJob_Async
while (runningJob.Status != JobStatus.Failed && runningJob.Status != JobStatus.Succeeded)
{
    await Task.Delay(500);
    Console.WriteLine($"Waiting for job ID: {runningJob.Id}...");
    runningJob = await projectClient.DataGenerationJobs.GetGenerationJobAsync(jobId: runningJob.Id);
}
if (runningJob.Status == JobStatus.Failed)
{
    throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
}
Console.WriteLine($"The job ID: {runningJob.Id} completed");
if (runningJob.Result.Outputs[0] is DatasetDataGenerationJobOutput dataOutput)
{
    Console.WriteLine($"Created the dataset {dataOutput.Name}, v. {dataOutput.Version}");
}
```

5. The job also can be cancelled as it is demonstrated below.

Synchronous sample:
```C# Snippet:Sample_CancelingJob_DataGenerationJob_Sync
outputOptions = new()
{
    Name = "another-dataset",
    Description = "QnA pairs generated from the Contoso refund policy prompt.",
};
job = new()
{
    Inputs = new DataGenerationJobInputs(
        name: "sampleGeneration",
        sources: [new PromptDataGenerationJobSource(prompt: "Zawa offers a full refund within 130 days of purchase for any product " +
                "returned in its original condition. After 30 days, store credit may be " +
                "issued at the discretion of customer support."){
            Description = "Zawa refund policy"
        }],
        options: new SimpleQnADataGenerationJobOptions(maxSamples: 1000)
        {
            ModelOptions = new(modelDeploymentName)
        },
        scenario: DataGenerationJobScenario.Evaluation
    )
    {
        OutputOptions = outputOptions
    },
};
DataGenerationJob jobToCancel = projectClient.DataGenerationJobs.CreateGenerationJob(job);
jobToCancel = projectClient.DataGenerationJobs.CancelGenerationJob(jobToCancel.Id);
while (jobToCancel.Status != JobStatus.Failed && jobToCancel.Status != JobStatus.Succeeded && jobToCancel.Status != JobStatus.Cancelled)
{
    Thread.Sleep(500);
    Console.WriteLine($"Waiting for job {jobToCancel.Id} to cancel...");
    jobToCancel = projectClient.DataGenerationJobs.GetGenerationJob(jobId: jobToCancel.Id);
}
if (jobToCancel.Status != JobStatus.Cancelled)
{
    throw new InvalidOperationException($"The job {jobToCancel.Id} has failed.");
}
Console.WriteLine($"The job {jobToCancel.Id} was canceled.");
```

Asynchronous sample:
```C# Snippet:Sample_CancelingJob_DataGenerationJob_Async
outputOptions = new()
{
    Name = "another-dataset",
    Description = "QnA pairs generated from the Contoso refund policy prompt.",
};
job = new()
{
    Inputs = new DataGenerationJobInputs(
        name: "sampleGeneration",
        sources: [new PromptDataGenerationJobSource(prompt: "Zawa offers a full refund within 130 days of purchase for any product " +
                "returned in its original condition. After 30 days, store credit may be " +
                "issued at the discretion of customer support."){
            Description = "Zawa refund policy"
        }],
        options: new SimpleQnADataGenerationJobOptions(maxSamples: 1000)
        {
            ModelOptions = new(modelDeploymentName)
        },
        scenario: DataGenerationJobScenario.Evaluation
    )
    {
        OutputOptions = outputOptions
    },
};
DataGenerationJob jobToCancel = await projectClient.DataGenerationJobs.CreateGenerationJobAsync(job);
jobToCancel = await projectClient.DataGenerationJobs.CancelGenerationJobAsync(jobToCancel.Id);
while (jobToCancel.Status != JobStatus.Failed && jobToCancel.Status != JobStatus.Succeeded && jobToCancel.Status != JobStatus.Cancelled)
{
    await Task.Delay(500);
    Console.WriteLine($"Waiting for job {jobToCancel.Id} to cancel...");
    jobToCancel = await projectClient.DataGenerationJobs.GetGenerationJobAsync(jobId: jobToCancel.Id);
}
if (jobToCancel.Status != JobStatus.Cancelled)
{
    throw new InvalidOperationException($"The job {jobToCancel.Id} has failed.");
}
Console.WriteLine($"The job {jobToCancel.Id} was canceled.");
```

6. List data generation jobs.

Synchronous sample:
```C# Snippet:Sample_ListJob_DataGenerationJob_Sync
foreach (DataGenerationJob oneJob in projectClient.DataGenerationJobs.GetGenerationJobs())
{
    Console.WriteLine($"Job ID: {oneJob.Id}, Status: {oneJob.Status}.");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListJob_DataGenerationJob_Async
await foreach (DataGenerationJob oneJob in projectClient.DataGenerationJobs.GetGenerationJobsAsync())
{
    Console.WriteLine($"Job ID: {oneJob.Id}, Status: {oneJob.Status}.");
}
```

7. Finally, delete the jobs we have created.

Synchronous sample:
```C# Snippet:Sample_DeleteJob_DataGenerationJob_Sync
projectClient.DataGenerationJobs.DeleteGenerationJob(jobId: runningJob.Id);
projectClient.DataGenerationJobs.DeleteGenerationJob(jobId: jobToCancel.Id);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteJob_DataGenerationJob_Async
await projectClient.DataGenerationJobs.DeleteGenerationJobAsync(jobId: runningJob.Id);
await projectClient.DataGenerationJobs.DeleteGenerationJobAsync(jobId: jobToCancel.Id);
```
