# Sample using Datasets in Azure.AI.Projects

In this example, we will demonstrate how to upload files and folders to create new dataset versions, list and retrieve dataset versions, and delete them.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `DATASET_NAME`: The name of the dataset to retrieve.

## Synchronous sample:
```C# Snippet:AI_Projects_DatasetsExampleSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Datasets datasets = projectClient.GetDatasetsClient();

Console.WriteLine("Uploading a single file to create Dataset version '1'...");
var datasetResponse = datasets.UploadFile(
    name: datasetName,
    version: "1",
    filePath: "sample_folder/sample_file1.txt"
    );
Console.WriteLine(datasetResponse);

Console.WriteLine("Uploading folder to create Dataset version '2'...");
datasetResponse = datasets.UploadFolder(
    name: datasetName,
    version: "2",
    folderPath: "sample_folder"
);
Console.WriteLine(datasetResponse);

Console.WriteLine("Retrieving Dataset version '1'...");
DatasetVersion dataset = datasets.GetDataset(datasetName, "1");
Console.WriteLine(dataset);

Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
foreach (var ds in datasets.GetVersions(datasetName))
{
    Console.WriteLine(ds);
}

Console.WriteLine($"Listing latest versions for all datasets:");
foreach (var ds in datasets.GetDatasetVersions())
{
    Console.WriteLine(ds);
}

Console.WriteLine("Deleting Dataset versions '1' and '2'...");
datasets.Delete(datasetName, "1");
datasets.Delete(datasetName, "2");
```


## Asynchronous sample:
```C# Snippet:AI_Projects_DatasetsExampleAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Datasets datasets = projectClient.GetDatasetsClient();

Console.WriteLine("Uploading a single file to create Dataset version '1'...");
var datasetResponse = datasets.UploadFile(
    name: datasetName,
    version: "1",
    filePath: "sample_folder/sample_file1.txt"
    );
Console.WriteLine(datasetResponse);

Console.WriteLine("Uploading folder to create Dataset version '2'...");
datasetResponse = datasets.UploadFolder(
    name: datasetName,
    version: "2",
    folderPath: "sample_folder"
);
Console.WriteLine(datasetResponse);

Console.WriteLine("Retrieving Dataset version '1'...");
DatasetVersion dataset = await datasets.GetDatasetAsync(datasetName, "1");
Console.WriteLine(dataset);

Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
await foreach (var ds in datasets.GetVersionsAsync(datasetName))
{
    Console.WriteLine(ds);
}

Console.WriteLine($"Listing latest versions for all datasets:");
await foreach (var ds in datasets.GetDatasetVersionsAsync())
{
    Console.WriteLine(ds);
}

Console.WriteLine("Deleting Dataset versions '1' and '2'...");
await datasets.DeleteAsync(datasetName, "1");
await datasets.DeleteAsync(datasetName, "2");
```
