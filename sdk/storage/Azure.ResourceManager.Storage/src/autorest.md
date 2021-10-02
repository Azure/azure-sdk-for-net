# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.Storage
tag: package-2021-04
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/7384176da46425e7899708f263e0598b851358c2/specification/storage/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
modelerfour:
    lenient-model-deduplication: true
    seal-single-value-enum-by-default: true
operation-group-to-resource-type:
    Skus: Microsoft.Storage/skus
    DeletedAccounts: Microsoft.Storage/deletedAccounts
    Usages: Microsoft.Storage/locations/usages
    PrivateLinkResources: Microsoft.Storage/storageAccounts/privateLinkResources
    StorageAccountName: Microsoft.Storage/storageAccountsss
operation-group-to-resource:
    StorageAccounts: StorageAccount
    DeletedAccounts: NonResource
    Table: Table
    StorageAccountName: NonResource
operation-group-to-parent:
    BlobContainers: Microsoft.Storage/storageAccounts/blobServices
    FileShares: Microsoft.Storage/storageAccounts/fileServices
    Queue: Microsoft.Storage/storageAccounts/queueServices
    Table: Microsoft.Storage/storageAccounts/tableServices
    StorageAccountName: subscriptions
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
  - from: swagger-document
    where: $.definitions.ListQueueResource.properties.value.items["$ref"]
    transform: return "#/definitions/StorageQueue"
# change default to service name and add to parameter
  - from: swagger-document
    where: $.paths
    transform: >
      for (var key in $) {
          var newKey=key.replace('fileServices/default','fileServices/{FileServicesName}');
          if (newKey !== key){
              $[newKey] = $[key];
              for (var key1 in $[newKey]){
                $[newKey][key1]['parameters'].push(
                  {
                    "$ref": "#/parameters/FileServicesName"
                  }
                );
              }
              delete $[key];
              continue;
            }
            newKey=key.replace('blobServices/default','blobServices/{BlobServicesName}');
          if (newKey !== key){
              $[newKey] = $[key];
              for (var key1 in $[newKey]){
                $[newKey][key1]['parameters'].push(
                  {
                    "$ref": "#/parameters/BlobServicesName"
                  }
                );
              }
              delete $[key];
              continue;
            }
          newKey=key.replace('queueServices/default','queueServices/{queueServiceName}');
           if (newKey !== key){
              $[newKey] = $[key];
              for (var key1 in $[newKey]){
                $[newKey][key1]['parameters'].push(
                  {
                    "$ref": "#/parameters/QueueServiceName"
                  }
                );
              }
              delete $[key];
              continue;
            }
          newKey=key.replace('tableServices/default','tableServices/{tableServiceName}');
          if (newKey !== key){
              $[newKey] = $[key]
              for (var key1 in $[newKey]){
                $[newKey][key1]['parameters'].push(
                  {
                    "$ref": "#/parameters/TableServiceName"
                  }
                );
              }
              delete $[key];
            }
      }
# delete enum property
  - from: swagger-document
    where: $.parameters
    transform: >
      for (var key in $) {
          if (key === 'BlobServicesName'||key === 'FileServicesName'||key === 'QueueServiceName'||key === 'TableServiceName'){
              delete $[key]['enum']
          }
      }
# change checkname availability operation id
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability'].post.operationId
    transform: return 'StorageAccountName_CheckAvailability'
```
