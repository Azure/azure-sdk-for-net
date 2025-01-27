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
    - [Function call](#function-call)
    - [Azure function call](#azure-function-call)
    - [Azure Function Call](#create-agent-with-azure-function-call)
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
var connectionString = Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());
```

With an authenticated client, an agent can be created:
```C# Snippet:OverviewCreateAgent
Response<Agent> agentResponse = await client.CreateAgentAsync(
    model: "gpt-4-1106-preview",
    name: "Math Tutor",
    instructions: "You are a personal math tutor. Write and run code to answer math questions.",
    tools: new List<ToolDefinition> { new CodeInterpreterToolDefinition() });
Agent agent = agentResponse.Value;
```

#### Create thread

Next, create a thread:
```C# Snippet:OverviewCreateThread
Response<AgentThread> threadResponse = await client.CreateThreadAsync();
AgentThread thread = threadResponse.Value;
```

#### Create message

With a thread created, messages can be created on it:
```C# Snippet:OverviewCreateMessage
Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");
ThreadMessage message = messageResponse.Value;
```

#### Create and execute run

A run can then be started that evaluates the thread against an agent:
```C# Snippet:OverviewCreateRun
Response<ThreadRun> runResponse = await client.CreateRunAsync(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
ThreadRun run = runResponse.Value;
```

Once the run has started, it should then be polled until it reaches a terminal status:
```C# Snippet:OverviewWaitForRun
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);
}
while (runResponse.Value.Status == RunStatus.Queued
    || runResponse.Value.Status == RunStatus.InProgress);
```

#### Retrieve messages

Assuming the run successfully completed, listing messages from the thread that was run will now reflect new information
added by the agent:
```C# Snippet:OverviewListUpdatedMessages
Response<PageableList<ThreadMessage>> afterRunMessagesResponse
    = await client.GetMessagesAsync(thread.Id);
IReadOnlyList<ThreadMessage> messages = afterRunMessagesResponse.Value.Data;

// Note: messages iterate from newest to oldest, with the messages[0] being the most recent
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
Response<AgentFile> uploadAgentFileResponse = await client.UploadFileAsync(
    filePath: "sample_file_for_upload.txt",
    purpose: AgentFilePurpose.Agents);

AgentFile uploadedAgentFile = uploadAgentFileResponse.Value;
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
Response<Agent> agentResponse = await client.CreateAgentAsync(
        model: "gpt-4-1106-preview",
        name: "SDK Test Agent - Retrieval",
        instructions: "You are a helpful agent that can help fetch data from files you know about.",
        tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
        toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
Agent agent = agentResponse.Value;
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
var vectorStoreTask = await client.CreateVectorStoreAsync(
    name: "sample_vector_store",
    storeConfiguration: new VectorStoreConfiguration(
        dataSources: new List<VectorStoreDataSource> { ds }
    )
);
var vectorStore = vectorStoreTask.Value;

FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

List<ToolDefinition> tools = [new FileSearchToolDefinition()];
Response<Agent> agentResponse = await client.CreateAgentAsync(
    model: modelName,
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
var vectorStoreTask = await client.CreateVectorStoreAsync(
    name: "sample_vector_store"
);
var vectorStore = vectorStoreTask.Value;

var uploadTask = await client.CreateVectorStoreFileBatchAsync(
    vectorStoreId: vectorStore.Id,
    dataSources: new List<VectorStoreDataSource> { ds }
);
Console.WriteLine($"Created vector store file batch, vector store file batch ID: {uploadTask.Value.Id}");

FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);
```

#### Create Message with Code Interpreter Attachment

To attach a file with the context to the message, use the `MessageAttachment` class. To be able to process the attached file contents we need to provide the `List` with the single element `CodeInterpreterToolDefinition` as a `tools` parameter to both `CreateAgent` method and `MessageAttachment` class constructor.

Here is an example to pass `CodeInterpreterTool` as tool:

```C# Snippet:CreateAgentWithInterpreterTool
AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());

List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
Response<Agent> agentResponse = await client.CreateAgentAsync(
    model: modelName,
    name: "my-assistant",
    instructions: "You are helpful assistant.",
    tools: tools
);
Agent agent = agentResponse.Value;

var fileResponse = await client.UploadFileAsync(filePath, AgentFilePurpose.Agents);
var fileId = fileResponse.Value.Id;

var attachment = new MessageAttachment(
    fileId: fileId,
    tools: tools
);

Response<AgentThread> threadResponse = await client.CreateThreadAsync();
AgentThread thread = threadResponse.Value;

Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What does the attachment say?",
    attachments: new List< MessageAttachment > { attachment}
    );
ThreadMessage message = messageResponse.Value;
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
Response<Agent> agentResponse = await client.CreateAgentAsync(
    model: modelName,
    name: "SDK Test Agent - Functions",
        instructions: "You are a weather bot. Use the provided functions to help answer questions. "
            + "Customize your responses to the user's preferences as much as possible and use friendly "
            + "nicknames for cities whenever possible.",
    tools: new List<ToolDefinition> { getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool }
    );
Agent agent = agentResponse.Value;
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
    runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);

    if (runResponse.Value.Status == RunStatus.RequiresAction
        && runResponse.Value.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
    {
        List<ToolOutput> toolOutputs = new();
        foreach (RequiredToolCall toolCall in submitToolOutputsAction.ToolCalls)
        {
            toolOutputs.Add(GetResolvedToolOutput(toolCall));
        }
        runResponse = await client.SubmitToolOutputsToRunAsync(runResponse.Value, toolOutputs);
    }
}
while (runResponse.Value.Status == RunStatus.Queued
    || runResponse.Value.Status == RunStatus.InProgress);
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

