# Azure AI AgentServer client library for .NET
With hosted agents developers can deploy existing agents — whether built with supported agent
frameworks or custom code — into Microsoft AI Foundry with minimal effort.

## Getting started

### Prerequisites

### Install the package

```dotnetcli
dotnet add package Azure.AI.AgentServer.Core --prerelease
```

### Authenticate the client

A secure, keyless authentication approach is to use Microsoft Entra ID (formerly Azure Active Directory) via the [Azure Identity library][azure_identity]. To use this library, you need to install the [Azure.Identity package](https://www.nuget.org/packages/Azure.Identity):

```dotnetcli
dotnet add package Azure.Identity
```

## Key concepts

## Examples

## Troubleshooting

## Next steps

## Contributing

See the [Azure SDK CONTRIBUTING.md][aiprojects_contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[RequestFailedException]: https://learn.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Projects/tests/Samples
[api_ref_docs]: https://learn.microsoft.com/dotnet/api/azure.ai.projects?view=azure-dotnet-preview
[nuget]: https://www.nuget.org/packages/Azure.AI.Projects
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Projects
[product_doc]: https://learn.microsoft.com/azure/ai-studio/
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[azure_identity_dac]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[aiprojects_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com

