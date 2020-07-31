# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    for (var path in $)
    {
      if (!path.includes("CloudEvent") && !path.includes("EventGridEvent"))
      {
        $[path]["x-namespace"] = "Azure.Messaging.EventGrid.Models.SystemEvents";
      }
      console.log('hello world');
      $[path]["x-csharp-usage"] = "model,output";
      $[path]["x-csharp-formats"] = "json";
    }
- from: swagger-document
  where: $.definitions.WebAppServicePlanUpdatedEventData
  transform: >
    $.properties.sku["x-namespace"] = "Azure.Messaging.EventGrid.Models.SystemEvents";
    $.properties.sku["x-csharp-usage"] = "model,output";
    $.properties.sku["x-csharp-formats"] = "json";
- from: swagger-document
  where: $.definitions.DeviceTwinInfo
  transform: >
    $.properties.properties["x-namespace"] = "Azure.Messaging.EventGrid.Models.SystemEvents";
    $.properties.properties["x-csharp-usage"] = "model,output";
    $.properties.properties["x-csharp-formats"] = "json";
    $.properties.x509Thumbprint["x-namespace"] = "Azure.Messaging.EventGrid.Models.SystemEvents";
    $.properties.x509Thumbprint["x-csharp-usage"] = "model,output";
    $.properties.x509Thumbprint["x-csharp-formats"] = "json";
- from: swagger-document
  where: $.definitions.MediaJobError
  transform: >
    $.properties.code["x-namespace"] = "Azure.Messaging.EventGrid.Models.SystemEvents";
    $.properties.category["x-namespace"] = "Azure.Messaging.EventGrid.Models.SystemEvents";
    $.properties.retry["x-namespace"] = "Azure.Messaging.EventGrid.Models.SystemEvents";
- from: swagger-document
  where: $.definitions.MediaJobOutputStateChangeEventData
  transform: >
    $.properties.previousState["x-namespace"] = "Azure.Messaging.EventGrid.Models.SystemEvents";

input-file:
    -  https://github.com/ellismg/azure-rest-api-specs/blob/db8e376aa3b6ba4b9d2e22aa29e48e0647f75c58/specification/eventgrid/data-plane/Microsoft.EventGrid/stable/2018-01-01/EventGrid.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.Storage/stable/2018-01-01/Storage.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.EventHub/stable/2018-01-01/EventHub.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.Resources/stable/2018-01-01/Resources.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.Devices/stable/2018-01-01/IotHub.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.ContainerRegistry/stable/2018-01-01/ContainerRegistry.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.ServiceBus/stable/2018-01-01/ServiceBus.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.Media/stable/2018-01-01/MediaServices.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.Maps/stable/2018-01-01/Maps.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.AppConfiguration/stable/2018-01-01/AppConfiguration.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.SignalRService/stable/2018-01-01/SignalRService.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.KeyVault/stable/2018-01-01/KeyVault.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.MachineLearningServices/stable/2018-01-01/MachineLearningServices.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.Cache/stable/2018-01-01/RedisCache.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/00ac1cbffba123ba5e30cb324935100495d0700d/specification/eventgrid/data-plane/Microsoft.Web/stable/2018-01-01/Web.json
```
