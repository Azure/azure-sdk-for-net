# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/954bf4ebc679ba55a6cacb39dbdacdbb956359f2/specification/keyvault/resource-manager/readme.md

skip-csproj: true

operation-group-to-resource-type:
    PrivateLinkResources: Microsoft.KeyVault/vaults/privateLinkResources
    MHSMPrivateLinkResources: Microsoft.KeyVault/managedHSMs/privateLinkResources
    Operations: Microsoft.KeyVault/operations
operation-group-to-resource:
    PrivateLinkResources: PrivateLinkResource
    MHSMPrivateLinkResources: MHSMPrivateLinkResource
    Operations: NonResource
```