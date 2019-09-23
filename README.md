# Azure SDK for .NET
This repository contains official .NET libraries for Azure services. You can find NuGet packages for these libraries [here](packages.md). 

## Getting started

To get started with a library, see the README.md file located in the library's project folder. You can find these library folders grouped by service in the /sdk directory.

For tutorials, samples, quick starts, and other documentation, go to [Azure for .NET Developers](https://docs.microsoft.com/en-us/dotnet/azure/).

## Packages available
Each service might have a number of libraries available from each of the following categories discussed below:

* [Client - July 2019 Preview](#Client-July-2019-Preview)
* [Client - Stable](#Client-Stable)
* [Management](#Management)


### Client: July 2019 Preview
New wave of packages that we are currently releasing in **preview**.
These libraries follow the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet/guidelines/) and share a number of core features such as HTTP retries, logging, transport protocols, authentication protocols, etc., so that once you learn how to use these features in one client library, you will know how to use them in other client libraries. You can learn about these shared features at [Azure.Core](/sdk/core/Azure.Core/README.md).

These preview libraries can be easily identified by their folder, package, and namespaces names starting with 'Azure', e.g. Azure.Storage.Blobs. 

The libraries released in the July 2019 preview:
* [Azure.ApplicationModel.Configuration](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md)
* [Azure.Messaging.EventHubs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/README.md)
* [Azure.Security.KeyVault.Keys](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md)
* [Azure.Security.KeyVault.Secrets](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md)
* [Azure.Storage.Blobs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Blobs/README.md)
* [Azure.Storage.Files](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Files/README.md)
* [Azure.Storage.Queues](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Queues/README.md)

>NOTE: If you need to ensure your code is ready for production, use one of the stable libraries.

### Client: Stable
Last stable versions of packages that are production-ready. These libraries provide similar functionalities to the preview packages, as they allow you to use and consume existing resources and interact with them, for example: upload a storage blob. Stable library directories typically contain 'Microsoft.Azure' in their names, e.g. 'Microsoft.Azure.KeyVault'.

### Management
Libraries which enable you to provision specific server resources. They are directly mirroring Azure service's REST endpoints. Management library directories typically contain the word 'Management' in their names, e.g. 'Microsoft.Azure.Management.Storage'.

## Need help?
* For reference documentation visit the [Azure SDK for .NET API Reference](http://aka.ms/net-docs).
* For tutorials, samples, quick starts, and other documentation, go to [Azure for .NET Developers](https://docs.microsoft.com/en-us/dotnet/azure/).
* File an issue via [Github Issues](https://github.com/Azure/azure-sdk-for-net/issues/new/choose).
* Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on StackOverflow using `azure` and `.net` tags.

## Contributing
For details on contributing to this repository, see the [contributing guide](CONTRIBUTING.md).

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit
https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

| Component | Build Status |
| --------- | ------------ |
| Client Libraries | [![Build Status](https://dev.azure.com/azure-sdk/public/_apis/build/status/290?branchName=master)](https://dev.azure.com/azure-sdk/public/_build/latest?definitionId=290&branchName=master) [![Dependencies](https://img.shields.io/badge/dependencies-analyzed-blue.svg)](https://azuresdkartifacts.blob.core.windows.net/azure-sdk-for-net/dependencies/dependencies.html) |
| Management Libraries | [![Build Status](https://dev.azure.com/azure-sdk/public/_apis/build/status/529?branchName=master)](https://dev.azure.com/azure-sdk/public/_build/latest?definitionId=529&branchName=master) |

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2FREADME.png)
