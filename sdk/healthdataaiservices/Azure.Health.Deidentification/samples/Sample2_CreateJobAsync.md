# Create and Run Job Async

This sample demonstrates how to create a job which will deidentify all files within a blob storage container filtering via a prefix.


## Create Job and Check Status

```C# Snippet:AzHealthDeidSample2Async_CreateJob
DeidentificationJob job = new()
{
    SourceLocation = new SourceStorageLocation(new Uri(storageAccountUrl), "folder1/"),
    TargetLocation = new TargetStorageLocation(new Uri(storageAccountUrl), "output_folder1/"),
    OperationType = DeidentificationOperationType.Redact,
};

job = (await client.DeidentifyDocumentsAsync(WaitUntil.Completed, "my-job-1", job)).Value;
Console.WriteLine($"Job Status: {job.Status}"); // Job Status: Completed
```
