# Azure.Security.KeyVault.Administration

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet msbuild /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.KeyVault.Administration
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/189fe8eb8d1ce60c9a782bbd1a0d632ffd70f1ae/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/rbac.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/189fe8eb8d1ce60c9a782bbd1a0d632ffd70f1ae/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/backuprestore.json
namespace: Azure.Security.KeyVault.Administration
include-csproj: disable
```
