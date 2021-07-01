# Azure.Communication.Chat
When a new version of the swagger needs to be updated:
1. Go to sdk\communication, and run `dotnet msbuild /t:GenerateCode` to generate code.
2. Upload the Azure.Communication.Chat.dll to the apiview.dev tool.
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev 

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-chat-2021-04-05-preview6
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/896d05e37dbb00712726620b8d679cc3c3be09fb/specification/communication/data-plane/Chat/readme.md
payload-flattening-threshold: 10
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.Chat"
```
