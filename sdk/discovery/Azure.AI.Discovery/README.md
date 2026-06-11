# Azure AI Discovery client library for .NET

The Azure AI Discovery client library for .NET provides two clients for interacting with Microsoft Discovery services:

- **`WorkspaceClient`** — manage investigations, conversations, tasks, and tools in a Discovery workspace.
- **`BookshelfClient`** — manage knowledge bases and knowledge base versions.

[Source code][source_code] | [Package (NuGet)][nuget] | [API reference documentation][api_reference] | [Product documentation][product_docs] | [Samples][samples]

## Getting started

### Install the package

Install the client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.Discovery --prerelease
```

### Prerequisites

- An [Azure subscription][azure_sub].
- An existing Microsoft Discovery workspace or bookshelf instance.
- The client library targets `netstandard2.0`, `net8.0`, and `net10.0`.

### Authenticate the client

Both clients use Microsoft Entra ID (Azure Active Directory) token authentication. Use the [Azure.Identity][azure_identity] library to obtain credentials:

```dotnetcli
dotnet add package Azure.Identity
```

```C# Snippet:CreateDiscoveryClients
WorkspaceClient workspaceClient = new WorkspaceClient(
    new Uri("https://<workspaceName>.workspace.discovery.azure.com"),
    new DefaultAzureCredential());

BookshelfClient bookshelfClient = new BookshelfClient(
    new Uri("https://<bookshelfName>.bookshelf.discovery.azure.com"),
    new DefaultAzureCredential());
```

### Service API versions

The client library targets the latest service API version by default. You can optionally select a supported service API version when instantiating a client:

```C# Snippet:CreateDiscoveryClientForSpecificApiVersion
WorkspaceClientOptions options = new WorkspaceClientOptions(
    WorkspaceClientOptions.ServiceVersion.V2026_02_01_Preview);

WorkspaceClient client = new WorkspaceClient(
    new Uri("https://<workspaceName>.workspace.discovery.azure.com"),
    new DefaultAzureCredential(),
    options);
```

## Key concepts

### WorkspaceClient

`WorkspaceClient` is the entry point for Discovery workspace operations. It exposes four sub-clients:

- **`DiscoveryInvestigationsClient`** — create and manage research investigations within a project. Each investigation can have a Discovery Engine that autonomously explores data and generates insights.
- **`DiscoveryConversationsClient`** — interact with the Discovery Engine through conversational sessions tied to an investigation.
- **`DiscoveryTasksClient`** — create, assign, and track units of work within an investigation, such as research steps or follow-up actions.
- **`DiscoveryToolsClient`** — run compute jobs on supercomputer node pools and monitor their status and resource usage.

Sub-clients are obtained from a `WorkspaceClient` instance:

```C#
DiscoveryInvestigationsClient investigations = workspaceClient.GetDiscoveryInvestigationsClient();
DiscoveryConversationsClient conversations = workspaceClient.GetDiscoveryConversationsClient();
DiscoveryTasksClient         tasks         = workspaceClient.GetDiscoveryTasksClient();
DiscoveryToolsClient         tools         = workspaceClient.GetDiscoveryToolsClient();
```

### BookshelfClient

`BookshelfClient` is the entry point for knowledge base management. It exposes two sub-clients:

- **`KnowledgeBases`** — list available knowledge bases.
- **`KnowledgeBaseVersions`** — create, update, index, and manage versions of knowledge bases backed by storage assets.

```C#
KnowledgeBases        knowledgeBases        = bookshelfClient.GetKnowledgeBasesClient();
KnowledgeBaseVersions knowledgeBaseVersions = bookshelfClient.GetKnowledgeBaseVersionsClient();
```

### Long-running operations

Operations such as deleting an investigation or indexing a knowledge base version are modeled as Azure SDK long-running operations (`Operation<T>`). Pass `WaitUntil.Completed` to block until the operation finishes, or `WaitUntil.Started` to receive the operation handle immediately and poll later.

### Thread safety

All client instance methods are thread-safe and independent of each other ([guideline][thread_safety]). This means it is safe — and recommended — to reuse a single client instance across threads.

## Examples

The following sections provide code snippets covering common scenarios. For complete runnable samples, see the [Samples][samples] directory.

### Create and manage an investigation

```C# Snippet:CreateAndManageInvestigation
WorkspaceClient client = new WorkspaceClient(
    new Uri("https://<workspaceName>.workspace.discovery.azure.com"),
    new DefaultAzureCredential());

DiscoveryInvestigationsClient investigations = client.GetDiscoveryInvestigationsClient();

string projectName = "my-project";
string investigationName = "sample-investigation";

// Create or replace an investigation.
DiscoveryInvestigation resource = new DiscoveryInvestigation
{
    DisplayName = "Sample Investigation",
    Description = "Investigating anomalies in dataset X",
};

Response<DiscoveryInvestigation> created = await investigations.CreateOrReplaceAsync(
    projectName, investigationName, resource);

Console.WriteLine($"Created investigation: {created.Value.Name}");

// Start the Discovery Engine for the investigation.
Response<DiscoveryEngine> engine = await investigations.StartDiscoveryEngineAsync(
    projectName, investigationName);

Console.WriteLine($"Discovery Engine status: {engine.Value.DiscoveryEngineStatus}");
```

### Create and manage tasks

```C# Snippet:CreateAndManageTasks
WorkspaceClient client = new WorkspaceClient(
    new Uri("https://<workspaceName>.workspace.discovery.azure.com"),
    new DefaultAzureCredential());

