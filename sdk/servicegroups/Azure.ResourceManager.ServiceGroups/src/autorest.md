# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: ServiceGroups
title: ServiceGroupClient
namespace: Azure.ResourceManager.ServiceGroups
require: https://github.com/Azure/azure-rest-api-specs/blob/94cec42b293ffaaf67b51ac86235819e6c4886b3/specification/management/resource-manager/Microsoft.Management/ServiceGroups/readme.md
#tag: package-2024-02-preview
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

rename-mapping:
  ProvisioningState: ServiceGroupProvisioningState

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
