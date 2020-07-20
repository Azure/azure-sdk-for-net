# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "public"

input-file:
    -  https://github.com/ellismg/azure-rest-api-specs/blob/e93e9529ffa1a3ace9b260070de4bfdf57be17e4/specification/eventgrid/data-plane/Microsoft.EventGrid/stable/2018-01-01/EventGrid.json
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
    -  $(this-folder)/Storage.json
    -  $(this-folder)/EventHub.json
    -  $(this-folder)/Resources.json
```
