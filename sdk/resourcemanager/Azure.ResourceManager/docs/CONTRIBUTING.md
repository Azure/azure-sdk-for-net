# Contributing

Thank you for your interest in contributing to the Azure App Configuration client library. As an open source effort, we're excited to welcome feedback and contributions from the community. A great first step in sharing your thoughts and understanding where help is needed would be to take a look at the [open issues][open_issues].

Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

## Code of conduct

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

## Getting started

Before working on a contribution, it would be beneficial to familiarize yourself with the process and guidelines used for the Azure SDKs so that your submission is consistent with the project standards and is ready to be accepted with fewer changes requested. In particular, it is recommended to review:

 - [Azure SDK README][sdk_readme], to learn more about the overall project and processes used.
 - [Azure SDK Design Guidelines][sdk_design_guidelines], to understand the general guidelines for the Azure SDK across all languages and platforms.
 - [Azure SDK Contributing Guide][sdk_contributing], for information about how to onboard and contribute to the overall Azure SDK ecosystem.

## Azure SDK Design Guidelines for .NET

These libraries follow the [Azure SDK Design Guidelines for .NET][sdk_design_guidelines_dotnet] and share a number of core features such as HTTP retries, logging, transport protocols, authentication protocols, etc., so that once you learn how to use these features in one client library, you will know how to use them in other client libraries. You can learn about these shared features in the [Azure.Core README][sdk_dotnet_code_readme].

## Public API changes  

To update [`Azure.Data.AppConfiguration.netstandard2.0.cs`][azconfig_api] after making changes to the public API, execute [`./eng/scripts/Export-API.ps1`][azconfig_export_api]. 

## Testing

See [here][test_guide] for the details about how to test .NET management plane SDK.

## Development history

For additional insight and context, the development, release, and issue history for the Azure Event Hubs client library is available in read-only form, in its previous location, the [Azure App Configuration .NET repository](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/appconfiguration).

<!-- LINKS -->
[azconfig_root]: ../../sdk/appconfiguration
[azconfig_api]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/appconfiguration/Azure.Data.AppConfiguration/api/Azure.Data.AppConfiguration.netstandard2.0.cs
[azconfig_export_api]: https://github.com/Azure/azure-sdk-for-net/blob/master/eng/scripts/Export-API.ps1
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[open_issues]: https://github.com/Azure/azure-sdk-for-net/issues?utf8=%E2%9C%93&q=is%3Aopen+is%3Aissue+label%3AClient+label%3AAzConfig
[sdk_readme]: https://github.com/Azure/azure-sdk
[sdk_contributing]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/appconfiguration/CONTRIBUTING.md
[sdk_design_guidelines]: https://azure.github.io/azure-sdk/general_introduction.html
[sdk_design_guidelines_dotnet]: https://azure.github.io/azure-sdk/dotnet_introduction.html
[sdk_dotnet_code_readme]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md
[email_opencode]: mailto:opencode@microsoft.com
[test_guide]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/TestGuide.md