# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: ServiceGroups
title: ServiceGroupClient
namespace: Azure.ResourceManager.ServiceGroups
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/8b0ad3e71102ad633f716845e5bc2d2d25d9f6a0/specification/management/resource-manager/Microsoft.Management/ServiceGroups/preview/2024-02-01-preview/serviceGroups.json
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
deserialize-null-collection-as-null-value: true
use-model-reader-writer: true
model-namespace: false
public-clients: false
head-as-boolean: false
enable-bicep-serialization: true

# mgmt-debug:
#   show-serialized-names: true

directive:
  # Fix inconsistent operationIds in the swagger - normalize to ServiceGroups_ prefix
  - from: serviceGroups.json
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}"].put
    transform: $.operationId = "ServiceGroups_CreateOrUpdate"
  - from: serviceGroups.json
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}"].patch
    transform: $.operationId = "ServiceGroups_Update"
  - from: serviceGroups.json
    where: $.paths["/providers/Microsoft.Management/serviceGroups/{serviceGroupName}"].delete
    transform: $.operationId = "ServiceGroups_Delete"
```
