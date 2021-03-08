# Azure.Communication.Chat

When a new version of the swagger needs to be updated:

1. Go to sdk\communication, and run `dotnet msbuild /t:GenerateCode` to generate code.
2. Upload the Azure.Communication.Chat.dll to the apiview.dev tool.
   If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev

### AutoRest Configuration

> see https://aka.ms/autorest

<<<<<<< HEAD
``` yaml
input-file:
    -  communicationserviceschat.json
=======
```yaml
tag: package-2020-11-01-preview3
required:
    - https://github.com/Azure/azure-rest-api-specs/tree/5b19c6e69cd2bb9dbe4e5c1237b2c5a175d90ca5/specification/communication/data-plane/readme.md
>>>>>>> 1688f21a40 ([autorest] update the autorest to point to readme)
payload-flattening-threshold: 10
directive:
    from: swagger-document
    where: $.definitions.*
    transform: >
        $["x-namespace"] = "Azure.Communication.Chat"
```
