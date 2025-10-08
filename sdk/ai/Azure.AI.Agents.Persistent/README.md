# Azure AI Persistent Agents client library for .NET

Use the AI Agents client library to:

* **Develop Agents using the Azure AI Agents Service**, leveraging an extensive ecosystem of models, tools, and capabilities from OpenAI, Microsoft, and other LLM providers. The Azure AI Agents Service enables the building of Agents for a wide range of generative AI use cases.
* **Note:** While this package can be used independently, we recommend using the Azure AI Projects client library (Azure.AI.Projects) for an enhanced experience. 
The Projects library provides simplified access to advanced functionality, such as creating and managing agents, enumerating AI models, working with datasets and 
managing search indexes, evaluating generative AI performance, and enabling OpenTelemetry tracing.

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
    - [Function call Executed Manually](#function-call-executed-manually)
    - [Function call Executed Automatically](#function-call-executed-automatically)
    - [Azure function Call](#azure-function-call)
    - [OpenAPI](#create-agent-with-openapi)
    - [Tracing](#tracing)
      - [Azure Monitor Tracing](#tracing-to-azure-monitor)
      - [Console Tracing](#tracing-to-console)
- [Troubleshooting](#troubleshooting)
- [Next steps](#next-steps)
- [Contributing](#contributing)

## Getting started

### Prerequisites

To use Azure AI Agents capabilities, you must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/). This will allow you to create an Azure AI resource and get a connection URL.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.Agents.Persistent --prerelease
```

### Authenticate the client

A secure, keyless authentication approach is to use Microsoft Entra ID (formerly Azure Active Directory) via the [Azure Identity library][azure_identity]. To use this library, you need to install the [Azure.Identity package](https://www.nuget.org/packages/Azure.Identity):

```dotnetcli
dotnet add package Azure.Identity
```

## Key concepts

### Create and authenticate the client

To interact with Azure AI Agents, you will need to create an instance of `PersistentAgentsClient`. Use the appropriate credential type from the Azure Identity library. For example, [DefaultAzureCredential][azure_identity_dac]:

```C# Snippet:AgentsOverviewCreateClient
var projectEndpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
PersistentAgentsClient projectClient = new(projectEndpoint, new DefaultAzureCredential());
```

**Note:** Support for project connection string and hub-based projects has been discontinued. We recommend creating a new Azure AI Foundry resource utilizing project endpoint. If this is not possible, please pin the version of `Azure.AI.Agents.Persistent` to version `1.0.0-beta.2` or earlier.

## Examples

### Agents

Agents in the Azure AI Agents client library are designed to facilitate various interactions and operations within your AI projects. They serve as the core components that manage and execute tasks, leveraging different tools and resources to achieve specific goals. The following steps outline the typical sequence for interacting with agents:

#### Create an Agent

First, you need to create an `PersistentAgentsClient`
```C# Snippet:AgentsOverviewCreateAgentClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

With an authenticated client, an agent can be created:
```C# Snippet:AgentsOverviewCreateAgent
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal math tutor. Write and run code to answer math questions."
);
```

#### Create thread

Next, create a thread:
```C# Snippet:AgentsOverviewCreateThread
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
```

#### Create message

With a thread created, messages can be created on it:
```C# Snippet:AgentsOverviewCreateMessage
PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");
```

#### Create and execute run

A run can then be started that evaluates the thread against an agent:
```C# Snippet:AgentsOverviewCreateRun
ThreadRun run = await client.Runs.CreateRunAsync(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
```

Once the run has started, it should then be polled until it reaches a terminal status:
```C# Snippet:AgentsOverviewWaitForRun
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.Runs.GetRunAsync(thread.Id, run.Id);
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
```C# Snippet:AgentsOverviewListUpdatedMessages
AsyncPageable<PersistentThreadMessage> messages
    = client.Messages.GetMessagesAsync(
        threadId: thread.Id, order: ListSortOrder.Ascending);

await foreach (PersistentThreadMessage threadMessage in messages)
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
 2024-10-15 23:12:59 - agent: Yes, Jane Doe, the solution to the equation \(3x + 11 = 14\) is \(x = 1\).
 2024-10-15 23:12:51 - user: I need to solve the equation `3x + 11 = 14`. Can you help me?
```

#### File search

Files can be uploaded and then referenced by agents or messages. First, use the generalized upload API with a
purpose of 'agents' to make a file ID available:
```C# Snippet:AgentsUploadAgentFilesToUse
// Upload a file and wait for it to be processed
System.IO.File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
PersistentAgentFileInfo uploadedAgentFile = await client.Files.UploadFileAsync(
    filePath: "sample_file_for_upload.txt",
    purpose: PersistentAgentFilePurpose.Agents);
Dictionary<string, string> fileIds = new()
{
    { uploadedAgentFile.Id, uploadedAgentFile.Filename }
};
```

Once uploaded, the file ID can then be provided to create a vector store for it
```C# Snippet:AgentsCreateVectorStore
// Create a vector store with the file and wait for it to be processed.
// If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
PersistentAgentsVectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
    fileIds:  new List<string> { uploadedAgentFile.Id },
    name: "my_vector_store");
```

The vectorStore ID can then be provided to an agent upon creation. Note that file search will only be used if an appropriate tool like Code Interpreter is enabled. Also, you do not need to provide toolResources if you did not create a vector store above
```C# Snippet:AgentsCreateAgentWithFiles
FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

// Create an agent with toolResources and process agent run
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
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

```C# Snippet:AgentsCreateVectorStoreBlob
var ds = new VectorStoreDataSource(
    assetIdentifier: blobURI,
    assetType: VectorStoreDataSourceAssetType.UriAsset
);
PersistentAgentsVectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
    name: "sample_vector_store",
    storeConfiguration: new VectorStoreConfiguration(
        dataSources: [ ds ]
    )
);

FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

List<ToolDefinition> tools = [new FileSearchToolDefinition()];
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "my-agent",
    instructions: "You are helpful agent.",
    tools: tools,
    toolResources: new ToolResources() { FileSearch = fileSearchResource }
);
```

We also can attach files to the existing vector store. In the code snippet below, we first create an empty vector store and add file to it.

```C# Snippet:AgentsBatchFileAttachment
var ds = new VectorStoreDataSource(
    assetIdentifier: blobURI,
    assetType: VectorStoreDataSourceAssetType.UriAsset
);
PersistentAgentsVectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
    name: "sample_vector_store"
);

VectorStoreFileBatch vctFile = await client.VectorStores.CreateVectorStoreFileBatchAsync(
    vectorStoreId: vectorStore.Id,
    dataSources: [ ds ]
);
Console.WriteLine($"Created vector store file batch, vector store file batch ID: {vctFile.Id}");

FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);
```

#### Create Message with Code Interpreter Attachment

To attach a file with the context to the message, use the `MessageAttachment` class. To be able to process the attached file contents we need to provide the `List` with the single element `CodeInterpreterToolDefinition` as a `tools` parameter to both `CreateAgent` method and `MessageAttachment` class constructor.

Here is an example to pass `CodeInterpreterTool` as tool:

```C# Snippet:AgentsCreateAgentWithInterpreterTool
List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "my-agent",
    instructions: "You are a helpful agent that can help fetch data from files you know about.",
    tools: tools
);

System.IO.File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
PersistentAgentFileInfo uploadedAgentFile = await client.Files.UploadFileAsync(
    filePath: "sample_file_for_upload.txt",
    purpose: PersistentAgentFilePurpose.Agents);
var fileId = uploadedAgentFile.Id;

var attachment = new MessageAttachment(
    fileId: fileId,
    tools: tools
);

PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "Can you give me the documented codes for 'banana' and 'orange'?",
    attachments: [ attachment ]
);
```

Azure blob storage can be used as a message attachment. In this case, use `VectorStoreDataSource` as a data source:

```C# Snippet:AgentsCreateMessageAttachmentWithBlobStore
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
```C# Snippet:AgentsBingGrounding_GetConnection
BingGroundingToolDefinition bingGroundingTool = new(
    new BingGroundingSearchToolParameters(
        [new BingGroundingSearchConfiguration(connectionId)]
    )
);
```
```C# Snippet:AgentsBingGroundingAsync_CreateAgent
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-agent",
   instructions: "You are a helpful agent.",
   tools: [ bingGroundingTool ]);
```

#### Create Agent with Azure AI Search

Azure AI Search is an enterprise search system for high-performance applications.
It integrates with Azure OpenAI Service and Azure Machine Learning, offering advanced
search technologies like vector search and full-text search. Ideal for knowledge base
insights, information discovery, and automation. Creating an Agent with Azure AI
Search requires an existing Azure AI Search Index. For more information and setup
guides, see [Azure AI Search Tool Guide](https://learn.microsoft.com/azure/ai-services/agents/how-to/tools/azure-ai-search).

```C# Snippet:AgentsCreateAgentWithAzureAISearchTool
AzureAISearchToolResource searchResource = new(
    connectionID,
    "sample_index",
    5,
    "category eq 'sleeping bag'",
    AzureAISearchQueryType.Simple
);
ToolResources toolResource = new()
{
    AzureAISearch = searchResource
};

PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-agent",
   instructions: "You are a helpful agent capable to perform Azure AI Search using attached resources.",
   tools: [ new AzureAISearchToolDefinition() ],
   toolResources: toolResource);
```

If the agent has found the relevant information in the index, the reference
and annotation will be provided in the message response. In the example above, we replace
the reference placeholder by the actual reference and url. Please note, that to
get sensible result, the index needs to have fields "title" and "url".

```C# Snippet:AgentsPopulateReferencesAgentWithAzureAISearchTool
AsyncPageable<PersistentThreadMessage> messages = client.Messages.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

await foreach (PersistentThreadMessage threadMessage in messages)
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
                    if (annotation is MessageTextUriCitationAnnotation uriAnnotation)
                    {
                        annotatedText = annotatedText.Replace(
                            uriAnnotation.Text,
                            $" [see {uriAnnotation.UriCitation.Title}] ({uriAnnotation.UriCitation.Uri})");
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

#### Function call executed manually

Tools that reference caller-defined capabilities as functions can be provided to an agent to allow it to
dynamically resolve and disambiguate during a run.

Here, outlined is a simple agent that "knows how to," via caller-provided functions:

1. Get the user's favorite city
1. Get a nickname for a given city
1. Get the current weather, optionally with a temperature unit, in a city

To do this, begin by defining the functions to use -- the actual implementations here are merely representative stubs.

```C# Snippet:AgentsFunctionsDefineFunctionTools
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

```C# Snippet:AgentsFunctionsCreateAgentWithFunctionTools
// NOTE: parallel function calling is only supported with newer models like gpt-4-1106-preview
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
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

```C# Snippet:AgentsFunctionsHandleFunctionCalls
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

```C# Snippet:AgentsFunctionsHandlePollingWithRequiredAction
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.Runs.GetRunAsync(thread.Id, run.Id);

    if (run.Status == RunStatus.RequiresAction
        && run.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
    {
        List<ToolOutput> toolOutputs = [];
        foreach (RequiredToolCall toolCall in submitToolOutputsAction.ToolCalls)
        {
            toolOutputs.Add(GetResolvedToolOutput(toolCall));
        }
        run = await client.Runs.SubmitToolOutputsToRunAsync(run, toolOutputs,toolApprovals: null);
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

```C# Snippet:AgentsFunctionsWithStreamingUpdateHandling
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
We create a stream and wait for the stream update of the `RequiredActionUpdate` type. This update will mark the point, when we need to submit tool outputs to the stream. We will submit outputs to the new stream. Please note that `RequiredActionUpdate` keeps only one required action, while our run may require multiple function calls. After all required actions were submitted we clean up the array of required actions.

```C# Snippet:AgentsFunctionsWithStreamingUpdateCycle
List<ToolOutput> toolOutputs = [];
ThreadRun streamRun = null;
AsyncCollectionResult<StreamingUpdate> stream = client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id);
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
        else if (streamingUpdate.UpdateKind == StreamingUpdateReason.Error && streamingUpdate is RunUpdate errorStep)
        {
            Console.WriteLine($"Error: {errorStep.Value.LastError}");
        }
    }
    if (toolOutputs.Count > 0)
    {
        stream = client.Runs.SubmitToolOutputsToStreamAsync(streamRun, toolOutputs);
    }
}
while (toolOutputs.Count > 0);
```

#### Function call executed automatically

In addition to the manual function calls, SDK supports automatic function calling.  After creating functions and`FunctionToolDefinition` according to the last section, here is the steps:

When you create an agent, you can specify the function call by tools argument similar to the example of manual function calls:
```C# Snippet:StreamingWithAutoFunctionCall_CreateAgent
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = client.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "SDK Test Agent - Functions",
        instructions: "You are a weather bot. Use the provided functions to help answer questions. "
            + "Customize your responses to the user's preferences as much as possible and use friendly "
            + "nicknames for cities whenever possible.",
    tools: [getCityNicknameTool, getCurrentWeatherAtLocationTool, getUserFavoriteCityTool]
);
```

We create a thread and message similar to the example of manual function tool calls:
```C# Snippet:StreamingWithAutoFunctionCall_CreateThreadMessage
PersistentAgentThread thread = client.Threads.CreateThread();

PersistentThreadMessage message = client.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What's the weather like in my favorite city?");
```

Setup `AutoFunctionCallOptions`:
```C# Snippet:StreamingWithAutoFunctionCall_EnableAutoFunctionCalls
List<ToolOutput> toolOutputs = new();
Dictionary<string, Delegate> toolDelegates = new();
toolDelegates.Add(nameof(GetWeatherAtLocation), GetWeatherAtLocation);
toolDelegates.Add(nameof(GetCityNickname), GetCityNickname);
toolDelegates.Add(nameof(GetUserFavoriteCity), GetUserFavoriteCity);
AutoFunctionCallOptions autoFunctionCallOptions = new(toolDelegates, 10);
```

With autoFunctionCallOptions as parameter for `CreateRunStreamingAsync`, the agent will then call the function automatically when it is needed:
```C# Snippet:StreamingWithAutoFunctionCallAsync
CreateRunStreamingOptions runOptions = new()
{
    AutoFunctionCallOptions = autoFunctionCallOptions
};
await foreach (StreamingUpdate streamingUpdate in client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id, options: runOptions))
{
    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
    {
        Console.WriteLine("--- Run started! ---");
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
```
To allow the agent cast the parameters to the function call, you must use the supported argument types.  They are `string`, `int`, `ushort`, `float`, `uint`, `decimal`, `double`, `long`, and `bool`.   Other tpes such as array, dictionary, or classes are not supported.   

#### Azure function call

We can use Azure Function from inside the agent. In the example below we are calling function "foo", which responds "Bar". In this example we create `AzureFunctionToolDefinition` object, with the function name, description, input and output queues, followed by function parameters. See below for the instructions on function deployment.
```C# Snippet:AgentsAzureFunctionsDefineFunctionTools
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var storageQueueUri = System.Environment.GetEnvironmentVariable("STORAGE_QUEUE_URI");

PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

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
```C# Snippet:AgentsAzureFunctionsCreateAgentWithFunctionTools
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
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
```C# Snippet:AgentsAzureFunctionsHandlePollingWithRequiredAction
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the most prevalent element in the universe? What would foo say?");

ThreadRun run = await client.Runs.CreateRunAsync(thread, agent);

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.Runs.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress
    || run.Status == RunStatus.RequiresAction);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

**Note:** The Azure Function may be only used in standard agent setup. Please follow the [instruction](https://github.com/azure-ai-foundry/foundry-samples/tree/main/samples/microsoft/infrastructure-setup/41-standard-agent-setup) to deploy an agent, capable of calling Azure Functions.
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
        [QueueOutput("azure-function-tool-output", Connection = "AzureWebJobsStorage")]
        public string Run([QueueTrigger("azure-function-foo-input")] Arguments input, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Foo");
            logger.LogInformation("C# Queue function processed a request.");

            var response = new Response
            {
                Value = "Bar",
                // Important! Correlation ID must match the input correlation ID.
                CorrelationId = input.CorrelationId
            };

            return JsonSerializer.Serialize(response);
        }
    }
}
```

In this code we define function input and output classes: `Arguments` and `Response` respectively. These two data classes will be serialized in JSON. It is important that the both contain field `CorrelationId`, which is the same between input and output. `Connection` contains the name of environment variable `AzureWebJobsStorage` on function app resource. This variable contains connection string to the storage account, with input and output queue. It can be found in the Settings>Environment variables section of the function app resource in Azure portal.

In our example the function will be stored in the storage account, created with the AI hub. For that we need to allow key access to that storage. In Azure portal go to Storage account > Settings > Configuration and set "Allow storage account key access" to Enabled. If it is not done, the error will be displayed "The remote server returned an error: (403) Forbidden." To create the function resource that will host our function, install [azure-cli](https://pypi.org/project/azure-cli/) python package and run the next command:

```shell
pip install -U azure-cli
az login
az functionapp create --resource-group your-resource-group --consumption-plan-location region --runtime dotnet-isolated --functions-version 4 --name function_name --storage-account storage_account_already_present_in_resource_group --app-insights existing_or_new_application_insights_name
```

Now we will create the function itself. Install [.NET](https://dotnet.microsoft.com/download) and [Core Tools](https://go.microsoft.com/fwlink/?linkid=2174087) and create the function project using next commands. 
```
func init FunctionProj --worker-runtime dotnet-isolated --target-framework net8.0
cd FunctionProj
func new --name foo --template "HTTP trigger" --authlevel "anonymous"
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

After the processing, the output queue should contain the message with the following contents:
```json
{
  "Value": "Bar",
  "CorrelationId": "42"
}
```
Please note that the input `CorrelationId` value is the same as in the output.
*Hint:* Place multiple messages to input queue and keep second internet browser window with the output queue open, hit the refresh button on the portal user interface, so that you will not miss the message. If the function completed with error the message instead gets into the `azure-function-foo-input-poison` queue. If that happened, please check your setup.
After we have tested the function and confirmed that it works, please make sure that the Azure AI Project have the next roles for the storage account: `Storage Account Contributor`, `Storage Blob Data Contributor`, `Storage File Data Privileged Contributor`, `Storage Queue Data Contributor` and `Storage Table Data Contributor`. Now the function is ready to be used by the agent.


#### Create Agent With OpenAPI

OpenAPI specifications describe REST operations against a specific endpoint. Agents SDK can read an OpenAPI spec, create a function from it, and call that function against the REST endpoint without additional client-side execution.

Here is an example creating an OpenAPI tool (using anonymous authentication):
```C# Snippet:AgentsOpenAPIDefineFunctionTools
OpenApiAnonymousAuthDetails oaiAuth = new();
OpenApiToolDefinition openapiTool = new(
    name: "get_weather",
    description: "Retrieve weather information for a location",
    spec: BinaryData.FromBytes(System.IO.File.ReadAllBytes(file_path)),
    openApiAuthentication: oaiAuth,
    defaultParams: [ "format" ]
);

// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "azure-function-agent-foo",
    instructions: "You are a helpful agent.",
    tools: [ openapiTool ]
);
```

In this example we are using the `weather_openapi.json` file and agent will request the [wttr.in](https://wttr.in) website for the weather in a location from the prompt.
```C# Snippet:AgentsOpenAPIHandlePollingWithRequiredAction
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What's the weather in Seattle?");

ThreadRun run = await client.Runs.CreateRunAsync(thread, agent);

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.Runs.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress
    || run.Status == RunStatus.RequiresAction);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```
`

#### Tracing

You can add an Application Insights Azure resource to your Azure AI Foundry project. See the Tracing tab in your AI Foundry project. If one was enabled, you use the Application Insights connection string, configure your Agents, and observe the full execution path through Azure Monitor. Typically, you might want to start tracing before you create an Agent.

Tracing requires enabling OpenTelemetry support. One way to do this is to set the `AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE` environment variable value to `true`. You can also enable the feature with the following code:
```C# Snippet:EnableActivitySourceToGetTraces
AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);
```

To enabled content recording, set the `AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED` environment variable to `true`. Content in this context refers to chat message content, function call tool related function names, function parameter names and values. Alternatively, you can control content recording with the following code:
```C# Snippet:DisableContentRecordingForTraces
AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);
```
Set the value to `true` to enable content recording.

##### Tracing to Azure Monitor
First, set the `APPLICATIONINSIGHTS_CONNECTION_STRING` environment variable to point to your Azure Monitor resource.

For tracing to Azure Monitor from your application, the preferred option is to use Azure.Monitor.OpenTelemetry.AspNetCore. Install the package with [NuGet](https://www.nuget.org/ ):
```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore
```

More information about using the Azure.Monitor.OpenTelemetry.AspNetCore package can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/README.md ).

Another option is to use Azure.Monitor.OpenTelemetry.Exporter package. Install the pacakge with [NuGet](https://www.nuget.org/ )
```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry.Exporter
```

Here is an example how to set up tracing to Azure monitor using Azure.Monitor.OpenTelemetry.Exporter:
```C# Snippet:AgentsTelemetrySetupTracingToAzureMonitor
var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("Azure.AI.Agents.Persistent.*")
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
    .AddAzureMonitorTraceExporter().Build();
```

##### Tracing to Console

For tracing to console from your application, install the OpenTelemetry.Exporter.Console with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package OpenTelemetry.Exporter.Console
```


Here is an example how to set up tracing to console:
```C# Snippet:AgentsTelemetrySetupTracingToConsole
var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("Azure.AI.Agents.Persistent.*") // Add the required sources name
                .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                .AddConsoleExporter() // Export traces to the console
                .Build();
```

## Troubleshooting

Any operation that fails will throw a [RequestFailedException][RequestFailedException]. The exception's `code` will hold the HTTP response status code. The exception's `message` contains a detailed message that may be helpful in diagnosing the issue:

```C# Snippet:AgentsReadme_Troubleshooting
try
{
    client.Messages.CreateMessage(
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

Beyond the introductory scenarios discussed, the AI Agents client library offers support for additional scenarios to help take advantage of the full feature set of the AI services.  In order to help explore some of these scenarios, the AI Agents client library offers a set of samples to serve as an illustration for common scenarios.  Please see the [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Agents.Persistent/samples) for details.

## Contributing

See the [Azure SDK CONTRIBUTING.md][aiprojects_contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[RequestFailedException]: https://learn.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Agents.Persistent/tests/Samples
[api_ref_docs]: https://learn.microsoft.com/dotnet/api/overview/azure/ai.agents.persistent-readme
[nuget]: https://www.nuget.org/packages/Azure.AI.Agents.Persistent/
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Agents.Persistent
[product_doc]: https://learn.microsoft.com/azure/ai-studio/
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[azure_identity_dac]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[aiprojects_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
