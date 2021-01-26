# Azure.Security.KeyVault.Administration

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.KeyVault.Administration
input-file:
    - https://raw.githubusercontent.com/christothes/azure-rest-api-specs/dd69d680c22cf6a10cc0f3abb21d8030252e4cd8/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/rbac.json
    - https://raw.githubusercontent.com/christothes/azure-rest-api-specs/dd69d680c22cf6a10cc0f3abb21d8030252e4cd8/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/backuprestore.json
namespace: Azure.Security.KeyVault.Administration
include-csproj: disable
```
