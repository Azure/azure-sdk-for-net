# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.Storage
tag: package-2021-04
#require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/storage/resource-manager/readme.md
require: D:\yukun\projects\azure-rest-api-specs\specification\storage\resource-manager\readme.md
use: https://github.com/Azure/autorest.csharp/releases/download/v3.0.0-beta.20210816.2/autorest-csharp-3.0.0-beta.20210816.2.tgz
clear-output-folder: true
skip-csproj: true
modelerfour:
    lenient-model-deduplication: true
operation-group-to-resource-type:
    Skus: Microsoft.Storage/skus
    DeletedAccounts: Microsoft.Storage/deletedAccounts
    Usages: Microsoft.Storage/locations/usages
    PrivateLinkResources: Microsoft.Storage/storageAccounts/privateLinkResources
    StorageAccountName: Microsoft.Storage/storageAccountsss
operation-group-to-resource:
    StorageAccounts: StorageAccount
    DeletedAccounts: DeletedAccount
    Table: Table
    StorageAccountName: NonResource
operation-group-to-parent:
    BlobContainers: Microsoft.Storage/storageAccounts/blobServices
    FileShares: Microsoft.Storage/storageAccounts/fileServices
    Queue: Microsoft.Storage/storageAccounts/queueServices
    Table: Microsoft.Storage/storageAccounts/tableServices
    StorageAccountName: subscriptions
#singleton-resource: BlobService;FileService;QueueService;TableService
directive:
  - rename-model:
      from: BlobServiceProperties
      to: BlobService
  - rename-model:
      from: QueueServiceProperties
      to: QueueService
  - rename-model:
      from: FileServiceProperties
      to: FileService
  - rename-model:
      from: TableServiceProperties
      to: TableService
  - from: swagger-document
    where: $.definitions.FileShareItems.properties.value.items["$ref"]
    transform: return "#/definitions/FileShare"
  - from: swagger-document
    where: $.definitions.ListContainerItems.properties.value.items["$ref"]
    transform: return "#/definitions/BlobContainer"
  - from swagger-document
    where: $.definitions.ListQueueResource.properties.value.items["$ref"]
    transform: return "#/definitions/StorageQueue"
```
