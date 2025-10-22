# Sample using Datasets in Azure.AI.Projects

In this sample, we showcase some basic round trip handling for files with datasets, as well as general API usage.

## Dataset Round Trip Sample

### Round Trip Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `DATASET_NAME`: The name of the dataset to create and retrieve.
  - `SAMPLE_FILE_PATH`: The file path where a data file for upload is located.
  - `DATASET_VERSION`: (Optional) The first version of the Dataset to create and use in this sample.

### Usage

Start by instantiating expected environment variables, and the Project Client.

```C# Snippet:AI_Projects_DatasetRoundTripSample_ClientSetup
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
var datasetVersion = System.Environment.GetEnvironmentVariable("DATASET_VERSION") ?? "1.0";
var filePath = System.Environment.GetEnvironmentVariable("SAMPLE_FILE_PATH") ?? "sample_folder/sample_file1.txt";

AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
```

We can upload a local file to a named and versioned dataset, for use elsewhere in the system.

```C# Snippet:AI_Projects_DatasetRoundTripSample_DatasetCreation
Console.WriteLine("Retrieve the default Azure Storage Account connection to use when creating a dataset");
AIProjectConnection storageConnection = projectClient.Connections.GetDefaultConnection(ConnectionType.AzureStorageAccount);

Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {datasetVersion}:");
FileDataset fileDataset = projectClient.Datasets.UploadFile(
    name: datasetName,
    version: datasetVersion,
    filePath: filePath,
    connectionName: storageConnection.Name
    );
```

If at any time we want to retrieve the file associated with a dataset, we can get a sas credential associated with the specific dataset, and use that to instantiate the necessary storage clients to download the file back to our local machine.

```C# Snippet:AI_Projects_DatasetRoundTripSample_DatasetDownload
Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion}:");
DatasetCredential credentials = projectClient.Datasets.GetCredentials(datasetName, datasetVersion);

Console.WriteLine($"Using DatasetCredential to initialize Azure Storage client and download the file to local disk:");

// Get the blob URI and SAS URI from the dataset credentials
Uri blobUri = credentials.BlobReference.BlobUri;
Uri sasUri = credentials.BlobReference.Credential.SasUri;
Console.WriteLine($"Blob URI: {blobUri}");
Console.WriteLine($"SAS URI: {sasUri}");

// Create BlobContainerClient using the SAS URI
BlobContainerClient containerClient = new BlobContainerClient(sasUri);
Console.WriteLine($"Container client created successfully");

// Create BlobClient from the container client using the blob name from BlobUri
var blobUriBuilder = new UriBuilder(blobUri);
var blobPathParts = blobUriBuilder.Path.TrimStart('/').Split('/');
string blobName = string.Join("/", blobPathParts.Skip(1)); // Skip container name, get blob path

BlobClient blobClient = containerClient.GetBlobClient(blobName);
Console.WriteLine($"BlobClient created successfully for blob: {blobClient.Name}");

// Define local download path
string downloadFileName = $"downloaded_{blobClient.Name.Replace("/", "_")}";
string downloadPath = Path.Combine(Path.GetTempPath(), downloadFileName);
Console.WriteLine($"Downloading blob to: {downloadPath}");

// Download blob to local file
blobClient.DownloadTo(downloadPath);
Console.WriteLine($"Downloaded blob '{blobClient.Name}' to '{downloadPath}' - Size: {new FileInfo(downloadPath).Length} bytes");
```

## General API Usage

### General Sample Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `CONNECTION_NAME`: The name of the Azure Storage Account connection to use for uploading files.
  - `DATASET_NAME`: The name of the dataset to create and retrieve.
  - `SAMPLE_FILE_PATH`: The file path where a data file for upload is located.
  - `SAMPLE_FOLDER_PATH`: The folder path where the data files for upload are located.
  - `DATASET_VERSION_1`: (Optional) The first version of the Dataset to create and use in this sample.
  - `DATASET_VERSION_2`: (Optional) The second version of the Dataset to create and use in this sample.

### Synchronous sample

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

### Asynchronous sample

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
