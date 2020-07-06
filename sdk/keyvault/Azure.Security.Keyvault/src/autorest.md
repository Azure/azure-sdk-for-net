# Azure.Security.KeyVault

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet msbuild /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.KeyVault
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/16178fee3c9288bd43fd4db804e4b010257f1414/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.1/certificates.json
    - https://github.com/Azure/azure-rest-api-specs/blob/16178fee3c9288bd43fd4db804e4b010257f1414/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.1/keys.json
    - https://github.com/Azure/azure-rest-api-specs/blob/16178fee3c9288bd43fd4db804e4b010257f1414/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.1/secrets.json
    - https://github.com/Azure/azure-rest-api-specs/blob/16178fee3c9288bd43fd4db804e4b010257f1414/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.1/storage.json
namespace: Azure.Security.KeyVault
# include-csproj: disable
```
