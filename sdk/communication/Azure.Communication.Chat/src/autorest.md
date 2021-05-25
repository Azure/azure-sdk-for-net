# Azure.Communication.Chat
When a new version of the swagger needs to be updated:
1. Go to sdk\communication, and run `dotnet msbuild /t:GenerateCode` to generate code.
2. Upload the Azure.Communication.Chat.dll to the apiview.dev tool.
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev 

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/08ef4099dff05de3ce1682d58cd4e0e2b1565905/specification/communication/data-plane/Microsoft.CommunicationServicesChat/preview/2021-04-05-preview6/communicationserviceschat.json
payload-flattening-threshold: 10
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.Chat"
```
