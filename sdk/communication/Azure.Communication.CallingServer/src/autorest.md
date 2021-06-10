# Azure.Communication.CallingServer

When a new version of the swagger needs to be updated:
1. Open Azure.Communication.sln and under sdk\communication, run `dotnet msbuild /t:GenerateCode` to generate code.

2. Upload the Azure.Communication.Call.dll to the [apiview.dev tool](https://apiview.dev/).
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev.

## General settings
> see https://aka.ms/autorest 

## Configuration 
The following are the settings for generating this API with AutoRest.

```yaml
tag: beta
input-file: https://github.com/Azure/azure-rest-api-specs/blob/74575fadb83fcd08a70d1168c8d04a6ca5e90715/specification/communication/data-plane/CallingServer/preview/2021-06-15-preview/communicationservicescallingserver.json
payload-flattening-threshold: 10
clear-output-folder: true
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.CallingServer"
```
