# Sample using Datasets in Azure.AI.Projects

In this example, we will demonstrate how to upload files and folders to create new dataset versions, list and retrieve dataset versions, and delete them.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `CONNECTION_NAME`: The name of the Azure Storage Account connection to use for uploading files.
  - `DATASET_NAME`: The name of the dataset to create and retrieve.
  - `SAMPLE_FILE_PATH`: The file path where a data file for upload is located.
  - `SAMPLE_FOLDER_PATH`: The folder path where the data files for upload are located.
  - `DATASET_VERSION_1`: (Optional) The first version of the Dataset to create and use in this sample.
  - `DATASET_VERSION_2`: (Optional) The second version of the Dataset to create and use in this sample.

## Synchronous sample:
```C# Snippet:AI_Projects_DatasetsExampleSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME");
var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
var datasetVersion1 = System.Environment.GetEnvironmentVariable("DATASET_VERSION_1") ?? "1.0";
var datasetVersion2 = System.Environment.GetEnvironmentVariable("DATASET_VERSION_2") ?? "2.0";
var filePath = System.Environment.GetEnvironmentVariable("SAMPLE_FILE_PATH") ?? "sample_folder/sample_file1.txt";
var folderPath = System.Environment.GetEnvironmentVariable("SAMPLE_FOLDER_PATH") ?? "sample_folder";
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Datasets datasets = projectClient.GetDatasetsClient();

Console.WriteLine($"Uploading a single file to create Dataset version {datasetVersion1}:");
DatasetVersion dataset = datasets.UploadFile(
    name: datasetName,
    version: datasetVersion1,
    filePath: filePath,
    connectionName: connectionName
    );
Console.WriteLine(dataset);

Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion2}:");
dataset = datasets.UploadFolder(
    name: datasetName,
    version: datasetVersion2,
    folderPath: folderPath,
    connectionName: connectionName
);
Console.WriteLine(dataset);

Console.WriteLine($"Retrieving Dataset version {datasetVersion1}:");
dataset = datasets.GetDataset(datasetName, datasetVersion1);
Console.WriteLine(dataset);

Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
AssetCredentialResponse credentials = datasets.GetCredentials(datasetName, datasetVersion1);
Console.WriteLine(credentials);

Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
foreach (var ds in datasets.GetVersions(datasetName))
{
    Console.WriteLine(ds);
    Console.WriteLine(ds.Version);
}

Console.WriteLine($"Listing latest versions for all datasets:");
foreach (var ds in datasets.GetDatasetVersions())
{
    Console.WriteLine(ds);
}

Console.WriteLine($"Deleting Dataset versions {datasetVersion1} and {datasetVersion2}:");
datasets.Delete(datasetName, datasetVersion1);
datasets.Delete(datasetName, datasetVersion2);
```


## Asynchronous sample:
```C# Snippet:AI_Projects_DatasetsExampleAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
var datasetVersion1 = System.Environment.GetEnvironmentVariable("DATASET_VERSION_1") ?? "1.0";
var datasetVersion2 = System.Environment.GetEnvironmentVariable("DATASET_VERSION_2") ?? "2.0";
var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME");
var filePath = System.Environment.GetEnvironmentVariable("SAMPLE_FILE_PATH") ?? "sample_folder/sample_file1.txt";
var folderPath = System.Environment.GetEnvironmentVariable("SAMPLE_FOLDER_PATH") ?? "sample_folder";
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Datasets datasets = projectClient.GetDatasetsClient();

Console.WriteLine($"Uploading a single file to create Dataset version {datasetVersion1}...");
DatasetVersion dataset = await datasets.UploadFileAsync(
    name: datasetName,
    version: datasetVersion1,
    filePath: filePath,
    connectionName: connectionName
    );
Console.WriteLine(dataset);

Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion2}...");
dataset = await datasets.UploadFolderAsync(
    name: datasetName,
    version: datasetVersion2,
    folderPath: folderPath,
    connectionName: connectionName
);
Console.WriteLine(dataset);

Console.WriteLine($"Retrieving Dataset version {datasetVersion1}...");
dataset = await datasets.GetDatasetAsync(datasetName, datasetVersion1);
Console.WriteLine(dataset);

Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
AssetCredentialResponse credentials = await datasets.GetCredentialsAsync(datasetName, datasetVersion1);
Console.WriteLine(credentials);

Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
await foreach (var ds in datasets.GetVersionsAsync(datasetName))
{
    Console.WriteLine(ds.Version);
}

Console.WriteLine($"Listing latest versions for all datasets:");
await foreach (var ds in datasets.GetDatasetVersionsAsync())
{
    Console.WriteLine(ds);
}

Console.WriteLine($"Deleting Dataset versions {datasetVersion1} and {datasetVersion2}...");
await datasets.DeleteAsync(datasetName, datasetVersion1);
await datasets.DeleteAsync(datasetName, datasetVersion2);
```
