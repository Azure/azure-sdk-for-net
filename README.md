# Azure SDK for .NET

[![Packages](https://img.shields.io/badge/packages-latest-blue.svg)](https://azure.github.io/azure-sdk/releases/latest/dotnet.html) [![Dependencies](https://img.shields.io/badge/dependencies-analyzed-blue.svg)](https://azuresdkartifacts.blob.core.windows.net/azure-sdk-for-net/dependencies/dependencies.html)

This repository is intended for active development of the Azure SDK for .NET. For consumers of the SDK we recommend visiting our [public developer docs](https://docs.microsoft.com/en-us/dotnet/azure/) or our versioned [developer docs](https://azure.github.io/azure-sdk-for-net).

## Getting started

To get started with a library, see the README.md file located in the library's project folder. You can find these library folders grouped by service in the /sdk directory.

For tutorials, samples, quick starts, and other documentation, go to [Azure for .NET Developers](https://docs.microsoft.com/en-us/dotnet/azure/).

## Packages available

### Client: November 2019 Releases
New wave of packages that we are announcing as **GA** and several that are currently releasing in **preview**. These libraries follow the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet/guidelines/) and share a number of core features such as HTTP retries, logging, transport protocols, authentication protocols, etc., so that once you learn how to use these features in one client library, you will know how to use them in other client libraries. You can learn about these shared features at [Azure.Core](sdk/core/Azure.Core/README.md).

These preview libraries can be easily identified by their folder, package, and namespaces names starting with 'Azure', e.g. Azure.Storage.Blobs.

The libraries released in the November 2019 GA release:
* [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md)
* [Azure.Security.KeyVault.Keys](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md)
* [Azure.Security.KeyVault.Secrets](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md)
* [Azure.Storage.Blobs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Blobs/README.md)
* [Azure.Storage.Blobs.Batch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Blobs.Batch/README.md)
* [Azure.Storage.Queues](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Queues/README.md)

The libraries released in the November 2019 preview:
* [Azure.ApplicationModel.Configuration](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md)
* [Azure.Security.KeyVault.Certificates](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Certificates/README.md)
* [Azure.Messaging.EventHubs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/README.md)
* [Azure.Storage.Files.Shares](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Files.Shares/README.md)

> NOTE: If you need to ensure your code is ready for production use one of the stable, non-preview libraries.

### Client: Previous Versions

Last stable versions of packages that are production-ready. These libraries provide similar functionalities to the preview packages, as they allow you to use and consume existing resources and interact with them, for example: upload a storage blob. Stable library directories typically contain 'Microsoft.Azure' in their names, e.g. 'Microsoft.Azure.KeyVault'. They might not implement the [guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) or have the same feature set as the Novemeber releases. They do however offer wider coverage of services.

### Management

Libraries which enable you to provision specific server resources. They are directly mirroring Azure service's REST endpoints. Management library directories typically contain the word 'Management' in their names, e.g. 'Microsoft.Azure.Management.Storage'.

## Need help?

* For reference documentation visit the [Azure SDK for .NET API Reference](http://aka.ms/net-docs).
* For tutorials, samples, quick starts, and other documentation, go to [Azure for .NET Developers](https://docs.microsoft.com/en-us/dotnet/azure/).
* File an issue via [Github Issues](https://github.com/Azure/azure-sdk-for-net/issues/new/choose).
* Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on StackOverflow using `azure` and `.net` tags.

### Reporting security issues and security bugs

Security issues and bugs should be reported privately, via email, to the Microsoft Security Response Center (MSRC) <secure@microsoft.com>. You should receive a response within 24 hours. If for some reason you do not, please follow up via email to ensure we received your original message. Further information, including the MSRC PGP key, can be found in the [Security TechCenter](https://www.microsoft.com/msrc/faqs-report-an-issue).

## Contributing
For details on contributing to this repository, see the [contributing guide](CONTRIBUTING.md).

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit
https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2FREADME.png)
