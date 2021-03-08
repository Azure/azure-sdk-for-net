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
required:
    - https://github.com/Azure/azure-rest-api-specs/blob/644ed41f990d8adc0edc7aa81e5f03b7ddc493f0/specification/communication/data-plane/readme.md
payload-flattening-threshold: 10
directive:
    from: swagger-document
    where: $.definitions.*
    transform: >
        $["x-namespace"] = "Azure.Communication.Chat"
```