We parse streaming updates in two cycles. One iterates over the streaming run outputs and when we are getting update, requiring the action, we are starting the second cycle, which iterates over the outputs of the same run, after submission of the local functions calls results.

```C# Snippet:FunctionsWithStreamingUpdateCycle
List<ToolOutput> toolOutputs = new();
ThreadRun streamRun = null;
await foreach (StreamingUpdate streamingUpdate in client.CreateRunStreamingAsync(thread.Id, agent.Id))
{
    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
    {
        Console.WriteLine("--- Run started! ---");
    }
    else if (streamingUpdate is RequiredActionUpdate submitToolOutputsUpdate)
    {
        streamRun = submitToolOutputsUpdate.Value;
        RequiredActionUpdate newActionUpdate = submitToolOutputsUpdate;
        while (streamRun.Status == RunStatus.RequiresAction) {
            toolOutputs.Add(
                GetResolvedToolOutput(
                    newActionUpdate.FunctionName,
                    newActionUpdate.ToolCallId,
                    newActionUpdate.FunctionArguments
            ));
            await foreach (StreamingUpdate actionUpdate in client.SubmitToolOutputsToStreamAsync(streamRun, toolOutputs))
            {
                if (actionUpdate is MessageContentUpdate contentUpdate)
                {
                    Console.Write(contentUpdate.Text);
                }
                else if (actionUpdate is RequiredActionUpdate newAction)
                {
                    newActionUpdate = newAction;
                }
                else if (actionUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
                {
                    Console.WriteLine();
                    Console.WriteLine("--- Run completed! ---");
                }
            }
            streamRun = client.GetRun(thread.Id, streamRun.Id);
            toolOutputs.Clear();
        }
        break;
    }
    else if (streamingUpdate is MessageContentUpdate contentUpdate)
    {
        Console.Write(contentUpdate.Text);
    }
}
```

#### Azure function call

We also can use Azure Function from inside the agent. In the example below we are calling function "foo", which responds "Bar". In this example we create `AzureFunctionToolDefinition` object, with the function name, description, input and output queues, followed by function parameters.  
```C# Snippet:AzureFunctionsDefineFunctionTools
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
Response<Agent> agentResponse = await client.CreateAgentAsync(
    model: "gpt-4",
    name: "azure-function-agent-foo",
        instructions: "You are a helpful support agent. Use the provided function any "
        + "time the prompt contains the string 'What would foo say?'. When you invoke "
        + "the function, ALWAYS specify the output queue uri parameter as "
        + $"'{storageQueueUri}/azure-function-tool-output'. Always responds with "
        + "\"Foo says\" and then the response from the tool.",
    tools: new List<ToolDefinition> { azureFnTool }
    );
Agent agent = agentResponse.Value;
```

After we have created a message with request to ask "What would foo say?", we need to wait while the run is in queued, in progress or requires action states.
```C# Snippet:AzureFunctionsHandlePollingWithRequiredAction
Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the most prevalent element in the universe? What would foo say?");
ThreadMessage message = messageResponse.Value;

Response<ThreadRun> runResponse = await client.CreateRunAsync(thread, agent);

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);
}
while (runResponse.Value.Status == RunStatus.Queued
    || runResponse.Value.Status == RunStatus.InProgress
    || runResponse.Value.Status == RunStatus.RequiresAction);
```

#### Create Agent With OpenAPI

OpenAPI specifications describe REST operations against a specific endpoint. Agents SDK can read an OpenAPI spec, create a function from it, and call that function against the REST endpoint without additional client-side execution.

Here is an example creating an OpenAPI tool (using anonymous authentication):
```C# Snippet:OpenAPIDefineFunctionTools
OpenApiAnonymousAuthDetails oaiAuth = new();
OpenApiToolDefinition openapiTool = new(
    name: "get_weather",
    description: "Retrieve weather information for a location",
    spec: BinaryData.FromBytes(File.ReadAllBytes(file_path)),
    auth: oaiAuth
);

Response<Agent> agentResponse = await client.CreateAgentAsync(
    model: "gpt-4",
    name: "azure-function-agent-foo",
    instructions: "You are a helpful assistant.",
    tools: new List<ToolDefinition> { openapiTool }
    );
Agent agent = agentResponse.Value;
```

In this example we are using the `weather_openapi.json` file and agent will request the wttr.in website for the weather in a location fron the prompt.
```C# Snippet:OpenAPIHandlePollingWithRequiredAction
Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What's the weather in Seattle?");
ThreadMessage message = messageResponse.Value;

Response<ThreadRun> runResponse = await client.CreateRunAsync(thread, agent);

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);
}
while (runResponse.Value.Status == RunStatus.Queued
    || runResponse.Value.Status == RunStatus.InProgress
    || runResponse.Value.Status == RunStatus.RequiresAction);
```

## Troubleshooting

Any operation that fails will throw a [RequestFailedException][RequestFailedException]. The exception's `code` will hold the HTTP response status code. The exception's `message` contains a detailed message that may be helpful in diagnosing the issue:

```C# Snippet:Readme_Troubleshooting
try
{
    client.CreateMessage(
    "1234",
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

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/ai/Azure.AI.Projects/README.png)
