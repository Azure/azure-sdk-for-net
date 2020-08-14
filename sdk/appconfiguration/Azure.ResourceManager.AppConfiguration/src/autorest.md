# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/c81039d056cc5aa0a0025f5b9e5446a7c194bd1f/specification/appconfiguration/resource-manager/readme.md
```

## Swagger workarounds

### Add nullable annotations

``` yaml
directive:
  from: swagger-document
  where: $.definitions.EncryptionProperties
  transform: >
    $.properties.keyVaultProperties["x-nullable"] = true;
````


``` yaml
directive:
  from: swagger-document
  where: $.definitions.ConfigurationStoreProperties
  transform: >
    $.properties.privateEndpointConnections["x-nullable"] = true;
````