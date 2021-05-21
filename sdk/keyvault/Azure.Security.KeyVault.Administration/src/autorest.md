# Azure.Security.KeyVault.Administration

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.KeyVault.Administration
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/1e2c9f3ec93078da8078389941531359e274f32a/specification/keyvault/data-plane/Microsoft.KeyVault/stable/7.2/rbac.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/1e2c9f3ec93078da8078389941531359e274f32a/specification/keyvault/data-plane/Microsoft.KeyVault/stable/7.2/backuprestore.json
namespace: Azure.Security.KeyVault.Administration
include-csproj: disable
```
