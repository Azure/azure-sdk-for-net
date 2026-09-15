# Azure Semantic Reranker client library for .NET

> [!IMPORTANT]
> `Azure.Data.AI` is a provisional package and namespace for the Semantic Reranker service. Product naming is not final.

Azure.Data.AI provides semantic reranking operations for .NET applications.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Data.AI --prerelease
```

### Prerequisites

- You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).
- A Semantic Reranker endpoint.
- Either an API key or a Microsoft Entra identity assigned the **Semantic Reranker User** role on the `Microsoft.InferenceService/inferenceAccounts` resource.

### Authenticate the client

Create a client with an API key:

```C# Snippet:SemanticReranker_CreateClient
Uri endpoint = new Uri("<semantic-reranker-endpoint>");
AzureKeyCredential credential = new AzureKeyCredential("<api-key>");
InferenceServiceClient client = new InferenceServiceClient(endpoint, credential);
```

Or authenticate with a `TokenCredential`, such as `DefaultAzureCredential` from
[`Azure.Identity`](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme):

```C#
Uri endpoint = new Uri("<semantic-reranker-endpoint>");
InferenceServiceClient client = new InferenceServiceClient(endpoint, new DefaultAzureCredential());
```

The generated bearer-token policy requests the `https://dbinference.azure.com/.default` scope.

## Key concepts

Use `InferenceServiceClient.GetDataInferenceClient()` to obtain the generated operation client.

## Examples

See [Semantic reranking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/inferenceservice/Azure.Data.AI/samples/Sample1_SemanticReranking.md).

## Troubleshooting

Service operations throw `RequestFailedException` when the service returns a non-success status code.

## Next steps

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.