# Using Datasets to create a Vector Store

This sample demonstrates how to make use of datasets to create a Vector Store, to be used as an Agent tool.

## Prerequisites

- Install the Azure.AI.Projects and Azure.AI.Agents.Persistent package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the deployment to retrieve.

## Execution

Start by initializing the necessary local variables based on preset environment variables, and initialize the `AIProjectClient`.

```C# Snippet:AI_Projects_VectorStoreWithDatasetsInitializeProjectClient
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
var datasetVersion = System.Environment.GetEnvironmentVariable("DATASET_VERSION");
var filePath = System.Environment.GetEnvironmentVariable("SAMPLE_FILE_PATH");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");

AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
```

Using the default Connection to Azure Blob Storage, upload a local file to storage, and register it as a Dataset within the Project.

```C# Snippet:AI_Projects_VectorStoreWithDatasetsDatasetCreation
Console.WriteLine("Retrieve the default Azure Storage Account connection to use when creating a dataset");
AIProjectConnection storageConnection = projectClient.Connections.GetDefaultConnection(ConnectionType.AzureStorageAccount);

Console.WriteLine($"Uploading a file to create Dataset with name {datasetName} and version {datasetVersion}:");
FileDataset fileDataset = projectClient.Datasets.UploadFile(
    name: datasetName,
    version: datasetVersion,
    filePath: filePath,
    connectionName: storageConnection.Name
);
```

Finally, using the created dataset, we can initialize the Agent client, the Vector Store source, and create the vector store using the Agent client. Lastly, create the Agent with a File Search tool backed by the created Vector Store.

```C# Snippet:AI_Projects_VectorStoreWithDatasetsCreateVectorStoreAndAgent
PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();

Console.WriteLine("Initialize the vector store source using the created dataset");
VectorStoreDataSource vectorStoreDataSource = new VectorStoreDataSource(assetIdentifier: fileDataset.Id, assetType: VectorStoreDataSourceAssetType.UriAsset);

Console.WriteLine("Call to create the vector store in the service");
PersistentAgentsVectorStore vectorStore = agentsClient.VectorStores.CreateVectorStore(
    name: "MyVectorStore",
    storeConfiguration: new VectorStoreConfiguration(
        dataSources: [vectorStoreDataSource]
    )
);

FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

Console.WriteLine("Create agent with file search tool backed by the created vector store");
PersistentAgent agent = agentsClient.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "my-agent",
    instructions: "You are helpful agent.",
    tools: [new FileSearchToolDefinition()],
    toolResources: new ToolResources() { FileSearch = fileSearchResource }
);
```
