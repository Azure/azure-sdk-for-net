---
#   Please see this to see how it works
#
#   https://github.com/Azure/autorest/blob/master/docs/proposals/generator-specific-settings/literate-configuration.md
#
#   To run just do autorest storage.md
#
override-info:
  title: Storage Admin Client
csharp:
    namespace: Microsoft.AzureStack.Storage.Admin
    output-folder: Generated

output-folder: Artifacts

output-artifact: 
    - swagger-document.json
    - swagger-document.yaml


input-file:
    - "https://github.com/BrianLPeterson/azure-rest-api-specs/blob/feature/azsswagger/arm-storage-admin/2015-12-01-preview/swagger/common.json"
    - "https://github.com/BrianLPeterson/azure-rest-api-specs/blob/feature/azsswagger/arm-storage-admin/2015-12-01-preview/swagger/blobServices.json"
    - "https://github.com/BrianLPeterson/azure-rest-api-specs/blob/feature/azsswagger/arm-storage-admin/2015-12-01-preview/swagger/tableServices.json"
    - "https://github.com/BrianLPeterson/azure-rest-api-specs/blob/feature/azsswagger/arm-storage-admin/2015-12-01-preview/swagger/queueServices.json"
    - "https://github.com/BrianLPeterson/azure-rest-api-specs/blob/feature/azsswagger/arm-storage-admin/2015-12-01-preview/swagger/storageaccounts.json"
    - "https://github.com/BrianLPeterson/azure-rest-api-specs/blob/feature/azsswagger/arm-storage-admin/2015-12-01-preview/swagger/shares.json"
    - "https://github.com/BrianLPeterson/azure-rest-api-specs/blob/feature/azsswagger/arm-storage-admin/2015-12-01-preview/swagger/quota.json"
    - "https://github.com/BrianLPeterson/azure-rest-api-specs/blob/feature/azsswagger/arm-storage-admin/2015-12-01-preview/swagger/farm.json"
    - "https://github.com/BrianLPeterson/azure-rest-api-specs/blob/feature/azsswagger/arm-storage-admin/2015-12-01-preview/swagger/container.json"
    - "https://github.com/BrianLPeterson/azure-rest-api-specs/blob/feature/azsswagger/arm-storage-admin/2015-12-01-preview/swagger/acquisition.json"

header-text: MICROSOFT_MIT

azure-arm: true

payload-flatteningthreshold: 2
