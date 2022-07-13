# Azure.Communication.Identity

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-2022-10
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/49e2859d9eef95013f083af9506127cfffd1e866/specification/communication/data-plane/Identity/readme.md
payload-flattening-threshold: 3
generation1-convenience-client: true
```
