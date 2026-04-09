# Azure AI Projects Agents client library for .NET

Develop Agents using the Azure AI Foundry platform, leveraging an extensive ecosystem of models, tools, and capabilities from OpenAI, Microsoft, and other LLM providers.

**Note:** This package is dedicated to perform CRUD operations on Agents and can be used to enable the telemetry.

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
- [Examples](#examples)
  - [Prompt Agents](#prompt-agents)
  - [Hosted Agents](#hosted-agents)
  - [Toolboxes](#toolboxes)
- [Tracing](#tracing)
  - [Enabling GenAI Tracing](#enabling-genai-tracing)
  - [Tracing to Azure Monitor](#tracing-to-azure-monitor)
  - [Tracing to Console](#tracing-to-console)
  - [Enabling content recording](#enabling-content-recording)
- [Troubleshooting](#troubleshooting)
- [Next steps](#next-steps)
- [Contributing](#contributing)

## Getting started

### Prerequisites

To use Azure AI Agents capabilities, you must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/). This will allow you to create an Azure AI resource and get a connection URL.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```shell
dotnet add package Azure.AI.Extensions.OpenAI --prerelease
```

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.

### Authenticate the client

To be able to create, update and delete Agents, please use `AgentAdministrationClient`. It is a good practice to only allow this operation for users with elevated permissions, for example, administrators.

```C# Snippet:Sample_Agents_CreateAgentClientCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

## Key concepts

### Service API versions

When clients send REST requests to the endpoint, one of the query parameters is `api-version`. It allows us to select the API versions supporting different features. The current stable version is `v1` (default).

#### Select a service API version

The API version may be set supplying `version` parameter to `AgentAdministrationClientOptions` constructor as shown in the example code below.

```C# Snippet:Sample_Agents_API_version
AgentAdministrationClientOptions options = new(version: AgentAdministrationClientOptions.ServiceVersion.V1);
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
```

### Additional concepts
The Azure.AI.Projects.Agents framework organized in a way that for each call, requiring the REST API request, there are synchronous and asynchronous counterparts where the letter has the "Async" suffix. For example, the following code demonstrates the creation of a `ProjectsAgentVersion` object.

Synchronous call:
```C# Snippet:Sample_Agents_CreateAgentVersionCRUD_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
ProjectsAgentVersion agentVersion1 = agentsClient.CreateAgentVersion(
    agentName: "myAgent1",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
ProjectsAgentVersion agentVersion2 = agentsClient.CreateAgentVersion(
    agentName: "myAgent2",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

Asynchronous call:

```C# Snippet:Sample_Agents_CreateAgentVersionCRUD_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
ProjectsAgentVersion agentVersion1 = await agentsClient.CreateAgentVersionAsync(
    agentName: "myAgent1",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
ProjectsAgentVersion agentVersion2 = await agentsClient.CreateAgentVersionAsync(
    agentName: "myAgent2",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

In the most of code snippets we will show only asynchronous sample for brevity. Please refer individual [samples][samples] for both synchronous and asynchronous code.

## Examples

## Declarative Agents

When creating the Agents we need to supply Agent definitions to its constructor. To create a declarative prompt Agent, use the `DeclarativeAgentDefinition`:

```C# Snippet:Sample_Agents_CreateAgentVersionCRUD_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
ProjectsAgentVersion agentVersion1 = await agentsClient.CreateAgentVersionAsync(
    agentName: "myAgent1",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
ProjectsAgentVersion agentVersion2 = await agentsClient.CreateAgentVersionAsync(
    agentName: "myAgent2",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

The code above will result in creation of `ProjectsAgentVersion` object, which is the data object containing Agent's name and version.

### Hosted Agents

**Note:** This feature is in the preview, to use it, please disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

Hosted agents simplify the custom agent deployment on fully controlled environment [see more](https://learn.microsoft.com/azure/ai-foundry/agents/concepts/hosted-agents).

To use hosted agent we need to provide the `Foundry-Features` header in our REST requests. It can be done using `PipelinePolicy`.

```C# Snippet:Sample_Agents_ExperimentalHeader
internal class FeaturePolicy(string feature) : PipelinePolicy
{
    private const string _FEATURE_HEADER = "Foundry-Features";

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
```

To create the hosted agent, please use the `HostedAgentDefinition` while creating the AgentVersion object.

```C# Snippet:Sample_Agents_ImageBasedHostedAgentDefinition_HostedAgent
private static  HostedAgentDefinition GetAgentDefinition(string dockerImage, string modelDeploymentName, string accountId, string applicationInsightConnectionString, string projectEndpoint)
{
    HostedAgentDefinition agentDefinition = new(
        versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.ActivityProtocol, "v1")],
        cpu: "1",
        memory: "2Gi"
    )
    {
        EnvironmentVariables = {
            { "AZURE_OPENAI_ENDPOINT", $"https://{accountId}.cognitiveservices.azure.com/" },
            { "AZURE_OPENAI_CHAT_DEPLOYMENT_NAME", modelDeploymentName },
            // Optional variables, used for logging
            { "APPLICATIONINSIGHTS_CONNECTION_STRING", applicationInsightConnectionString },
            { "AGENT_PROJECT_RESOURCE_ID", projectEndpoint },
        },
        Image = dockerImage,
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

### Toolboxes

Toolboxes allow us to store tools in Azure so that they can be retrieved and used by the Agents.
As for the Hosted Agent we will need to set the experimental header, but in this scenario the header is `Toolboxes=V1Preview`,  we also need to disable the `AAIP001` warning.

In the example below we create two versions of MCP tool and save it to Azure.
```C# Snippet:Sample_CreateToolbox_ToolboxesAgentsCRUD_Async
ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
    serverLabel: "api-specs",
    serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
    toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
));
ToolboxVersion toolBox1 = await toolboxClient.CreateToolboxVersionAsync(
    toolboxName: toolboxName,
    tools: [tool],
    description: "Example toolbox created by the azure-ai-projects sample.",
    metadata: new Dictionary<string, string> {
        {"team", "Engineers"}
    }
);
ToolboxVersion toolBox2 = await toolboxClient.CreateToolboxVersionAsync(
    toolboxName: toolboxName,
    tools: [tool],
    description: "Another toolbox created by the azure-ai-projects sample.",
    metadata: new Dictionary<string, string> {
        {"team", "Data scientists"}
    }
);
string status = "unknown status";
toolBox1.Metadata?.TryGetValue("team", out status);
Console.WriteLine($"Toolbox: {toolBox1.Name}, version: {toolBox1.Version}, (tools: {toolBox1.Tools.Count}) (team: {status}).");
```

There are two objects which help to work with the Toolboxes: `ToolboxRecord` and `ToolboxVersion`. `ToolboxRecord` can be retrieved by
name, it contains the default version of the Toolbox.

```C# Snippet:Sample_GetToolbox_ToolboxesAgentsCRUD_Async
ToolboxRecord record = await toolboxClient.GetToolboxAsync(toolboxName: toolBox1.Name);
Console.WriteLine($"The default version for a toolbox {record.Name} is {record.DefaultVersion}");
```

The name of Toolbox and its version allow to get the `ToolboxVersion`, containing the tools, which can be used by Agent.

```C# Snippet:Sample_GetToolboxVersion_ToolboxesAgentsCRUD_Async
ToolboxVersion toolBox = await toolboxClient.GetToolboxVersionAsync(record.Name, record.DefaultVersion);
Console.WriteLine($"Retrieved toolbox: {toolBox.Name} ({toolBox.Id})");
```


## Tracing

**Note:** Tracing functionality is in preliminary preview and is subject to change. Spans, attributes, and events may be modified in future versions.

> **Environment variable values:** All tracing-related environment variables accept `true` (case-insensitive) or `1` as equivalent enabling values.

### Enabling GenAI Tracing

Tracing requires enabling GenAI-specific OpenTelemetry support. One way to do this is to set the `AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING` environment variable value to `true`. You can also enable the feature with the following code:
```C# Snippet:Sample_Agents_EnableGenAITracing
AppContext.SetSwitch("Azure.Experimental.EnableGenAITracing", true);
```

> **Precedence:** If both the `AppContext` switch and the environment variable are set, the `AppContext` switch takes priority. No exception is thrown on conflict. If neither is set, the value defaults to `false`.

**Important:** When you enable `Azure.Experimental.EnableGenAITracing`, the SDK automatically enables the `Azure.Experimental.EnableActivitySource` flag, which is required for the OpenTelemetry instrumentation to function.

You can add an Application Insights Azure resource to your Microsoft Foundry project. If one was enabled, you can get the Application Insights connection string, configure your AI Projects client, and observe traces in Azure Monitor. Typically, you might want to start tracing before you create a client or Agent.

### Tracing to Azure Monitor

First, set the `APPLICATIONINSIGHTS_CONNECTION_STRING` environment variable to point to your Azure Monitor resource.

For tracing to Azure Monitor from your application, the preferred option is to use Azure.Monitor.OpenTelemetry.AspNetCore. Install the package with [NuGet](https://www.nuget.org/ ):
```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore
```

More information about using the Azure.Monitor.OpenTelemetry.AspNetCore package can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/README.md).

Another option is to use Azure.Monitor.OpenTelemetry.Exporter package. Install the package with [NuGet](https://www.nuget.org/ ):
```dotnetcli
dotnet add package Azure.Monitor.OpenTelemetry.Exporter
```

Here is an example how to set up tracing to Azure Monitor using Azure.Monitor.OpenTelemetry.Exporter:
```C# Snippet:Sample_Agents_SetupTracingToAzureMonitor
var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("Azure.AI.Projects.*")
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
    .AddAzureMonitorTraceExporter().Build();
```

### Tracing to Console

For tracing to console from your application, install the OpenTelemetry.Exporter.Console with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package OpenTelemetry.Exporter.Console
```

Here is an example how to set up tracing to console:
```C# Snippet:Sample_Agents_SetupTracingToConsole
var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("Azure.AI.Projects.*") // Add the required sources name
                .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                .AddConsoleExporter() // Export traces to the console
                .Build();
```

### Enabling content recording

Content recording controls whether message contents and tool call related details, such as parameters and return values, are captured with the traces. This data may include sensitive user information.

To enable content recording, set the `OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT` environment variable to `true`. Alternatively, you can control content recording with the following code:
```C# Snippet:Sample_Agents_ResponsesEnableGenAITracing
AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);
```

If neither the environment variable nor the `AppContext` switch is set, content recording defaults to `false`.

> **Precedence:** If both the `AppContext` switch and the environment variable are set, the `AppContext` switch takes priority. No exception is thrown on conflict.


## Troubleshooting

Any operation that fails will throw a [ClientResultException][ClientResultException]. The exception's `Status` will hold the HTTP response status code. The exception's `Message` contains a detailed message that may be helpful in diagnosing the issue:

```C# Snippet:Sample_Agent_ErrorHandling
try
{
    ProjectsAgentVersion agent = await agentsClient.GetAgentVersionAsync(
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

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/ai/Azure.AI.Extensions.OpenAI/README.png)

<!-- LINKS -->
[ClientResultException]: https://learn.microsoft.com/dotnet/api/system.clientmodel.clientresultexception
[samples]: https://aka.ms/azsdk/Azure.AI.Projects.Agents/net/samples
[api_ref_docs]: https://aka.ms/azsdk/azure-ai-projects-v2/api-reference-2025-11-15-preview
[nuget]: https://aka.ms/azsdk/Azure.AI.Projects.Agents/package
[source_code]: https://aka.ms/Azure.AI.Projects.Agents/net/code
[product_doc]: https://aka.ms/azsdk/azure-ai-projects-v2/product-doc
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[azure_identity_dac]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[aiprojects_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
