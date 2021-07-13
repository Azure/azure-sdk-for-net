# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: KeyVault
require: https://raw.githubusercontent.com/HarveyLink/azure-rest-api-specs/020ab40d6d35c3535e67129480d08855cc6e8117/specification/keyvault/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
namespace: Azure.ResourceManager.KeyVault
modelerfour:
  lenient-model-deduplication: true
model-namespace: false
payload-flattening-threshold: 2
operation-group-to-resource-type:
    PrivateLinkResources: Microsoft.KeyVault/vaults/privateLinkResources
    MHSMPrivateLinkResources: Microsoft.KeyVault/managedHSMs/privateLinkResources
    # Operations: Microsoft.KeyVault/operations
operation-group-to-resource:
    # PrivateLinkResources: PrivateLinkResource
    # MHSMPrivateLinkResources: MHSMPrivateLinkResource
    # Operations: NonResource
    Vaults: Vault
operation-group-to-parent:
   VirtualMachineExtensionImages: subscriptions
directive:
    # - rename-model:
    #     from: Operation
    #     to: RestApi
    - from: swagger-document
      where: $.paths
      transform: delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/accessPolicies/{operationKind}']
    - from: swagger-document
      where: $.definitions
      transform: delete $['VaultAccessPolicyParameters']
    - from: swagger-document
      where: $.definitions
      transform: delete $['VaultAccessPolicyProperties']
    - from: swagger-document
      where: $.paths.'/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults'.'get'.operationId
      transform: 
```