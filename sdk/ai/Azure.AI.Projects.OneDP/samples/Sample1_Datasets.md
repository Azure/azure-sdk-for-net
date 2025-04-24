# Sample using Datasets in Azure.AI.Projects.OneDP

In this example, we will demonstrate how to upload files and folders to create new dataset versions, list and retrieve dataset versions, and delete them.

## Prerequisites

- Install the Azure.AI.Projects.OneDP package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `DATASET_NAME`: The name of the dataset to retrieve.

## Synchronous sample:
```C# Snippet:DatasetsExampleSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Datasets datasets = projectClient.GetDatasetsClient();

Console.WriteLine("Uploading a single file to create Dataset version '1'...");
var dataset = datasets.UploadFileAndCreate(
    name: datasetName,
    version: "1",
    filePath: "sample_folder/sample_file1.txt"
    );
Console.WriteLine(dataset);

Console.WriteLine("Uploading folder to create Dataset version '2'...");
dataset = datasets.UploadFolderAndCreate(
    name: datasetName,
    version: "2",
    folderPath: "sample_folder"
);
Console.WriteLine(dataset.DatasetUri);

Console.WriteLine("Retrieving Dataset version '1'...");
dataset = datasets.GetVersion(datasetName, "1");
Console.WriteLine(dataset.DatasetUri);

Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
foreach (var ds in datasets.GetVersions(datasetName))
{
    Console.WriteLine(ds.DatasetUri);
}

Console.WriteLine("Retrieving Dataset version '1' credentials...");
var credentials = datasets.GetCredentials(datasetName, "1", new GetCredentialsRequest());
Console.WriteLine(credentials);

Console.WriteLine("Deleting Dataset versions '1' and '2'...");
datasets.DeleteVersion(datasetName, "1");
datasets.DeleteVersion(datasetName, "2");
```


## Asynchronous sample:
```C# Snippet:DatasetsExampleAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Datasets datasets = projectClient.GetDatasetsClient();

Console.WriteLine("Uploading a single file to create Dataset version '1'...");
var dataset = datasets.UploadFileAndCreate(
    name: datasetName,
    version: "1",
    filePath: "sample_folder/sample_file1.txt"
    );
Console.WriteLine(dataset);

Console.WriteLine("Uploading folder to create Dataset version '2'...");
dataset = datasets.UploadFolderAndCreate(
    name: datasetName,
    version: "2",
    folderPath: "sample_folder"
);
Console.WriteLine(dataset.DatasetUri);

Console.WriteLine("Retrieving Dataset version '1'...");
dataset = await datasets.GetVersionAsync(datasetName, "1");
Console.WriteLine(dataset.DatasetUri);

Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
await foreach (var ds in datasets.GetVersionsAsync(datasetName))
{
    Console.WriteLine(ds.DatasetUri);
}

Console.WriteLine("Retrieving Dataset version '1' credentials...");
var credentials = await datasets.GetCredentialsAsync(datasetName, "1", new GetCredentialsRequest());
Console.WriteLine(credentials);

Console.WriteLine("Deleting Dataset versions '1' and '2'...");
await datasets.DeleteVersionAsync(datasetName, "1");
await datasets.DeleteVersionAsync(datasetName, "2");
```
