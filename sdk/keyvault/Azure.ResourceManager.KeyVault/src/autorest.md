# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: KeyVault
require: https://github.com/Azure/azure-rest-api-specs/blob/d29e6eb4894005c52e67cb4b5ac3faf031113e7d/specification/keyvault/resource-manager/readme.md
tag: package-2021-10
clear-output-folder: true
skip-csproj: true
namespace: Azure.ResourceManager.KeyVault
modelerfour:
  flatten-payloads: false
model-namespace: false
override-operation-name:
  Vaults_CheckNameAvailability: CheckKeyVaultNameAvailability
  MHSMPrivateLinkResources_ListByMhsmResource: GetMhsmPrivateLinkResources
list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}
mgmt-debug:
  show-request-path: true
directive:
  - rename-model:
      from: Attributes
      to: BaseAttributes
  - rename-model:
      from: Permissions
      to: AccessPermissions
  - from: swagger-document
    where: $.paths
    transform: delete $['/subscriptions/{subscriptionId}/resources']
  - from: swagger-document
    where: $['definitions']['Sku']['properties']['family']
    transform: delete $['x-ms-client-default']
  - from: swagger-document
    where: $['definitions']['ManagedHsmSku']['properties']['family']
    transform: delete $['x-ms-client-default']
  - from: swagger-document
    where: "$.definitions.CheckNameAvailabilityResult.properties.reason"
    transform: >
      $["x-ms-enum"] = {
        "modelAsString": false,
        "name": "NameAvailabilityReason"
      }
  - from: swagger-document
    where: "$.definitions.Resource"
    transform: >
      $["x-ms-client-name"] = "KeyVaultResource";
```
