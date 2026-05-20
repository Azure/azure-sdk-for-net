# Azure AI Discovery snippets

This project contains the C# snippets referenced by the package [README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/README.md). The snippets are organized by scenario and authored as `#region Snippet:Name` blocks that the [snippet generator](https://github.com/Azure/azure-sdk-tools/tree/main/tools/snippet-generator) reuses to keep the README examples in sync with compiling code.

Each file under this directory is a stand-alone partial class with one method per snippet. The code in each `#region` is what gets injected into the matching ` ```C# Snippet:Name ` block in the README.

| File | Scenarios |
|------|-----------|
| [AuthenticationSnippets.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/snippets/AuthenticationSnippets.cs) | Construct `WorkspaceClient` / `BookshelfClient`; pick a service API version |
| [InvestigationsSnippets.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/snippets/InvestigationsSnippets.cs) | Create or replace an investigation; start the Discovery Engine |
| [TasksSnippets.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/snippets/TasksSnippets.cs) | Create a task, add a comment, list with a filter |
| [ToolsSnippets.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/snippets/ToolsSnippets.cs) | Run a tool on a compute node pool |
| [KnowledgeBasesSnippets.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/discovery/Azure.AI.Discovery/samples/snippets/KnowledgeBasesSnippets.cs) | List knowledge bases, create a version, start indexing |

## Running the snippets

Snippets are intentionally non-runnable on their own — they call `WorkspaceClient` / `BookshelfClient` against placeholder endpoints, and the methods return without `await`ing the resulting operations (see `CS1998` suppression in the project file). To run end-to-end scenarios, copy a snippet into a console app and substitute real values for the endpoint, project, knowledge base, and ARM resource IDs.

## Updating

When you edit a snippet, run the snippet generator from the repo root to refresh the README. CI will fail the PR if the README and snippets drift out of sync.
