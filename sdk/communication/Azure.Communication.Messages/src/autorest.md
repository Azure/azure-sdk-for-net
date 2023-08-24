# Azure.Communication.Messages

When a new version of the swagger needs to be updated:
1. Go to sdk\communication, and run `dotnet msbuild /t:GenerateCode` to generate code.
2. Upload the Azure.Communication.Messages.dll to the apiview.dev tool.
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.
3. Repeat 2 and 3 until the decided interface is reflected in the apiview.dev 

### AutoRest Configuration

> see https://aka.ms/autorest
``` yaml
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/0734629ebe21f0ff3a46794e71a095deafbae029/specification/communication/data-plane/Messages/preview/2023-08-24-preview/CommunicationServicesMessages.json
payload-flattening-threshold: 10
generation1-convenience-client: true
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.Messages"

```

### Don't buffer media downloads

Sets the success response as binary stream, instead of error object.

``` yaml
directive:
- from: swagger-document
  where: $..[?(@.operationId=='Stream_DownloadMedia')]
  transform:
    $["x-csharp-buffer-response"] = false;
    $.responses["200"].schema.format = "binary";
```
