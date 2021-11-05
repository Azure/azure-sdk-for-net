# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/d302c82f32daec0feb68cd7d68d45ba898b67ee7/specification/appconfiguration/resource-manager/readme.md
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