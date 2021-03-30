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
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0d832037c324f08da297bb292b5ad91c47f5fa23/specification/communication/data-plane/Microsoft.CommunicationServicesChat/stable/2021-03-07/communicationserviceschat.json
payload-flattening-threshold: 10
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.Chat"
```
