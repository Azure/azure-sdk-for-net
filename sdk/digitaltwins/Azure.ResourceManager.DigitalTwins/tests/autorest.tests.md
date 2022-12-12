# Generated code configuration

Run `dotnet build /t:GenerateTest` to generate code.

# Azure.ResourceManager.DigitalTwins.Tests

> see https://aka.ms/autorest
``` yaml
require: ../src/autorest.md
include-x-ms-examples-original-file: true
testgen:
  sample: true
directive:
  - from: digitaltwins.json
    where: $.definitions
    transform: >
      $.TimeSeriesDatabaseConnection.properties.properties.$ref = "#/definitions/AzureDataExplorerConnectionProperties";
      $.DigitalTwinsEndpointResource.properties.properties.$ref = "#/definitions/ServiceBus";
```
