# Azure.Communication.Identity

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-2022-10
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/a8c4340400f1ab1ae6a43b10e8d635ecb9c49a2a/specification/communication/data-plane/Identity/readme.md
payload-flattening-threshold: 3
generation1-convenience-client: true
```
