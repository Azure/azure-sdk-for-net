# Azure.Security.KeyVault.Administration

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet msbuild /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.KeyVault.Administration
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0902e37d8806dc8f5d7866a9960581e366f5f5b3/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/rbac.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0902e37d8806dc8f5d7866a9960581e366f5f5b3/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/backuprestore.json
namespace: Azure.Security.KeyVault.Administration
include-csproj: disable
```
