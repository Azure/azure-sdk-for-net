# Azure AI Agent Server Contracts client library for .NET

Azure.AI.AgentServer.Responses.Contracts contains the TypeSpec-generated model contracts for the Azure AI Responses API. These types are used by [Azure.AI.AgentServer.Responses](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/README.md) and can also be consumed directly for serialization, validation, and integration purposes.

[Source code][source] | [Package (NuGet)][nuget] | [REST API reference][rest_api] | [Product documentation][product_doc]

## Getting started

### Install the package

Install the library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses.Contracts --prerelease
```

### Prerequisites

- [.NET 8.0](https://dotnet.microsoft.com/download) or later

### Authenticate the client

This is a data model package and does not make service calls.
Authentication is handled by the server library [Azure.AI.AgentServer.Responses](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/README.md).

## Key concepts

This package contains the generated data models for the Azure AI Responses API, including:

- **Request/Response models**: `CreateResponse`, `Response`, `ResponseStreamEvent`
- **Output items**: `OutputItem` and its subtypes (message, function call, web search, etc.)
- **Content types**: Text, refusal, image, file, and other content parts
- **Validators**: Schema-driven validators generated from the OpenAPI specification

### Thread safety

All model types are designed for safe concurrent read access. Serialization and deserialization operations are thread-safe.

## Examples

See the [Azure.AI.AgentServer.Responses samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples) for usage examples.

## Troubleshooting

Model serialization uses `System.ClientModel` conventions. Ensure you use `ModelReaderWriter` for round-trip serialization fidelity.

## Next steps

- [Azure.AI.AgentServer.Responses](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/README.md) — The SDK that builds on these contracts

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses.Contracts/src
[nuget]: https://www.nuget.org/packages/Azure.AI.AgentServer.Responses.Contracts
[rest_api]: https://learn.microsoft.com/azure/foundry/reference/foundry-project#responses-94
[product_doc]: https://learn.microsoft.com/azure/foundry/agents/concepts/hosted-agents
