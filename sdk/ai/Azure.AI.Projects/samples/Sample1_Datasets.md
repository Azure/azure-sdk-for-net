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

AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {datasetVersion1}:");
FileDataset fileDataset = projectClient.Datasets.UploadFile(
    name: datasetName,
    version: datasetVersion1,
    filePath: filePath,
    connectionName: connectionName
    );
Console.WriteLine(fileDataset);

Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion2}:");
FolderDataset folderDataset = projectClient.Datasets.UploadFolder(
    name: datasetName,
    version: datasetVersion2,
    folderPath: folderPath,
    connectionName: connectionName,
    filePattern: new Regex(".*\\.txt")
);
Console.WriteLine(folderDataset);

Console.WriteLine($"Retrieving Dataset version {datasetVersion1}:");
AIProjectDataset dataset = projectClient.Datasets.GetDataset(datasetName, datasetVersion1);
Console.WriteLine(dataset.Id);

Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
DatasetCredential credentials = projectClient.Datasets.GetCredentials(datasetName, datasetVersion1);
Console.WriteLine(credentials);

Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasetVersions(datasetName))
{
    Console.WriteLine(ds);
    Console.WriteLine(ds.Version);
}

Console.WriteLine($"Listing latest versions for all datasets:");
foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasets())
{
    Console.WriteLine($"{ds.Name}, {ds.Version}, {ds.Id}");
}

Console.WriteLine($"Deleting Dataset versions {datasetVersion1} and {datasetVersion2}:");
projectClient.Datasets.Delete(datasetName, datasetVersion1);

projectClient.Datasets.Delete(datasetName, datasetVersion2);
```


## Asynchronous sample:
```C# Snippet:AI_Projects_DatasetsExampleAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME");
var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
var datasetVersion1 = System.Environment.GetEnvironmentVariable("DATASET_VERSION_1") ?? "1.0";
var datasetVersion2 = System.Environment.GetEnvironmentVariable("DATASET_VERSION_2") ?? "2.0";
var filePath = System.Environment.GetEnvironmentVariable("SAMPLE_FILE_PATH") ?? "sample_folder/sample_file1.txt";
var folderPath = System.Environment.GetEnvironmentVariable("SAMPLE_FOLDER_PATH") ?? "sample_folder";

AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {datasetVersion1}:");
FileDataset fileDataset = await projectClient.Datasets.UploadFileAsync(
    name: datasetName,
    version: datasetVersion1,
    filePath: filePath,
    connectionName: connectionName
    );
Console.WriteLine(fileDataset);

Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion2}:");
FolderDataset folderDataset = await projectClient.Datasets.UploadFolderAsync(
    name: datasetName,
    version: datasetVersion2,
    folderPath: folderPath,
    connectionName: connectionName,
    filePattern: new Regex(".*\\.txt")
);
Console.WriteLine(folderDataset);

Console.WriteLine($"Retrieving Dataset version {datasetVersion1}:");
AIProjectDataset dataset = await projectClient.Datasets.GetDatasetAsync(datasetName, datasetVersion1);
Console.WriteLine(dataset.Id);

Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
DatasetCredential credentials = await projectClient.Datasets.GetCredentialsAsync(datasetName, datasetVersion1);
Console.WriteLine(credentials);

Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
await foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasetVersionsAsync(datasetName))
{
    Console.WriteLine(ds);
    Console.WriteLine(ds.Version);
}

Console.WriteLine($"Listing latest versions for all datasets:");
await foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasetsAsync())
{
    Console.WriteLine($"{ds.Name}, {ds.Version}, {ds.Id}");
}

Console.WriteLine($"Deleting Dataset versions {datasetVersion1} and {datasetVersion2}:");
await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion1);

await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion2);
```
