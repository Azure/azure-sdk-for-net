# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 1
namespace: Azure.ResourceManager.DigitalTwins
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8ba18e990a5c1a98d505018329d53272ce43f334/specification/digitaltwins/resource-manager/readme.md

```

## Swagger workarounds

### Add nullable annotations

``` yaml
directive:
  from: swagger-document
  where: $.definitions.DigitalTwinsResource
  transform: >
    $.properties.tags["x-nullable"] = true;
````
