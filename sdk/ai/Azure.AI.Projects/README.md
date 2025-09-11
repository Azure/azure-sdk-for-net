# Azure AI Projects client library for .NET
The AI Projects client library is part of the Azure AI Foundry SDK and provides easy access to resources in your Azure AI Foundry Project. Use it to:

* **Create and run Agents** using the `GetPersistentAgentsClient` method on the client.
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
  - [Performing Agent operations](#performing-agent-operations)
  - [Get an authenticated AzureOpenAI client](#get-an-authenticated-azureopenai-client)
  - [Get an authenticated ChatCompletionsClient](#get-an-authenticated-chatcompletionsclient)
  - [Deployments operations](#deployments-operations)
  - [Connections operations](#connections-operations)
  - [Dataset operations](#dataset-operations)
  - [Indexes operations](#indexes-operations)
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

### Performing Agent operations

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
Assert.AreEqual(message.Id, messagesList[0].Id);

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
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
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

### Get an authenticated AzureOpenAI client

Your Azure AI Foundry project may have one or more OpenAI models deployed that support chat completions. Use the code below to get an authenticated ChatClient from the [Azure.AI.OpenAI](https://learn.microsoft.com/dotnet/api/overview/azure/ai.openai-readme?view=azure-dotnet) package, and execute a chat completions call.

The code below assumes `ModelDeploymentName` (a string) is defined. It's the deployment name of an AI model in your Foundry Project, or a connected Azure OpenAI resource. As shown in the "Models + endpoints" tab, under the "Name" column.

You can update the `connectionName` with one of the connections in your Foundry project, and you can update the `apiVersion` value with one found in the "Data plane - inference" row [in this table](https://learn.microsoft.com/azure/ai-services/openai/reference#api-specs).

```C# Snippet:AI_Projects_AzureOpenAIChatSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI chat client");
var credential = new DefaultAzureCredential();
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), credential);

ClientConnection connection = projectClient.GetConnection(typeof(AzureOpenAIClient).FullName!);

if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
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

### Get an authenticated ChatCompletionsClient

Your Azure AI Foundry project may have one or more AI models deployed that support chat completions. Use the code below to get an authenticated [ChatCompletionsClient](https://learn.microsoft.com/dotnet/api/azure.ai.inference.chatcompletionsclient?view=azure-dotnet-preview) from the `Azure.AI.Inference` package, and execute a chat completions call.

The code below assumes `ModelDeploymentName` (a string) is defined. It's the deployment name of an AI model in your Foundry Project, or a connected Azure OpenAI resource. As shown in the "Models + endpoints" tab, under the "Name" column.

```C# Snippet:AI_Projects_ChatClientSync
var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT"));
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

var credential = new DefaultAzureCredential();
BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

ChatCompletionsClient chatClient = new ChatCompletionsClient(new Uri(inferenceEndpoint), credential, clientOptions);

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
        {
            new ChatRequestSystemMessage("You are a helpful assistant."),
            new ChatRequestUserMessage("How many feet are in a mile?"),
        },
    Model = modelDeploymentName
};
Response<ChatCompletions> response = chatClient.Complete(requestOptions);
Console.WriteLine(response.Value.Content);
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
FileDatasetVersion fileDataset = projectClient.Datasets.UploadFile(
    name: datasetName,
    version: datasetVersion1,
    filePath: filePath,
    connectionName: connectionName
    );
Console.WriteLine(fileDataset);

Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion2}:");
FolderDatasetVersion folderDataset = projectClient.Datasets.UploadFolder(
    name: datasetName,
    version: datasetVersion2,
    folderPath: folderPath,
    connectionName: connectionName,
    filePattern: new Regex(".*\\.txt")
);
Console.WriteLine(folderDataset);

Console.WriteLine($"Retrieving Dataset version {datasetVersion1}:");
DatasetVersion dataset = projectClient.Datasets.GetDataset(datasetName, datasetVersion1);
Console.WriteLine(dataset.Id);

Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
DatasetCredential credentials = projectClient.Datasets.GetCredentials(datasetName, datasetVersion1);
Console.WriteLine(credentials);

Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
foreach (DatasetVersion ds in projectClient.Datasets.GetDatasetVersions(datasetName))
{
    Console.WriteLine(ds);
    Console.WriteLine(ds.Version);
}

Console.WriteLine($"Listing latest versions for all datasets:");
foreach (DatasetVersion ds in projectClient.Datasets.GetDatasets())
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
