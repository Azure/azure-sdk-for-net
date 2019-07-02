# Azure SDK for .NET

| Component | Build Status |
| --------- | ------------ |
| Management Libraries | [![Build Status](https://dev.azure.com/azure-sdk/public/_apis/build/status/529?branchName=master)](https://dev.azure.com/azure-sdk/public/_build/latest?definitionId=529&branchName=master) |
| Client Libraries | [![Build Status](https://dev.azure.com/azure-sdk/public/_apis/build/status/290?branchName=master)](https://dev.azure.com/azure-sdk/public/_build/latest?definitionId=290&branchName=master)[![Dependencies](https://img.shields.io/badge/dependencies-analyzed-blue.svg)](https://azuresdkartifacts.blob.core.windows.net/azure-sdk-for-python/dependencies/dependencies.html) |

This repository contains official .NET client libraries for Azure services.

You can find NuGet packages for these libraries [here](packages.md).

## Getting started

To get started with a specific library, see the **README.md** file located in the library's project folder. 
The following sections provide direct links to READMEs of the most commonly used libraries.

### Core services

* [Azure.Messaging.EventHubs](/sdk/eventhub/Azure.Messaging.EventHubs/README.md)
* [Azure.Identity.KeyVault.Keys](/sdk/keyvault/Azure.Security.KeyVault.Keys/Readme.md)
* [Azure.Identity.KeyVault.Secrets](/sdk/keyvault/Azure.Security.KeyVault.Secrets/Readme.md)
* [Azure.Storage.Blobs](/sdk/storage/Azure.Storage.Blobs/README.md)
* [Azure.Storage.Files](/sdk/storage/Azure.Storage.Files/README.md)
* [Azure.Storage.Queues](/sdk/storage/Azure.Storage.Queues/README.md)

### Shared libraries

Azure SDK clients use shared libraries implementing retries, logging, transport protocols, authentication protocols, etc.

[Azure.Core](/sdk/core/Azure.Core/README.md)

### Other services

[Azure.ApplicationModel.Configuration](/sdk/appconfiguration/Azure.ApplicationModel.Configuration/README.md)

## Contributing

For details on contributing to this repository, see the [contributing guide](CONTRIBUTING.md).
