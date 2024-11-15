# Azure AI Projects client library for .NET
Use the AI Projects client library to:

* **Develop Agents using the Azure AI Agent Service**, leveraging an extensive ecosystem of models, tools, and capabilities from OpenAI, Microsoft, and other LLM providers. The Azure AI Agent Service enables the building of Agents for a wide range of generative AI use cases. The package is currently in preview.
* **Enumerate connections** in your Azure AI Studio project and get connection properties. For example, get the inference endpoint URL and credentials associated with your Azure OpenAI connection.

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
    - [Function call](#function-call)
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
    model: "gpt-4-1106-preview",
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

Beyond the introductory scenarios discussed, the AI Projects client library offers support for additional scenarios to help take advantage of the full feature set of the AI services.  In order to help explore some of these scenarios, the AI Projects client library offers a set of samples to serve as an illustration for common scenarios.  Please see the `Azure.AI.Projects/tests/Samples` for details.

## Contributing

See the [Azure SDK CONTRIBUTING.md][aiprojects_contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[RequestFailedException]: https://learn.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[azure_identity_dac]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[aiprojects_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/ai/Azure.AI.Projects/README.png)
