# Azure.Communication.Chat

When a new version of the swagger needs to be updated:

1. Go to sdk\communication, and run `dotnet msbuild /t:GenerateCode` to generate code.
2. Upload the Azure.Communication.Chat.dll to the apiview.dev tool.
   If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
tag: package-2020-11-01-preview3
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/e5a57e87f16c7fd9a6eaeb3c6049293d1334f6c6/specification/communication/data-plane/Microsoft.CommunicationServicesChat/readme.md
payload-flattening-threshold: 10
directive:
    from: swagger-document
    where: $.definitions.*
    transform: >
        $["x-namespace"] = "Azure.Communication.Chat"
```
