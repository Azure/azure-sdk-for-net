# Azure.IoT.DeviceUpdate

Run `generate.ps1` or `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
low-level-client: true
input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/53574efb3c9199b9dcec21bd8e7ca5b9e8d4f9b9/specification/deviceupdate/data-plane/Microsoft.DeviceUpdate/preview/2020-09-01/deviceupdate.json
security: AADToken
modelerfour:
    group-parameters: false
```
