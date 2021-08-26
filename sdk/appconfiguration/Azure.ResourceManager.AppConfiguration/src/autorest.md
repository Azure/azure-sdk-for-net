# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://github.com/Azure/azure-rest-api-specs/blob/cde7f150e8d3bf3af2418cc347cae0fb2baed6a7/specification/appconfiguration/resource-manager/readme.md
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
