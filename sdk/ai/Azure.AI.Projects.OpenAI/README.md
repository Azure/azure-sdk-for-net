# Azure AI Agents client library for .NET

Develop Agents using the Azure AI Foundry platform, leveraging an extensive ecosystem of models, tools, and capabilities from OpenAI, Microsoft, and other LLM providers.

**Note:** While this package can be used independently, we recommend using the Azure AI Projects client library (Azure.AI.Projects.OpenAI) for an enhanced experience. The Projects library provides simplified access to advanced functionality, such as creating and managing Agents, enumerating AI models, working with datasets, managing search indexes, evaluating generative AI performance, and enabling OpenTelemetry tracing.

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects.OpenAI/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://docs.microsoft.com/azure)

## Getting started

Pending

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.Projects.OpenAI --prerelease
```

### Prerequisites

Include a section after the install command that details any requirements that must be satisfied before a developer can [authenticate](#authenticate-the-client) and test all of the snippets in the [Examples](#examples) section. For example, for Cosmos DB:

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.

### Authenticate the client

If you're already using an `AIProjectClient` from `Azure.AI.Projects`, you can initialize an `AgentClient` instance directly via an extension method:

```C# Snippet:CreateAgentClientFromProjectsClient
AIProjectClient projectClient = new(
    endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
    tokenProvider: new AzureCliCredential());
AgentClient agentClient = projectClient.GetAgentClient();
```

If you aren't yet using an `AIProjectClient`, you can also initialize an `AgentClient` instance directly, against a Foundry Project endpoint:

```C# Snippet:CreateAgentClientDirectlyFromProjectEndpoint
AgentClient agentClient = new(
    endpoint: new Uri("https://<RESOURCE>.services.ai.azure.com/api/projects/<PROJECT>"),
    tokenProvider: new AzureCliCredential());
```

For operations based on OpenAI APIs like `/responses`, `/files`, and `/vector_stores`, you can retrieve an `OpenAIClient` instance (from the official `OpenAI` library for .NET) via `.GetOpenAIClient()` and the related subclient retrieval methods:

```C# Snippet:GetOpenAIClientsFromAgents
OpenAIClient openAIClient = agentClient.GetOpenAIClient();

OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient("MODEL_DEPLOYMENT");
OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
VectorStoreClient vectorStoreClient = openAIClient.GetVectorStoreClient();
```

### Service API versions

TBD

#### Select a service API version

TBD

## Key concepts

TBD

### Additional concepts

TBD

## Examples

**Prompt Agents**

To create a declarative Prompt Agent, use the `PromptAgentDefinition` type when creating an `AgentVersion`:

```C# Snippet:CreateAPromptAgent
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");

AgentClient agentClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());

AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
{
    Instructions = "You are a foo bar agent. In EVERY response you give, ALWAYS include both `foo` and `bar` strings somewhere in the response.",
};

AgentVersion newAgentVersion = await agentClient.CreateAgentVersionAsync(
    agentName: AGENT_NAME,
    options: new(agentDefinition));
Console.WriteLine($"Created new agent version: {newAgentVersion.Name}");
```

To run an existing Prompt Agent, reference the Agent by ID when calling the OpenAI Responses API:

```C# Snippet:RunAPromptAgent
    string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
    string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
        ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
    string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
        ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");
    AgentClient agentClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
    OpenAIClient openAIClient = agentClient.GetOpenAIClient();
    OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

    ResponseCreationOptions responseCreationOptions = new();
    responseCreationOptions.SetAgentReference(AGENT_NAME);

    // Optionally, use a conversation to automatically maintain state between calls.
    AgentConversation conversation = await agentClient.GetConversationClient().CreateConversationAsync();
    responseCreationOptions.SetConversationReference(conversation);

    List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Tell me a one-line story.")];
    OpenAIResponse response = await responseClient.CreateResponseAsync(items, responseCreationOptions);

    Console.WriteLine(response.GetOutputText());
```

The conversation may be used to communicate messages to the agent.

```C# Snippet:FullPromptAgentEndToEnd
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");
AgentClient agentClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
OpenAIClient openAIClient = agentClient.GetOpenAIClient();
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

//
// Create an agent version for a new prompt agent
//

AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
{
    Instructions = "You are a foo bar agent. In EVERY response you give, ALWAYS include both `foo` and `bar` strings somewhere in the response.",
};
AgentVersion newAgentVersion = await agentClient.CreateAgentVersionAsync(
    agentName: AGENT_NAME,
    options: new(agentDefinition));

//
// Create a conversation to maintain state between calls
//

AgentConversationCreationOptions conversationOptions = new()
{
    Items = { ResponseItem.CreateSystemMessageItem("Your preferred genre of story today is: horror.") },
    Metadata = { ["foo"] = "bar" },
};
AgentConversation conversation = await agentClient.GetConversationClient().CreateConversationAsync(conversationOptions);

//
// Add items to an existing conversation to supplement the interaction state
//
string EXISTING_CONVERSATION_ID = conversation.Id;

_ = await agentClient.GetConversationClient().CreateConversationItemsAsync(
    EXISTING_CONVERSATION_ID,
    [ResponseItem.CreateSystemMessageItem("Story theme to use: department of licensing.")]);

//
// Use the agent and conversation in a response
//

ResponseCreationOptions responseCreationOptions = new();
responseCreationOptions.SetAgentReference(AGENT_NAME);
responseCreationOptions.SetConversationReference(EXISTING_CONVERSATION_ID);

List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Tell me a one-line story.")];
OpenAIResponse response = await responseClient.CreateResponseAsync(items, responseCreationOptions);

Console.WriteLine(response.GetOutputText());
```

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Projects.OpenAI/samples).

## Tracing
**Note:** The tracing functionality is currently in preview with limited scope. Only agent creation operations generate dedicated gen_ai traces at this time. As a preview feature, the trace structure including spans, attributes, and events may change in future releases.

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

#### Tracing to Azure Monitor
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
    .AddSource("Azure.AI.Projects.OpenAI.Persistent.*")
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
    .AddAzureMonitorTraceExporter().Build();
```

##### Tracing to Console

For tracing to console from your application, install the OpenTelemetry.Exporter.Console with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package OpenTelemetry.Exporter.Console
```


Here is an example how to set up tracing to console:
```C# Snippet:AgentTelemetrySetupTracingToConsole
var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("Azure.AI.Projects.OpenAI.Persistent.*") // Add the required sources name
                .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                .AddConsoleExporter() // Export traces to the console
                .Build();
```

## Troubleshooting

Describe common errors and exceptions, how to "unpack" them if necessary, and include guidance for graceful handling and recovery.

Provide information to help developers avoid throttling or other service-enforced errors they might encounter. For example, provide guidance and examples for using retry or connection policies in the API.

If the package or a related package supports it, include tips for logging or enabling instrumentation to help them debug their code.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/ai/Azure.AI.Projects.OpenAI/README.png)
