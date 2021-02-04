# Azure.Communication.Chat
1. When a new version of the swagger needs to be updated:
- Go to the 'Swagger' folder, and update the swagger.json file with the new version.

2. Go to sdk\communication, and run `dotnet msbuild /t:GenerateCode` to generate code.

3. Upload the Azure.Communication.Chat.dll to the apiview.dev tool.
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

4. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev 

### AutoRest Configuration
> see https://aka.ms/autorest

IMPORTANT: Update input-file to reviewed version before merging to master

``` yaml
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5c659a0b9a2826f1133cef96748f5c7b956557bf/specification/communication/data-plane/Microsoft.CommunicationServicesChat/preview/2020-11-01-preview3/communicationserviceschat.json
payload-flattening-threshold: 10
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.Chat"
```
