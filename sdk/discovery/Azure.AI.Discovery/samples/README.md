# Azure AI Discovery samples for .NET

This directory contains sample code demonstrating common scenarios for the [Azure AI Discovery client library for .NET](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/README.md).

## Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/).
- An existing Microsoft Discovery workspace or bookshelf instance.
- The [.NET SDK](https://dotnet.microsoft.com/download).
- Install the package:
  ```dotnetcli
  dotnet add package Azure.AI.Discovery --prerelease
  ```
- Install [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) for credentials:
  ```dotnetcli
  dotnet add package Azure.Identity
  ```

## Setup

All samples use `DefaultAzureCredential` for authentication — see [Azure.Identity](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme) for details on the credential chain.

You will need to substitute real values for the following placeholders before running any sample:

| Placeholder | Example | Description |
|---|---|---|
| `https://<workspaceName>.workspace.discovery.azure.com` | `https://contoso-research.workspace.discovery.azure.com` | The Workspace endpoint for `WorkspaceClient` samples. |
| `https://<bookshelfName>.bookshelf.discovery.azure.com` | `https://contoso-kb.bookshelf.discovery.azure.com` | The Bookshelf endpoint for `BookshelfClient` samples. |
| `my-project` | The name of a project under your Workspace. |
| `my-kb` | The name of a knowledge base under your Bookshelf. |
| `/subscriptions/.../tools/my-tool` | The ARM resource ID of a Discovery tool. |
| `/subscriptions/.../nodePools/my-pool` | The ARM resource ID of a node pool used for compute or indexing. |
| `/subscriptions/.../storageAssets/my-asset` | The ARM resource ID of a storage asset that backs a knowledge base version. |
| `/subscriptions/.../userAssignedIdentities/my-id` | The ARM resource ID of a user-assigned managed identity authorized to read the storage asset. |

## Samples

The runnable snippet sources live under [snippets/](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/snippets/). They are referenced by the package [README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/README.md) via the snippet generator, so the README examples are guaranteed to compile.

| Scenario | Snippet | Description |
|---|---|---|
| Authentication | [`AuthenticationSnippets.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/snippets/AuthenticationSnippets.cs) | Construct `WorkspaceClient` / `BookshelfClient`; select a service API version. |
| Investigations | [`InvestigationsSnippets.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/snippets/InvestigationsSnippets.cs) | Create or replace an investigation; start the Discovery Engine. |
| Tasks | [`TasksSnippets.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/snippets/TasksSnippets.cs) | Create a task, add a comment, list tasks with a filter. |
| Tools | [`ToolsSnippets.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/snippets/ToolsSnippets.cs) | Run a tool on a supercomputer node pool as a long-running operation. |
| Knowledge bases | [`KnowledgeBasesSnippets.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/snippets/KnowledgeBasesSnippets.cs) | List knowledge bases, create a version, and start an indexing operation. |

To run a snippet end-to-end, copy the body of the `#region Snippet:...` block into a console app, supply real values for the placeholders above, and `await` the asynchronous calls.
