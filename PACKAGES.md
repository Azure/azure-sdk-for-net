# Azure SDK for .NET Packages

Historically, the Azure SDK has been just a collection of independent packages. In recent months, we embarked on an effort to transition the SDK from a collection of packages to a well-rounded, consistent, and dependable product. You can read about this effort in a blog post [Previewing Azure SDKs following new Azure SDK API Standards](https://azure.microsoft.com/en-in/blog/previewing-azure-sdks-following-new-azure-sdk-api-standards/). 

This repo contains all Azure SDK libraries for .NET. Some of these libraries have been transitioned to the Azure SDK Standard, i.e. they follow the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html), and some are awaiting be to transitioned. We will refer to the already transitioned packages as _Azure SDK Standard Libraries_, or _Azure Standard Libraries_, for short. Azure Standard Libraries can be easily identified by their folder, package, and namespaces names starting with 'Azure', e.g. Azure.Storage.Blobs.

The following sections lists Azure Standard Library packages, and other important packages contained in this repo. 

## Azure SDK Standard Libraries

### General Avaliability (GA) Packages

* [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md)
* [Azure.Security.KeyVault.Keys](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md)
* [Azure.Security.KeyVault.Secrets](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md)
* [Azure.Storage.Blobs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Blobs/README.md)
* [Azure.Storage.Blobs.Batch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Blobs.Batch/README.md)
* [Azure.Storage.Queues](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Queues/README.md)

### Preview Packages

* [Azure.ApplicationModel.Configuration](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md)
* [Azure.Messaging.EventHubs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/README.md)
* [Azure.Security.KeyVault.Certificates](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Certificates/README.md)
* [Azure.Storage.Files.Shares](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Files.Shares/README.md)

## Other Client Libraries

The repo also contains packages that are production-ready, but not yet transitioned to the Azure Standard. They do however offer wider coverage of services. Directories containing these libraries typically contain 'Microsoft.Azure' in their names, e.g. 'Microsoft.Azure.KeyVault'.

### Management

Libraries which enable you to provision specific server resources. They are directly mirroring Azure service's REST endpoints. Management library directories typically contain the word 'Management' in their names, e.g. 'Microsoft.Azure.Management.Storage'.