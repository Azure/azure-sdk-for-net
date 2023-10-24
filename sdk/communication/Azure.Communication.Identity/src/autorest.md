# Azure.Communication.Identity

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-2023-08
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/7824f04db829f016255f0042e86f7061401ca5bb/specification/communication/data-plane/Identity/readme.md
payload-flattening-threshold: 3
generation1-convenience-client: true
```
