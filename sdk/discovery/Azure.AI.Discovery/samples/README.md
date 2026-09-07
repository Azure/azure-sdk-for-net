# Azure.AI.Discovery samples

The following samples show common scenarios with the Azure AI Discovery client library for .NET.

| Sample | Description |
|--------|-------------|
| [Sample1_GettingStarted](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/Sample1_GettingStarted.md) | Authenticate, create the workspace and bookshelf clients, and run basic conversation and knowledge-base operations. |

## Prerequisites

- An Azure subscription and an existing Azure AI Discovery workspace and bookshelf endpoint.
- The `Azure.AI.Discovery` and `Azure.Identity` packages.

Set the workspace and bookshelf endpoints as environment variables before running the samples:

```dotnetcli
DISCOVERY_WORKSPACE_ENDPOINT=https://<your-workspace>.workspace.discovery.azure.com
DISCOVERY_BOOKSHELF_ENDPOINT=https://<your-bookshelf>.bookshelf.discovery.azure.com
```
