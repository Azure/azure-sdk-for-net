# Azure.Communication.Identity

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-2022-06
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5b0818f55339dbff370a967e3f068e180c6ad5a1/specification/communication/data-plane/Identity/readme.md
payload-flattening-threshold: 3
generation1-convenience-client: true
```
