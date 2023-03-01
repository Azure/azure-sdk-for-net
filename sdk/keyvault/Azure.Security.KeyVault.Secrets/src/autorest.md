# Azure.Security.KeyVault.Secrets

## AutoRest Configuration

> See https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Secret
input-file:
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/d78681a9d322bbd8d33ecaad7e6aaa2d513513b4/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.4-preview.1/secrets.json
namespace: Azure.Security.KeyVault.Secrets
clear-output-folder: true
```

## Swagger customization

These changes should eventually be included in the swagger or at least centralized in Azure/azure-rest-api-specs.

``` yaml
directive:
- from: swagger-document
  where: $["x-ms-parameterized-host"].parameters[?(@.name == "vaultBaseUrl")]
  transform: >
    $["format"] = "url";
    $["x-ms-parameter-location"] = "client";
```
