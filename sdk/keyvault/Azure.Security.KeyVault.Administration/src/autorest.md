# Azure.Security.KeyVault.Administration

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.KeyVault.Administration
input-file:
    - ../../../../../azure-rest-api-specs/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/common.json
    - ../../../../../azure-rest-api-specs/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/rbac.json
    - ../../../../../azure-rest-api-specs/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/backuprestore.json
namespace: Azure.Security.KeyVault.Administration
include-csproj: disable
```

>    - https://raw.githubusercontent.com/christothes/azure-rest-api-specs/4bd8acb2d4fcaaa0f5615614fcf65bfda89292d4/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/rbac.json
>    - https://raw.githubusercontent.com/christothes/azure-rest-api-specs/4bd8acb2d4fcaaa0f5615614fcf65bfda89292d4/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/backuprestore.json
