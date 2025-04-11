# Azure AI Projects client library for .NET
Use the AI Projects client library to:

* **Develop Agents using the Azure AI Agent Service**, leveraging an extensive ecosystem of models, tools, and capabilities from OpenAI, Microsoft, and other LLM providers. The Azure AI Agent Service enables the building of Agents for a wide range of generative AI use cases. The package is currently in preview.
* **Enumerate connections** in your Azure AI Foundry project and get connection properties. For example, get the inference endpoint URL and credentials associated with your Azure OpenAI connection.

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
  - [Agents](#agents)
    - [Create an Agent](#create-an-agent)
      - [Create thread](#create-thread)
      - [Create message](#create-message)
      - [Create and execute run](#create-and-execute-run)
      - [Retrieve messages](#retrieve-messages)
    - [File search](#file-search)
    - [Enterprise File Search](#create-agent-with-enterprise-file-search)
    - [Code interpreter attachment](#create-message-with-code-interpreter-attachment)
    - [Create Agent with Bing Grounding](#create-agent-with-bing-grounding)
    - [Azure AI Search](#create-agent-with-azure-ai-search)
    - [Function call](#function-call)
    - [Azure function Call](#azure-function-call)
    - [OpenAPI](#create-agent-with-openapi)
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

```C# Snippet:OverviewCreateClient
var connectionString = Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
AIProjectClient projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
```

Once the `AIProjectClient` is created, you can call methods in the form of `GetXxxClient()` on this client to retrieve instances of specific sub-clients.

## Examples

### Agents

Agents in the Azure AI Projects client library are designed to facilitate various interactions and operations within your AI projects. They serve as the core components that manage and execute tasks, leveraging different tools and resources to achieve specific goals. The following steps outline the typical sequence for interacting with agents:

#### Create an Agent

First, you need to create an `AgentsClient`
```C# Snippet:OverviewCreateAgentClient
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AgentsClient client = new(connectionString, new DefaultAzureCredential());
```

With an authenticated client, an agent can be created:
```C# Snippet:OverviewCreateAgent
Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal math tutor. Write and run code to answer math questions."
);
```

#### Create thread

Next, create a thread:
```C# Snippet:OverviewCreateThread
AgentThread thread = await client.CreateThreadAsync();
```

#### Create message

With a thread created, messages can be created on it:
```C# Snippet:OverviewCreateMessage
ThreadMessage message = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");
```

#### Create and execute run

A run can then be started that evaluates the thread against an agent:
```C# Snippet:OverviewCreateRun
ThreadRun run = await client.CreateRunAsync(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
```

Once the run has started, it should then be polled until it reaches a terminal status:
```C# Snippet:OverviewWaitForRun
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

#### Retrieve messages

Assuming the run successfully completed, listing messages from the thread that was run will now reflect new information
added by the agent:
```C# Snippet:OverviewListUpdatedMessages
PageableList<ThreadMessage> messages
    = await client.GetMessagesAsync(
        threadId: thread.Id, order: ListSortOrder.Ascending);

foreach (ThreadMessage threadMessage in messages)
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
```

Example output from this sequence:
```
 2024-10-15 23:12:59 - assistant: Yes, Jane Doe, the solution to the equation \(3x + 11 = 14\) is \(x = 1\).
 2024-10-15 23:12:51 - user: I need to solve the equation `3x + 11 = 14`. Can you help me?
```

#### File search

Files can be uploaded and then referenced by agents or messages. First, use the generalized upload API with a
purpose of 'agents' to make a file ID available:
```C# Snippet:UploadAgentFilesToUse
// Upload a file and wait for it to be processed
File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
AgentFile uploadedAgentFile = await client.UploadFileAsync(
    filePath: "sample_file_for_upload.txt",
    purpose: AgentFilePurpose.Agents);
Dictionary<string, string> fileIds = new()
{
    { uploadedAgentFile.Id, uploadedAgentFile.Filename }
};
```

Once uploaded, the file ID can then be provided to create a vector store for it
```C# Snippet:CreateVectorStore
// Create a vector store with the file and wait for it to be processed.
// If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
VectorStore vectorStore = await client.CreateVectorStoreAsync(
    fileIds:  new List<string> { uploadedAgentFile.Id },
    name: "my_vector_store");
```

The vectorStore ID can then be provided to an agent upon creation. Note that file search will only be used if an appropriate tool like Code Interpreter is enabled. Also, you do not need to provide toolResources if you did not create a vector store above
```C# Snippet:CreateAgentWithFiles
FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

// Create an agent with toolResources and process assistant run
Agent agent = await client.CreateAgentAsync(
        model: modelDeploymentName,
        name: "SDK Test Agent - Retrieval",
        instructions: "You are a helpful agent that can help fetch data from files you know about.",
        tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
        toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
```

With a file ID association and a supported tool enabled, the agent will then be able to consume the associated
data when running threads.

#### Create Agent with Enterprise File Search

We can upload file to Azure as it is shown in the example, or use the existing Azure blob storage. In the code below we demonstrate how this can be achieved. First we upload file to azure and create `VectorStoreDataSource`, which then is used to create vector store. This vector store is then given to the `FileSearchTool` constructor.

```C# Snippet:CreateVectorStoreBlob
var ds = new VectorStoreDataSource(
    assetIdentifier: blobURI,
    assetType: VectorStoreDataSourceAssetType.UriAsset
);
VectorStore vectorStore = await client.CreateVectorStoreAsync(
    name: "sample_vector_store",
    storeConfiguration: new VectorStoreConfiguration(
        dataSources: [ ds ]
    )
);

FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

List<ToolDefinition> tools = [new FileSearchToolDefinition()];
Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "my-assistant",
    instructions: "You are helpful assistant.",
    tools: tools,
    toolResources: new ToolResources() { FileSearch = fileSearchResource }
);
```

We also can attach files to the existing vector store. In the code snippet below, we first create an empty vector store and add file to it.

```C# Snippet:BatchFileAttachment
var ds = new VectorStoreDataSource(
    assetIdentifier: blobURI,
    assetType: VectorStoreDataSourceAssetType.UriAsset
);
VectorStore vectorStore = await client.CreateVectorStoreAsync(
    name: "sample_vector_store"
);

VectorStoreFileBatch vctFile = await client.CreateVectorStoreFileBatchAsync(
    vectorStoreId: vectorStore.Id,
    dataSources: [ ds ]
);
Console.WriteLine($"Created vector store file batch, vector store file batch ID: {vctFile.Id}");

FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);
```

#### Create Message with Code Interpreter Attachment

To attach a file with the context to the message, use the `MessageAttachment` class. To be able to process the attached file contents we need to provide the `List` with the single element `CodeInterpreterToolDefinition` as a `tools` parameter to both `CreateAgent` method and `MessageAttachment` class constructor.

Here is an example to pass `CodeInterpreterTool` as tool:

```C# Snippet:CreateAgentWithInterpreterTool
List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "my-assistant",
    instructions: "You are a helpful agent that can help fetch data from files you know about.",
    tools: tools
);

File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
AgentFile uploadedAgentFile = await client.UploadFileAsync(
    filePath: "sample_file_for_upload.txt",
    purpose: AgentFilePurpose.Agents);
var fileId = uploadedAgentFile.Id;

var attachment = new MessageAttachment(
    fileId: fileId,
    tools: tools
);

AgentThread thread = await client.CreateThreadAsync();

ThreadMessage message = await client.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "Can you give me the documented codes for 'banana' and 'orange'?",
    attachments: [ attachment ]
);
```

Azure blob storage can be used as a message attachment. In this case, use `VectorStoreDataSource` as a data source:

```C# Snippet:CreateMessageAttachmentWithBlobStore
var ds = new VectorStoreDataSource(
    assetIdentifier: blobURI,
    assetType: VectorStoreDataSourceAssetType.UriAsset
);

var attachment = new MessageAttachment(
    ds: ds,
    tools: tools
);
```

#### Create Agent with Bing Grounding

To enable your Agent to perform search through Bing search API, you use `BingGroundingTool` along with a connection.

Here is an example:
```C# Snippet:BingGroundingAsync_GetConnection
ConnectionResponse bingConnection = await projectClient.GetConnectionsClient().GetConnectionAsync(bingConnectionName);
var connectionId = bingConnection.Id;

ToolConnectionList connectionList = new()
{
    ConnectionList = { new ToolConnection(connectionId) }
};
BingGroundingToolDefinition bingGroundingTool = new(connectionList);
```
```C# Snippet:BingGroundingAsync_CreateAgent
Agent agent = await agentClient.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [ bingGroundingTool ]);
```

#### Create Agent with Azure AI Search

Azure AI Search is an enterprise search system for high-performance applications.
It integrates with Azure OpenAI Service and Azure Machine Learning, offering advanced
search technologies like vector search and full-text search. Ideal for knowledge base
insights, information discovery, and automation. Creating an Agent with Azure AI
Search requires an existing Azure AI Search Index. For more information and setup
guides, see [Azure AI Search Tool Guide](https://learn.microsoft.com/azure/ai-services/agents/how-to/tools/azure-ai-search).

```C# Snippet:CreateAgentWithAzureAISearchTool
ListConnectionsResponse connections = await projectClient.GetConnectionsClient().GetConnectionsAsync(ConnectionType.AzureAISearch).ConfigureAwait(false);

if (connections?.Value == null || connections.Value.Count == 0)
{
    throw new InvalidOperationException("No connections found for the Azure AI Search.");
}

ConnectionResponse connection = connections.Value[0];

AzureAISearchResource searchResource = new(
    connection.Id,
    "sample_index",
    5,
    "category eq 'sleeping bag'",
    AzureAISearchQueryType.Simple
);
ToolResources toolResource = new()
{
    AzureAISearch = searchResource
};

AgentsClient agentClient = projectClient.GetAgentsClient();

Agent agent = await agentClient.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [ new AzureAISearchToolDefinition() ],
   toolResources: toolResource);
```

If the agent has found the relevant information in the index, the reference
and annotation will be provided in the message response. In the example above, we replace
the reference placeholder by the actual reference and url. Please note, that to
get sensible result, the index needs to have fields "title" and "url".

```C# Snippet:PopulateReferencesAgentWithAzureAISearchTool
PageableList<ThreadMessage> messages = await agentClient.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

foreach (ThreadMessage threadMessage in messages)
{
    Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
    foreach (MessageContent contentItem in threadMessage.ContentItems)
    {
        if (contentItem is MessageTextContent textItem)
        {
            // We need to annotate only Agent messages.
            if (threadMessage.Role == MessageRole.Agent && textItem.Annotations.Count > 0)
            {
                string annotatedText = textItem.Text;
                foreach (MessageTextAnnotation annotation in textItem.Annotations)
                {
                    if (annotation is MessageTextUrlCitationAnnotation urlAnnotation)
                    {
                        annotatedText = annotatedText.Replace(
                            urlAnnotation.Text,
                            $" [see {urlAnnotation.UrlCitation.Title}] ({urlAnnotation.UrlCitation.Url})");
                    }
                }
                Console.Write(annotatedText);
            }
            else
            {
                Console.Write(textItem.Text);
            }
        }
        else if (contentItem is MessageImageFileContent imageFileItem)
        {
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}
```

#### Function call

Tools that reference caller-defined capabilities as functions can be provided to an agent to allow it to
dynamically resolve and disambiguate during a run.

Here, outlined is a simple agent that "knows how to," via caller-provided functions:

1. Get the user's favorite city
1. Get a nickname for a given city
1. Get the current weather, optionally with a temperature unit, in a city

To do this, begin by defining the functions to use -- the actual implementations here are merely representative stubs.

```C# Snippet:FunctionsDefineFunctionTools
// Example of a function that defines no parameters
string GetUserFavoriteCity() => "Seattle, WA";
FunctionToolDefinition getUserFavoriteCityTool = new("getUserFavoriteCity", "Gets the user's favorite city.");
// Example of a function with a single required parameter
string GetCityNickname(string location) => location switch
{
    "Seattle, WA" => "The Emerald City",
    _ => throw new NotImplementedException(),
};
FunctionToolDefinition getCityNicknameTool = new(
    name: "getCityNickname",
    description: "Gets the nickname of a city, e.g. 'LA' for 'Los Angeles, CA'.",
    parameters: BinaryData.FromObjectAsJson(
        new
        {
            Type = "object",
            Properties = new
            {
                Location = new
                {
                    Type = "string",
                    Description = "The city and state, e.g. San Francisco, CA",
                },
            },
            Required = new[] { "location" },
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
// Example of a function with one required and one optional, enum parameter
string GetWeatherAtLocation(string location, string temperatureUnit = "f") => location switch
{
    "Seattle, WA" => temperatureUnit == "f" ? "70f" : "21c",
    _ => throw new NotImplementedException()
};
FunctionToolDefinition getCurrentWeatherAtLocationTool = new(
    name: "getCurrentWeatherAtLocation",
    description: "Gets the current weather at a provided location.",
    parameters: BinaryData.FromObjectAsJson(
        new
        {
            Type = "object",
            Properties = new
            {
                Location = new
                {
                    Type = "string",
                    Description = "The city and state, e.g. San Francisco, CA",
                },
                Unit = new
                {
                    Type = "string",
                    Enum = new[] { "c", "f" },
                },
            },
            Required = new[] { "location" },
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
```

With the functions defined in their appropriate tools, an agent can be now created that has those tools enabled:

```C# Snippet:FunctionsCreateAgentWithFunctionTools
// note: parallel function calling is only supported with newer models like gpt-4-1106-preview
Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "SDK Test Agent - Functions",
        instructions: "You are a weather bot. Use the provided functions to help answer questions. "
            + "Customize your responses to the user's preferences as much as possible and use friendly "
            + "nicknames for cities whenever possible.",
    tools: [ getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool ]
    );
```

If the agent calls tools, the calling code will need to resolve `ToolCall` instances into matching
`ToolOutput` instances. For convenience, a basic example is extracted here:

```C# Snippet:FunctionsHandleFunctionCalls
ToolOutput GetResolvedToolOutput(RequiredToolCall toolCall)
{
    if (toolCall is RequiredFunctionToolCall functionToolCall)
    {
        if (functionToolCall.Name == getUserFavoriteCityTool.Name)
        {
            return new ToolOutput(toolCall, GetUserFavoriteCity());
        }
        using JsonDocument argumentsJson = JsonDocument.Parse(functionToolCall.Arguments);
        if (functionToolCall.Name == getCityNicknameTool.Name)
        {
            string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
            return new ToolOutput(toolCall, GetCityNickname(locationArgument));
        }
        if (functionToolCall.Name == getCurrentWeatherAtLocationTool.Name)
        {
            string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
            if (argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unitElement))
            {
                string unitArgument = unitElement.GetString();
                return new ToolOutput(toolCall, GetWeatherAtLocation(locationArgument, unitArgument));
            }
            return new ToolOutput(toolCall, GetWeatherAtLocation(locationArgument));
        }
    }
    return null;
}
```

To handle user input like "what's the weather like right now in my favorite city?", polling the response for completion
should be supplemented by a `RunStatus` check for `RequiresAction` or, in this case, the presence of the
`RequiredAction` property on the run. Then, the collection of `ToolOutputSubmissions` should be submitted to the
run via the `SubmitRunToolOutputs` method so that the run can continue:

```C# Snippet:FunctionsHandlePollingWithRequiredAction
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.GetRunAsync(thread.Id, run.Id);

    if (run.Status == RunStatus.RequiresAction
        && run.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
    {
        List<ToolOutput> toolOutputs = [];
        foreach (RequiredToolCall toolCall in submitToolOutputsAction.ToolCalls)
        {
            toolOutputs.Add(GetResolvedToolOutput(toolCall));
        }
        run = await client.SubmitToolOutputsToRunAsync(run, toolOutputs);
    }
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Calling function with streaming requires small modification of the code above. Streaming updates contain one ToolOutput per update and now the GetResolvedToolOutput function will look like it is shown on the code snippet below:

```C# Snippet:FunctionsWithStreamingUpdateHandling
ToolOutput GetResolvedToolOutput(string functionName, string toolCallId, string functionArguments)
{
    if (functionName == getUserFavoriteCityTool.Name)
    {
        return new ToolOutput(toolCallId, GetUserFavoriteCity());
    }
    using JsonDocument argumentsJson = JsonDocument.Parse(functionArguments);
    if (functionName == getCityNicknameTool.Name)
    {
        string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
        return new ToolOutput(toolCallId, GetCityNickname(locationArgument));
    }
    if (functionName == getCurrentWeatherAtLocationTool.Name)
    {
        string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
        if (argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unitElement))
        {
            string unitArgument = unitElement.GetString();
            return new ToolOutput(toolCallId, GetWeatherAtLocation(locationArgument, unitArgument));
        }
        return new ToolOutput(toolCallId, GetWeatherAtLocation(locationArgument));
    }
    return null;
}
```

We create a stream and wait for the stream update of the `RequiredActionUpdate` type. This update will mark the point, when we need to submit tool outputs to the stream. We will submit outputs in the inner cycle. Please note that `RequiredActionUpdate` keeps only one required action, while our run may require multiple function calls, this case is handled in the inner cycle, so that we can add tool output to the existing array of outputs. After all required actions were submitted we clean up the array of required actions.

```C# Snippet:FunctionsWithStreamingUpdateCycle
List<ToolOutput> toolOutputs = [];
ThreadRun streamRun = null;
AsyncCollectionResult<StreamingUpdate> stream = client.CreateRunStreamingAsync(thread.Id, agent.Id);
do
{
    toolOutputs.Clear();
    await foreach (StreamingUpdate streamingUpdate in stream)
    {
        if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
        {
            Console.WriteLine("--- Run started! ---");
        }
        else if (streamingUpdate is RequiredActionUpdate submitToolOutputsUpdate)
        {
            RequiredActionUpdate newActionUpdate = submitToolOutputsUpdate;
            toolOutputs.Add(
                GetResolvedToolOutput(
                    newActionUpdate.FunctionName,
                    newActionUpdate.ToolCallId,
                    newActionUpdate.FunctionArguments
            ));
            streamRun = submitToolOutputsUpdate.Value;
        }
        else if (streamingUpdate is MessageContentUpdate contentUpdate)
        {
            Console.Write(contentUpdate.Text);
        }
        else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
        {
            Console.WriteLine();
            Console.WriteLine("--- Run completed! ---");
        }
    }
    if (toolOutputs.Count > 0)
    {
        stream = client.SubmitToolOutputsToStreamAsync(streamRun, toolOutputs);
    }
}
while (toolOutputs.Count > 0);
```

#### Azure function call

We can use Azure Function from inside the agent. In the example below we are calling function "foo", which responds "Bar". In this example we create `AzureFunctionToolDefinition` object, with the function name, description, input and output queues, followed by function parameters. See below for the instructions on function deployment.
```C# Snippet:AzureFunctionsDefineFunctionTools
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var storageQueueUri = System.Environment.GetEnvironmentVariable("STORAGE_QUEUE_URI");

AgentsClient client = new(connectionString, new DefaultAzureCredential());

AzureFunctionToolDefinition azureFnTool = new(
    name: "foo",
    description: "Get answers from the foo bot.",
    inputBinding: new AzureFunctionBinding(
        new AzureFunctionStorageQueue(
            queueName: "azure-function-foo-input",
            storageServiceEndpoint: storageQueueUri
        )
    ),
    outputBinding: new AzureFunctionBinding(
        new AzureFunctionStorageQueue(
            queueName: "azure-function-tool-output",
            storageServiceEndpoint: storageQueueUri
        )
    ),
    parameters: BinaryData.FromObjectAsJson(
            new
            {
                Type = "object",
                Properties = new
                {
                    query = new
                    {
                        Type = "string",
                        Description = "The question to ask.",
                    },
                    outputqueueuri = new
                    {
                        Type = "string",
                        Description = "The full output queue uri."
                    }
                },
            },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
    )
);
```

Note that in this scenario we are asking agent to supply storage queue URI to the azure function whenever it is called.
```C# Snippet:AzureFunctionsCreateAgentWithFunctionTools
Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "azure-function-agent-foo",
        instructions: "You are a helpful support agent. Use the provided function any "
        + "time the prompt contains the string 'What would foo say?'. When you invoke "
        + "the function, ALWAYS specify the output queue uri parameter as "
        + $"'{storageQueueUri}/azure-function-tool-output'. Always responds with "
        + "\"Foo says\" and then the response from the tool.",
    tools: [ azureFnTool ]
    );
```

After we have created a message with request to ask "What would foo say?", we need to wait while the run is in queued, in progress or requires action states.
```C# Snippet:AzureFunctionsHandlePollingWithRequiredAction
AgentThread thread = await client.CreateThreadAsync();

ThreadMessage message = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the most prevalent element in the universe? What would foo say?");

ThreadRun run = await client.CreateRunAsync(thread, agent);

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress
    || run.Status == RunStatus.RequiresAction);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

To make a function call we need to create and deploy the Azure function. In the code snippet below, we have an example of function on C# which can be used by the code above.

```C#
namespace FunctionProj
{
    public class Response
    {
        public required string Value { get; set; }
        public required string CorrelationId { get; set; }
    }

    public class Arguments
    {
        public required string OutputQueueUri { get; set; }
        public required string CorrelationId { get; set; }
    }

    public class Foo
    {
        private readonly ILogger<Foo> _logger;

        public Foo(ILogger<Foo> logger)
        {
            _logger = logger;
        }

        [Function("Foo")]
        public void Run([QueueTrigger("azure-function-foo-input")] Arguments input, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Foo");
            logger.LogInformation("C# Queue function processed a request.");

            // We have to provide the Managed identity for function resource
            // and allow this identity a Queue Data Contributor role on the storage account.
            var cred = new DefaultAzureCredential();
            var queueClient = new QueueClient(new Uri(input.OutputQueueUri), cred,
                    new QueueClientOptions { MessageEncoding = QueueMessageEncoding.Base64 });

            var response = new Response
            {
                Value = "Bar",
                // Important! Correlation ID must match the input correlation ID.
                CorrelationId = input.CorrelationId
            };

            var jsonResponse = JsonSerializer.Serialize(response);
            queueClient.SendMessage(jsonResponse);
        }
    }
}
```

In this code we define function input and output class: `Arguments` and `Response` respectively. These two data classes will be serialized in JSON. It is important that these both contain field `CorrelationId`, which is the same between input and output.

In our example the function will be stored in the storage account, created with the AI hub. For that we need to allow key access to that storage. In Azure portal go to Storage account > Settings > Configuration and set "Allow storage account key access" to Enabled. If it is not done, the error will be displayed "The remote server returned an error: (403) Forbidden." To create the function resource that will host our function, install azure-cli python package and run the next command:

```shell
pip install -U azure-cli
az login
az functionapp create --resource-group your-resource-group --consumption-plan-location region --runtime dotnet-isolated --functions-version 4 --name function_name --storage-account storage_account_already_present_in_resource_group --app-insights existing_or_new_application_insights_name
```

This function writes data to the output queue and hence needs to be authenticated to Azure, so we will need to assign the function system identity and provide it `Storage Queue Data Contributor`. To do that in Azure portal select the function, located in `your-resource-group` resource group and in Settings>Identity, switch it on and click Save. After that assign the `Storage Queue Data Contributor` permission on storage account used by our function (`storage_account_already_present_in_resource_group` in the script above) for just assigned System Managed identity.

Now we will create the function itself. Install [.NET](https://dotnet.microsoft.com/download) and [Core Tools](https://go.microsoft.com/fwlink/?linkid=2174087) and create the function project using next commands. 
```
func init FunctionProj --worker-runtime dotnet-isolated --target-framework net8.0
cd FunctionProj
func new --name foo --template "HTTP trigger" --authlevel "anonymous"
dotnet add package Azure.Identity
dotnet add package Microsoft.Azure.Functions.Worker.Extensions.Storage.Queues --prerelease
```

**Note:** There is a "Azure Queue Storage trigger", however the attempt to use it results in error for now.
We have created a project, containing HTTP-triggered azure function with the logic in `Foo.cs` file. As far as we need to trigger Azure function by a new message in the queue, we will replace the content of a Foo.cs by the C# sample code above. 
To deploy the function run the command from dotnet project folder:

```
func azure functionapp publish function_name
```

In the `storage_account_already_present_in_resource_group` select the `Queue service` and create two queues: `azure-function-foo-input` and `azure-function-tool-output`. Note that the same queues are used in our sample. To check that the function is working, place the next message into the `azure-function-foo-input` and replace `storage_account_already_present_in_resource_group` by the actual resource group name, or just copy the output queue address.
```json
{
  "OutputQueueUri": "https://storage_account_already_present_in_resource_group.queue.core.windows.net/azure-function-tool-output",
  "CorrelationId": "42"
}
```

Next, we will monitor the output queue or the message. You should receive the next message.
```json
{
  "Value": "Bar",
  "CorrelationId": "42"
}
```
Please note that the input `CorrelationId` is the same as output.
*Hint:* Place multiple messages to input queue and keep second internet browser window with the output queue open and hit the refresh button on the portal user interface, so that you will not miss the message. If the message instead went to `azure-function-foo-input-poison` queue, the function completed with error, please check your setup.
After we have tested the function and made sure it works, please make sure that the Azure AI Project have the next roles for the storage account: `Storage Account Contributor`, `Storage Blob Data Contributor`, `Storage File Data Privileged Contributor`, `Storage Queue Data Contributor` and `Storage Table Data Contributor`. Now the function is ready to be used by the agent.


#### Create Agent With OpenAPI

OpenAPI specifications describe REST operations against a specific endpoint. Agents SDK can read an OpenAPI spec, create a function from it, and call that function against the REST endpoint without additional client-side execution.

Here is an example creating an OpenAPI tool (using anonymous authentication):
```C# Snippet:OpenAPIDefineFunctionTools
OpenApiAnonymousAuthDetails oaiAuth = new();
OpenApiToolDefinition openapiTool = new(
    name: "get_weather",
    description: "Retrieve weather information for a location",
    spec: BinaryData.FromBytes(File.ReadAllBytes(file_path)),
    auth: oaiAuth,
    defaultParams: ["format"]
);

Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "azure-function-agent-foo",
    instructions: "You are a helpful assistant.",
    tools: [ openapiTool ]
);
```

In this example we are using the `weather_openapi.json` file and agent will request the wttr.in website for the weather in a location fron the prompt.
```C# Snippet:OpenAPIHandlePollingWithRequiredAction
AgentThread thread = await client.CreateThreadAsync();
ThreadMessage message = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What's the weather in Seattle?");

ThreadRun run = await client.CreateRunAsync(thread, agent);

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress
    || run.Status == RunStatus.RequiresAction);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

## Troubleshooting

Any operation that fails will throw a [RequestFailedException][RequestFailedException]. The exception's `code` will hold the HTTP response status code. The exception's `message` contains a detailed message that may be helpful in diagnosing the issue:

```C# Snippet:Readme_Troubleshooting
try
{
    client.CreateMessage(
    "thread1234",
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine($"Exception status code: {ex.Status}");
    Console.WriteLine($"Exception message: {ex.Message}");
}
```

To further diagnose and troubleshoot issues, you can enable logging following the [Azure SDK logging documentation](https://learn.microsoft.com/dotnet/azure/sdk/logging). This allows you to capture additional insights into request and response details, which can be particularly helpful when diagnosing complex issues.

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
