# Azure Cosmos DB client library for .NET

Azure Cosmos DB is a fully managed NoSQL and relational database for modern app development. This library is the next-generation .NET client for Azure Cosmos DB for NoSQL. Requests are executed by the Azure Cosmos DB Rust driver through a native interop layer, and only Gateway mode is supported.

> This package is under active development and doesn't expose any public APIs yet. For production workloads, use [Microsoft.Azure.Cosmos](https://www.nuget.org/packages/Microsoft.Azure.Cosmos).

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cosmosdb/Azure.Data.Cosmos/src) | [Product documentation](https://learn.microsoft.com/azure/cosmos-db/)

## Getting started

### Install the package

The package isn't published to NuGet yet.

### Prerequisites

- .NET 10 or later. .NET Standard and .NET Framework aren't supported.
- An [Azure subscription](https://azure.microsoft.com/free/dotnet/) and an [Azure Cosmos DB for NoSQL account](https://learn.microsoft.com/azure/cosmos-db/nosql/quickstart-portal), or the [Azure Cosmos DB emulator](https://learn.microsoft.com/azure/cosmos-db/emulator).

### Authenticate the client

Authentication guidance will be added along with the client APIs.

## Key concepts

Key concepts will be documented along with the client APIs.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

## Examples

Examples will be added along with the client APIs.

## Troubleshooting

Troubleshooting guidance will be added along with the client APIs.

## Next steps

- [Azure Cosmos DB documentation](https://learn.microsoft.com/azure/cosmos-db/)

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
