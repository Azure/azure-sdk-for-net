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
  - [Authenticate the client](#authenticate-the-client)
- [Key concepts](#key-concepts)
  - [Service API versions](#service-api-versions)
  - [Select a service API version](#select-a-service-api-version)
- [Additional concepts](#additional-concepts)
- [Examples]
  - [Prompt Agents](#prompt-agents)
    - [Agents](#agents)
    - [Responses](#responses)
    - [Conversations](#conversations)
    - [Logging](#logging)
  - [Published Agents](#published-agents)
  - [Container App](#container-app)
  - [Hosted Agents](#hosted-agents)
  - [File search](#file-search)
  - [Code interpreter](#code-interpreter)
  - [Computer use](#computer-use)
  - [Function call](#function-call)
  - [Web Search](#web-search)
  - [Bing Grounding](#bing-grounding)
  - [Bing Custom Search](#bing-custom-search)
  - [MCP tool](#mcp-tool)
  - [MCP tool with project connection](#mcp-tool-with-project-connection)
  - [OpenAPI tool](#openapi-tool)
  - [OpenAPI tool with project connection](#openapi-tool-project-connection)
  - [Browser automation](#browser-automation)
    - [Create Azure Playwright workspace](#create-azure-playwright-workspace)
    - [Configure Microsoft Foundry](#configure-microsoft-foundry)
    - [Using Browser automation tool](#using-browser-automation-tool)
  - [SharePoint tool](#sharepoint-tool)
  - [Fabric Data Agent tool](#fabric-data-agent-tool)
    - [Create a Fabric Capacity](#create-a-fabric-capacity)
    - [Create a Lakehouse data repository](#create-a-lakehouse-data-repository)
    - [Add a data agent to the Fabric](#add-a-data-agent-to-the-fabric)
    - [Create a Fabric connection in Microsoft Foundry](#create-a-fabric-connection-in-microsoft-foundry)
    - [Using Microsoft Fabric tool](#using-microsoft-fabric-tool)
  - [A2ATool](#a2atool)
    - [Create a connection to A2A agent](#create-a-connection-to-a2a-agent)
      - [Classic Microsoft Foundry](#classic-microsoft-foundry)
      - [New Microsoft Foundry](#new-microsoft-foundry)
    - [Using A2A Tool](#using-a2a-tool)
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

```shell
dotnet add package Azure.AI.Projects.OpenAI --prerelease
```

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.

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

For operations based on OpenAI APIs like `/responses`, `/files`, and `/vector_stores`, you can retrieve `ResponsesClient`, `OpenAIFileClient` and `VectorStoreClient` through the appropriate helper methods:

```C# Snippet:GetOpenAIClientsFromProjects
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent("AGENT_NAME");
OpenAIFileClient fileClient = projectClient.OpenAI.GetOpenAIFileClient();
VectorStoreClient vectorStoreClient = projectClient.OpenAI.GetVectorStoreClient();
```

## Key concepts

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
The Azure.AI.Projects.OpenAI framework organized in a way that for each call, requiring the REST API request, there are synchronous and asynchronous counterparts where the letter has the "Async" suffix. For example, the following code demonstrates the creation of a `ResponseResult` object.

Synchronous call:
```C# Snippet:Sample_CreateResponse_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);
ResponseResult response = responseClient.CreateResponse("What is the size of France in square miles?");
```

Asynchronous call:

```C# Snippet:Sample_CreateResponse_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);
ResponseResult response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");
```

In the most of code snippets we will show only asynchronous sample for brevity. Please refer individual [samples][samples] for both synchronous and asynchronous code.

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
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);
ResponseResult response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");
```

After the response was created we need to wait for it to complete.

```C# Snippet:Sample_WriteOutput_ResponseBasic_Async
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

To associate the Response with the Agent the agent reference needs to be created. It is done by calling `GetProjectResponsesClientForAgent` method.

```C# Snippet:CreateResponseBasic_Async
var agentReference = new AgentReference(name: agentVersion.Name);
ProjectResponsesClient responseClient = openaiClient.GetProjectResponsesClientForAgent(agentReference);
CreateResponseOptions responseOptions = new([ResponseItem.CreateUserMessageItem("Write Maxwell's equation in LaTeX format.")]);
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
Console.WriteLine(response.GetOutputText());
```

Previous Response ID may be used to ask follow up questions. In this case we need to set `PreviousResponseId` property on `CreateResponseOptions` object.

```C# Snippet:FollowUp_Basic_Async
CreateResponseOptions followupOptions = new()
{
    PreviousResponseId = response.Id,
    InputItems = { ResponseItem.CreateUserMessageItem("What was the previous question?") },
};
response = await responseClient.CreateResponseAsync(followupOptions);
Console.WriteLine(response.GetOutputText());
```

Finally, we can delete Agent.

```C# Snippet:CleanUp_Basic_Async
await projectClient.Agents.DeleteAgentAsync(agentName: "myAgent");
```

Previously created responses can also be listed, typically to find all responses associated with a particular agent or conversation.

```C# Snippet:Sample_ListResponses_Async
await foreach (ResponseResult response
    in projectClient.OpenAI.Responses.GetProjectResponsesAsync(agent: new AgentReference(agentName), conversationId: conversationId))
{
    Console.WriteLine($"Matching response: {response.Id}");
}
```

#### Conversations

Conversations may be used to store the history of interaction with the agent. To add the responses to a conversation,
set the conversation parameter while calling `GetProjectResponsesClientForAgent`.

```C# Snippet:ConversationClient
CreateResponseOptions CreateResponseOptions = new();
// Optionally, use a conversation to automatically maintain state between calls.
ProjectConversation conversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync();
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(AGENT_NAME, conversation);
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
ProjectConversation conversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync(conversationOptions);

//
// Add items to an existing conversation to supplement the interaction state
//
string EXISTING_CONVERSATION_ID = conversation.Id;

_ = await projectClient.OpenAI.Conversations.CreateProjectConversationItemsAsync(
    EXISTING_CONVERSATION_ID,
    [ResponseItem.CreateSystemMessageItem(inputTextContent: "Story theme to use: department of licensing.")]);
//
// Use the agent and conversation in a response
//
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(AGENT_NAME);
CreateResponseOptions responseOptions = new()
{
    AgentConversationId = EXISTING_CONVERSATION_ID,
    InputItems =
    {
        ResponseItem.CreateUserMessageItem("Tell me a one-line story."),
    },
};

List<ResponseItem> items = [];
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
```

### Logging

Logging ofservice requests and responses may be a useful tool for troubleshooting of the issues.
It can be implemented through custom policy. In the example bwlow we implement `LoggingPolicy` by inheriting the `PipelinePolicy`.
This class implements two methods `Process` and `ProcessAsync`. The Azure pipeline calls the chain of policies, where the preceding
one calls the next policy, hence by placing calls to `ProcessMessage` method before and after `ProcessNext` we can print request
and response. The `ProcessMessage` method contains logic to show the contents of web request and response along with headers and URI paths.

```C# Snippet:Sample_LoggingPolicy_AgentsLogging
public class LoggingPolicy : PipelinePolicy
{
    private static void ProcessMessage(PipelineMessage message)
    {
        if (message.Request is not null && message.Response is null)
        {
            Console.WriteLine($"{message?.Request?.Method} URI: {message?.Request?.Uri}");
            Console.WriteLine($"--- New request ---");
            IEnumerable<string> headerPairs = message?.Request?.Headers?.Select(header => $"\n    {header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
            string headers = string.Join("", headerPairs);
            Console.WriteLine($"Request headers:{headers}");
            if (message.Request?.Content != null)
            {
                string contentType = "Unknown Content Type";
                if (message.Request.Headers?.TryGetValue("Content-Type", out contentType) == true
                    && contentType == "application/json")
                {
                    using MemoryStream stream = new();
                    message.Request.Content.WriteTo(stream, default);
                    stream.Position = 0;
                    using StreamReader reader = new(stream);
                    string requestDump = reader.ReadToEnd();
                    stream.Position = 0;
                    requestDump = Regex.Replace(requestDump, @"""data"":[\\w\\r\\n]*""[^""]*""", @"""data"":""...""");
                    // Make sure JSON string is properly formatted.
                    JsonSerializerOptions jsonOptions = new()
                    {
                        WriteIndented = true,
                    };
                    JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(requestDump);
                    Console.WriteLine("--- Begin request content ---");
                    Console.WriteLine(JsonSerializer.Serialize(jsonElement, jsonOptions));
                    Console.WriteLine("--- End request content ---");
                }
                else
                {
                    string length = message.Request.Content.TryComputeLength(out long numberLength)
                        ? $"{numberLength} bytes"
                        : "unknown length";
                    Console.WriteLine($"<< Non-JSON content: {contentType} >> {length}");
                }
            }
        }
        if (message.Response != null)
        {
            IEnumerable<string> headerPairs = message?.Response?.Headers?.Select(header => $"\n    {header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
            string headers = string.Join("", headerPairs);
            Console.WriteLine($"Response headers:{headers}");
            if (message.BufferResponse)
            {
                message.Response.BufferContent();
                Console.WriteLine("--- Begin response content ---");
                Console.WriteLine(message.Response.Content?.ToString());
                Console.WriteLine("--- End of response content ---");
            }
            else
            {
                Console.WriteLine("--- Response (unbuffered, content not rendered) ---");
            }
        }
    }

    public LoggingPolicy(){}

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        ProcessMessage(message); // for request
        ProcessNext(message, pipeline, currentIndex);
        ProcessMessage(message); // for response
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        ProcessMessage(message); // for request
        await ProcessNextAsync(message, pipeline, currentIndex);
        ProcessMessage(message); // for response
    }
}
```

To apply the policy to the pipeline, we create `AIProjectClientOptions` object
containing  `LoggingPolicy`, inform the pipeline to execute this policy by call
and set the option while instantiating `AIProjectClient` that we will consequently use.

```C# Snippet:Sample_CreateClient_AgentsLogging
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME")
    ?? throw new InvalidOperationException("Missing environment variable 'MODEL_DEPLOYMENT_NAME'");
AIProjectClientOptions options = new();
options.AddPolicy(new LoggingPolicy(), PipelinePosition.PerCall);
AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential(), options: options);
```

### Published Agents

Published Agents are available outside the Microsoft Foundry and can be used by external applications.

#### Publish Agent

1. Click **New foundry** switch at the top of Microsoft Foundry UI.
2. Click **Build** at the upper right.
3. Click **Create agent** button and name your Agent.
4. Select the created Agent at the central panel and click **Publish** at the upper right corner.

After the Agent is published, you will be provided with two URLs
- `https://<Account name>.services.ai.azure.com/api/projects/<Project Name>/applications/<Agent Name>/protocols/activityprotocol?api-version=2025-11-15-preview`
- `https://<Account name>.services.ai.azure.com/api/projects/<Project Name>/applications/<Agent Name>/protocols/openai/responses?=2025-11-15-preview`

The second URL can be usedto call responses API, we will use it to run sample.

### Use the published Agent
The URL, returned during Agent publishing contains `/openai/responses` path and query parameter, setting `api-version`. These parts need to be removed.

Create a `ProjectResponsesClient`, get the response from Agent and print the output.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_ReadEndpoint_Sync
ProjectResponsesClient responseClient = new(
    projectEndpoint: endpoint,
    tokenProvider: new DefaultAzureCredential()
);
ResponseResult response = responseClient.CreateResponse("What is the size of France in square miles?");
Console.WriteLine(response.GetOutputText());
```


### Container App

[Azure Container App](https://learn.microsoft.com/azure/container-apps/ai-integration) may act as an agent if it implements the OpenAI-like protocol. Azure.AI.Projects.OpenAI allow you to interact with these applications as with regular agents. The main difference is that in this case agent needs to be created with `ContainerAppAgentDefinition`. This agent can be used in responses API as a regular agent.

```C# Snippet:Sample_CreateContainerApp_ContainerApp_Async
AgentVersion containerAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "containerAgent",
    options: new(new ContainerApplicationAgentDefinition(
        containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
        containerAppResourceId: containerAppResourceId,
        ingressSubdomainSuffix: ingressSubdomainSuffix)));
```

### Hosted Agents

Hosted agents simplify the custom agent deployment on fully controlled environment [see more](https://learn.microsoft.com/azure/ai-foundry/agents/concepts/hosted-agents).

To create the hosted agent, please use the `ImageBasedHostedAgentDefinition` while creating the AgentVersion object.

```C# Snippet:Sample_ImageBasedHostedAgentDefinition_HostedAgent
private static  ImageBasedHostedAgentDefinition GetAgentDefinition(string dockerImage, string modelDeploymentName, string accountId, string applicationInsightConnectionString, string projectEndpoint)
{
    ImageBasedHostedAgentDefinition agentDefinition = new(
        containerProtocolVersions: [new ProtocolVersionRecord(AgentCommunicationMethod.ActivityProtocol, "v1")],
        cpu: "1",
        memory: "2Gi",
        image: dockerImage
    )
    {
        EnvironmentVariables = {
            { "AZURE_OPENAI_ENDPOINT", $"https://{accountId}.cognitiveservices.azure.com/" },
            { "AZURE_OPENAI_CHAT_DEPLOYMENT_NAME", modelDeploymentName },
            // Optional variables, used for logging
            { "APPLICATIONINSIGHTS_CONNECTION_STRING", applicationInsightConnectionString },
            { "AGENT_PROJECT_RESOURCE_ID", projectEndpoint },
        }
    };
    return agentDefinition;
}
```

The created agent needs to be deployed using [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli)

```bash
az login
az cognitiveservices agent start --account-name ACCOUNTNAME --project-name PROJECTNAME --name myHostedAgent --agent-version 1
```

After the deployment is complete, this Agent can be used for calling responses.

Agent deletion should be done through Azure CLI.

```bash
az cognitiveservices agent delete-deployment --account-name ACCOUNTNAME --project-name PROJECTNAME --name myHostedAgent --agent-version 1
az cognitiveservices agent delete --account-name ACCOUNTNAME --project-name PROJECTNAME --name myHostedAgent --agent-version 1
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
AgentReference agentReference = new(name: agentVersion.Name, version: agentVersion.Version);
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentReference);

ResponseResult response = await responseClient.CreateResponseAsync("I need to solve the equation sin(x) + x^2 = 42");
```

### Computer use

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
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    TruncationMode = ResponseTruncationMode.Auto,
    InputItems =
    {
        ResponseItem.CreateUserMessageItem(
        [
            ResponseContentPart.CreateInputTextPart("I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete."),
            ResponseContentPart.CreateInputImagePart(imageBytes: screenshots["browser_search"], imageBytesMediaType: "image/png", imageDetailLevel: ResponseImageDetailLevel.High)
        ]),
    },
};
bool computerUseCalled = false;
string currentScreenshot = "browser_search";
int limitIteration = 10;
ResponseResult response;
do
{
    response = await CreateResponseAsync(
        responseClient,
        responseOptions
    );
    computerUseCalled = false;
    responseOptions.PreviousResponseId = response.Id;
    responseOptions.InputItems.Clear();
    foreach (ResponseItem responseItem in response.OutputItems)
    {
        responseOptions.InputItems.Add(responseItem);
        if (responseItem is ComputerCallResponseItem computerCall)
        {
            currentScreenshot = ProcessComputerUseCall(computerCall, currentScreenshot);
            responseOptions.InputItems.Add(ResponseItem.CreateComputerCallOutputItem(callId: computerCall.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageBytes: screenshots[currentScreenshot], screenshotImageBytesMediaType: "image/png")));
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

To supply functions outputs, we will need to obtain responses multiple times. We will define method `CreateAndWaitForResponseAsync` for brevity.

```C# Snippet:Sample_CheckResponse_Function_Async
public static async Task<ResponseResult> CreateAndCheckResponseAsync(ResponsesClient responseClient, IEnumerable<ResponseItem> items)
{
    ResponseResult response = await responseClient.CreateResponseAsync(
        inputItems: items);
    Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    return response;
}
```

If the local function call is required, the response item will be of `FunctionCallResponseItem` type and will contain the function name needed by the Agent. In this case we will use our helper method `GetResolvedToolOutput` to get the `FunctionCallOutputResponseItem` with function call result. To provide the right answer, we need to supply all the response items to `CreateResponse` or `CreateResponseAsync` call. At the end we will print out the function response.

```C# Snippet:Sample_CreateResponse_Function_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

ResponseItem request = ResponseItem.CreateUserMessageItem("What's the weather like in my favorite city?");
List<ResponseItem> inputItems = [request];
bool funcionCalled = false;
ResponseResult response;
do
{
    response = await CreateAndCheckResponseAsync(
        responseClient,
        inputItems);
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

### Web Search

The `WebSearchTool` allows the agent to perform web search. To improve the results we can set up the search location. After the agent was created, it can be used as usual. When needed it will use web search to answer the question.

```C# Snippet:Sample_CreateAgent_WebSearch_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that can search the web",
    Tools = { ResponseTool.CreateWebSearchTool(userLocation: WebSearchToolLocation.CreateApproximateLocation(country: "GB", city: "London", region: "London")), }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

### Azure AI Search

Azure AI Search is an enterprise search system for high-performance applications.
It integrates with Azure OpenAI Service and Azure Machine Learning, offering advanced
search technologies like vector search and full-text search. Ideal for knowledge base
insights, information discovery, and automation. Creating an Agent with Azure AI
Search requires an existing Azure AI Search Index. For more information and setup
guides, see [Azure AI Search Tool Guide](https://learn.microsoft.com/azure/ai-services/agents/how-to/tools/azure-ai-search).

```C# Snippet:Sample_CreateAgent_AzureAISearch_Async
AzureAISearchToolIndex index = new()
{
    ProjectConnectionId = aiSearchConnectionName,
    IndexName = "sample_index",
    TopK = 5,
    Filter = "category eq 'sleeping bag'",
    QueryType = AzureAISearchQueryType.Simple
};
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant. You must always provide citations for answers using the tool and render them as: `\u3010message_idx:search_idx\u2020source\u3011`.",
    Tools = { new AzureAISearchTool(new AzureAISearchToolOptions(indexes: [index])) }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

If the agent has found the relevant information in the index, the reference
and annotation will be provided in the response. In this example, we add the reference and url to the end of the response. Please note that to
get sensible result, the index needs to have fields "title" and "url" in the search index.
We have created a helper method to format the reference.

```C# Snippet:Sample_FormatReference_AzureAISearch
private static string GetFormattedAnnotation(ResponseResult response)
{
    foreach (ResponseItem item in response.OutputItems)
    {
        if (item is MessageResponseItem messageItem)
        {
            foreach (ResponseContentPart content in messageItem.Content)
            {
                foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
                {
                    if (annotation is UriCitationMessageAnnotation uriAnnotation)
                    {
                        return $" [{uriAnnotation.Title}]({uriAnnotation.Uri})";
                    }
                }
            }
        }
    }
    return "";
}
```

Use the helper method to output the result.

```C# Snippet:Sample_WaitForResponse_AzureAISearch
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");
```

The same can be done in the streaming scenarios, however in this case the helper method takes response item.

```C# Snippet:Sample_FormatReference_AzureAISearchStreaming
private static string GetFormattedAnnotation(ResponseItem item)
{
    if (item is MessageResponseItem messageItem)
    {
        foreach (ResponseContentPart content in messageItem.Content)
        {
            foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
            {
                if (annotation is UriCitationMessageAnnotation uriAnnotation)
                {
                    return $" [{uriAnnotation.Title}]({uriAnnotation.Uri})";
                }
            }
        }
    }
    return "";
}
```

Read the input in streaming mode.

```C# Snippet:Sample_StreamResponse_AzureAISearchStreaming_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

string annotation = "";
string text = "";
await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync("What is the temperature rating of the cozynights sleeping bag?"))
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
        text = textDoneUpdate.Text;
    }
    else if (streamResponse is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
    {
        if (annotation.Length == 0)
        {
            annotation = GetFormattedAnnotation(itemDoneUpdate.Item);
        }
    }
    else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
    {
        throw new InvalidOperationException($"The stream has failed: {errorUpdate.Message}");
    }
}
Console.WriteLine($"{text}{annotation}");
```

### Bing Grounding

To support the response returned by the Agent, Bing grounding can be used. To implement it,
create the `BingGroundingAgentTool` and use it in `PromptAgentDefinition` object.

```C# Snippet:Sample_CreateAgent_BingGrounding_Sync
AIProjectConnection bingConnectionName = projectClient.Connections.GetConnection(connectionName: connectionName);
BingGroundingTool bingGroundingAgentTool = new(new BingGroundingSearchToolOptions(
    searchConfigurations: [new BingGroundingSearchConfiguration(projectConnectionId: bingConnectionName.Id)]
    )
);
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent.",
    Tools = { bingGroundingAgentTool, }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

If the Bing search returned the result, we can get the URL annotation
using the same methods we used for AI Search result.


Getting the result of Bing grounding in non-streaming scenarios:
```C# Snippet:Sample_WaitForResponse_BingGrounding
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");
```

Streaming the results:
```C# Snippet:Sample_StreamResponse_BingGroundingStreaming_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

string annotation = "";
string text = "";
await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync("How does wikipedia explain Euler's Identity?"))
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
        text = textDoneUpdate.Text;
    }
    else if (streamResponse is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
    {
        if (annotation.Length == 0)
        {
            annotation = GetFormattedAnnotation(itemDoneUpdate.Item);
        }
    }
    else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
    {
        throw new InvalidOperationException($"The stream has failed: {errorUpdate.Message}");
    }
}
Console.WriteLine($"{text}{annotation}");
```

### Bing Custom Search

Along with bing grounding, Agents can use the custom search. To implement it,
create the `BingCustomSearchAgentTool` and use it in `PromptAgentDefinition` object. The
use of this tool is like Bing Grounding, however it requires ID of Grounding with Bing
Custom Search and the name of a search configuration. In this scenario, we use Bing to search
en.wikipedia.org. This configuration is called "wikipedia" its search URL is configured through Azure.

```C# Snippet:Sample_CreateAgent_CustomBingSearch_Async
AIProjectConnection bingConnectionName = await projectClient.Connections.GetConnectionAsync(connectionName: connectionName);
BingCustomSearchPreviewTool customBingSearchAgentTool = new(new BingCustomSearchToolParameters(
    searchConfigurations: [new BingCustomSearchConfiguration(projectConnectionId: bingConnectionName.Id, instanceName: customInstanceName)]
    )
);
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent.",
    Tools = { customBingSearchAgentTool, }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Sending request and formatting the response is done the same way as in Bing Grounding.

### MCP tool
The `MCPTool` allows Agent to communicate with third party services using [Model Context Protocol (MCP)](https://learn.microsoft.com/windows/ai/mcp/overview).
To use MCP we need to create agent definition with the `MCPTool`.

```C# Snippet:Sample_CreateAgent_MCPTool_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
    Tools = { ResponseTool.CreateMcpTool(
        serverLabel: "api-specs",
        serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
        toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
    )) }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Note that in this scenario we are using `GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval`, which means that any calls to the MCP server need to be approved.
Because of this setup we will need to get the response and check if we need to approve the call. If no calls were made, we are safe to output the Agent result.

```C# Snippet:Sample_CreateResponse_MCPTool_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

CreateResponseOptions nextResponseOptions = new([ResponseItem.CreateUserMessageItem("Please summarize the Azure REST API specifications Readme")]);
ResponseResult latestResponse = null;

while (nextResponseOptions is not null)
{
    latestResponse = await responseClient.CreateResponseAsync(nextResponseOptions);
    nextResponseOptions = null;

    foreach (ResponseItem responseItem in latestResponse.OutputItems)
    {
        if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
        {
            nextResponseOptions = new CreateResponseOptions()
            {
                PreviousResponseId = latestResponse.PreviousResponseId,
            };
            if (string.Equals(mcpToolCall.ServerLabel, "api-specs"))
            {
                Console.WriteLine($"Approving {mcpToolCall.ServerLabel}...");
                // Automatically approve the MCP request to allow the agent to proceed
                // In production, you might want to implement more sophisticated approval logic
                nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
            }
            else
            {
                Console.WriteLine($"Rejecting unknown call {mcpToolCall.ServerLabel}...");
                nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
            }
        }
    }
}
Console.WriteLine(latestResponse.GetOutputText());
```

### MCP tool with project connection
Running MCP tool with project connection allows you to connect to an MCP server that requires authentication. The only difference from
the previous example is that we need to provide the connection name. To create connection valid for GitHub please log in to your GitHub profile, click on the profile picture at the upper right corner and select "Settings". At the left panel click "Developer Settings", select "Personal access tokens > Tokens (classic)". At the top choose "Generate new token" and enter password and create a token, which can read public repositories. **Save the token, or keep the page open as once the page is closed, token cannot be shown again!**
In the Azure portal open Microsoft Foundry you are using, at the left panel select "Management center" and then select "Connected resources". Create new connection of "Custom keys" type; name it and add a key value pair. Set the key name `Authorization` and the value should have a form of `Bearer your_github_token`.
When the connection is created, we can set it on the MCPTool and use it in `PromptAgentDefinition`.

```C# Snippet:Sample_CreateAgent_MCPTool_ProjectConnection_Async
McpTool tool = ResponseTool.CreateMcpTool(
        serverLabel: "api-specs",
        serverUri: new Uri("https://api.githubcopilot.com/mcp"),
        toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
    ));
tool.ProjectConnectionId = mcpProjectConnectionName;
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
    Tools = { tool }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

In this scenario the agent can be asked questions about GitHub profile, the token is attributed to. The responses from Agent with project connection should be
handled the same way as described in the MCP tool section.

### OpenAPI tool
OpenAPI tool allows Agent to get information from Web services using [OpenAPI Specification](https://en.wikipedia.org/wiki/OpenAPI_Specification).
To use the OpenAPI tool, we need to Create the `OpenAPIFunctionDefinition` object and provide the specification file to its constructor. `OpenAPIAgentTool` contains a `Description` property, serving as a hint when this tool should be used.

```C# Snippet:Sample_CreateAgent_OpenAPI_Async
string filePath = GetFile();
OpenAPIFunctionDefinition toolDefinition = new(
    name: "get_weather",
    spec: BinaryData.FromBytes(BinaryData.FromBytes(File.ReadAllBytes(filePath))),
    auth: new OpenAPIAnonymousAuthenticationDetails()
);
toolDefinition.Description = "Retrieve weather information for a location.";
OpenAPITool openapiTool = new(toolDefinition);

PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = {openapiTool}
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

The Agent created this way can be asked questions, specific to the Web service.

```C# Snippet:Sample_CreateResponse_OpenAPI_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
ResponseResult response = await responseClient.CreateResponseAsync(
        userInputText: "Use the OpenAPI tool to print out, what is the weather in Seattle, WA today."
    );
Console.WriteLine(response.GetOutputText());
```

### OpenAPI tool with project connection
Some Web services, using OpenAPI specification, may require authentication, which can be done through the Microsoft Foundry project connection.
In our example we are using TripAdvisor  specification, which use key authentication.
To create a connection, in the Azure portal open Microsoft Foundry you are using, at the left panel select "Management center" and then select "Connected resources", and, finally, create new connection of "Custom keys" type; name it and add a key value pair.
Add key called "Key" and value with the actual TripAdvisor key.
Contrary to OpenAPI tool without authentication, in this scenario we need to provide tool constructor with `OpenAPIProjectConnectionAuthenticationDetails` initialized with `OpenAPIProjectConnectionSecurityScheme`.

```C# Snippet:Sample_CreateAgent_OpenAPIProjectConnection_Sync
string filePath = GetFile();
AIProjectConnection tripadvisorConnection = projectClient.Connections.GetConnection("tripadvisor");
OpenAPIFunctionDefinition toolDefinition = new(
    name: "tripadvisor",
    spec: BinaryData.FromBytes(BinaryData.FromBytes(File.ReadAllBytes(filePath))),
    auth: new OpenAPIProjectConnectionAuthenticationDetails(new OpenAPIProjectConnectionSecurityScheme(
        projectConnectionId: tripadvisorConnection.Id
    ))
);
toolDefinition.Description = "Trip Advisor API to get travel information.";
OpenAPITool openapiTool = new(toolDefinition);

PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = { openapiTool }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

We recommend testing the Web service access before running production scenarios. It can be done by setting
`ToolChoice = ResponseToolChoice.CreateRequiredChoice()` in the `CreateResponseOptions`. This setting will
force Agent to use tool and will trigger the error if it is not accessible.

```C# Snippet:Sample_CreateResponse_OpenAPIProjectConnection_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems =
    {
        ResponseItem.CreateUserMessageItem("Recommend me 5 top hotels in paris, France."),
    }
};
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
Console.WriteLine(response.GetOutputText());
```

### Browser automation

Playwright is a Node.js library for browser automation. Microsoft provides the [Azure Playwright workspace](https://learn.microsoft.com/javascript/api/overview/azure/playwright-readme), which can execute Playwright-based tasks triggered by an Agent using the BrowserAutomationAgentTool.

#### Create Azure Playwright workspace

1. Deploy an Azure Playwright workspace.
2. In the **Get started** section, open **2. Set up authentication**.
3. **Select Service Access Token**, then choose **Generate Token**. **Save the token immediately-once you close the page, it cannot be viewed again.**

#### Configure Microsoft Foundry

1. Open the left navigation and select **Management center**.
2. Choose **Connected resources**.
3. Create a new connection of type **Serverless Model**.
4. Provide a name, then paste your Access Token into the **Key** field.
5. Set the Playwright Workspace Browser endpoint as the **Target URI**. You can find this endpoint on the Workspace **Overview page**. It begins with `wss://`.

#### Using Browser automation tool

Please note that Browser automation operations may take longer than typical calls to process. Using background mode for Responses or applying a network timeout of at least five minutes for non-background calls is highly recommended.

```C# Snippet:Sample_CreateProjectClient_BrowserAutomotion
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var playwrightConnectionName = System.Environment.GetEnvironmentVariable("PLAYWRIGHT_CONNECTION_NAME");
AIProjectClientOptions options = new()
{
    NetworkTimeout = TimeSpan.FromMinutes(5)
};
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
```

To use Azure Playwright workspace we need to create agent with `BrowserAutomationAgentTool`.

```C# Snippet:Sample_CreateAgent_BrowserAutomotion_Async
AIProjectConnection playwrightConnection = await projectClient.Connections.GetConnectionAsync(playwrightConnectionName);
BrowserAutomationPreviewTool playwrightTool = new(
    new BrowserAutomationToolParameters(
        new BrowserAutomationToolConnectionParameters(playwrightConnection.Id)
    ));

PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are an Agent helping with browser automation tasks.\n" +
    "You can answer questions, provide information, and assist with various tasks\n" +
    "related to web browsing using the Browser Automation tool available to you.",
    Tools = {playwrightTool}
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Streaming response outputs with browser automation provides incremental updates as the automation is processed. This is advised for interactive scenarios, as browser automation can require several minutes to fully complete.

```C# Snippet:Sample_CreateResponse_BrowserAutomotion_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    StreamingEnabled = true,
    InputItems =
    {
        ResponseItem.CreateUserMessageItem("Your goal is to report the percent of Microsoft year-to-date stock price change.\n" +
            "To do that, go to the website finance.yahoo.com.\n" +
            "At the top of the page, you will find a search bar.\n" +
            "Enter the value 'MSFT', to get information about the Microsoft stock price.\n" +
            "At the top of the resulting page you will see a default chart of Microsoft stock price.\n" +
            "Click on 'YTD' at the top of that chart, and report the percent value that shows up just below it.")
    }
};
await foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreamingAsync(responseOptions))
{
    ParseResponse(update);
}
```

### SharePoint tool
`SharepointAgentTool` allows Agent to access SharePoint pages to get the data context. Use the SharePoint connection name as it is shown in the connections section of Microsoft Foundry to get the connection. Get the connection ID to initialize the `SharePointGroundingToolOptions`, which will be used to create `SharepointAgentTool`.

```C# Snippet:Sample_CreateAgent_Sharepoint_Async
AIProjectConnection sharepointConnection = await projectClient.Connections.GetConnectionAsync(sharepointConnectionName);
SharePointGroundingToolOptions sharepointToolOption = new()
{
    ProjectConnections = { new ToolProjectConnection(projectConnectionId: sharepointConnection.Id) }
};
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = { new SharepointPreviewTool(sharepointToolOption), }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Create the response and make sure we are always using tool.

```C# Snippet:Sample_CreateResponse_Sharepoint_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("What is Contoso whistleblower policy") },
};
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
```

SharePoint tool can create the reference to the page, grounding the data. We will create the `GetFormattedAnnotation` method to get the URI annotation.

```C# Snippet:Sample_FormatReference_Sharepoint
private static string GetFormattedAnnotation(ResponseResult response)
{
    foreach (ResponseItem item in response.OutputItems)
    {
        if (item is MessageResponseItem messageItem)
        {
            foreach (ResponseContentPart content in messageItem.Content)
            {
                foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
                {
                    if (annotation is UriCitationMessageAnnotation uriAnnotation)
                    {
                        return $" [{uriAnnotation.Title}]({uriAnnotation.Uri})";
                    }
                }
            }
        }
    }
    return "";
}
```

Print the Agent output and add the annotation at the end.

```C# Snippet:Sample_WaitForResponse_Sharepoint
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");
```

### Fabric Data Agent tool

As a prerequisite to this example, we will need to create Microsoft Fabric with Lakehouse data repository. Please see the end-to end tutorials on using Microsoft Fabric [here](https://learn.microsoft.com/fabric/fundamentals/end-to-end-tutorials) for more information.

#### Create a Fabric Capacity

1. Create a **Fabric Capacity** resource in the Azure Portal **(attention, the rate is being applied!)**.
2. Create the workspace in [Power BI portal](https://msit.powerbi.com/home) by clicking **Workspaces** icon on the left panel.
3. At the bottom click **+ New workspace**.
4. At the right panel populate the name of a workspace, select **Fabric capacity** as a **License mode**; in the **Capacity** dropdown select Fabric Capacity resource we have just created.
5. Click **Apply**.

#### Create a Lakehouse data repository

1. Click a **Lakehouse** icon in **Other items you can create with Microsoft Fabric** section and name the new data repository.
2. Download the [public holidays data set](https://github.com/microsoft/fabric-samples/raw/refs/heads/main/docs-samples/data-engineering/Lakehouse/PublicholidaysSample/publicHolidays.parquet).
3. At the Lakehouse menu select **Get data > Upload files** and upload the `publicHolidays.parquet`.
4. In the **Files** section, click on three dots next to uploaded file and click **Load to Tables > new table** and then **Load** in the opened window.
5. Delete the uploaded file, by clicking three dots and selecting **Delete**.

#### Add a data agent to the Fabric

1. At the top panel select **Add to data agent > New data agent** and name the newly created Agent.
2. In the open view on the left panel select the Lakehouse "publicholidays" table and set a checkbox next to it.
4. Ask the question we will further use in the Requests API. "What was the number of public holidays in Norway in 2024?"
5. The Agent should show a table containing one column called "NumberOfPublicHolidays" with the single row, containing number 62.
6. Click **Publish** and in the description add "Agent has data about public holidays." If this stage was omitted the error, saying "Stage configuration not found." will be returned during sample run.

#### Create a Fabric connection in Microsoft Foundry.

After we have created the Fabric data Agent, we can connect fabric to our Microsoft Foundry.
1. Open the [Power BI](https://msit.powerbi.com/home) and select the workspace we have created.
2. In the open view select the Agent we have created.
3. The URL of the opened page will look like `https://msit.powerbi.com/groups/%workspace_id%/aiskills/%artifact_id%?experience=power-bi`, where `workspace_id` and `artifact_id` are GUIDs in a form like `811acded-d5f7-11f0-90a4-04d3b0c6010a`.
4. In the **Microsoft Foundry** you are using for the experimentation, on the left panel select **Management center**.
5. Choose **Connected resources**.
6. Create a new connection of type **Microsoft Fabric**.
7. Populate **workspace-id** and **artifact-id** fields with GUIDs found in the Microsoft Data Agent URL and name the new connection.

#### Using Microsoft Fabric tool

To use the Agent with Microsoft Fabric tool, we need to include `MicrosoftFabricAgentTool` into `PromptAgentDefinition`.

```C# Snippet:Sample_CreateAgent_Fabric_Async
AIProjectConnection fabricConnection = await projectClient.Connections.GetConnectionAsync(fabricConnectionName);
FabricDataAgentToolOptions fabricToolOption = new()
{
    ProjectConnections = { new ToolProjectConnection(projectConnectionId: fabricConnection.Id) }
};
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = { new MicrosoftFabricPreviewTool(fabricToolOption), }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

### A2ATool

The [A2A or Agent2Agent](https://a2a-protocol.org/latest/) protocol is designed to enable seamless communication between agents. In the scenario below we assume that we have the application endpoint, which complies  with A2A; the authentication is happening through header `x-api-key` value.

#### Create a connection to A2A agent

The connection to A2A service can be created in two ways. In classic Microsoft Foundry, we need to create Custom keys connection, however in the new version of Microsoft Foundry we can create the specialized A2A connection.

##### Classic Microsoft Foundry

1. In the **Microsoft Foundry** you are using for the experimentation, on the left panel select **Management center**.
2. Choose **Connected resources**.
3. Create a new connection of type **Custom keys**.
4. Add two key-value pairs:
   * x-api-key: \<your key\>
   * type: custom_A2A
5. Name and save the connection.

##### New Microsoft Foundry

If we are using the Agent2agent connection, we do not need to provide the endpoint as it already contains it.

1. Click **New foundry** switch at the top of Microsoft Foundry UI.
2. Click **Tools** on the left panel.
3. Click **Connect tool** at the upper right corner.
4. In the open window select **Custom** tab.
5. Select **Agent2agent(A2A)** and click **Create**.
6. Populate **Name** and **A2A Agent Endpoint**, leave **Authentication** being "Key-based".
7. In the **Credential** Section set key "x-api-key" with the value being your secret key.

#### Using A2A Tool

To use the Agent with A2A tool, we need to include `A2ATool` into `PromptAgentDefinition`.

```C# Snippet:Sample_CreateAgent_AgentToAgent_Async
AIProjectConnection a2aConnection = projectClient.Connections.GetConnection(a2aConnectionName);
A2APreviewTool a2aTool = new()
{
    ProjectConnectionId = a2aConnection.Id
};
if (!string.Equals(a2aConnection.Type.ToString(), "RemoteA2A"))
{
    if (a2aBaseUri is null)
    {
        throw new InvalidOperationException($"The connection {a2aConnection.Name} is of {a2aConnection.Type.ToString()} type and does not carry the A2A service base URI. Please provide this value through A2A_BASE_URI environment variable.");
    }
    a2aTool.BaseUri = new Uri(a2aBaseUri);
}
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = { a2aTool }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
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
```shell
dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore
```

More information about using the Azure.Monitor.OpenTelemetry.AspNetCore package can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/README.md ).

Another option is to use Azure.Monitor.OpenTelemetry.Exporter package. Install the package with [NuGet](https://www.nuget.org/ )
```shell
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

```shell
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

Beyond the introductory scenarios discussed, the AI Agents client library offers support for additional scenarios to help take advantage of the full feature set of the AI services.  To help explore some of these scenarios, the AI Agents client library offers a set of samples to serve as an illustration for common scenarios.  Please see the [Samples][samples]

## Contributing

See the [Azure SDK CONTRIBUTING.md][aiprojects_contrib] for details on building, testing, and contributing to this library.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/ai/Azure.AI.Projects.OpenAI/README.png)

<!-- LINKS -->
[ClientResultException]: https://learn.microsoft.com/dotnet/api/system.clientmodel.clientresultexception
[samples]: https://aka.ms/azsdk/Azure.AI.Projects.OpenAI/net/samples
[api_ref_docs]: https://aka.ms/azsdk/azure-ai-projects-v2/api-reference-2025-11-15-preview
[nuget]: https://www.nuget.org/packages/Azure.AI.Projects.OpenAI/
[source_code]: https://aka.ms/azsdk/Azure.AI.Projects.OpenAI/net/code
[product_doc]: https://aka.ms/azsdk/azure-ai-projects-v2/product-doc
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[azure_identity_dac]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[aiprojects_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
