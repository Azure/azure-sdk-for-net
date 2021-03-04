# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    const namespace = "Azure.Messaging.EventGrid.SystemEvents";
    for (var path in $)
    {
      if (!path.includes("CloudEvent") && !path.includes("EventGridEvent"))
      {
        $[path]["x-namespace"] = namespace;
      }
      $[path]["x-csharp-usage"] = "model,output,converter";
      $[path]["x-csharp-formats"] = "json";
      if (path.includes("WebAppServicePlanUpdatedEventData"))
      {
          $[path]["properties"]["sku"]["x-namespace"] = namespace;
          $[path]["properties"]["sku"]["x-csharp-usage"] = "model,output,converter";
          $[path]["properties"]["sku"]["x-csharp-formats"] = "json";
      }
      if (path.includes("DeviceTwinInfo"))
      {
          $[path]["properties"]["properties"]["x-namespace"] = namespace;
          $[path]["properties"]["properties"]["x-csharp-usage"] = "model,output,converter";
          $[path]["properties"]["properties"]["x-csharp-formats"] = "json";
          $[path]["properties"]["x509Thumbprint"]["x-namespace"] = namespace;
          $[path]["properties"]["x509Thumbprint"]["x-csharp-usage"] = "model,output,converter";
          $[path]["properties"]["x509Thumbprint"]["x-csharp-formats"] = "json";
      }
    }

title: EventGridClient
require: https://github.com/Azure/azure-rest-api-specs/blob/6c9d4fe7445b78db8336271895924379d95fbc6c/specification/eventgrid/data-plane/readme.md

```

## Swagger workarounds

### Add nullable annotations

``` yaml
directive:
  from: swagger-document
  where: $.definitions.CloudEventEvent
  transform: >
    $.properties.data["x-nullable"] = true;
````
