# Azure.Communication.Identity

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-2023-10
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5797d78f04cd8ca773be82d2c99a3294009b3f0a/specification/communication/data-plane/Identity/readme.md
payload-flattening-threshold: 3
generation1-convenience-client: true
```
