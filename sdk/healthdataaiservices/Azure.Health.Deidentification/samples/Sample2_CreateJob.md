# Realtime Deidentification

This sample demonstrates how to create a `DeidentificationClient` and then create a job which will deidentify all files within a blob storage container filtering via a prefix.

## Create a DeidentificationClient

The service endpoint url can be pulled from the azure portal `Service Url`.

```C# Snippet:AzHealthDeidSample2_CreateDeidClient
DeidentificationClient client = new(
    new Uri(serviceEndpoint),
    credential,
    new DeidentificationClientOptions()
);
```

## Create Job and Check Status

```C# Snippet:AzHealthDeidSample2_CreateJob
DeidentificationJob job = new()
{
    SourceLocation = new SourceStorageLocation(new Uri(storageAccountUrl), "folder1/", new string[] { "*" }),
    TargetLocation = new TargetStorageLocation(new Uri(storageAccountUrl), "output_path"),
    DataType = DocumentDataType.PlainText,
    Operation = OperationType.Surrogate
};

job = client.CreateJob(WaitUntil.Started, "my-job-1", job).Value;
Console.WriteLine($"Job status: {job.Status}"); // Job status: NotStarted
```