DiscoveryTasksClient tasks = client.GetDiscoveryTasksClient();

string projectName = "my-project";
string investigationName = "sample-investigation";

DiscoveryTask task = new DiscoveryTask
{
    Title = "Analyze compound interactions",
    Description = "Review the interaction data for compounds A and B",
    Priority = TaskPriority.High,
    AssignedTo = new TaskAssignee("researcher-agent", ByType.Application),
    InvestigationId = $"/projects/{projectName}/investigations/{investigationName}",
};

Response<DiscoveryTask> created = await tasks.CreateAsync(projectName, investigationName, task);
Console.WriteLine($"Created task: {created.Value.Title} ({created.Value.Status})");

// Add a comment to the task.
await tasks.AddCommentAsync(
    created.Value.Name,
    projectName,
    investigationName,
    new TaskComment("sample-user", ByType.User, "Initial analysis shows promising results."));

// List tasks with a filter.
await foreach (DiscoveryTask t in tasks.GetAllAsync(projectName, investigationName, filter: "status eq 'New'"))
{
    Console.WriteLine($"{t.Name}: {t.Title}");
}
```

### Run a tool on compute

```C# Snippet:RunToolOnCompute
WorkspaceClient client = new WorkspaceClient(
    new Uri("https://<workspaceName>.workspace.discovery.azure.com"),
    new DefaultAzureCredential());

DiscoveryToolsClient tools = client.GetDiscoveryToolsClient();

Operation<RunResult> run = await tools.RunAsync(
    WaitUntil.Completed,
    projectName: "my-project",
    toolId: new ResourceIdentifier("/subscriptions/.../tools/my-tool"),
    nodePoolIds: new[] { new ResourceIdentifier("/subscriptions/.../nodePools/my-pool") },
    command: "echo \"Hello from Discovery\"");

Console.WriteLine($"Run completed: {run.Value.Status}");
```

### Manage knowledge base versions

```C# Snippet:ManageKnowledgeBaseVersions
BookshelfClient client = new BookshelfClient(
    new Uri("https://<bookshelfName>.bookshelf.discovery.azure.com"),
    new DefaultAzureCredential());

KnowledgeBases knowledgeBases = client.GetKnowledgeBasesClient();
KnowledgeBaseVersions versions = client.GetKnowledgeBaseVersionsClient();

// List knowledge bases.
await foreach (KnowledgeBase kb in knowledgeBases.GetAllAsync())
{
    Console.WriteLine($"Knowledge base: {kb.Name}");
}

// Create a knowledge base version. CreateOrUpdate is currently exposed as a protocol method
// (no typed convenience overload), so build a RequestContent from the typed model.
string knowledgeBaseName = "my-kb";
string versionName = "v1";

KnowledgeBaseVersion resource = new KnowledgeBaseVersion(
    description: "Research data for compound analysis",
    copilotInstruction: "Use this to query information about compound interactions.")
{
    StorageAssetReferences =
    {
        new StorageAssetReference(new ResourceIdentifier("/subscriptions/.../storageAssets/my-asset"))
        {
            UserAssignedIdentity = new ResourceIdentifier("/subscriptions/.../userAssignedIdentities/my-id"),
        },
    },
};

Response createResponse = await versions.CreateOrUpdateAsync(
    knowledgeBaseName, versionName, RequestContent.Create(resource));
Console.WriteLine($"CreateOrUpdate status: {createResponse.Status}");

// Start indexing as a long-running operation.
Operation<KnowledgeBaseVersion> indexing = await versions.StartIndexingAsync(
    WaitUntil.Completed,
    knowledgeBaseName,
    versionName,
    nodePoolId: "/subscriptions/.../nodePools/my-pool");

Console.WriteLine($"Indexed version: {indexing.Value.Version}");
```

## Troubleshooting

### Logging

This library uses the standard Azure.Core diagnostics pipeline. Enable detailed HTTP request/response logging by adding an `AzureEventSourceListener` to your application:

```C#
using Azure.Core.Diagnostics;
using System.Diagnostics.Tracing;

using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);
```

See the [Azure SDK logging guidelines][azure_logging] for more details.

### Exceptions

Azure AI Discovery clients raise exceptions defined in [Azure.Core][azure_core_exceptions]. For example, if you try to get an investigation that does not exist, `RequestFailedException` is thrown with `Status == 404`:

```C#
try
{
    Response<DiscoveryInvestigation> investigation = await investigations.GetAsync(
        "my-project", "nonexistent");
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine($"Investigation not found: {ex.Message}");
}
```

## Next steps

- Browse the [samples][samples] for runnable code that demonstrates common scenarios.
- Read the [Microsoft Discovery product documentation][product_docs].

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information, see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<!-- LINKS -->
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/discovery/Azure.AI.Discovery/src
[nuget]: https://www.nuget.org/packages/Azure.AI.Discovery
[api_reference]: https://learn.microsoft.com/dotnet/api/azure.ai.discovery
[product_docs]: https://learn.microsoft.com/azure/microsoft-discovery/
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/discovery/Azure.AI.Discovery/samples
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme
[azure_core_exceptions]: https://learn.microsoft.com/dotnet/api/azure.requestfailedexception
[azure_logging]: https://learn.microsoft.com/dotnet/azure/sdk/logging
[thread_safety]: https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
