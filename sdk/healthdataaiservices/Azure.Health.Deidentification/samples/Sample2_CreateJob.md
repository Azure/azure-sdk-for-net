# Realtime Deidentification

This sample demonstrates how to create a job which will deidentify all files within a blob storage container filtering via a prefix.

## Create Job and Check Status

```C# Snippet:AzHealthDeidSample2_CreateJob
DeidentificationJob job = new()
{
    SourceLocation = new SourceStorageLocation(new Uri(storageAccountUrl), "example_patient_1/"),
    TargetLocation = new TargetStorageLocation(new Uri(storageAccountUrl), "output_folder1/") { Overwrite = true },
    OperationType = DeidentificationOperationType.Redact,
};

job = client.DeidentifyDocuments(WaitUntil.Started, jobName, job).Value;
Console.WriteLine($"Job status: {job.Status}"); // Job status: NotStarted
```
