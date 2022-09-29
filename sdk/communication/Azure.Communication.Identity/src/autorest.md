# Azure.Communication.Identity

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-2022-06
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f0343961168af6b19ea86dd3aa2429e2ca453db4/specification/communication/data-plane/Identity/readme.md
payload-flattening-threshold: 3
generation1-convenience-client: true
```
