# Azure AI Projects client library for .NET
The AI Projects client library is part of the Azure AI Foundry SDK and provides easy access to resources in your Azure AI Foundry Project. Use it to:

* **Create and run Classic Agents** using the `GetPersistentAgentsClient` method on the client.
* **Create Agents** using `Agents` property.
* **Enumerate AI Models** deployed to your Foundry Project using the `Deployments` operations.
* **Enumerate connected Azure resources** in your Foundry project using the `Connections` operations.
* **Upload documents and create Datasets** to reference them using the `Datasets` operations.
* **Create and enumerate Search Indexes** using the `Indexes` operations.

The client library uses version `v1` of the AI Foundry [data plane REST APIs](https://aka.ms/azsdk/azure-ai-projects/ga-rest-api-reference).

[Product documentation][product_doc]
| [Samples][samples]
| [API reference documentation][api_ref_docs]
| [Package (NuGet)][nuget]
| [SDK source code][source_code]

## Table of contents

- [Getting started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Install the package](#install-the-package)
- [Key concepts](#key-concepts)
  - [Create and authenticate the client](#create-and-authenticate-the-client)
- [Examples](#examples)
  - [Performing Classic Agent operations](#performing-classic-agent-operations)
  - [Performing Agent operations](#performing-agent-operations)
  - [Get an authenticated AzureOpenAI client](#get-an-authenticated-azureopenai-client)
  - [Get an authenticated ChatCompletionsClient](#get-an-authenticated-chatcompletionsclient)
  - [Deployments operations](#deployments-operations)
  - [Connections operations](#connections-operations)
  - [Dataset operations](#dataset-operations)
  - [Indexes operations](#indexes-operations)
  - [Files operations](#files-operations)
  - [Fine-Tuning operations](#fine-tuning-operations)
  - [Memory store operations](#memory-store-operations)
  - [Evaluations](#evalustions)
    - [Basic evaluations sample](#basic-evaluations-sample)
    - [Using uploaded datasets](#using-uploaded-datasets)
    - [Using custom prompt-based evaluator](#using-custom-prompt-based-evaluator)
    - [Using custom code-based evaluator](#using-custom-code-based-evaluator)
- [Troubleshooting](#troubleshooting)
- [Next steps](#next-steps)
- [Contributing](#contributing)

## Getting started

### Prerequisites

To use Azure AI Projects capabilities, you must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/). This will allow you to create an Azure AI resource and get a connection URL.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.Projects --prerelease
```

### Authenticate the client

A secure, keyless authentication approach is to use Microsoft Entra ID (formerly Azure Active Directory) via the [Azure Identity library][azure_identity]. To use this library, you need to install the [Azure.Identity package](https://www.nuget.org/packages/Azure.Identity):

```dotnetcli
dotnet add package Azure.Identity
```

## Key concepts

### Create and authenticate the client

To interact with Azure AI Projects, you’ll need to create an instance of `AIProjectClient`. Use the appropriate credential type from the Azure Identity library. For example, [DefaultAzureCredential][azure_identity_dac]:

```C# Snippet:AI_Projects_OverviewCreateClient
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
```

**Note:** Support for project connection string and hub-based projects has been discontinued. We recommend creating a new Azure AI Foundry resource utilizing project endpoint. If this is not possible, please pin the version of `Azure.AI.Projects` to version `1.0.0-beta.8` or earlier.

Once the `AIProjectClient` is created, you can use properties such as `.Datasets` and `.Indexes` on this client to perform relevant operations.

## Examples

### Performing Classic Agent operations

The `GetPersistentAgentsClient` method on the `AIProjectsClient` gives you access to an authenticated `PersistentAgentsClient` from the `Azure.AI.Agents.Persistent` package. Below we show how to create an Agent and delete it. To see what you can do with the agent you created, see the [many samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Agents.Persistent/samples) associated with the `Azure.AI.Agents.Persistent` package.

The code below assumes `ModelDeploymentName` (a string) is defined. It's the deployment name of an AI model in your Foundry Project, as shown in the "Models + endpoints" tab, under the "Name" column.
```C# Snippet:AI_Projects_ExtensionsAgentsBasicsSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();

// Step 1: Create an agent
PersistentAgent agent = agentsClient.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal math tutor. Write and run code to answer math questions."
);

// Step 2: Create a thread
PersistentAgentThread thread = agentsClient.Threads.CreateThread();

// Step 3: Add a message to a thread
PersistentThreadMessage message = agentsClient.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");

// Intermission: message is now correlated with thread
// Intermission: listing messages will retrieve the message just added

List<PersistentThreadMessage> messagesList = [.. agentsClient.Messages.GetMessages(thread.Id)];
Assert.That(message.Id, Is.EqualTo(messagesList[0].Id));

// Step 4: Run the agent
ThreadRun run = agentsClient.Runs.CreateRun(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = agentsClient.Runs.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.That(
    RunStatus.Completed,
    Is.EqualTo(run.Status),
    run.LastError?.Message);

Pageable<PersistentThreadMessage> messages
    = agentsClient.Messages.GetMessages(
        threadId: thread.Id, order: ListSortOrder.Ascending);

foreach (PersistentThreadMessage threadMessage in messages)
{
    Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
    foreach (MessageContent contentItem in threadMessage.ContentItems)
    {
        if (contentItem is MessageTextContent textItem)
        {
            Console.Write(textItem.Text);
        }
        else if (contentItem is MessageImageFileContent imageFileItem)
        {
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}

agentsClient.Threads.DeleteThread(threadId: thread.Id);
agentsClient.Administration.DeleteAgent(agentId: agent.Id);
```

### Performing Agent operations

Azure.AI.Projects can be used to create, update and delete Agents.

Create Agent

Synchronous call:
```C# Snippet:Sample_CreateAgentVersionCRUD_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion1 = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent1",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
AgentVersion agentVersion2 = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent2",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

Asynchronous call:
```C# Snippet:Sample_CreateAgentVersionCRUD_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion1 = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent1",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
AgentVersion agentVersion2 = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent2",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

Get Agent

Synchronous call:
```C# Snippet:Sample_GetAgentCRUD_Sync
AgentRecord result = projectClient.Agents.GetAgent(agentVersion1.Name);
Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
```

Asynchronous call:
```C# Snippet:Sample_GetAgentCRUD_Async
AgentRecord result = await projectClient.Agents.GetAgentAsync(agentVersion1.Name);
Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
```

List Agents

Synchronous call:
```C# Snippet:Sample_ListAgentsCRUD_Sync
foreach (AgentRecord agent in projectClient.Agents.GetAgents())
{
    Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
}
```

Asynchronous call:
```C# Snippet:Sample_ListAgentsCRUD_Async
await foreach (AgentRecord agent in projectClient.Agents.GetAgentsAsync())
{
    Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
}
```

Delete Agent

Synchronous call:
```C# Snippet:Sample_DeleteAgentCRUD_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

Asynchronous call:
```C# Snippet:Sample_DeleteAgentCRUD_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

### Get an authenticated AzureOpenAI client

Your Azure AI Foundry project may have one or more OpenAI models deployed that support chat completions. Use the code below to get an authenticated ChatClient from the [Azure.AI.OpenAI](https://learn.microsoft.com/dotnet/api/overview/azure/ai.openai-readme?view=azure-dotnet) package, and execute a chat completions call.

The code below assumes `modelDeploymentName` (a string) is defined. It's the deployment name of an AI model in your Foundry Project, or a connected Azure OpenAI resource. As shown in the "Models + endpoints" tab, under the "Name" column.

You can update the `connectionName` with one of the connections in your Foundry project, and you can update the `apiVersion` value with one found in the "Data plane - inference" row [in this table](https://learn.microsoft.com/azure/ai-services/openai/reference#api-specs).

```C# Snippet:AI_Projects_AzureOpenAIChatSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI chat client");
var credential = new DefaultAzureCredential();
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), credential);

ClientConnection connection = projectClient.GetConnection(typeof(AzureOpenAIClient).FullName!);

if (!connection.TryGetLocatorAsUri(out Uri uri) || uri is null)
{
    throw new InvalidOperationException("Invalid URI.");
}
uri = new Uri($"https://{uri.Host}");

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(uri, credential);
ChatClient chatClient = azureOpenAIClient.GetChatClient(deploymentName: modelDeploymentName);

Console.WriteLine("Complete a chat");
ChatCompletion result = chatClient.CompleteChat("List all the rainbow colors");
Console.WriteLine(result.Content[0].Text);
```

### Deployments operations

The code below shows some Deployments operations, which allow you to enumerate the AI models deployed to your AI Foundry Projects. These models can be seen in the "Models + endpoints" tab in your AI Foundry Project. Full samples can be found under the "Deployment" folder in the [package samples][samples].

```C# Snippet:AI_Projects_DeploymentExampleSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var modelPublisher = System.Environment.GetEnvironmentVariable("MODEL_PUBLISHER");

AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine("List all deployments:");
foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeployments())
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeployments(modelPublisher: modelPublisher))
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
ModelDeployment deploymentDetails = (ModelDeployment)projectClient.Deployments.GetDeployment(modelDeploymentName);
Console.WriteLine(deploymentDetails);
```

### Connections operations

The code below shows some Connection operations, which allow you to enumerate the Azure Resources connected to your AI Foundry Projects. These connections can be seen in the "Management Center", in the "Connected resources" tab in your AI Foundry Project. Full samples can be found under the "Connections" folder in the [package samples][samples].

```C# Snippet:AI_Projects_ConnectionsExampleSync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine("List the properties of all connections:");
foreach (AIProjectConnection connection in projectClient.Connections.GetConnections())
{
    Console.WriteLine(connection);
    Console.WriteLine(connection.Name);
}

Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
foreach (AIProjectConnection connection in projectClient.Connections.GetConnections(connectionType: ConnectionType.AzureOpenAI))
{
    Console.WriteLine(connection);
}

Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
AIProjectConnection specificConnection = projectClient.Connections.GetConnection(connectionName, includeCredentials: false);
Console.WriteLine(specificConnection);

Console.WriteLine("Get the properties of a connection with credentials:");
AIProjectConnection specificConnectionCredentials = projectClient.Connections.GetConnection(connectionName, includeCredentials: true);
Console.WriteLine(specificConnectionCredentials);

Console.WriteLine($"Get the properties of the default connection:");
AIProjectConnection defaultConnection = projectClient.Connections.GetDefaultConnection(includeCredentials: false);
Console.WriteLine(defaultConnection);

Console.WriteLine($"Get the properties of the default connection with credentials:");
AIProjectConnection defaultConnectionCredentials = projectClient.Connections.GetDefaultConnection(includeCredentials: true);
Console.WriteLine(defaultConnectionCredentials);
```

### Dataset operations

The code below shows some Dataset operations. Full samples can be found under the "Datasets" folder in the [package samples][samples].

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

### Indexes operations

The code below shows some Indexes operations. Full samples can be found under the "Indexes" folder in the [package samples][samples].

```C# Snippet:AI_Projects_IndexesExampleSync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var indexName = Environment.GetEnvironmentVariable("INDEX_NAME") ?? "my-index";
var indexVersion = Environment.GetEnvironmentVariable("INDEX_VERSION") ?? "1.0";
var aiSearchConnectionName = Environment.GetEnvironmentVariable("AI_SEARCH_CONNECTION_NAME") ?? "my-ai-search-connection-name";
var aiSearchIndexName = Environment.GetEnvironmentVariable("AI_SEARCH_INDEX_NAME") ?? "my-ai-search-index-name";

AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
Console.WriteLine("Create a local Index with configurable data, referencing an existing AI Search resource");
AzureAISearchIndex searchIndex = new AzureAISearchIndex(aiSearchConnectionName, aiSearchIndexName)
{
    Description = "Sample Index for testing"
};

Console.WriteLine($"Create the Project Index named `{indexName}` using the previously created local object:");
searchIndex = (AzureAISearchIndex)projectClient.Indexes.CreateOrUpdate(
    name: indexName,
    version: indexVersion,
    index: searchIndex
);
Console.WriteLine(searchIndex);

Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
AIProjectIndex retrievedIndex = projectClient.Indexes.GetIndex(name: indexName, version: indexVersion);
Console.WriteLine(retrievedIndex);

Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
foreach (AIProjectIndex version in projectClient.Indexes.GetIndexVersions(name: indexName))
{
    Console.WriteLine(version);
}

Console.WriteLine($"Listing all Indices:");
foreach (AIProjectIndex version in projectClient.Indexes.GetIndexes())
{
    Console.WriteLine(version);
}

Console.WriteLine("Delete the Index version created above:");
projectClient.Indexes.Delete(name: indexName, version: indexVersion);
```

### Files operations

The code below shows some Files operations, which allow you to manage files through the OpenAI Files API. These operations are accessed via the ProjectOpenAIClient. Full samples can be found under the "FineTuning" folder in the [package samples][samples].

The first step working with OpenAI files is to authenticate to Azure through `AIProjectClient` and get the `OpenAIFileClient`.
```C# Snippet:AI_Projects_Files_CreateClients
string trainFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
```

Use authenticated `OpenAIFileClient` to upload the local files to Azure. 
```C# Snippet:AI_Projects_Files_UploadFile
using FileStream fileStream = File.OpenRead(trainFilePath);
OpenAIFile uploadedFile = fileClient.UploadFile(
    fileStream,
    "sft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
```

To retrieve file, use `GetFile` method of `OpenAIFileClient`.
```C# Snippet:AI_Projects_Files_GetFile
OpenAIFile retrievedFile = fileClient.GetFile(fileId);
Console.WriteLine($"Retrieved file: {retrievedFile.Filename} ({retrievedFile.SizeInBytes} bytes)");
```

Use `GetFiles` method of `OpenAIFileClient` to list the files.
```C# Snippet:AI_Projects_Files_ListFiles
ClientResult<OpenAIFileCollection> filesResult = fileClient.GetFiles();
Console.WriteLine($"Listed {filesResult.Value.Count} file(s)");
```

```C# Snippet:AI_Projects_Files_DeleteFile
ClientResult<FileDeletionResult> deleteResult = fileClient.DeleteFile(fileId);
Console.WriteLine($"Deleted file: {deleteResult.Value.FileId}");
```

### Fine-Tuning operations

The code below shows how to create a supervised fine-tuning job using the OpenAI Fine-Tuning API through the ProjectOpenAIClient. Fine-tuning allows you to customize models for specific tasks using your own training data. Full samples can be found under the "FineTuning" folder in the [package samples][samples].

```C# Snippet:AI_Projects_FineTuning_CreateClients
string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/sft_validation_set.jsonl";
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ProjectOpenAIClient oaiClient = projectClient.OpenAI;
OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
```

The fine-tuning task represents the adaptation of deep neural network weights to the domain specific data. To achieve this goal, we need to provide model with training data set for weights update and a validation set for evaluation of learning efficiency.
```C# Snippet:AI_Projects_FineTuning_UploadFiles
// Upload training file
Console.WriteLine("Uploading training file...");
using FileStream trainStream = File.OpenRead(trainingFilePath);
OpenAIFile trainFile = fileClient.UploadFile(
    trainStream,
    "sft_training_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

// Upload validation file
Console.WriteLine("Uploading validation file...");
using FileStream validationStream = File.OpenRead(validationFilePath);
OpenAIFile validationFile = fileClient.UploadFile(
    validationStream,
    "sft_validation_set.jsonl",
    FileUploadPurpose.FineTune);
Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
```

Now we will use the uploaded training and validation set to fine-tue the model. In our experiment we will train the model for three epochs batch size of one and the constant [learning rate](https://en.wikipedia.org/wiki/Learning_rate) of 1.0.
```C# Snippet:AI_Projects_FineTuning_CreateJob
// Create supervised fine-tuning job
Console.WriteLine("Creating supervised fine-tuning job...");
FineTuningJob fineTuningJob = fineTuningClient.FineTune(
    modelDeploymentName,
    trainFile.Id,
    waitUntilCompleted: false,
    new()
    {
        TrainingMethod = FineTuningTrainingMethod.CreateSupervised(
            epochCount: 3,
            batchSize: 1,
            learningRate: 1.0),
        ValidationFile = validationFile.Id
    });
Console.WriteLine($"Created fine-tuning job: {fineTuningJob.JobId}");
Console.WriteLine($"Status: {fineTuningJob.Status}");
```

### Memory store operations

Memory in Foundry Agent Service is a managed, long-term memory solution. It enables Agent continuity across sessions, devices, and workflows.
Project client can be used to manage memory stores. In the examples below we show only synchronous version of API for brevity.

Use the client to create the `MemoryStore`. Memory store requires two models, one for embedding and another for chat completion.

```C# Snippet:Sample_Create_MemoryStore_Sync
MemoryStoreDefaultDefinition memoryStoreDefinition = new(
    chatModel: modelDeploymentName,
    embeddingModel: embeddingDeploymentName
);
memoryStoreDefinition.Options = new(userProfileEnabled: true, chatSummaryEnabled: true);
MemoryStore memoryStore = projectClient.MemoryStores.CreateMemoryStore(
    name: "testMemoryStore",
    definition: memoryStoreDefinition,
    description: "Memory store demo."
);
Console.WriteLine($"Memory store with id {memoryStore.Id}, name {memoryStore.Name} and description {memoryStore.Description} was created.");
```

Update the description of memory store we have just created.

```C# Snippet:Sample_Update_MemoryStore_Sync
memoryStore = projectClient.MemoryStores.UpdateMemoryStore(name: memoryStore.Name, description: "New description for memory store demo.");
Console.WriteLine($"Memory store with id {memoryStore.Id}, name {memoryStore.Name} now has description: {memoryStore.Description}.");
```

Get the memory store.

```C# Snippet:Sample_Get_MemoryStore_Sync
memoryStore = projectClient.MemoryStores.GetMemoryStore(name: memoryStore.Name);
Console.WriteLine($"Returned Memory store with id {memoryStore.Id}, name {memoryStore.Name} and description {memoryStore.Description}.");
```

List all memory stores in our Microsoft Foundry.

```C# Snippet:Sample_List_MemoryStore_Sync
foreach (MemoryStore store in projectClient.MemoryStores.GetMemoryStores())
{
    Console.WriteLine($"Memory store id: {store.Id}, name: {store.Name}, description: {store.Description}.");
}
```

Create a scope in the `MemoryStore` and add one item.

```C# Snippet:Sample_AddMemories_MemoryStore_Sync
string scope = "Flower";
MemoryUpdateOptions memoryOptions = new(scope);
memoryOptions.Items.Add(ResponseItem.CreateUserMessageItem("My favourite flower is Cephalocereus euphorbioides."));
MemoryUpdateResult updateResult = projectClient.MemoryStores.WaitForMemoriesUpdate(memoryStoreName: memoryStore.Name, options: memoryOptions, pollingInterval: 500);
if (updateResult.Status == MemoryStoreUpdateStatus.Failed)
{
    throw new InvalidOperationException(updateResult.ErrorDetails);
}
Console.WriteLine($"The update operation {updateResult.UpdateId} has finished with {updateResult.Status} status.");
```

Ask the question about the memorized item.

```C# Snippet:Sample_MemorySearch_Sync
MemorySearchOptions opts = new(scope)
{
    Items = { ResponseItem.CreateUserMessageItem("What was is your favourite flower?") },
};
MemoryStoreSearchResponse resp = projectClient.MemoryStores.SearchMemories(
    memoryStoreName: memoryStore.Name,
    options: new(scope)
);
Console.WriteLine("==The output from memory tool.==");
foreach (Azure.AI.Projects.MemorySearchItem item in resp.Memories)
{
    Console.WriteLine(item.MemoryItem.Content);
}
Console.WriteLine("==End of memory tool output.==");
```

Remove the scope we have created from `MemoryStore`.

```C# Snippet:Sample_DeleteScope_MemoryStore_Sync
MemoryStoreDeleteScopeResponse deleteScopeResponse = projectClient.MemoryStores.DeleteScope(name: memoryStore.Name, scope: "Flower");
string status = deleteScopeResponse.Deleted ? "" : " not";
Console.WriteLine($"The scope {deleteScopeResponse.Name} was{status} deleted.");
```

Finally, delete `MemoryStore`.

```C# Snippet:Sample_Cleanup_MemoryStore_Sync
DeleteMemoryStoreResponse deleteResponse = projectClient.MemoryStores.DeleteMemoryStore(name: memoryStore.Name);
status = deleteResponse.Deleted ? "" : " not";
Console.WriteLine($"The memory store {deleteResponse.Name} was{status} deleted.");
```

For more information abouit memory stores please refer [this article](https://learn.microsoft.com/azure/ai-foundry/agents/concepts/agent-memory)

### Evaluations

Evaluation in Azure AI Project client library provides quantitative, AI-assisted quality and safety metrics to asses
performance and Evaluate LLM Models, GenAI Application and Agents. Metrics are defined as evaluators. Built-in or
custom evaluators can provide comprehensive evaluation insights.

#### Basic evaluation sample

All the operations with evaluations can be performed using `EvaluationClient`. Here we will demonstrate only the basic concepts of the evaluations.
Please see the full sample of evaluations in our samples section.

First, we need to define the evaluation criteria and the data source config. Testing criteria lists all the evaluators and
data mappings for them. In the example below we will use three built in evaluators: "violence_detection",
"fluency" and "task_adherence". We will use Agent's string and structured JSON outputs, named `sample.output_text` and `sample.output_items` respectively as response parameter for the evaluation and take query property from the data set, using `item.query` placeholder.

```C# Snippet:Sample_CreateData_Evaluations
object[] testingCriteria = [
    new {
        type = "azure_ai_evaluator",
        name = "violence_detection",
        evaluator_name = "builtin.violence",
        data_mapping = new { query = "{{item.query}}", response = "{{sample.output_text}}"}
    },
    new {
        type = "azure_ai_evaluator",
        name = "fluency",
        evaluator_name = "builtin.fluency",
        initialization_parameters = new { deployment_name = modelDeploymentName},
        data_mapping = new { query = "{{item.query}}", response = "{{sample.output_text}}"}
    },
    new {
        type = "azure_ai_evaluator",
        name = "task_adherence",
        evaluator_name = "builtin.task_adherence",
        initialization_parameters = new { deployment_name = modelDeploymentName},
        data_mapping = new { query = "{{item.query}}", response = "{{sample.output_items}}"}
    },
];
object dataSourceConfig = new {
    type = "custom",
    item_schema = new
    {
        type = "object",
        properties = new
        {
            query = new
            {
                type = "string"
            }
        },
        required = new[] { "query" }
    },
    include_sample_schema = true
};
BinaryData evaluationData = BinaryData.FromObjectAsJson(
    new
    {
        name = "Agent Evaluation",
        data_source_config = dataSourceConfig,
        testing_criteria = testingCriteria
    }
);
```

Use `EvaluationClient` to create the evaluation with provided parameters.

```C# Snippet:Sample_CreateEvaluationObject_Evaluations_Async
using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

Create the data source. It contains name, the ID of the evaluation we have created above, and data source, consisting of target agent name and version, two queries for an agent and the template, mapping these questions to the text field of the user messages, which will be sent to Agent.

```C# Snippet:Sample_CreateDataSource_Evaluations
object dataSource = new
{
    type = "azure_ai_target_completions",
    source = new
    {
        type = "file_content",
        content = new[] {
            new { item = new { query = "What is the capital of France?" } },
            new { item = new { query = "How do I reverse a string in Python? "} },
        }
    },
    input_messages = new
    {
        type = "template",
        template = new[] {
            new {
                type = "message",
                role = "user",
                content = new { type = "input_text", text = "{{item.query}}" }
            }
        }
    },
    target = new
    {
        type = "azure_ai_agent",
        name = agentVersion.Name,
        // Version is optional. Defaults to latest version if not specified.
        version = agentVersion.Version,
    }
};
BinaryData runData = BinaryData.FromObjectAsJson(
    new
    {
        eval_id = evaluationId,
        name = $"Evaluation Run for Agent {agentVersion.Name}",
        data_source = dataSource
    }
);
using BinaryContent runDataContent = BinaryContent.Create(runData);
```

Create the evaluation run and extract its ID and status.

```C# Snippet:Sample_CreateRun_Evaluations_Async
ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

Wait for evaluation run to arrive at the terminal state.

```C# Snippet:Sample_WaitForRun_Evaluations_Async
while (runStatus != "failed" && runStatus != "completed")
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
    runStatus = ParseClientResult(run, ["status"])["status"];
    Console.WriteLine($"Waiting for eval run to complete... current status: {runStatus}");
}
if (runStatus == "failed")
{
    throw new InvalidOperationException($"Evaluation run failed with error: {GetErrorMessageOrEmpty(run)}");
}
```

Get the results using `GetResultsListAsync` method. It calls `GetEvaluationRunOutputItemsAsync` on the `EvaluationClient` returning the object representing `ClientResult`, which contains binary encoded JSON response that can be retrieved using `GetRawResponse()`.

```C# Snippet:Sampple_GetResultsList_Evaluations_Async
private static async Task<List<string>> GetResultsListAsync(EvaluationClient client, string evaluationId, string evaluationRunId)
{
    List<string> resultJsons = [];
    bool hasMore = false;
    do
    {
        ClientResult resultList = await client.GetEvaluationRunOutputItemsAsync(evaluationId: evaluationId, evaluationRunId: evaluationRunId, limit: null, order: "asc", after: default, outputItemStatus: default, options: new());
        Utf8JsonReader reader = new(resultList.GetRawResponse().Content.ToMemory().ToArray());
        JsonDocument document = JsonDocument.ParseValue(ref reader);

        foreach (JsonProperty topProperty in document.RootElement.EnumerateObject())
        {
            if (topProperty.NameEquals("has_more"u8))
            {
                hasMore = topProperty.Value.GetBoolean();
            }
            else if (topProperty.NameEquals("data"u8))
            {
                if (topProperty.Value.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement dataElement in topProperty.Value.EnumerateArray())
                    {
                        resultJsons.Add(dataElement.ToString());
                    }
                }
            }
        }
    } while (hasMore);
    return resultJsons;
}
```

#### Using uploaded datasets

To use the uploaded data set with evaluations please upload the data set as described in [dataset operations](#dataset-operations) section and
use uploaded data set ID while creating data source object.

```C# Snippet:Sample_CreateDataSource_EvaluationsWithDataSetID
object dataSource = new
{
    type = "jsonl",
    source = new
    {
        type = "file_id",
        id = fileDataset.Id
    },
};
object runMetadata = new
{
    team = "evaluator-experimentation",
    scenario = "dataset-with-id",
};
BinaryData runData = BinaryData.FromObjectAsJson(
    new
    {
        eval_id = evaluationId,
        name = $"Evaluation Run for dataset {fileDataset.Name}",
        metadata = runMetadata,
        data_source = dataSource
    }
);
using BinaryContent runDataContent = BinaryContent.Create(runData);
```

#### Using custom prompt-based evaluator

Side by side with built in evaluators, it is possible to define ones with custom logic. After the
evaluator has been created and uploaded to catalog, it can be used as a regular evaluator:

Create a prompt-based evaluator.

```C# Snippet:Sampple_PromptEvaluator_EvaluationsCatalogPromptBased
private EvaluatorVersion promptVersion = new(
    categories: [EvaluatorCategory.Quality],
    definition: new PromptBasedEvaluatorDefinition(
        promptText: """
            You are a Groundedness Evaluator.

            Your task is to evaluate how well the given response is grounded in the provided ground truth.  
            Groundedness means the response’s statements are factually supported by the ground truth.  
            Evaluate factual alignment only — ignore grammar, fluency, or completeness.

            ---

            ### Input:
            Query:
            {{query}}

            Response:
            {{response}}

            Ground Truth:
            {{ground_truth}}

            ---

            ### Scoring Scale (1–5):
            5 → Fully grounded. All claims supported by ground truth.  
            4 → Mostly grounded. Minor unsupported details.  
            3 → Partially grounded. About half the claims supported.  
            2 → Mostly ungrounded. Only a few details supported.  
            1 → Not grounded. Almost all information unsupported.

            ---

            ### Output Format (JSON):
            {
                "result": <integer from 1 to 5>,
                "reason": "<brief explanation for the score>"
            }
            """
    ),
    evaluatorType: EvaluatorType.Custom
) {
    DisplayName = "Custom prompt evaluator example",
    Description = "Custom evaluator for groundedness",
};
```

Upload evaluator to Azure.

```C# Snippet:Sample_CreateEvaluator_EvaluationsCatalogPromptBased_Async
EvaluatorVersion promptEvaluator = await projectClient.Evaluators.CreateVersionAsync(
    name: "myCustomEvaluatorPrompt",
    evaluatorVersion: promptVersion
);
Console.WriteLine($"Created evaluator {promptEvaluator.Id}");
```

To use the evaluator we have created, the next testing criteria should be set.

```C# Snippet:Sample_TestingCriteria_EvaluationsCatalogPromptBased
object[] testingCriteria = [
    new {
        type = "azure_ai_evaluator",
        name = "MyCustomEvaluation",
        evaluator_name = promptEvaluator.Name,
        data_mapping = new {
            query = "{{item.query}}",
            response = "{{item.response}}",
            ground_truth = "{{item.ground_truth}}",
        },
        initialization_parameters = new { deployment_name = modelDeploymentName, threshold = 3},
    },
];
```

#### Using custom code-based evaluator

Custom evaluators may rely on code-based rules as shown below.

```C# Snippet:Sampple_CodeEvaluator_EvaluationsCatalogCodeBased
private EvaluatorVersion GetCodeEvaluatorVersion()
{
    EvaluatorMetric resultMetric = new()
    {
        Type = EvaluatorMetricType.Ordinal,
        DesirableDirection = EvaluatorMetricDirection.Increase,
        MinValue = 0.0f,
        MaxValue = 1.0f
    };
    EvaluatorVersion evaluatorVersion = new(
        categories: [EvaluatorCategory.Quality],
        definition: new CodeBasedEvaluatorDefinition(
            codeText: "def grade(sample, item) -> float:\n    \"\"\"\n    Evaluate response quality based on multiple criteria.\n    Note: All data is in the \\'item\\' parameter, \\'sample\\' is empty.\n    \"\"\"\n    # Extract data from item (not sample!)\n    response = item.get(\"response\", \"\").lower() if isinstance(item, dict) else \"\"\n    ground_truth = item.get(\"ground_truth\", \"\").lower() if isinstance(item, dict) else \"\"\n    query = item.get(\"query\", \"\").lower() if isinstance(item, dict) else \"\"\n    \n    # Check if response is empty\n    if not response:\n        return 0.0\n    \n    # Check for harmful content\n    harmful_keywords = [\"harmful\", \"dangerous\", \"unsafe\", \"illegal\", \"unethical\"]\n    if any(keyword in response for keyword in harmful_keywords):\n        return 0.0\n    \n    # Length check\n    if len(response) < 10:\n        return 0.1\n    elif len(response) < 50:\n        return 0.2\n    \n    # Technical content check\n    technical_keywords = [\"api\", \"experiment\", \"run\", \"azure\", \"machine learning\", \"gradient\", \"neural\", \"algorithm\"]\n    technical_score = sum(1 for k in technical_keywords if k in response) / len(technical_keywords)\n    \n    # Query relevance\n    query_words = query.split()[:3] if query else []\n    relevance_score = 0.7 if any(word in response for word in query_words) else 0.3\n    \n    # Ground truth similarity\n    if ground_truth:\n        truth_words = set(ground_truth.split())\n        response_words = set(response.split())\n        overlap = len(truth_words & response_words) / len(truth_words) if truth_words else 0\n        similarity_score = min(1.0, overlap)\n    else:\n        similarity_score = 0.5\n    \n    return min(1.0, (technical_score * 0.3) + (relevance_score * 0.3) + (similarity_score * 0.4))",
            initParameters: BinaryData.FromObjectAsJson(
                new
                {
                    required = new[] { "deployment_name", "pass_threshold" },
                    type = "object",
                    properties = new
                    {
                        deployment_name = new { type = "string" },
                        pass_threshold = new { type = "string" }
                    }
                }
            ),
            dataSchema: BinaryData.FromObjectAsJson(
                new {
                    required = new[] { "item" },
                    type = "object",
                    properties = new
                    {
                        item = new
                        {
                            type = "object",
                            properties = new
                            {
                                query = new { type = "string" },
                                response = new { type = "string" },
                                ground_truth = new { type = "string" },
                            }
                        }
                    }
                }
            ),
            metrics: new Dictionary<string, EvaluatorMetric> {
                { "result", resultMetric }
            }
        ),
        evaluatorType: EvaluatorType.Custom
    )
    {
        DisplayName = "Custom code evaluator example",
        Description = "Custom evaluator to detect violent content",
    };
    return evaluatorVersion;
}
```

The code-based evaluator can be used the same way as prompt-based

## Troubleshooting

Any operation that fails will throw a [RequestFailedException][RequestFailedException]. The exception's `code` will hold the HTTP response status code. The exception's `message` contains a detailed message that may be helpful in diagnosing the issue:

```C# Snippet:AI_Projects_Readme_Troubleshooting
try
{
    projectClient.Datasets.GetDataset("non-existent-dataset-name", "non-existent-dataset-version");
}
catch (ClientResultException ex) when (ex.Status == 404)
{
    Console.WriteLine($"Exception status code: {ex.Status}");
    Console.WriteLine($"Exception message: {ex.Message}");
}
```

To further diagnose and troubleshoot issues, you can enable logging following the [Azure SDK logging documentation](https://learn.microsoft.com/dotnet/azure/sdk/logging). This allows you to capture additional insights into request and response details, which can be particularly helpful when diagnosing complex issues.

### Reporting issues

To report an issue with the client library, or request additional features, please open a [GitHub issue here](https://github.com/Azure/azure-sdk-for-net/issues). Mention the package name "Azure.AI.Projects" in the title or content.

## Next steps

Beyond the introductory scenarios discussed, the AI Projects client library offers support for additional scenarios to help take advantage of the full feature set of the AI services.  In order to help explore some of these scenarios, the AI Projects client library offers a set of samples to serve as an illustration for common scenarios.  Please see the [Samples][samples] for details.

## Contributing

See the [Azure SDK CONTRIBUTING.md][aiprojects_contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[RequestFailedException]: https://learn.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Projects/tests/Samples
[api_ref_docs]: https://learn.microsoft.com/dotnet/api/azure.ai.projects?view=azure-dotnet-preview
[nuget]: https://www.nuget.org/packages/Azure.AI.Projects
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Projects
[product_doc]: https://learn.microsoft.com/azure/ai-studio/
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[azure_identity_dac]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[aiprojects_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
