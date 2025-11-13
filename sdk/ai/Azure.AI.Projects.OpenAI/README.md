# Azure AI Projects OpenAI client library for .NET

Develop Agents using the Azure AI Foundry platform, leveraging an extensive ecosystem of models, tools, and capabilities from OpenAI, Microsoft, and other LLM providers.

**Note:** This package can be used to create requests to the _existing_ agents. It was split from Azure.AI.Projects because the create, update, and delete operations on agents are recommended to be used with enhanced privileges. The Projects library provides simplified access to advanced functionality, such as creating and managing Agents, enumerating AI models, working with datasets, managing search indexes, evaluating generative AI performance, and enabling OpenTelemetry tracing. In this tutorial we are showing how to create agents with the specific data mining functionalities provided by tools.

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
  - [Authenticate the client](#authenticate-the-client)
  - [Service API versions](#service-api-versions)
  - [Select a service API version](#select-a-service-api-version)
- [Additional concepts](#additional-concepts)
- [Examples]
  - [Prompt Agents](#prompt-agents)
    - [Agents](#agents)
    - [Responses](#responses)
    - [Coversations](#coversations)
  - [Container App](#container-app)
  - [File search](#file-search)
  - [Code interpreter](#code-interpreter)
  - [Computer use](#computer-use)
  - [Function call](#function-call)
- [Tracing](#tracing)
  - [Tracing to Azure Monitor](#tracing-to-azure-monitor)
  - [Tracing to Console](#tracing-to-console)
- [Troubleshooting](#troubleshooting)
- [Next steps](#next-steps)
- [Contributing](#contributing)

## Getting started

### Prerequisites

To use Azure AI Agents capabilities, you must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/). This will allow you to create an Azure AI resource and get a connection URL.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.Orojects.OpenAI --prerelease
```

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.

## Key concepts

### Authenticate the client

To be able to create, update and delete Agent, please install `Azure.AI.Projects` and use `AIProjectClient`. It is a good practice to only allow this operation for users with elevated permissions, for example, administrators.

```C# Snippet:CreateAgentClientDirectlyFromProjectEndpoint
AIProjectClient projectClient = new(
    endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
    tokenProvider: new AzureCliCredential());
AIProjectAgentsOperations agentClient = projectClient.Agents;
```

If you're already using an `AIProjectClient` from `Azure.AI.Projects`, you can initialize an `ProjectOpenAIClient` instance directly via an extension method:

```C# Snippet:CreateAgentClientFromProjectsClient
AIProjectClient projectClient = new(
    endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
    tokenProvider: new AzureCliCredential());
ProjectOpenAIClient agentClient = projectClient.OpenAI;
```

For operations based on OpenAI APIs like `/responses`, `/files`, and `/vector_stores`, you can retrieve `OpenAIResponseClient`, `OpenAIFileClient` and `VectorStoreClient` through the appropriate helper methods:

```C# Snippet:GetOpenAIClientsFromProjects
ProjectOpenAIResponseClient responseClient = projectClient.OpenAI.GetProjectOpenAIResponseClientForAgent("AGENT_NAME");
OpenAIFileClient fileClient = projectClient.OpenAI.GetOpenAIFileClient();
VectorStoreClient vectorStoreClient = projectClient.OpenAI.GetVectorStoreClient();
```

### Service API versions

When clients send REST requests to the endpoint, one of the query parameters is `api-version`. It allows us to select the API versions supporting different features. Currently supported values for API versions are `2025-11-01` and `2025-11-15-preview` (default).

#### Select a service API version

The API version may be set supplying `version` parameter to `AgentClientOptions` constructor as shown in the example code below.

```C# Snippet:SelectAPIVersion
ProjectOpenAIClientOptions option = new()
{
    ApiVersion = "2025-11-15-preview"
};
ProjectOpenAIClient projectClient = new(
    projectEndpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
    tokenProvider: new AzureCliCredential());
```

### Additional concepts
The Azure.AI.Projects.OpenAI framework organized in a way that for each call, requiring the REST API request, there are synchronous and asynchronous counterparts where the letter has the "Async" suffix. For example, the following code demonstrates the creation of a `OpenAIResponse` object.

Synchronous call:
```C# Snippet:Sample_CreateResponse_Sync
OpenAIResponseClient responseClient = client.GetProjectOpenAIResponseClientForModel(modelDeploymentName);
OpenAIResponse response = responseClient.CreateResponse("What is the size of France in square miles?");
```

Asynchronous call:

```C# Snippet:Sample_CreateResponse_Async
OpenAIResponseClient responseClient = client.GetProjectOpenAIResponseClientForModel(modelDeploymentName);
OpenAIResponse response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");
```

In the most of code snippets we will show only asynchronous sample for brevity. Please refer individual [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Orojects.OpenAI/samples) for both synchronous and asynchronous code.

## Examples

### Prompt Agents

#### Agents

**Note:** Please intall `Azure.AI.Projects` to manipulate Agents.
When creating the Agents we need to supply Agent definitions to its constructor. To create a declarative prompt Agent, use the `PromptAgentDefinition`:

```C# Snippet:CreateAPromptAgent
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");

AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());

AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
{
    Instructions = "You are a foo bar agent. In EVERY response you give, ALWAYS include both `foo` and `bar` strings somewhere in the response.",
};

AgentVersion newAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: AGENT_NAME,
    options: new(agentDefinition));
Console.WriteLine($"Created new agent version: {newAgentVersion.Name}");
```

The code above will result in creation of `AgentVersion` object, which is the data object containing Agent's name and version.

#### Responses

OpenAI API allows you to get the response without creating an agent by using the response API. In this scenario we first create the response object.

```C# Snippet:Sample_CreateResponse_Async
OpenAIResponseClient responseClient = client.GetProjectOpenAIResponseClientForModel(modelDeploymentName);
OpenAIResponse response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");
```

After the response was created we need to wait for it to complete.

```C# Snippet:Sample_WriteOutput_ResponseBasic_Async
while (response.Status != ResponseStatus.Incomplete || response.Status != ResponseStatus.Failed || response.Status != ResponseStatus.Completed)
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    response = await responseClient.GetResponseAsync(responseId: response.Id);
}

Console.WriteLine(response.GetOutputText());
```

Alternatively, we can stream the response.
```C# Snippet:Sample_WriteOutput_ResponseStreaming_Async
await foreach (StreamingResponseUpdate streamResponse in responsesClient.CreateResponseStreamingAsync("What is the size of France in square miles?"))
{
    if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
    {
        Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
    }
    else if (streamResponse is StreamingResponseOutputTextDeltaUpdate textDelta)
    {
        Console.WriteLine($"Delta: {textDelta.Delta}");
    }
    else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
    {
        Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
    }
    else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
    {
        throw new InvalidOperationException($"The stream has failed with the error: {errorUpdate.Message}");
    }
}
```

Responses can be used with the agents. First we need to create an `AgentVersion` object.

```C# Snippet:CreateAgent_Basic_Async
PromptAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
{
    Instructions = "You are a physics teacher with a sense of humor.",
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition)
);
```

To associate the Response with the Agent the agent reference needs to be created. It is done by calling `GetProjectOpenAIResponseClientForAgent` method.

```C# Snippet:CreateResponseBasic_Async
var agentReference = new AgentReference(name: agentVersion.Name);
ProjectOpenAIResponseClient responseClient = openaiClient.GetProjectOpenAIResponseClientForAgent(agentReference);
ResponseCreationOptions responseCreationOptions = new();
OpenAIResponse response = await responseClient.CreateResponseAsync(
    [ResponseItem.CreateUserMessageItem("Write Maxwell's eqution in LaTeX format.")],
    responseCreationOptions);
Console.WriteLine(response.GetOutputText());
```

Previous Response ID may be used to ask follow up questions. In this case we need to set `PreviousResponseId` property on `ResponseCreationOptions` object.

```C# Snippet:FollowUp_Basic_Async
responseCreationOptions.PreviousResponseId = response.Id;
response = await responseClient.CreateResponseAsync(
    [ResponseItem.CreateUserMessageItem("What was the previous question?")],
    responseCreationOptions);
Console.WriteLine(response.GetOutputText());
```

Finally, we can delete Agent.

```C# Snippet:CleanUp_Basic_Async
await projectClient.Agents.DeleteAgentAsync(agentName: "myAgent");
```

#### Coversations

Conversations may be used to store the history of interaction with the agent. To add the responses to a conversation,
set the conversation parameter while calling `GetProjectOpenAIResponseClientForAgent`.

```C# Snippet:ConversationClient
ResponseCreationOptions responseCreationOptions = new();
// Optionally, use a conversation to automatically maintain state between calls.
AgentConversation conversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync();
ProjectOpenAIResponseClient responseClient = projectClient.OpenAI.GetProjectOpenAIResponseClientForAgent(AGENT_NAME, conversation);
```

Conversations may be deleted to clean up the resources.

```C# Snippet:DeleteConversationClient
await openAIClient.GetConversationClient().DeleteConversationAsync(conversation.Id);
```

The conversation may be used to communicate messages to the agent.

```C# Snippet:ExistingConversations
ProjectConversationCreationOptions conversationOptions = new()
{
    Items = { ResponseItem.CreateSystemMessageItem("Your preferred genre of story today is: horror.") },
    Metadata = { ["foo"] = "bar" },
};
AgentConversation conversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync(conversationOptions);

//
// Add items to an existing conversation to supplement the interaction state
//
string EXISTING_CONVERSATION_ID = conversation.Id;

_ = await projectClient.OpenAI.Conversations.CreateAgentConversationItemsAsync(
    EXISTING_CONVERSATION_ID,
    [ResponseItem.CreateSystemMessageItem(inputTextContent: "Story theme to use: department of licensing.")]);
//
// Use the agent and conversation in a response
//
ProjectOpenAIResponseClient responseClient = projectClient.OpenAI.GetProjectOpenAIResponseClientForAgent(AGENT_NAME);
ResponseCreationOptions responseCreationOptions = new()
{
    AgentConversationId = EXISTING_CONVERSATION_ID,
};

List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Tell me a one-line story.")];
OpenAIResponse response = await responseClient.CreateResponseAsync(items, responseCreationOptions);
```

### Container App

[Azure Container App](https://learn.microsoft.com/azure/container-apps/ai-integration) may act as an agent if it implements the OpenAI-like protocol. Azure.AI.Orojects.OpenAI allow you to interact with these applications as with regular agents. The main difference is that in this case agent needs to be created with `ContainerAppAgentDefinition`. This agent can be used in responses API as a regular agent.

```C# Snippet:Sample_CreateContainerApp_ContainerApp_Async
AgentVersion containerAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "containerAgent",
    options: new(new ContainerApplicationAgentDefinition(
        containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
        containerAppResourceId: containerAppResourceId,
        ingressSubdomainSuffix: ingressSubdomainSuffix)));
```

### File search

If Agents are provided with `FileSearchTool`, they can give the responses based on the information from the uploaded file(s).
Here are the steps needed to implement the file search. Upload the file:

```C# Snippet:Sample_UploadFile_FileSearch_Async
string filePath = "sample_file_for_upload.txt";
File.WriteAllText(
    path: filePath,
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
OpenAIFileClient fileClient = projectClient.OpenAI.GetOpenAIFileClient();
OpenAIFile uploadedFile = await fileClient.UploadFileAsync(filePath: filePath, purpose: FileUploadPurpose.Assistants);
File.Delete(filePath);
```

Add it to `VectorStore`:

```C# Snippet:Sample_CreateVectorStore_FileSearch_Async
VectorStoreClient vctStoreClient = projectClient.OpenAI.GetVectorStoreClient();
VectorStoreCreationOptions options = new()
{
    Name = "MySampleStore",
    FileIds = { uploadedFile.Id }
};
VectorStore vectorStore = await vctStoreClient.CreateVectorStoreAsync(options);
```

Finally, create the tool, aware of the vector store and add it to the Agent.

```C# Snippet:Sample_CreateAgent_FileSearch_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can help fetch data from files you know about.",
    Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]), }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

### Code interpreter

The `CodeInterpreterTool` allows Agents to run the code in the container. Here are the steps needed to run Code interpreter.
Create an Agent:

```C# Snippet:Sample_CreateAgent_CodeInterpreter_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a personal math tutor. When asked a math question, write and run code using the python tool to answer the question.",
    Tools = {
        ResponseTool.CreateCodeInterpreterTool(
            new CodeInterpreterToolContainer(
                CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
            )
        ),
    }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Now we can ask the agent a question, which requires running python code in the container.

```C# Snippet:Sample_CreateResponse_CodeInterpreter_Async
OpenAIResponseClient responseClient = projectClient.OpenAI.GetOpenAIResponseClient(modelDeploymentName);
ResponseCreationOptions responseOptions = new();
responseOptions.Agent = agentVersion;

ResponseItem request = ResponseItem.CreateUserMessageItem("I need to solve the equation sin(x) + x^2 = 42");
OpenAIResponse response = await responseClient.CreateResponseAsync(
    [request],
    responseOptions);
```

### Computer tool

`ComputerTool` allows Agents to assist customer in computer related tasks. Its constructor is provided with description of an operation system and screen resolution.

```C# Snippet:Sample_CreateAgent_ComputerUse_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a computer automation assistant.\n\n" +
                   "Be direct and efficient. When you reach the search results page, read and describe the actual search result titles and descriptions you can see.",
    Tools = {
        ResponseTool.CreateComputerTool(
            environment: new ComputerToolEnvironment("windows"),
            displayWidth: 1026,
            displayHeight: 769
        ),
    }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition)
);
```

Users can create a message to the Agent, which contains text and screenshots.

```C# Snippet:Sample_CreateResponse_ComputerUse_Async
ProjectOpenAIResponseClient responseClient = projectClient.OpenAI.GetProjectOpenAIResponseClientForAgent(agentVersion.Name);
ResponseCreationOptions responseOptions = new();
responseOptions.TruncationMode = ResponseTruncationMode.Auto;
ResponseItem request = ResponseItem.CreateUserMessageItem(
    [
        ResponseContentPart.CreateInputTextPart("I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete."),
        ResponseContentPart.CreateInputImagePart(imageBytes: screenshots["browser_search"], imageBytesMediaType: "image/png", imageDetailLevel: ResponseImageDetailLevel.High)
    ]
);
List<ResponseItem> inputItems = [request];
bool computerUseCalled = false;
string currentScreenshot = "browser_search";
int limitIteration = 10;
OpenAIResponse response;
do
{
    response = await CreateAndWaitForResponseAsync(
        responseClient,
        inputItems,
        responseOptions
    );
    computerUseCalled = false;
    responseOptions.PreviousResponseId = response.Id;
    inputItems.Clear();
    foreach (ResponseItem responseItem in response.OutputItems)
    {
        inputItems.Add(responseItem);
        if (responseItem is ComputerCallResponseItem computerCall)
        {
            currentScreenshot = ProcessComputerUseCall(computerCall, currentScreenshot);
            inputItems.Add(ResponseItem.CreateComputerCallOutputItem(callId: computerCall.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageBytes: screenshots[currentScreenshot], screenshotImageBytesMediaType: "image/png")));
            computerUseCalled = true;
        }
    }
    limitIteration--;
} while (computerUseCalled && limitIteration > 0);
Console.WriteLine(response.GetOutputText());
```

The Agent in turn can analyze it, and return actions, user need to do, then user sends another screenshot with the actions result. This continues until the task is complete. In our example we have created a simple method, which analyzes Agent's actions and returns the appropriate screenshot name.

```C# Snippet:Sample_ProcessComputerUseCall_ComputerUse
private static string ProcessComputerUseCall(ComputerCallResponseItem item, string oldScreenshot)
{
    string currentScreenshot = "browser_search";
    switch (item.Action.Kind)
    {
        case ComputerCallActionKind.Type:
            Console.WriteLine($"  Typing text \"{item.Action.TypeText}\" - Simulating keyboard input");
            currentScreenshot = "search_typed";
            break;
        case ComputerCallActionKind.KeyPress:
            HashSet<string> codes = [.. item.Action.KeyPressKeyCodes];
            if (codes.Contains("Return") || codes.Contains("ENTER"))
            {
                // If we have typed the value to the search field, go to search results.
                if (string.Equals(oldScreenshot, "search_typed"))
                {
                    Console.WriteLine("  -> Detected ENTER key press, when search field was populated, displaying results.");
                    currentScreenshot = "search_results";
                }
                else
                {
                    Console.WriteLine("  -> Detected ENTER key press, on results or unpopulated search, do nothing.");
                    currentScreenshot = oldScreenshot;
                }
            }
            else
            {
                Console.WriteLine($"  Key press: {item.Action.KeyPressKeyCodes.Aggregate("", (agg, next) => agg + "+" + next)} - Simulating key combination");
            }
            break;
        case ComputerCallActionKind.Click:
            Console.WriteLine($"  Click at ({item.Action.ClickCoordinates.Value.X}, {item.Action.ClickCoordinates.Value.Y}) - Simulating click on UI element");
            if (string.Equals(oldScreenshot, "search_typed"))
            {
                Console.WriteLine("  -> Assuming click on Search button when search field was populated, displaying results.");
                currentScreenshot = "search_results";
            }
            else
            {
                Console.WriteLine("  -> Assuming click on Search on results or when search was not populated, do nothing.");
                currentScreenshot = oldScreenshot;
            }
            break;
        case ComputerCallActionKind.Drag:
            string pathStr = item.Action.DragPath.ToArray().Select(p => $"{p.X}, {p.Y}").Aggregate("", (agg, next) => $"{agg} -> {next}");
            Console.WriteLine($"  Drag path: {pathStr} - Simulating drag operation");
            break;
        case ComputerCallActionKind.Scroll:
            Console.WriteLine($"  Scroll at ({item.Action.ScrollCoordinates.Value.X}, {item.Action.ScrollCoordinates.Value.Y}) - Simulating scroll action");
            break;
        case ComputerCallActionKind.Screenshot:
            Console.WriteLine("  Taking screenshot - Capturing current screen state");
            break;
        default:
            break;
    }
    Console.WriteLine($"  -> Action processed: {item.Action.Kind}");

    return currentScreenshot;
}
```

### Function call.

To supply Agents with the information from running local functions the `FunctionTool` is used.
In our example we define three toy functions: `GetUserFavoriteCity` that always returns "Seattle, WA" and `GetCityNickname`, which will handle only "Seattle, WA" and will throw exception in response to other city names. The last function `GetWeatherAtLocation` returns the weather in Seattle, WA.

```C# Snippet:Sample_Functions_Function
/// Example of a function that defines no parameters
/// returns user favorite city.
private static string GetUserFavoriteCity() => "Seattle, WA";

/// <summary>
/// Example of a function with a single required parameter
/// </summary>
/// <param name="location">The location to get nickname for.</param>
/// <returns>The city nickname.</returns>
/// <exception cref="NotImplementedException"></exception>
private static string GetCityNickname(string location) => location switch
{
    "Seattle, WA" => "The Emerald City",
    _ => throw new NotImplementedException(),
};

/// <summary>
/// Example of a function with one required and one optional, enum parameter
/// </summary>
/// <param name="location">Get weather for location.</param>
/// <param name="temperatureUnit">"c" or "f"</param>
/// <returns>The weather in selected location.</returns>
/// <exception cref="NotImplementedException"></exception>
public static string GetWeatherAtLocation(string location, string temperatureUnit = "f") => location switch
{
    "Seattle, WA" => temperatureUnit == "f" ? "70f" : "21c",
    _ => throw new NotImplementedException()
};
```

For each function we need to create `FunctionTool`, which defines function name, description and parameters.

```C# Snippet:Sample_FunctionTools_Function
public static readonly FunctionTool getUserFavoriteCityTool = ResponseTool.CreateFunctionTool(
    functionName: "getUserFavoriteCity",
    functionDescription: "Gets the user's favorite city.",
    functionParameters: BinaryData.FromString("{}"),
    strictModeEnabled: false
);

public static readonly FunctionTool getCityNicknameTool = ResponseTool.CreateFunctionTool(
    functionName: "getCityNickname",
    functionDescription: "Gets the nickname of a city, e.g. 'LA' for 'Los Angeles, CA'.",
    functionParameters: BinaryData.FromObjectAsJson(
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
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
    ),
    strictModeEnabled: false
);

private static readonly FunctionTool getCurrentWeatherAtLocationTool = ResponseTool.CreateFunctionTool(
    functionName: "getCurrentWeatherAtLocation",
    functionDescription: "Gets the current weather at a provided location.",
    functionParameters: BinaryData.FromObjectAsJson(
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
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
    ),
    strictModeEnabled: false
);
```

We have created the method `GetResolvedToolOutput`. It runs the abovementioned functions and wraps their outputs into `ResponseItem` object.

```C# Snippet:Sample_Resolver_Function
private static FunctionCallOutputResponseItem GetResolvedToolOutput(FunctionCallResponseItem item)
{
    if (item.FunctionName == getUserFavoriteCityTool.FunctionName)
    {
        return ResponseItem.CreateFunctionCallOutputItem(item.CallId, GetUserFavoriteCity());
    }
    using JsonDocument argumentsJson = JsonDocument.Parse(item.FunctionArguments);
    if (item.FunctionName == getCityNicknameTool.FunctionName)
    {
        string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
        return ResponseItem.CreateFunctionCallOutputItem(item.CallId, GetCityNickname(locationArgument));
    }
    if (item.FunctionName == getCurrentWeatherAtLocationTool.FunctionName)
    {
        string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
        if (argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unitElement))
        {
            string unitArgument = unitElement.GetString();
            return ResponseItem.CreateFunctionCallOutputItem(item.CallId, GetWeatherAtLocation(locationArgument, unitArgument));
        }
        return ResponseItem.CreateFunctionCallOutputItem(item.CallId, GetWeatherAtLocation(locationArgument));
    }
    return null;
}
```

Create Agent with the `FunctionTool`.

```C# Snippet:Sample_CreateAgent_Function_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a weather bot. Use the provided functions to help answer questions. "
            + "Customize your responses to the user's preferences as much as possible and use friendly "
            + "nicknames for cities whenever possible.",
    Tools = { getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

To supply functions outputs, we will need to wait for response multiple times. We will define method `CreateAndWaitForResponseAsync` for brevity.

```C# Snippet:Sample_WaitForResponse_Function_Async
public static async Task<OpenAIResponse> CreateAndWaitForResponseAsync(OpenAIResponseClient responseClient, IEnumerable<ResponseItem> items, ResponseCreationOptions options)
{
    OpenAIResponse response = await responseClient.CreateResponseAsync(
        inputItems: items,
        options: options);
    while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        response = await responseClient.GetResponseAsync(responseId: response.Id);
    }
    Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    return response;
}
```

Wait for the response; if the local function call is required, the response item will be of `FunctionCallResponseItem` type and will contain the function name needed by the Agent. In this case we will use our helper method `GetResolvedToolOutput` to get the `FunctionCallOutputResponseItem` with function call result. To provide the right answer, we need to supply all the response items to `CreateResponse` or `CreateResponseAsync` call. At the end we will print out the function response.

```C# Snippet:Sample_CreateResponse_Function_Async
OpenAIResponseClient responseClient = projectClient.OpenAI.GetOpenAIResponseClient(modelDeploymentName);
ResponseCreationOptions responseOptions = new();
responseOptions.Agent = agentVersion;

ResponseItem request = ResponseItem.CreateUserMessageItem("What's the weather like in my favorite city?");
List<ResponseItem> inputItems = [request];
bool funcionCalled = false;
OpenAIResponse response;
do
{
    response = await CreateAndWaitForResponseAsync(
        responseClient,
        inputItems,
        responseOptions);
    funcionCalled = false;
    foreach (ResponseItem responseItem in response.OutputItems)
    {
        inputItems.Add(responseItem);
        if (responseItem is FunctionCallResponseItem functionToolCall)
        {
            Console.WriteLine($"Calling {functionToolCall.FunctionName}...");
            inputItems.Add(GetResolvedToolOutput(functionToolCall));
            funcionCalled = true;
        }
    }
} while (funcionCalled);
Console.WriteLine(response.GetOutputText());
```

## Tracing
**Note:** The tracing functionality is currently in preview with limited scope. Only agent creation operations generate dedicated gen_ai traces currently. As a preview feature, the trace structure including spans, attributes, and events may change in future releases.

You can add an Application Insights Azure resource to your Azure AI Foundry project. See the Tracing tab in your AI Foundry project. If one was enabled, you use the Application Insights connection string, configure your Agents, and observe the full execution path through Azure Monitor. Typically, you might want to start tracing before you create an Agent.

Tracing requires enabling OpenTelemetry support. One way to do this is to set the `AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE` environment variable value to `true`. You can also enable the feature with the following code:
```C# Snippet:EnableActivitySourceToGetAgentTraces
AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);
```

To enabled content recording, set the `OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT` environment variable to `true`. Content in this context refers to chat message content, function call tool related function names, function parameter names and values. Alternatively, you can control content recording with the following code:
```C# Snippet:DisableContentRecordingForAgentTraces
AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);
```
Set the value to `true` to enable content recording.

### Tracing to Azure Monitor
First, set the `APPLICATIONINSIGHTS_CONNECTION_STRING` environment variable to point to your Azure Monitor resource. You can also retrieve the connection string programmatically using the Azure AI Projects client library (Azure.AI.Projects) by calling the `Telemetry.GetApplicationInsightsConnectionString()` method on the `AIProjectClient` class.

For tracing to Azure Monitor from your application, the preferred option is to use Azure.Monitor.OpenTelemetry.AspNetCore. Install the package with [NuGet](https://www.nuget.org/ ):
```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore
```

More information about using the Azure.Monitor.OpenTelemetry.AspNetCore package can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/README.md ).

Another option is to use Azure.Monitor.OpenTelemetry.Exporter package. Install the package with [NuGet](https://www.nuget.org/ )
```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry.Exporter
```

Here is an example how to set up tracing to Azure monitor using Azure.Monitor.OpenTelemetry.Exporter:
```C# Snippet:AgentTelemetrySetupTracingToAzureMonitor
var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("Azure.AI.Projects.Persistent.*")
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
    .AddAzureMonitorTraceExporter().Build();
```

### Tracing to Console

For tracing to console from your application, install the OpenTelemetry.Exporter.Console with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package OpenTelemetry.Exporter.Console
```


Here is an example how to set up tracing to console:
```C# Snippet:AgentTelemetrySetupTracingToConsole
var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("Azure.AI.Projects.Persistent.*") // Add the required sources name
                .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                .AddConsoleExporter() // Export traces to the console
                .Build();
```

## Troubleshooting

Any operation that fails will throw a [ClientResultException][ClientResultException]. The exception's `Status` will hold the HTTP response status code. The exception's `Message` contains a detailed message that may be helpful in diagnosing the issue:

```C# Snippet:ErrorHandling
try
{
    AgentVersion agent = await projectClient.Agents.GetAgentVersionAsync(
        agentName: "agent_which_dies_not_exist", agentVersion: "1");
}
catch (ClientResultException e) when (e.Status == 404)
{
    Console.WriteLine($"Exception status code: {e.Status}");
    Console.WriteLine($"Exception message: {e.Message}");
}
```

To further diagnose and troubleshoot issues, you can enable logging following the [Azure SDK logging documentation](https://learn.microsoft.com/dotnet/azure/sdk/logging). This allows you to capture additional insights into request and response details, which can be particularly helpful when diagnosing complex issues.

## Next steps

Beyond the introductory scenarios discussed, the AI Agents client library offers support for additional scenarios to help take advantage of the full feature set of the AI services.  To help explore some of these scenarios, the AI Agents client library offers a set of samples to serve as an illustration for common scenarios.  Please see the [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Orojects.OpenAI/samples)

## Contributing

See the [Azure SDK CONTRIBUTING.md][aiprojects_contrib] for details on building, testing, and contributing to this library.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/ai/Azure.AI.Orojects.OpenAI/README.png)

<!-- LINKS -->
[ClientResultException]: https://learn.microsoft.com/dotnet/api/system.clientmodel.clientresultexception
<!-- replace  feature/ai-foundry/agents-v2 -> main -->
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/feature/ai-foundry/agents-v2/sdk/ai/Azure.AI.Orojects.OpenAI/samples
<!-- remove "Persistent" -->
[api_ref_docs]: https://learn.microsoft.com/dotnet/api/overview/azure/ai.agents.persistent-readme
[nuget]: https://www.nuget.org/packages/Azure.AI.Orojects.OpenAI.Persistent/
<!-- replace  feature/ai-foundry/agents-v2 -> main -->
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/feature/ai-foundry/agents-v2/sdk/ai/Azure.AI.Orojects.OpenAI
[product_doc]: https://learn.microsoft.com/azure/ai-studio/
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[azure_identity_dac]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[aiprojects_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
