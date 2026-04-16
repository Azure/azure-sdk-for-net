# Azure.Security.KeyVault.Storage

## AutoRest Configuration

> see https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` in source directory to re-generate.

``` yaml
title: Azure.Security.KeyVault.Storage
namespace: Azure.Security.KeyVault.Storage
generate-model-factory: false
include-csproj: disable
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/615259b6d33d3029de2d6e403ffe0c12776da1d4/specification/keyvault/data-plane/Microsoft.KeyVault/stable/7.1/storage.json
generation1-convenience-client: true
```

## Swagger hacks

### Put generated models into Azure.Security.KeyVault.Storage.Models namespace

```yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: $["x-namespace"] = "Azure.Security.KeyVault.Storage.Models"
```

### Relocate the vaultBaseUrl parameter

```yaml
directive:
  from: swagger-document
  where: $["x-ms-parameterized-host"].parameters.*
  transform: $["x-ms-parameter-location"] = "client"
```
