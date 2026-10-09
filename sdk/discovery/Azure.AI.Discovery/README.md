# Azure AI Discovery client library for .NET

Azure AI Discovery lets you build investigation and knowledge-base experiences on top of your
Discovery workspace. The client library exposes two top-level clients:

- `WorkspaceClient` — conversations, investigations, tasks, and tools.
- `BookshelfClient` — knowledge bases (create, list, index, search, delete).

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.Discovery --prerelease
```

### Prerequisites

- You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).
- An existing Azure AI Discovery workspace and bookshelf endpoint.

### Authenticate the client

The library uses [`Azure.Identity`](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme)
for authentication. `DefaultAzureCredential` works for most scenarios, including local development.

```C# Snippet:Discovery_CreateClients
Uri workspaceEndpoint = new Uri("<workspace-endpoint>");
WorkspaceClient workspaceClient = new WorkspaceClient(workspaceEndpoint, new DefaultAzureCredential());

Uri bookshelfEndpoint = new Uri("<bookshelf-endpoint>");
BookshelfClient bookshelfClient = new BookshelfClient(bookshelfEndpoint, new DefaultAzureCredential());
```

## Key concepts

- **`WorkspaceClient`** is the entry point for workspace operations. Use its `Get*Client()` methods to
  obtain the sub-clients: `GetDiscoveryConversationsClient()`, `GetDiscoveryInvestigationsClient()`,
  `GetDiscoveryTasksClient()`, and `GetDiscoveryToolsClient()`.
- **`BookshelfClient`** is the entry point for knowledge-base operations via
  `GetKnowledgeBasesClient()`.
- **Long-running operations** (for example `KnowledgeBases.CreateOrUpdate` and `KnowledgeBases.Delete`)
  return an `Operation`; pass `WaitUntil.Completed` to wait for the operation to finish, or
  `WaitUntil.Started` to poll manually.

## Examples

See the [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/README.md) for end-to-end usage. A minimal example that creates and reads a
conversation:

```C# Snippet:Discovery_CreateAndReadConversation
DiscoveryConversationsClient conversationsClient = workspaceClient.GetDiscoveryConversationsClient();

DiscoveryConversation created = await conversationsClient.CreateAsync(
    projectName: "my-project",
    investigationName: "/projects/my-project/investigations/my-investigation",
    displayName: "Getting started conversation");

DiscoveryConversation conversation = await conversationsClient.GetAsync(created.Name);
Console.WriteLine($"Conversation: {conversation.Name}");
```

## Troubleshooting

Service operations throw a `RequestFailedException` on failure, with a `Status` code and an
error `Message` that can be used to diagnose the failure.

## Next steps

Browse the [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/README.md) for more scenarios covering investigations, tasks, tools, and
knowledge bases.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.