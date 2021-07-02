# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://raw.githubusercontent.com/HarveyLink/azure-rest-api-specs/020ab40d6d35c3535e67129480d08855cc6e8117/specification/keyvault/resource-manager/readme.md

skip-csproj: true

operation-group-to-resource-type:
    PrivateLinkResources: Microsoft.KeyVault/vaults/privateLinkResources
    MHSMPrivateLinkResources: Microsoft.KeyVault/managedHSMs/privateLinkResources
    Operations: Microsoft.KeyVault/operations
operation-group-to-resource:
    PrivateLinkResources: PrivateLinkResource
    MHSMPrivateLinkResources: MHSMPrivateLinkResource
    Operations: NonResource
    Vaults: Vault
directive:
    - rename-model:
      from: Vault
      to: RestApi
```